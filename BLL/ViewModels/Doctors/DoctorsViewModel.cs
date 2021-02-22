using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Web.BLL.ViewModels
{
    public class DoctorsViewModel
    {
        public int Id { get; set; }
        public string Doctor{ get; set; } // name + ' ' + surname
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public string Specialties { get; set; } // qwe | rty | uio...
        public bool Removed { get; set; }
    }
}
