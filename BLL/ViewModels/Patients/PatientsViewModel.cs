using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Web.BLL.ViewModels
{
    public class PatientsViewModel
    {
        public int Id { get; set; }
        public string PatientNS { get; set; } // name + ' ' + surname
        public string DoctorNS { get; set; } // name + ' ' + surname
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool Removed { get; set; }
    }
}
