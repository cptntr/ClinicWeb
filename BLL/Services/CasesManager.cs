using System.Collections.Generic;
using System.Linq;
using Clinic.Web.BLL.Interfaces;
using Clinic.Web.Entities;
using Clinic.Web.DAL.ADO;
using Clinic.Web.BLL.ViewModels;

namespace Clinic.Web.BLL.Services
{
    public class CasesManager : ICasesManager
    {
        public IEnumerable<CasesViewModel> ReadCases()
        {
            IEnumerable<CasesEntity> cases = new CasesRepository().Read();
            List<CasesViewModel> cases_vm = new List<CasesViewModel>();

            foreach (CasesEntity _case in cases)
            {
                cases_vm.Add(new CasesViewModel
                {
                    Id = _case.Id,
                    Doctor = _case.Doctor.Person.Name + ' ' + _case.Doctor.Person.Surname,
                    Patient = _case.Patient.Person.Name + ' ' + _case.Patient.Person.Surname,
                    Created = string.Format("{0:dd/MM/yyyy}", _case.Created),
                    Closed = string.Format("{0:dd/MM/yyyy}", _case.Closed),
                    Conclusion = _case.Conclusion,
                });
            }
            return cases_vm;
        }
        public IEnumerable<CasesViewModel> SearchCases(string _search)
        {
            IEnumerable<CasesEntity> cases = new CasesRepository().Search(_search);
            List<CasesViewModel> cases_vm = new List<CasesViewModel>();

            foreach (CasesEntity _case in cases)
            {
                cases_vm.Add(new CasesViewModel
                {
                    Id = _case.Id,
                    Doctor = _case.Doctor.Person.Name + ' ' + _case.Doctor.Person.Surname,
                    Patient = _case.Patient.Person.Name + ' ' + _case.Patient.Person.Surname,
                    Created = string.Format("{0:dd/MM/yyyy}", _case.Created),
                    Closed = string.Format("{0:dd/MM/yyyy}", _case.Closed),
                    Conclusion = _case.Conclusion,
                });
            }
            return cases_vm;
        }
        public CasesViewModel ReadOneCase(int _id)
        {
            CasesEntity _case = new CasesRepository().ReadOne(_id);
            CasesViewModel doctor_vm = new CasesViewModel();

            doctor_vm = new CasesViewModel
            {
                Id = _case.Id,
                Doctor = _case.Doctor.Person.Name + ' ' + _case.Doctor.Person.Surname,
                Patient = _case.Patient.Person.Name + ' ' + _case.Patient.Person.Surname,
                Created = string.Format("{0:dd/MM/yyyy}", _case.Created),
                Closed = string.Format("{0:dd/MM/yyyy}", _case.Closed),
                Conclusion = _case.Conclusion,
            };

            return doctor_vm;
        }

        public CasesViewModel AddCase(CasesViewModel _case)
        {
            CasesEntity new_case = new CasesEntity();

            /*new_case.Person.Name = _case.Name;
            new_case.Person.Surname = _case.Surname;
            new_case.Person.Address = _case.Address;
            new_case.Person.Phone = _case.Phone;
            new_case.Department.Name = _case.Department;*/

            new CasesRepository().Insert(new_case);

            return new CasesViewModel()/*this.ReadOneCase(0)*/;
        }

        public CasesViewModel UpdateCase(int _id_case, CasesViewModel _case)
        {
            CasesEntity upd_case = new CasesEntity();

            /*upd_case.Person.Name = _case.Name;
            upd_case.Person.Surname = _case.Surname;
            upd_case.Person.Address = _case.Address;
            upd_case.Person.Phone = _case.Phone;
            upd_case.Department.Name = _case.Department;*/

            new CasesRepository().Update(_id_case, upd_case);

            return new CasesViewModel()/*this.ReadOneCase(0)*/;
        }

        public void UpdateCloseCase(int id)
        {
            new CasesRepository().UpdateCloseCase(id);
        }
        public void DeleteCase(int _id)
        {
            new CasesRepository().Delete(_id);
        }
    }
}
