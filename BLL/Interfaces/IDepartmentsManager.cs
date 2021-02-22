using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Web.BLL.ViewModels;

namespace Clinic.Web.BLL.Interfaces
{
    public interface IDepartmentsManager
    {
        public IEnumerable<DepartmentsViewModel> ReadAllDepartments();
        public DepartmentsViewModel ReadOneDepartment(int _id);
        public void DeleteDepartment(int _id);
        public void AddDepartment(DepartmentsViewModel _specialty);
        public DepartmentsViewModel UpdateDepartment(DepartmentsViewModel _specialty);
    }
}