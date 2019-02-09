using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IOverallAttentance
    {
        GetAllManpowerCustomerList GetAllManpowerCustomer(GetAllCustomer objManpower);
        GetAllBranchManpowerList GetAllBranchManpower(GetAllBranch objBranch);
        GetAllSiteManpowerList GetAllSiteManpower(GetManpower objSite);

    }
}
