using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IStatusMaster
    {
        List<StatusMasterDTO> GetAllStatus(StatusMasterGetDTO objGetStatus);
        StatusMasterDTO GetStatusById(StatusMasterGetDTO objGetReqirementById);
        List<StatusMasterDTO> GetActiveStatus(StatusMasterGetDTO objActive);
        List<StatusMasterDTO> GetInActiveStatus(StatusMasterGetDTO objActive);
        bool InsertStatus(StatusMasterInsertDTO objStatus);
        bool UpdateStatus(StatusMasterUpdateDTO objStatus);
        bool RemoveStatus(StatusMasterRemoveDTO objStatus);
    }
}
