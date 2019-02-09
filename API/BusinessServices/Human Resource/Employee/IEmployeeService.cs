using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> GetAllEmployees(EmployeeGetDTO ObjGetEmp);
        EmployeeDTO GetEmployeeById(EmployeeGetDTO ObjGetEmpById);
        List<EmployeeDTO> GetActiveEmployee(EmployeeGetDTO objActive);
        List<GetEmployeeBankDetail> GetActiveEmployeeBankDetails(int id);
        List<EmployeeDTO> GetInActiveEmployee(EmployeeGetDTO objInActive);
        bool InsertEmployee(EmployeeInsertDTO employee);
        bool InsertEmployeeBankDtl(EmployeeBankDetailInsertDTO employee);
        bool UpdateEmployeeBankDtl(EmployeeBankDetailInsertDTO employee);
        bool UpdateEmployee(EmployeeUpdateDTO employee);
        bool DeactivateEmployee(int id);
        bool RemoveAllEmployee();
        bool RemoveEmployee(EmployeeRemoveDTO objRemoveEmp);
        bool RemoveEmployeeBankDtl(int id);
    }
}
