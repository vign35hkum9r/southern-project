using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IContractorMaster
    {
        List<ContractMasterDTO> GetAllContractMasters(ContractMasterGetDTO objGetContract);
        ContractMasterDTO GetContractMasterById(ContractMasterGetDTO objGetContractById);
        List<ContractMasterDTO> GetActiveContractMaster(ContractMasterGetDTO objActive);
        List<ContractMasterDTO> GetInActiveContractMaster(ContractMasterGetDTO objInActive);
        bool InsertContractMaster(ContractMasterInsertDTO objContract);
        bool UpdateContractMaster(ContractMasterUpdateDTO objContract);
        bool RemoveContractMasterById(ContractMasterRemoveDTO objRemoveContractById);
    }
}
