using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
  public interface ITargetService
    {
        List<TargetDTO> GetAllEmployee(TargetGetDTO objTarget);
        List<TargetGetAllChart> GetAllTargetGraph(TargetGetChart objTarget);
        List<TargetGetAllChart> GetAllTargetGraphByEmployeeId(TargetGetChart objTarget);
        List<TargetGetAllChart> GetAllTargetCumulitive(TargetGetChart objTarget);
        List<TargetGetAllChart> GetAllTargetCumulitiveStacked(TargetGetChart objTarget);
        List<TargetGetAllChart> GetAllTargetCumulitivebyEmployeeId(TargetGetChart objTarget);
        List<TargetGetAllDTO> GetAllTargets(TargetGetDTO objTarget);
        List<TargetGetEmployeeByAmount> GetAllEmployeeByMonth(TargetGetMonth objTarget);
        List<TargetGetAllDTO> GetTargetById(TargetGetDTO objTarget);
        List<TargetGetAllDTO> GetActiveTarget(TargetGetDTO objTarget);
        List<TargetGetAllDTO> GetInActiveTarget(TargetGetDTO objTarget);
        bool InsertTarget(TargetListDTO listTarget);
        bool UpdateTarget(TargetUpdateDTO objTarget);
        bool RemoveTarget(TargetRemoveDTO objTarget);
    }
}
