using System;
using System.Collections.Generic;
using System.Text;
using Clinic.Web.Models;

namespace Clinic.Web.DAL.Abstract
{
    public interface IPatientsRepository
    {
        IEnumerable<PatientsModel> Read();
        PatientsModel ReadOne(int _id);
        IEnumerable<PatientsModel> Search(string _search);
        PatientsModel Insert(PatientsModel _patient);
        PatientsModel Update(int _id, PatientsModel _patient);
        void Delete(int _id);
    }
}