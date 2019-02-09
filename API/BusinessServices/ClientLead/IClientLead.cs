using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public interface IClientLead
    {
        List<ClientLeadChangeDTO> GetClientList(GetClientbyEmployeeDTO objEmployee);
        List<OldEmployeeDTO> GetOldEmployeeList(GetOldEmployeeDTO objEmployee);
        List<NewEmployeeDTO> GetNewEmployeeList(GetNewEmployeeDTO objEmployee);
        bool ChangeLeadByClient(ChangeLeadbyClientDTO objchangelead);
    }
}
