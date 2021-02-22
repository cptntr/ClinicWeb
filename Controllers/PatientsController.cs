using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Clinic.Web.BLL.Services;
using Clinic.Web.BLL.ViewModels;

namespace Clinic.Web.Controllers
{
    public class PatientsController : Controller
    {
        private readonly Clinic.Web.BLL.Interfaces.IPatientsManager _patientsManager;

        public PatientsController()
        {
            _patientsManager = new Clinic.Web.BLL.Services.PatientsManager();
        }
        public IActionResult Index()
        {
            IEnumerable<PatientsViewModel> patients = _patientsManager.ReadAllPatients();
            return View(patients);
        }

        [HttpGet]
        public IActionResult Details(int _id)
        {
            var spec = _patientsManager.ReadOnePatient((int)_id);
            return View(spec);
        }

        [HttpGet]
        public ViewResult Delete(int? id)
        {
            PatientsViewModel patient = new PatientsManager().ReadOnePatient((int)id);
            return View(patient);
        }

        [HttpPost]
        public IActionResult Delete(PatientsViewModel patient)
        {
            new PatientsManager().DeletePatients(patient.Id);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            //var patient = _patientsManager.ReadOnePatient(1);

            return View(new PatientsViewModel());
        }

        [HttpPost]
        public IActionResult Create(PatientsEditViewModel patient)
        {
            _patientsManager.InsertPatients(patient);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit(int? _id)
        {
            PatientsViewModel patient = _patientsManager.ReadOnePatient((int)_id);

            return View(patient);
        }

        [HttpPost]
        public IActionResult Edit(PatientsEditViewModel patient)
        {
            _patientsManager.UpdatePatients(patient.Id, patient);
            return RedirectToAction("Index");
        }
    }
}
