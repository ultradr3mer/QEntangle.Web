using Microsoft.AspNetCore.Mvc;
using QEntangle.Web.Extensions;
using QEntangle.Web.Interfaces;
using QEntangle.Web.ViewModels;
using System.Linq;

namespace QEntangle.Web.Controllers
{
  public class ChoiceController : Controller
  {
    #region Fields

    private readonly IChoiceRepository choiceRepository;

    #endregion Fields

    #region Constructors

    public ChoiceController(IChoiceRepository choiceRepository)
    {
      this.choiceRepository = choiceRepository;
    }

    #endregion Constructors

    #region Methods

    public IActionResult Index()
    {
      return View();
    }

    public ViewResult List()
    {
      var data = this.choiceRepository.GetChoices();
      var vms = data.Select(o => new ChoicesListViewModel.ChoiceEntryViewModel().GetWithDataModel(o)).ToList();
      var vm = new ChoicesListViewModel { List = vms };
      return View(vm);
    }

    #endregion Methods
  }
}