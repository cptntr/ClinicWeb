using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Web.BLL.ViewModels;

namespace Clinic.Web.BLL.Interfaces
{
    public interface IDoctorsManager
    {
        public IEnumerable<DoctorsViewModel> ReadDoctors();
        public DoctorsViewModel ReadOneDoctor(int _id);
        IEnumerable<DoctorsViewModel> SearchDoctors(string _search);

        DoctorsViewModel InsertDoctors(DoctorsViewModel _doctor);
        DoctorsViewModel InsertDoctorsSpecialty(int _id_doctor, CasesViewModel _specialty);

        DoctorsViewModel UpdateDoctors(int _id_doctor, DoctorsViewModel _doctor);
        void DeleteDoctors(int _id);
    }
}
