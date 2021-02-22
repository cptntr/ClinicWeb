using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Clinic.Web.BLL.Services;
using Clinic.Web.BLL.ViewModels;

namespace Clinic.Web.Controllers
{
    public class SpecialtiesController : Controller
    {
        private readonly Clinic.Web.BLL.Interfaces.ISpecialtiesManager _specialtiesManager;

        public SpecialtiesController()
        {
            _specialtiesManager = new Clinic.Web.BLL.Services.SpecialtiesManager();
        }
        public IActionResult Index()
        {
            IEnumerable<SpecialtiesViewModel> specialties = _specialtiesManager.ReadSpecialties();
            return View(specialties);
        }

        [HttpGet]
        public IActionResult Details(int _id)
        {
            var spec = _specialtiesManager.ReadOneSpecialty((int)_id);
            return View(spec);
        }

        [HttpGet]
        public ViewResult Delete(int? id)
        {
            SpecialtiesViewModel specialty = new SpecialtiesManager().ReadOneSpecialty((int)id);
            return View(specialty);
        }

        [HttpPost]
        public IActionResult Delete(SpecialtiesViewModel specialty)
        {
            new SpecialtiesManager().DeleteSpecialty(specialty.Id);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            //var specialty = _specialtiesManager.ReadOneSpecialty(1);

            return View(new SpecialtiesViewModel());
        }

        [HttpPost]
        public IActionResult Create(SpecialtiesViewModel specialty)
        {
            _specialtiesManager.AddSpecialty(specialty);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit(int? _id)
        {
            SpecialtiesViewModel specialty = _specialtiesManager.ReadOneSpecialty((int)_id);

            return View(specialty);
        }

        [HttpPost]
        public IActionResult Edit(SpecialtiesViewModel specialty)
        {
            _specialtiesManager.UpdateSpecialty(specialty);
            return RedirectToAction("Index");
        }
    }
}
