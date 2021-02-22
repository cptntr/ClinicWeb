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
/*        public void DeleteCase(int id);
        public void AddCase(CasesViewModel _specialty);
        public CasesViewModel UpdateCase(CasesViewModel _specialty);*/
    }
}