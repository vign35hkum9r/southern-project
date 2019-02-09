using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IBDMAppointment
    {
        List<BDMAppointmentServerFilter> GetAllAppointmentDetails(BDMAppoinmentDetailGetDetailDTO objAppointmentDetail);
        List<BDMAppointmentDetailDTO> GetAppointmentDetailById(GetBDMAppointmentDetailDTO objAppointmentDetail);
        List<BDMAppoinmentDetailByStatus> GetAllStatusCoordinator(GetStatus objAppointmentDetail);
        BDMSurveyDetailDTO GetAppointmentDetailByClientId(BDMAppointmentGetIdDTO objSurveyAppointmentDetail);
        bool InsertBDMAppointmentDetail(BDMAppointmentDetailInsertDTO objAppointmentDetail);
        bool UpdateBDMAppointmentDetail(BDMAppointmentDetailUpdateDTO objAppointmentDetail);
        bool RemoveBDMAppointmentDetail(BDMAppoinmentDetailRemoveDTO objAppointmentDetail);
        List<BDMAppoinmentExportExcel> GetAppoinmentDetailtoExport(BDMAppoinmentDetailExport ExportDetail);
        List<BDMReportExportExcel> GetAppoinmentReporttoExport(BDMReportExport ExportDetail);
        List<BDMAppointmentServerFilter> GetAppoinmentDetailfromServerFilter(BDMAppointmentFilter FilterDetail);
        List<BDMGetDistinctEmployeeId> GetDistinctEmployeeId(BDMGetDistinctEmployeeId objId);
        List<BDMDistinctEmployeeName> GetDistinctEmployeeName(BDMDistinctEmployeeName objbdmName);
    }
}
