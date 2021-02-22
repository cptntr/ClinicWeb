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
        [HttpGet]
        public IActionResult Details(int _id)
        {
            var spec = _doctorsManager.ReadOneDoctor((int)_id);
            return View(spec);
        }

        [HttpGet]
        public ViewResult Delete(int? id)
        {
            DoctorsViewModel doctor = _doctorsManager.ReadOneDoctor((int)id);
            return View(doctor);
        }

        [HttpPost]
        public IActionResult Delete(DoctorsViewModel doctor)
        {
            _doctorsManager.DeleteDoctors(doctor.Id);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            //var doctor = _doctorsManager.ReadOneDoctor(1);

            return View(new DoctorsViewModel());
        }

        [HttpPost]
        public IActionResult Create(DoctorsViewModel doctor)
        {
            _doctorsManager.InsertDoctors(doctor);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit(int? _id)
        {
            DoctorsViewModel doctor = _doctorsManager.ReadOneDoctor((int)_id);

            return View(doctor);
        }

        [HttpPost]
        public IActionResult Edit(DoctorsViewModel doctor)
        {
            _doctorsManager.UpdateDoctors(doctor.Id, doctor);
            return RedirectToAction("Index");
        }

    }
}
