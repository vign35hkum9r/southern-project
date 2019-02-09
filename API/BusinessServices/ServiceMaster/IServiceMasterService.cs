using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public interface IServiceMasterService
    {
        List<ServiceMasterDTO> GetAllServices(ServiceMasterGetDTO objGetServices);
        ServiceMasterDTO GetServiceById(ServiceMasterGetDTO objGetServiceById);
        List<ServiceMasterDTO> GetActiveServiceMaster(ServiceMasterGetDTO objActive);
        List<ServiceMasterDTO> GetInActiveServiceMaster(ServiceMasterGetDTO objInActive);
        bool InsertServiceMaster(ServiceMasterInsertDTO objServiceMater);
        bool UpdateServiceMaster(ServiceMasterUpdateDTO objServiceMater);
        bool RemoveServiceMaster(ServiceMasterRemoveDTO objServiceMater);
    }
}
