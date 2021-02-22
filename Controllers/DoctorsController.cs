using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Clinic.Web.BLL.ViewModels;

namespace Clinic.Web.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly Clinic.Web.BLL.Interfaces.IDoctorsManager _doctorsManager;

        public DoctorsController()
        {
            _doctorsManager = new Clinic.Web.BLL.Services.DoctorsManager();
        }
        public IActionResult Index()
        {
            IEnumerable<DoctorsViewModel> doctors = _doctorsManager.ReadDoctors();

            foreach(DoctorsViewModel _d in doctors)
            {
                if (_d.Address.Length > 25)
                    _d.Address = _d.Address.Substring(0, 23) + "..";
            }

            return View(doctors);
        }
    }
}
