using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Web.Entities
{
    public partial class DoctorsEntity
    {
        public DoctorsEntity()
        {
/*            Cases = new HashSet<CasesModel>();
            Patients = new HashSet<PatientsModel>();*/
            Specialties = new HashSet<SpecialtiesEntity>();
        }
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public int IdDepartment { get; set; }

        public PersonsEntity Person { get; set; }
        public DepartmentsEntity Department { get; set; }
        public bool Removed { get; set; }

        //public virtual ICollection<CasesModel> Cases { get; set; }
        //public virtual ICollection<PatientsModel> Patients { get; set; }
        public virtual IEnumerable<SpecialtiesEntity> Specialties { get; set; }
    }
}
