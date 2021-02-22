using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Web.Models;
using Clinic.Web.DAL.ADO;
using Clinic.Web.BLL.Interfaces;
using Clinic.Web.BLL.ViewModels;

namespace Clinic.Web.BLL.Services
{
    public class SpecialtiesManager : ISpecialtiesManager
    {
        public IEnumerable<SpecialtiesViewModel> ReadSpecialties()
        {
            IEnumerable<SpecialtiesModel> specialties = new SpecialtiesRepository().ReadAll();
            List<SpecialtiesViewModel> specialties_vm = new List<SpecialtiesViewModel>();
            foreach (SpecialtiesModel _s in specialties)
            {
                specialties_vm.Add(new SpecialtiesViewModel
                {
                    Id = _s.Id,
                    Name = _s.Name
                });
            }
            return specialties_vm;
        }
        public SpecialtiesViewModel ReadOneSpecialty(int _id)
        {
            SpecialtiesModel specialty = new SpecialtiesRepository().ReadOneById(_id);
            SpecialtiesViewModel specialty_vm = new SpecialtiesViewModel();

            specialty_vm.Id = specialty.Id;
            specialty_vm.Name = specialty.Name;

            return specialty_vm;
        }
        public IEnumerable<SpecialtiesViewModel> ReadAllAvaibleForDoctor(int _id_doctor)
        {
            IEnumerable<SpecialtiesModel> specialties = new SpecialtiesRepository().ReadAllExceptDoctor(_id_doctor);
            List<SpecialtiesViewModel> specialties_vm = new List<SpecialtiesViewModel>();
            foreach (SpecialtiesModel _s in specialties)
            {
                specialties_vm.Add(new SpecialtiesViewModel
                {
                    Id = _s.Id,
                    Name = _s.Name
                });
            }
            return specialties_vm;
        }

        public void DeleteSpecialty(int _id)
        {
            new SpecialtiesRepository().Delete(_id);
        }
        public void AddSpecialty(SpecialtiesViewModel _specialty)
        {
            SpecialtiesModel specialty = new SpecialtiesModel();

            specialty.Id = _specialty.Id;
            specialty.Name = _specialty.Name;

            new SpecialtiesRepository().Insert(specialty);
        }
        public SpecialtiesViewModel UpdateSpecialty(SpecialtiesViewModel _specialty)
        {
            SpecialtiesModel upd_specialty = new SpecialtiesModel()
            {
                Id = _specialty.Id,
                Name = _specialty.Name
            };

            new SpecialtiesRepository().Update(upd_specialty.Id, upd_specialty);

            return this.ReadOneSpecialty(_specialty.Id);
        }

    }
}
