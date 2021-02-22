using System;
using System.Collections.Generic;
using System.Text;
using Clinic.Web.Models;

namespace Clinic.Web.DAL.Abstract
{
    public interface IDoctorsRepository
    {
        IEnumerable<DoctorsModel> Read();
        DoctorsModel ReadOne(int _id_doctor);
        IEnumerable<DoctorsModel> Search(string _search);
        DoctorsModel Insert(DoctorsModel _doctor);
        public void InsertSpecialty(int _doctor_id, int _specialty_id);
        public void DeleteSpecialty(int _doctor_id, int _specialty_id);

        DoctorsModel Update(int _id, DoctorsModel _doctor);
        void Delete(int _id);
    }
}
