using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IContractorDetail
    {
        List<ContractDetailsDTO> GetAllContractDetails(ContractDetailGetDTO objContract);
        List<getConsumeRequirementById> GetConsumeRequirement(getConsumeRequirement objContract);
        List<ContractDetailsDTO> GetContractDetailById(ContractDetailGetDTO objContract);
        List<ContractDetailsDTO> GetActiveContractDetail(ContractDetailGetDTO objContract);
        List<ContractDetailsDTO> GetInActiveContractDetail(ContractDetailGetDTO objContract);
        bool InsertContractDetails(ContractDetailsInsertDTO objContract);
        bool InsertConsumeContractDetails(ContractConsumeInsertDTO objContract);
        bool UpdateConsumeContractDetails(ContractConsumeUpdateDTO objContract);
        bool UpdateContractDetails(ContractDetailsUpdateDTO objContract);
        bool RemoveContractDetail(ContractDetailsRemoveDTO objContract);
    }
}
