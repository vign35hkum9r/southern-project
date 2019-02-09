using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public interface ILeaveFrequencyService
    {
        List<LeaveFrequencyMasterDTO> GetAllLeaveFrequencyMaster(LeaveFrequencyMasterGetDTO objLeave);
        LeaveFrequencyMasterDTO GetLeaveFrequencyMasterById(LeaveFrequencyMasterGetDTO objLeave);
        List<LeaveMasterDTO> GetActiveLeaveMaster(LeaveMasterGetDTO objLeave);
        List<LeaveFrequencyMasterDTO> GetInActiveLeaveFrequencyMaster(LeaveFrequencyMasterGetDTO objLeave);
        bool InsertLeaveFrequencyMaster(LeaveFrequencyMasterInsertDTO objLeave);
        bool UpdateLeaveFrequencyMaster(LeaveFrequencyMasterUpdateDTO Leave);
        bool DeactivateLeaveFrequencyMaster(LeaveFrequencyMasterRemoveDTO objLeave);
    }
}
