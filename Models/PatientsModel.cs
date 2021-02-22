using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Web.Models
{
    public partial class PatientsModel
    {
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public int IdDoctor { get; set; }
        public virtual PersonsModel Person { get; set; }
        public DoctorsModel Doctor { get; set; }
    }
}
