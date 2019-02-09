using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IBDMAppoinmentReport
    {
        List<BDMAppointmentReportDTO> GetAllAppointmentReports(BDMAppointmentReportGetByIdDTO objAppointmentReport);
        BDMAppointmentReportDTO GetAppointmentReportById(BDMAppointmentReportDTO objAppointmentReport);
        int InsertBDMAppointmentReport(BDMAppointmentReportDTO objAppointmentReport);
        bool UpdateBDMAppointmentReport(BDMAppointmentReportUpdateDTO objAppointmentReport);
        bool RemoveBDMAppointmentReport(BDMAppointmentReportRemoveDTO objAppointmentRemove);
    }
}
