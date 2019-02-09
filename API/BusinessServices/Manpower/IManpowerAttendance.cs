using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IManpowerAttendance
    {
        DataSet getAllAttendance(AttendancePopup Popup);
        List<ManpowerAttendanceCustomerAllDTO> GetAllCustomer(ManpowerAttendanceCustomerDTO objCustomer);
        List<ManpowerAttendanceBranchAllDTO> GetAllBranch(ManpowerAttendanceBranchDTO objBranch);
        List<ManpowerAttendanceSiteAllDTO> GetAllSite(ManpowerAttendanceSiteDTO objBranch);
        List<ManpowerAttendanceClassificationAllDTO> GetAllClassification(ManpowerAttendanceClassificationDTO objBranch);
        List<ManpowerAttendance> GetAllEmployee(ManpowerAttendanceEmployeeList objBranch);
        List<ManpowerStatusAllDTO> GetAllStatus(ManpowerStatusDTO objBranch);
        bool InsertAttendanceMaster(AddManpowerAttendanceDTO objAttendance);
        bool UpdateAttendanceMaster(UpdateAttendance objAttendance);
        bool InsertAttendanceHistory(InsertAttendanceHistory objAttendance);
    }
}
