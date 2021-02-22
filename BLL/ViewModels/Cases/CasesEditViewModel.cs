using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Web.BLL.ViewModels
{
    public class CasesEditViewModel
    {
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }

        public string Created { get; set; }
        public DateTime Closed { get; set; }
        public string Conclusion { get; set; }
    }
}
