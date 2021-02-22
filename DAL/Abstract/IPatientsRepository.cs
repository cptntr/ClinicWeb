using System;
using System.Collections.Generic;
using System.Text;
using Clinic.Web.Entities;

namespace Clinic.Web.DAL.Abstract
{
    public interface IPatientsRepository
    {
        IEnumerable<PatientsEntity> ReadAll();
        PatientsEntity ReadOne(int _id);
        IEnumerable<PatientsEntity> Search(string _search);
        PatientsEntity Insert(PatientsEntity _patient);
        PatientsEntity Update(int _id, PatientsEntity _patient);
        void Delete(int _id);
    }
}