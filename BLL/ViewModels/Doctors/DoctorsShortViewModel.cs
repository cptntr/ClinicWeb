using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Web.BLL.ViewModels
{
    public class DoctorsShortViewModel
    {
        public int Id { get; set; }
        public string Doctor{ get; set; } // name + ' ' + surname
    }
}
