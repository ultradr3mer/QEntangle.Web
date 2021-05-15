using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QEntangle.Web.Database.Identity;
using QEntangle.Web.Exceptions;
using QEntangle.Web.Extensions;
using QEntangle.Web.Interfaces;
using QEntangle.Web.Models;
using QEntangle.Web.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace QEntangle.Web.Controllers
{
  [Authorize]
  public class ChoiceController : Controller
  {
    #region Fields

    private readonly IChoiceRepository choiceRepository;
    private readonly UserManager<ApplicationUser> userManager;

    #endregion Fields

    #region Constructors

    public ChoiceController(IChoiceRepository choiceRepository, UserManager<ApplicationUser> userManager)
    {
      this.choiceRepository = choiceRepository;
      this.userManager = userManager;
    }

    #endregion Constructors

    #region Methods

    public IActionResult Index()
    {
      return View();
    }

    public async Task<ViewResult> List()
    {
      ApplicationUser user = await GetCurrentUserAsync();

      var data = await this.choiceRepository.GetChoices(user.Id);
      var evaluated = data.Where(o => !string.IsNullOrEmpty(o.DefinitiveOption)).Select(o => new ChoicesListViewModel.ChoiceEntryViewModel().GetWithDataModel(o)).ToList();
      var unevaluated = data.Where(o => string.IsNullOrEmpty(o.DefinitiveOption)).Select(o => new ChoicesListViewModel.ChoiceEntryViewModel().GetWithDataModel(o)).ToList();
      var vm = new ChoicesListViewModel { Evaluated = evaluated, Unevaluated = unevaluated };
      return View(vm);
    }

    public IActionResult PostChoice()
    {
      var vm = new ChoicePostViewModel()
      {
        PostChoiceData = new PostChoiceData()
      };

      return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> PostChoice(PostChoiceData choice)
    {
      ApplicationUser user = await GetCurrentUserAsync();

      try
      {
        await this.choiceRepository.PostChoiceAsync(choice, user.Id);
      }
      catch (UserException ex)
      {
        var vm = new ChoicePostViewModel()
        {
          ExceptionMessage = ex.Message,
          PostChoiceData = choice
        };

        return View(vm);
      }

      return RedirectToAction("List");
    }

    private async Task<ApplicationUser> GetCurrentUserAsync()
    {
      return await this.userManager.GetUserAsync(this.User);
    }

    #endregion Methods
  }
}