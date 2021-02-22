using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Web.BLL.ViewModels;

namespace Clinic.Web.BLL.Interfaces
{
    public interface IPatientsManager
    {
        public IEnumerable<PatientsViewModel> ReadAllPatients();
        public PatientsViewModel ReadOnePatient(int _id);
        IEnumerable<PatientsViewModel> SearchPatients(string _search);

        PatientsViewModel InsertPatients(PatientsEditViewModel _patient);

        PatientsViewModel UpdatePatients(int _id_patient, PatientsEditViewModel _patient);
        void DeletePatients(int _id);
    }
}
