using System;
using System.Collections.Generic;
using System.Text;
using Clinic.Web.Entities;

namespace Clinic.Web.DAL.Abstract
{
    public interface IDoctorsRepository
    {
        IEnumerable<DoctorsEntity> ReadAll();
        DoctorsEntity ReadOne(int _id_doctor);
        IEnumerable<DoctorsEntity> ReadAllForDepartment(int _id_department);
        IEnumerable<DoctorsEntity> Search(string _search);
        DoctorsEntity Insert(DoctorsEntity _doctor);
        public void InsertSpecialty(int _doctor_id, int _specialty_id);
        public void DeleteSpecialty(int _doctor_id, int _specialty_id);

        DoctorsEntity Update(int _id, DoctorsEntity _doctor);
        void Delete(int _id);
    }
}
