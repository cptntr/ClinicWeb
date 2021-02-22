using System;
using System.Collections.Generic;
using System.Text;
using Clinic.Web.Entities;

namespace Clinic.Web.DAL.Abstract
{
    public interface IDepartmentsRepository
    {
        IEnumerable<DepartmentsEntity> ReadAll();
        DepartmentsEntity ReadOne(int _id);

        DepartmentsEntity Insert(DepartmentsEntity _department);
        DepartmentsEntity Update(int _id, DepartmentsEntity _department);
        void Delete(int _id);
    }
}
