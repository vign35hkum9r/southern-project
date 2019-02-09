using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public interface ILeaveAllocation
    {
        List<LeaveAllocationDTO> GetAllLeaveAllocation(LeaveAllocationGetDTO objLeave);
        LeaveAllocationDTO GetLeaveAllocationById(LeaveAllocationGetDTO objLeave);
        List<LeaveAllocationDTO> GetActiveLeaveAllocation(LeaveAllocationGetDTO objLeave);
        List<LeaveAllocationDTO> GetInActiveLeaveAllocation(LeaveAllocationGetDTO objLeave);
        List<getAllEmployeeTypeDTO> GetAllEmployeetype(getEmployeeTypeDTO objLeave);
        bool InsertLeaveAllocation(List<LeaveAllocationInsertDTO> objLeave);
        bool UpdateLeaveAllocation(LeaveAllocationUpdateDTO Leave);
        bool DeactivateLeaveAllocation(LeaveAllocationRemoveDTO objLeave);
    }
}
