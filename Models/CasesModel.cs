using System;

namespace Clinic.Web.Models
{
    public partial class CasesModel
    {
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Closed { get; set; }
        public string Conclusion { get; set; }

        public virtual PatientsModel Patient { get; set; }
        public virtual DoctorsModel Doctor { get; set; }
    }
}
