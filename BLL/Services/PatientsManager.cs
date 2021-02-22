using System.Collections.Generic;
using System.Linq;
using Clinic.Web.BLL.Interfaces;
using Clinic.Web.Entities;
using Clinic.Web.DAL.ADO;
using Clinic.Web.BLL.ViewModels;

namespace Clinic.Web.BLL.Services
{
    public class PatientsManager : IPatientsManager
    {
        public IEnumerable<PatientsViewModel> ReadAllPatients()
        {
            IEnumerable<PatientsEntity> patients = new PatientsRepository().ReadAll();
            List<PatientsViewModel> patients_vm = new List<PatientsViewModel>();

            foreach (PatientsEntity _patient in patients)
            {
                patients_vm.Add(new PatientsViewModel
                {
                    Id = _patient.Id,
                    PatientNS = _patient.Person.Name + ' ' + _patient.Person.Surname,
                    DoctorNS = _patient.Doctor.Person.Name + ' ' + _patient.Doctor.Person.Surname,
                    Address = _patient.Person.Address,
                    Phone = _patient.Person.Phone,
                    Removed = _patient.Removed
                });
            }
            return patients_vm;
        }
        public IEnumerable<PatientsViewModel> SearchPatients(string _search)
        {
            IEnumerable<PatientsEntity> patients = new PatientsRepository().Search(_search);
            List<PatientsViewModel> patients_vm = new List<PatientsViewModel>();

            foreach (PatientsEntity _patient in patients)
            {
                patients_vm.Add(new PatientsViewModel
                {
                    Id = _patient.Id,
                    PatientNS = _patient.Person.Name + ' ' + _patient.Person.Surname,
                    DoctorNS = _patient.Doctor.Person.Name + ' ' + _patient.Doctor.Person.Surname,
                    Address = _patient.Person.Address,
                    Phone = _patient.Person.Phone,
                    Removed = _patient.Removed
                });
            }
            return patients_vm;
        }
        public PatientsViewModel ReadOnePatient(int _id)
        {
            PatientsEntity _patient = new PatientsRepository().ReadOne(_id);
            PatientsViewModel doctor_vm = new PatientsViewModel();

            doctor_vm = new PatientsViewModel
            {
                Id = _patient.Id,
                PatientNS = _patient.Person.Name + ' ' + _patient.Person.Surname,
                DoctorNS = _patient.Doctor.Person.Name + ' ' + _patient.Doctor.Person.Surname,
                Address = _patient.Person.Address,
                Phone = _patient.Person.Phone,
                Removed = _patient.Removed
            };

            return doctor_vm;
        }

        public PatientsViewModel InsertPatients(PatientsEditViewModel _patient)
        {
            PatientsEntity new_patient = new PatientsEntity();

            new_patient.Person.Name = _patient.Name;
            new_patient.Person.Surname = _patient.Surname;
            new_patient.Person.Address = _patient.Address;
            new_patient.Person.Phone = _patient.Phone;
            new_patient.IdDoctor = _patient.IdDoctor;

            new PatientsRepository().Insert(new_patient);

            return this.ReadOnePatient(0);
        }

        public PatientsViewModel UpdatePatients(int _id_patient, PatientsEditViewModel _patient)
        {
            PatientsEntity upd_patient = new PatientsEntity();

            upd_patient.Person.Name = _patient.Name;
            upd_patient.Person.Surname = _patient.Surname;
            upd_patient.Person.Address = _patient.Address;
            upd_patient.Person.Phone = _patient.Phone;
            upd_patient.IdDoctor = _patient.IdDoctor;

            new PatientsRepository().Update(_id_patient, upd_patient);

            return this.ReadOnePatient(_id_patient);
        }
        public void DeletePatients(int _id)
        {
            new PatientsRepository().Delete(_id);
        }
    }
}
