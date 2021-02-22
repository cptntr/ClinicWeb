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
    }
}
