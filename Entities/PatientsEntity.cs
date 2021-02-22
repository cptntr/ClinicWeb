using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Web.Entities
{
    public partial class PatientsEntity
    {
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public int IdDoctor { get; set; }
        public PersonsEntity Person { get; set; }
        public DoctorsEntity Doctor { get; set; }
        public bool Removed { get; set; }
    }
}
