using System;
using System.Collections.Generic;
using System.Text;
using Clinic.Web.Models;

namespace Clinic.Web.DAL.Abstract
{
    public interface IDepartmentsRepository
    {
        IEnumerable<DepartmentsModel> Read();
        DepartmentsModel ReadOne(int _id);

        DepartmentsModel Insert(DepartmentsModel _department);
        DepartmentsModel Update(int _id, DepartmentsModel _department);
        void Delete(int _id);
    }
}
