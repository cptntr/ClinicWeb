using System;
using System.Collections.Generic;
using System.Text;
using Clinic.Web.Models;

namespace Clinic.Web.DAL.Abstract
{
    public interface ISpecialtiesRepository
    {
        IEnumerable<SpecialtiesModel> ReadAll();
        IEnumerable<SpecialtiesModel> ReadAllForDoctor(int _id_doctor);
        IEnumerable<SpecialtiesModel> ReadAllExceptDoctor(int _id_doctor);
        SpecialtiesModel ReadOneById(int _id);

        SpecialtiesModel Insert(SpecialtiesModel _specialty);
        SpecialtiesModel Update(int _id, SpecialtiesModel _specialty);
        void Delete(int _id);
    }
}
