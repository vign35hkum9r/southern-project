using BusinessEntities;
using DataModel.DBLayer;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BusinessServices
{
    public class BDMAppointmentReportService:IBDMAppoinmentReport
    {
        private readonly IUnitOfWork _unitOfWork;

        public BDMAppointmentReportService(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public List<BDMAppointmentReportDTO> GetAllAppointmentReports(BDMAppointmentReportGetByIdDTO objAppointmentReport)
        {
            List<BDMAppointmentReportDTO> appoinment = new List<BDMAppointmentReportDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectBDMAppoinmentReport");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ClientId", objAppointmentReport.ClientId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objAppointmentReport.ActionBy);              
                appoinment = dbLayer.GetEntityList<BDMAppointmentReportDTO>(SqlCmd);
            }
            return appoinment;
        }
        public BDMAppointmentReportDTO GetAppointmentReportById(BDMAppointmentReportDTO objAppointmentReport)
        {
            BDMAppointmentReportDTO appoinment = new BDMAppointmentReportDTO();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectBDMAppoinmentReport");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Id", objAppointmentReport.Id);
                appoinment = dbLayer.GetEntityList<BDMAppointmentReportDTO>(SqlCmd).FirstOrDefault();
            }
            return appoinment;
        }
        public int InsertBDMAppointmentReport(BDMAppointmentReportDTO objAppointmentReport)
        {
            
            BDMAppointmentReportGetIdDTO appoinment = new BDMAppointmentReportGetIdDTO();
            { 
            SqlCommand SqlCmd = new SqlCommand("spInsertBDMAppoinmentReport");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ClientId", objAppointmentReport.ClientId);
            SqlCmd.Parameters.AddWithValue("@Date", objAppointmentReport.Date);
            SqlCmd.Parameters.AddWithValue("@Calltype", objAppointmentReport.Calltype);         
            SqlCmd.Parameters.AddWithValue("@Remarks", objAppointmentReport.Remarks);           
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objAppointmentReport.CreatedBy);
            appoinment = new DbLayer().GetEntityList<BDMAppointmentReportGetIdDTO>(SqlCmd).FirstOrDefault();           
            }
            if (appoinment != null)
            {
                return appoinment.Id;
            }
            else
                return -1;
        }
        public bool UpdateBDMAppointmentReport(BDMAppointmentReportUpdateDTO objAppointmentReport)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateBDMAppoinmentReport");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Id",objAppointmentReport.Id);
            SqlCmd.Parameters.AddWithValue("@ClientId", objAppointmentReport.ClientId);
            SqlCmd.Parameters.AddWithValue("@Date", objAppointmentReport.Date);
            SqlCmd.Parameters.AddWithValue("@Calltype", objAppointmentReport.Calltype);           
            SqlCmd.Parameters.AddWithValue("@Remarks", objAppointmentReport.Remarks);         
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", objAppointmentReport.ModifiedBy);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
        public bool RemoveBDMAppointmentReport(BDMAppointmentReportRemoveDTO objAppointmentRemove)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteBDMAppoinmentReport");
            sqlcmd.Parameters.AddWithValue("@Id", objAppointmentRemove.Id);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            int result = new DbLayer().ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
    }
}
