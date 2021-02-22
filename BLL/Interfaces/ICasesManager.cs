using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Web.BLL.ViewModels;

namespace Clinic.Web.BLL.Interfaces
{
    public interface ICasesManager
    {
        public IEnumerable<CasesViewModel> ReadCases();
        public CasesViewModel ReadOneCase(int id);
        public void UpdateCloseCase(int id);
        public void DeleteCase(int id);
        public CasesViewModel AddCase(CasesViewModel _case);
        public CasesViewModel UpdateCase(int _id_case, CasesViewModel _case);
    }
}