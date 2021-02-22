using System;
using System.Collections.Generic;
using System.Text;
using Clinic.Web.Models;

namespace Clinic.Web.DAL.Abstract
{
    public interface IPersonsRepository
    {
        IEnumerable<PersonsModel> Read();
        PersonsModel ReadOne(int _id);
        /*        IEnumerable<PersonsModel> Search(string _search);
                PersonsModel Insert(PersonsModel _person);
                PersonsModel Update(int _id, PersonsModel _person);
                void Delete(int _id);*/
    }
}
