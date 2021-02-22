using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Web.Models
{
    public partial class PersonsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address{ get; set; }
        public string Phone { get; set; }
    }
}
