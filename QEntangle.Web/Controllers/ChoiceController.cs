using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QEntangle.Web.Database;
using QEntangle.Web.Database.Identity;
using QEntangle.Web.Extensions;
using QEntangle.Web.Interfaces;
using QEntangle.Web.Models;
using QEntangle.Web.Services;
using QEntangle.Web.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QEntangle.Web.Controllers
{
  [Authorize]
  public class ChoiceController : Controller
  {
    #region Fields

    private readonly IChoiceRepository choiceRepository;
    private readonly QrngAnuClient qrng;
    private readonly UserManager<ApplicationUser> userManager;

    #endregion Fields

    #region Constructors

    public ChoiceController(IChoiceRepository choiceRepository, UserManager<ApplicationUser> userManager, QrngAnuClient qrng)
    {
      this.choiceRepository = choiceRepository;
      this.userManager = userManager;
      this.qrng = qrng;
    }

    #endregion Constructors

    #region Methods

    public async Task<IActionResult> Evaluate(Guid id)
    {
      ApplicationUser user = await this.GetCurrentUserAsync();

      ChoiceEntity entity = await this.choiceRepository.GetChoice(id, user.Id);

      if (entity == null)
      {
        throw new Exception("Choice not found.");
      }

      if (!string.IsNullOrEmpty(entity.DefinitiveOption))
      {
        throw new Exception("Choices can only be executed once.");
      }

      string[] options = entity.Options.Split(',');

      GetData qrngResult = await this.qrng.JsonIphpAsync(Services.Type.Uint8, 1, null);
      int number = qrngResult.Data.Single();

      int definitiveOptionNumber = number * options.Length / 256;
      string definitiveOptionString = options[definitiveOptionNumber];

      entity.DefinitiveOption = definitiveOptionString;
      await this.choiceRepository.SaveChanges();

      return this.RedirectToAction("List");
    }

    public IActionResult Index()
    {
      return this.View();
    }

    public async Task<ViewResult> List()
    {
      ApplicationUser user = await this.GetCurrentUserAsync();

      System.Collections.Generic.IList<Data.ChoiceData> data = await this.choiceRepository.GetChoices(user.Id);
      System.Collections.Generic.List<ChoicesListViewModel.ChoiceEntryViewModel> evaluated = data.Where(o => !string.IsNullOrEmpty(o.DefinitiveOption)).Select(o => new ChoicesListViewModel.ChoiceEntryViewModel().GetWithDataModel(o)).ToList();
      System.Collections.Generic.List<ChoicesListViewModel.ChoiceEntryViewModel> unevaluated = data.Where(o => string.IsNullOrEmpty(o.DefinitiveOption)).Select(o => new ChoicesListViewModel.ChoiceEntryViewModel().GetWithDataModel(o)).ToList();
      ChoicesListViewModel vm = new ChoicesListViewModel { Evaluated = evaluated, Unevaluated = unevaluated };
      return this.View(vm);
    }

    public IActionResult PostChoice()
    {
      return this.ShowPostChoiceView(new PostChoiceData(), string.Empty);
    }

    [HttpPost]
    public async Task<IActionResult> PostChoice(PostChoiceData choice)
    {
      ApplicationUser user = await this.GetCurrentUserAsync();

      string[] optionsArray = choice.Options.Split(",").Select(o => o.Trim()).ToArray();
      if (optionsArray.Length < 2)
      {
        const string message = "At least 2 options are required";
        return this.ShowPostChoiceView(choice, message);
      }

      System.Collections.Generic.IEnumerable<IGrouping<string, string>> optionGroups = optionsArray.GroupBy(o => o);
      if (optionGroups.Any(o => o.Count() > 1))
      {
        const string message = "Options must be unique";
        return this.ShowPostChoiceView(choice, message);
      }

      string optionsString = string.Join(",", optionsArray);

      ChoiceEntity entity = new ChoiceEntity()
      {
        Name = choice.Name,
        Options = optionsString,
        UserId = user.Id,
      };

      await this.choiceRepository.PostChoiceAsync(entity);

      return this.RedirectToAction("List");
    }

    private async Task<ApplicationUser> GetCurrentUserAsync()
    {
      return await this.userManager.GetUserAsync(this.User);
    }

    private IActionResult ShowPostChoiceView(PostChoiceData choice, string message)
    {
      ChoicePostViewModel vm = new ChoicePostViewModel()
      {
        ExceptionMessage = message,
        PostChoiceData = choice
      };

      return this.View(vm);
    }

    #endregion Methods
  }
}