using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface ICustomerMapping
    {
        bool InsertBranch(AddBranchDTO objBranch);
        List<GetBranchByCustomerDTO> GetAllBranch(GetCustomersBranchDTO objBranch);
        List<getCustomerSitebyBranchDTO> GetAllSite(getCustomerSiteDTO objBranch);
        bool InsertSite(AddSiteDTO objSite);
        bool InsertClassfication(AddClassificationDTO objClassfication);
        bool removeBranch(removeBranchDTO objBranch);
        bool removeSite(removeSiteDTO objSite);
        bool removeClassification(removeClassificationDTO objClassification);
    }
}
