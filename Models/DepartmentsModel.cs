using System.Collections.Generic;

namespace Clinic.Web.Models
{
    public partial class DepartmentsModel
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
