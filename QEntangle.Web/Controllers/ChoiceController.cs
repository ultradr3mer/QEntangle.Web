using Microsoft.AspNetCore.Mvc;
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
      var vm = new ChoicesListViewModel { List = this.choiceRepository.GetChoices() };
      return View(vm);
    }

    public IActionResult Index()
    {
      return View();
    }
  }
}
