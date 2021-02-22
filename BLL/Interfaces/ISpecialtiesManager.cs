using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Web.BLL.ViewModels;

namespace Clinic.Web.BLL.Interfaces
{
    public interface ISpecialtiesManager
    {
        public IEnumerable<SpecialtiesViewModel> ReadSpecialties();
        public SpecialtiesViewModel ReadOneSpecialty(int id);
        public IEnumerable<SpecialtiesViewModel> ReadAllAvaibleForDoctor(int _id_doctor);
        public void DeleteSpecialty(int id);
        public void AddSpecialty(SpecialtiesViewModel _specialty);
        public SpecialtiesViewModel UpdateSpecialty(SpecialtiesViewModel _specialty);
    }
}