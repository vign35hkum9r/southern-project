using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public interface ISalaryAllocation
    {
        List<GetAllSalaryReport> GetAllSalaryDetail(getSalaryAllocation des);
        List<getAllDepartmentByEmployeeType> GetAllDepartment(getDepartmentByEmployeeType des);
        List<getAllSalaryAllocation> GetAllSalaryAllocation(getSalaryAllocation des);
        List<getAllSalaryAllocation> GetAllSalaryReport(getSalaryAllocation des);
        List<getAllDesignationByDepartment> GetAllDesignation(getDesignationByDepartment des);
        List<getAllEmployeeByDesignation> GetAllEmployee(getEmployeeByDesignation des);
        bool InsertSalaryAllocation(List<InsertSalaryAllocation> objSalary);
    }
}
