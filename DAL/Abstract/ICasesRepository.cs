using System;
using System.Collections.Generic;
using System.Text;
using Clinic.Web.Entities;

namespace Clinic.Web.DAL.Abstract
{
    public interface ICasesRepository
    {
        IEnumerable<CasesEntity> Read();
        IEnumerable<CasesEntity> Search(string _search);
        //IEnumerable<CasesModel> ReadForDoctor(int _id);
        CasesEntity Insert(CasesEntity _case);
        CasesEntity Update(int _id, CasesEntity _case);
        CasesEntity UpdateCloseCase(int _id);
        void Delete(int _id);
    }
}
