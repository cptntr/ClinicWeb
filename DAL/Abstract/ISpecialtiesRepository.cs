using System;
using System.Collections.Generic;
using System.Text;
using Clinic.Web.Entities;

namespace Clinic.Web.DAL.Abstract
{
    public interface ISpecialtiesRepository
    {
        IEnumerable<SpecialtiesEntity> ReadAll();
        IEnumerable<SpecialtiesEntity> ReadAllForDoctor(int _id_doctor);
        IEnumerable<SpecialtiesEntity> ReadAllExceptDoctor(int _id_doctor);
        SpecialtiesEntity ReadOneById(int _id);

        SpecialtiesEntity Insert(SpecialtiesEntity _specialty);
        SpecialtiesEntity Update(int _id, SpecialtiesEntity _specialty);
        void Delete(int _id);
    }
}
