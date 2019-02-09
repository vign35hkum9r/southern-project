using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public interface IShiftMaster
    {
        List<ShiftMasterDTO> GetAllShifts(ShiftGetDTO objGetShift);
        ShiftMasterDTO GetShiftById(ShiftGetDTO objGetShiftById);
        bool InsertShift(ShiftInsertDTO shift);
        bool UpdateShift(ShiftUpdateDTO shift);
        bool RemoveAllShift(ShiftRemoveDTO objRemoveShift);
        bool RemoveShift(ShiftRemoveDTO objRemoveShift);
    }
}
