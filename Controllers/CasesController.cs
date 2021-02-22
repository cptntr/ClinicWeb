using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Clinic.Web.BLL.ViewModels;

namespace Clinic.Web.Controllers
{
    public class CasesController : Controller
    {
        private readonly Clinic.Web.BLL.Interfaces.ICasesManager _casesManager;

        public CasesController()
        {
            _casesManager = new Clinic.Web.BLL.Services.CasesManager();
        }
        public IActionResult Index()
        {
            IEnumerable<CasesViewModel> cases = _casesManager.ReadCases();
            return View(cases);
        }

/*        [HttpGet]
        public ViewResult CloseCase(int id)
        {
            CasesViewModel _case = _casesManager.ReadOneCase(id);
            return View(_case);
        }*/

        [HttpPost]
        public IActionResult CloseCase(CasesViewModel _case)
        {
            _casesManager.UpdateCloseCase(_case.Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int _id)
        {
            var spec = _casesManager.ReadOneCase((int)_id);
            return View(spec);
        }

        [HttpGet]
        public ViewResult Delete(int? id)
        {
            CasesViewModel _case = _casesManager.ReadOneCase((int)id);
            return View(_case);
        }

        [HttpPost]
        public IActionResult Delete(CasesViewModel _case)
        {
            _casesManager.DeleteCase(_case.Id);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            //var _case = _casesManager.ReadOneCase(1);

            return View(new CasesViewModel());
        }

        [HttpPost]
        public IActionResult Create(CasesViewModel _case)
        {
            _casesManager.AddCase(_case);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit(int? _id)
        {
            CasesViewModel _case = _casesManager.ReadOneCase((int)_id);

            return View(_case);
        }

        [HttpPost]
        public IActionResult Edit(CasesViewModel _case)
        {
            _casesManager.UpdateCase(_case.Id, _case);
            return RedirectToAction("Index");
        }

    }
}
