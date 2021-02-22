using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Clinic.Web.BLL.Services;
using Clinic.Web.BLL.ViewModels;

namespace Clinic.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly Clinic.Web.BLL.Interfaces.IDepartmentsManager _departmentsManager;

        public DepartmentsController()
        {
            _departmentsManager = new Clinic.Web.BLL.Services.DepartmentsManager();
        }
        public IActionResult Index()
        {
            IEnumerable<DepartmentsViewModel> departments = _departmentsManager.ReadAllDepartments();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Details(int _id)
        {
            var department = _departmentsManager.ReadOneDepartment((int)_id);
            return View(department);
        }

        [HttpGet]
        public ViewResult Delete(int? id)
        {
            DepartmentsViewModel department = new DepartmentsManager().ReadOneDepartment((int)id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(DepartmentsViewModel department)
        {
            new DepartmentsManager().DeleteDepartment(department.Id);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            //var department = _departmentsManager.ReadOneDepartment(1);

            return View(new DepartmentsViewModel());
        }

        [HttpPost]
        public IActionResult Create(DepartmentsViewModel department)
        {
            _departmentsManager.AddDepartment(department);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit(int? _id)
        {
            DepartmentsViewModel department = _departmentsManager.ReadOneDepartment((int)_id);

            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentsViewModel department)
        {
            _departmentsManager.UpdateDepartment(department);
            return RedirectToAction("Index");
        }
    }
}
