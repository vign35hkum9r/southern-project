using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public interface ISiteMapping
    {
        List<getAllCustomerDTO> GetAllCustomer(getCustomerDTO objCustomer);
        List<getAllBranchByCustomerDTO> GetAllBranch(getBranchDTO objBranch);
        List<getAllSiteByBranchDTO> GetAllSite(getSiteDTO objBranch);
        List<getAllClassficationbySiteDTO> GetAllClassification(getClassficationDTO objBranch);
        List<getAllServiceByCustomerDTO> GetAllService(getServiceDTO objBranch);
        List<GetAllManpowerList> GetAllManpowerList(GetManpowerListDTO objManpower);
        bool InsertSiteAllocation(AddSiteAllocationDTO objSite);
        List<getSiteAllocationDTO> GetAllSiteAllocation(getServiceDTO objBranch);
        bool removeSiteAllocation(removeSiteAllocation objSiteAllocation);

    }
}
