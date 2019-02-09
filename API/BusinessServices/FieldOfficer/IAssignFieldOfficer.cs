using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IAssignFieldOfficer
    {
        List<AssignFieldOfficerDTO> GetAllAssignFieldOfficer(FieldOfficer objEmpList);
        List<FieldOfficerAllDTO> GetAllEmpList(FieldOfficerDTO objEmpList);
        List<FieldOfficerCustomerAllDTO> GetAllCustomer(FieldOfficerCustomerDTO objCustomer);
        List<FieldOfficerBranchAllDTO> GetAllBranch(FieldOfficerBranchDTO objBranch);
        List<FieldOfficerSiteAllDTO> GetAllSite(FieldOfficerSiteDTO objBranch);
        bool InsertAssignFieldOfficer(AddFieldOfficerDTO objFieldOfficer);
        bool RemoveAssignFieldOfficer(RemoveFieldOfficer objRemoveFieldOfficer);
    }
}
