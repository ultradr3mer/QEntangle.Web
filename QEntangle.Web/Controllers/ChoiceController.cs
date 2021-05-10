using Microsoft.AspNetCore.Mvc;
using QEntangle.Web.Extensions;
using QEntangle.Web.Interfaces;
using QEntangle.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QEntangle.Web.Controllers
{
  public class ChoiceController : Controller
  {
    private readonly IChoiceRepository choiceRepository;

    public ChoiceController(IChoiceRepository choiceRepository)
    {
      this.choiceRepository = choiceRepository;
    }

    public ViewResult List()
    {
      var data = this.choiceRepository.GetChoices();
      var vms = data.Select(o => new ChoicesListViewModel.ChoiceEntryViewModel().GetWithDataModel(o)).ToList();
      var vm = new ChoicesListViewModel { List =  vms };
      return View(vm);
    }

    public IActionResult Index()
    {
      return View();
    }
  }
}
