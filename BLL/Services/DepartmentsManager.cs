using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Web.Entities;
using Clinic.Web.DAL.ADO;
using Clinic.Web.BLL.Interfaces;
using Clinic.Web.BLL.ViewModels;

namespace Clinic.Web.BLL.Services
{
    public class DepartmentsManager : IDepartmentsManager
    {
        public IEnumerable<DepartmentsViewModel> ReadAllDepartments()
        {
            IEnumerable<DepartmentsEntity> departments = new DepartmentsRepository().ReadAll();
            List<DepartmentsViewModel> departments_vm = new List<DepartmentsViewModel>();
            foreach (DepartmentsEntity _s in departments)
            {
                departments_vm.Add(new DepartmentsViewModel
                {
                    Id = _s.Id,
                    Name = _s.Name
                });
            }
            return departments_vm;
        }
        public DepartmentsViewModel ReadOneDepartment(int _id)
        {
            DepartmentsEntity department = new DepartmentsRepository().ReadOne(_id);
            DepartmentsViewModel department_vm = new DepartmentsViewModel();

            department_vm.Id = department.Id;
            department_vm.Name = department.Name;

            return department_vm;
        }
        public void DeleteDepartment(int _id)
        {
            new DepartmentsRepository().Delete(_id);
        }
        public void AddDepartment(DepartmentsViewModel _department)
        {
            DepartmentsEntity department = new DepartmentsEntity();

            department.Id = _department.Id;
            department.Name = _department.Name;

            new DepartmentsRepository().Insert(department);
        }
        public DepartmentsViewModel UpdateDepartment(DepartmentsViewModel _department)
        {
            DepartmentsEntity upd_department = new DepartmentsEntity()
            {
                Id = _department.Id,
                Name = _department.Name
            };

            new DepartmentsRepository().Update(upd_department.Id, upd_department);

            return this.ReadOneDepartment(_department.Id);
        }

    }
}
