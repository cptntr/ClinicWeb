using System.Collections.Generic;
using System.Linq;
using Clinic.Web.BLL.Interfaces;
using Clinic.Web.Models;
using Clinic.Web.DAL.ADO;
using Clinic.Web.BLL.ViewModels;

namespace Clinic.Web.BLL.Services
{
    public class DoctorsManager : IDoctorsManager
    {
        public IEnumerable<DoctorsViewModel> ReadDoctors()
        {
            IEnumerable<DoctorsModel> doctors = new DoctorsRepository().Read();
            List<DoctorsViewModel> doctors_vm = new List<DoctorsViewModel>();

            foreach (DoctorsModel _doctor in doctors)
            {
                doctors_vm.Add(new DoctorsViewModel
                {
                    Id = _doctor.Id,
                    Doctor = _doctor.Person.Name + ' ' + _doctor.Person.Surname,
                    Address = _doctor.Person.Address,
                    Phone = _doctor.Person.Phone,
                    Department = _doctor.Department.Name,
                    Specialties = string.Join(", ", _doctor.Specialties.Select(i => i.Name)),
                    Removed = _doctor.Removed
                });
            }
            return doctors_vm;
        }
        public IEnumerable<DoctorsViewModel> SearchDoctors(string _search)
        {
            IEnumerable<DoctorsModel> doctors = new DoctorsRepository().Search(_search);
            List<DoctorsViewModel> doctors_vm = new List<DoctorsViewModel>();

            foreach (DoctorsModel _doctor in doctors)
            {
                doctors_vm.Add(new DoctorsViewModel
                {
                    Id = _doctor.Id,
                    Doctor = _doctor.Person.Name + ' ' + _doctor.Person.Surname,
                    Address = _doctor.Person.Address,
                    Phone = _doctor.Person.Phone,
                    Department = _doctor.Department.Name,
                    Specialties = string.Join(", ", _doctor.Specialties.Select(i => i.Name)),
                    Removed = _doctor.Removed
                });
            }
            return doctors_vm;
        }
        public DoctorsViewModel ReadOneDoctor(int _id)
        {
            DoctorsModel _doctor = new DoctorsRepository().ReadOne(_id);
            DoctorsViewModel doctor_vm = new DoctorsViewModel();

            doctor_vm = new DoctorsViewModel
            {
                Id = _doctor.Id,
                Doctor = _doctor.Person.Name + ' ' + _doctor.Person.Surname,
                Address = _doctor.Person.Address,
                Phone = _doctor.Person.Phone,
                Department = _doctor.Department.Name,
                Specialties = string.Join(", ", _doctor.Specialties.Select(i => i.Name)),
                Removed = _doctor.Removed
            };

            return doctor_vm;
        }

        public DoctorsViewModel InsertDoctors(DoctorsEditViewModel _doctor)
        {
            DoctorsModel new_doctor = new DoctorsModel();

            new_doctor.Person.Name = _doctor.Name;
            new_doctor.Person.Surname = _doctor.Surname;
            new_doctor.Person.Address = _doctor.Address;
            new_doctor.Person.Phone = _doctor.Phone;
            new_doctor.Department.Name = _doctor.Department;

            new DoctorsRepository().Insert(new_doctor);

            return this.ReadOneDoctor(0);
        }
        public DoctorsViewModel InsertDoctorsSpecialty(int _id_doctor, CasesViewModel _specialty)
        {
            new DoctorsRepository().InsertSpecialty(_id_doctor, _specialty.Id);

            return this.ReadOneDoctor(_id_doctor);
        }

        public DoctorsViewModel UpdateDoctors(int _id_doctor, DoctorsEditViewModel _doctor)
        {
            DoctorsModel upd_doctor = new DoctorsModel();

            upd_doctor.Person.Name = _doctor.Name;
            upd_doctor.Person.Surname = _doctor.Surname;
            upd_doctor.Person.Address = _doctor.Address;
            upd_doctor.Person.Phone = _doctor.Phone;
            upd_doctor.Department.Name = _doctor.Department;

            new DoctorsRepository().Update(_id_doctor, upd_doctor);

            return this.ReadOneDoctor(_id_doctor);
        }
        public void DeleteDoctors(int _id)
        {
            new DoctorsRepository().Delete(_id);
        }
    }
}
