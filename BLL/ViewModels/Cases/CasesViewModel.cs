using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Web.BLL.ViewModels
{
    public class CasesViewModel
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Closed { get; set; }
        public string Conclusion { get; set; }

        public string Patient { get; set; } // name + ' ' + surname
        public string Doctor { get; set; } // name + ' ' + surname
    }
}
