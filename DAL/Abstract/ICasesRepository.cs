using System;
using System.Collections.Generic;
using System.Text;
using Clinic.Web.Models;

namespace Clinic.Web.DAL.Abstract
{
    public interface ICasesRepository
    {
        IEnumerable<CasesModel> Read();
        IEnumerable<CasesModel> Search(string _search);
        //IEnumerable<CasesModel> ReadForDoctor(int _id);
        CasesModel Insert(CasesModel _case);
        CasesModel Update(int _id, CasesModel _case);
        void Delete(int _id);
    }
}
