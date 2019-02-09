using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IEmployeeAccountService
    {
        List<GetEmployeeDTO> GetEmployee(EmplyoeeAccountsGetDTO objGetEmp);
        List<EmployeeAccountsDTO> GetAllEmployeeAccounts(EmplyoeeAccountsGetDTO objGetAccount);
        EmployeeAccountsDTO GetEmployeeAccountsById(EmplyoeeAccountsGetDTO objGetAccById);
        List<EmployeeAccountsDTO> GetActiveEmployeeAccount(EmplyoeeAccountsGetDTO objActive);
        List<EmployeeAccountsDTO> GetInActiveEmployeeAccount(EmplyoeeAccountsGetDTO objInActive);
        bool InsertEmployeeAccounts(EmployeeAccountsInsertDTO objAccount);
        bool CheckAccount(GetEmployeeDTO objCheck);
        bool UpdateEmployeeAccounts(EmployeeAccountsUpdateDTO objAccount);
        bool RemoveEmployeeAccount(EmployeeAccountRemoveDTO objRemoveAcc);
    }
}
