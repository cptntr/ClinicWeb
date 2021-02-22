using System.Collections.Generic;

namespace Clinic.Web.Entities
{
    public partial class DepartmentsEntity
    {
/*        public DepartmentsModel()
        {
            Doctors = new HashSet<DoctorsModel>();
        }*/
        public int Id { get; set; }
        public string Name { get; set; }

/*        public virtual ICollection<DoctorsModel> Doctors { get; set; }
*/    }
}
