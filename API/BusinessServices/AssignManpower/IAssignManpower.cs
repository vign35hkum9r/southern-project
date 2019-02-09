using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public interface IAssignManpower
    {
        List<ManPowerListDTO> GetAllManpowerList(ManpowerAssignDTO objCustomer);
        List<AssignManpowerDTO> GetAllAssignManPower(ManpowerBranchDTO objCustomer);
        List<AssignManpowerDTO> GetContractByAllCustomer(GetContractByAllCustomer objCustomer);
        List<ManpowerCustomerAllDTO> GetAllCustomer(ManpowerCustomerDTO objCustomer);
        List<ManpowerBranchAllDTO> GetAllBranch(ManpowerBranchDTO objBranch);
        List<ManpowerSiteAllDTO> GetAllSite(ManpowerSiteDTO objSite);
        List<ManpowerClassificationAllDTO> GetAllClassification(ManpowerClassificationDTO objClassification);
        List<ManpowerServiceAllDTO> GetAllService(ManpowerServiceDTO objService);
        bool InsertAssignManpower(AddManpowerDTO objSite);
        bool RemoveAssignManpower(RemoveManPowerDTO objRemoveManPower);
    }
}
