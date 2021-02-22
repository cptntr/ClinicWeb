using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Web.BLL.ViewModels
{
    public class PatientsShortViewModel
    {
        public int Id { get; set; }
        public string PatientNS { get; set; } // name + ' ' + surname
    }
}
