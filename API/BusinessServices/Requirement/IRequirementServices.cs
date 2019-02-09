using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IRequirementServices
    {
        List<RequirementDetailsDTO> GetAllRequirementDetails(RequirementDetailsGetDTO objRquirement);
        List<RequirementDetailsDTO> GetRequirementDetailsById(RequirementDetailsGetDTO objRquirement);
        List<RequirementDetailsDTO> GetActiveRequirementDetails(RequirementDetailsGetDTO objRquirement);
        List<RequirementDetailsDTO> GetInActiveRequirementDetails(RequirementDetailsGetDTO objRquirement);
        bool InsertRequirementDetails(RequirementDetailsInsertDTO objRquirement);
        bool UpdateRequirementDetails(RequirementDetailsUpdateDTO objRquirement);
        bool RemoveRequirementDetails(RequirementDetailsRemoveDTO objRquirement);
    }
}
