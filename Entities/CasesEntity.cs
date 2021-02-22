using System;

namespace Clinic.Web.Entities
{
    public partial class CasesEntity
    {
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Closed { get; set; }
        public string Conclusion { get; set; }
        public bool isclosed { get; set; }
        public virtual PatientsEntity Patient { get; set; }
        public virtual DoctorsEntity Doctor { get; set; }
    }
}
