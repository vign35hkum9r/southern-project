using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public interface ILeaveMasterService
    {
        List<LeaveMasterDTO> GetAllLeaveMaster(LeaveMasterGetDTO objLeave);
        LeaveMasterDTO GetLeaveMasterById(LeaveMasterGetDTO objLeave);
        List<LeaveMasterDTO> GetActiveLeaveMaster(LeaveMasterGetDTO objLeave);
        List<LeaveMasterDTO> GetInActiveLeaveMaster(LeaveMasterGetDTO objLeave);
        bool InsertLeaveMaster(LeaveMasterInsertDTO objLeave);
        bool UpdateLeaveMaster(LeaveMasterUpdateDTO Leave);
        bool DeactivateLeaveMaster(LeaveMasterRemoveDTO objLeave);
    }
}
