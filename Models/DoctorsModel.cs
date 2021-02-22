using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Web.Models
{
    public partial class DoctorsModel
    {
        public DoctorsModel()
        {
/*            Cases = new HashSet<CasesModel>();
            Patients = new HashSet<PatientsModel>();*/
            Specialties = new HashSet<SpecialtiesModel>();
        }
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public int IdDepartment { get; set; }

        public PersonsModel Person { get; set; }
        public DepartmentsModel Department { get; set; }
        public bool Removed { get; set; }

        //public virtual ICollection<CasesModel> Cases { get; set; }
        //public virtual ICollection<PatientsModel> Patients { get; set; }
        public virtual IEnumerable<SpecialtiesModel> Specialties { get; set; }
    }
}
