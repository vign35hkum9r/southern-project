using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public interface IShiftMapping
    {
        List<ShiftMappingDTO> GetAllShiftMapping(ShiftMappingGetDTO objGetShiftMapping);
        List<ShiftMappingDTO> GetAllShiftByContract(ShiftMappingGetDTO objGetShiftMapping);
        ShiftMappingDTO GetShiftMappingById(ShiftMappingGetDTO objGetShiftMappingById);
        List<ShiftMappingDTO> GetAllCustomerShiftMapping(ShiftMappingGetDTO objGetAllCustomer);
        bool InsertShiftMapping(ShiftMappingInsertDTO shiftMapping);
        bool UpdateShiftMapping(ShiftMappingUpdateDTO shiftmapping);
        bool RemoveAllShiftMapping(ShiftMappingRemoveDTO objRemoveShiftMapping);
        bool RemoveShiftMapping(ShiftMappingRemoveDTO objRemoveShiftMapping);
    }
}
