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
    public class ManpowerAttendanceDAL:IManpowerAttendance
    {

        private readonly IUnitOfWork _unitOfWork;

        public ManpowerAttendanceDAL(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public DataSet getAllAttendance(AttendancePopup Popup)
        {
            DataSet result;
            SqlCommand SqlCmd = new SqlCommand("spAttendanceReportByCustomer");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@CustomerId", (Popup.CustomerId == 0) ? null : Popup.CustomerId);
            SqlCmd.Parameters.AddWithValue("@BranchId", (Popup.BranchId == 0) ? null : Popup.BranchId);
            SqlCmd.Parameters.AddWithValue("@SiteId", (Popup.SiteId == 0) ? null : Popup.SiteId);
            SqlCmd.Parameters.AddWithValue("@ManpowerId", (Popup.ManpowerId == 0) ? null : Popup.ManpowerId);
            SqlCmd.Parameters.AddWithValue("@FromDate", Popup.FromDate);
            SqlCmd.Parameters.AddWithValue("@ToDate", Popup.ToDate);
            SqlCmd.Parameters.AddWithValue("@ActionBy", Popup.ActionBy);
            result = _unitOfWork.DbLayer.fillDataSet(SqlCmd);
            return result;
        }

        //public DataSet AttendancePopup(AttendancePopup Popup)
        //{
        //    DataSet result;
        //    SqlCommand SqlCmd = new SqlCommand("spAttendanceReport");
        //    SqlCmd.CommandType = CommandType.StoredProcedure;
        //    SqlCmd.Parameters.AddWithValue("@ManpowerId", Popup.ManpowerId);
        //    SqlCmd.Parameters.AddWithValue("@FromDate", Popup.FromDate);
        //    SqlCmd.Parameters.AddWithValue("@ToDate", Popup.ToDate);
        //    SqlCmd.Parameters.AddWithValue("@ActionBy", Popup.ActionBy);
        //    result = _unitOfWork.fillDataSet(SqlCmd);
        //    return result;
        //}

        public List<ManpowerAttendanceCustomerAllDTO> GetAllCustomer(ManpowerAttendanceCustomerDTO objCustomer)
        {
            List<ManpowerAttendanceCustomerAllDTO> customer = new List<ManpowerAttendanceCustomerAllDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectAllocateManpower");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@CompanyId", objCustomer.CompanyId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objCustomer.ActionBy);
                customer = dbLayer.GetEntityList<ManpowerAttendanceCustomerAllDTO>(SqlCmd);
            }
            return customer;
        }

        public List<ManpowerAttendanceBranchAllDTO> GetAllBranch(ManpowerAttendanceBranchDTO objBranch)
        {
            List<ManpowerAttendanceBranchAllDTO> branch = new List<ManpowerAttendanceBranchAllDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectAllocateManpower");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
                branch = dbLayer.GetEntityList<ManpowerAttendanceBranchAllDTO>(SqlCmd);
            }
            return branch;
        }

        public List<ManpowerAttendanceSiteAllDTO> GetAllSite(ManpowerAttendanceSiteDTO objBranch)
        {
            List<ManpowerAttendanceSiteAllDTO> site = new List<ManpowerAttendanceSiteAllDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectAllocateManpower");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);
                SqlCmd.Parameters.AddWithValue("@BranchId", objBranch.BranchId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
                site = dbLayer.GetEntityList<ManpowerAttendanceSiteAllDTO>(SqlCmd);
            }
            return site;
        }

        public List<ManpowerAttendanceClassificationAllDTO> GetAllClassification(ManpowerAttendanceClassificationDTO objBranch)
        {
            List<ManpowerAttendanceClassificationAllDTO> site = new List<ManpowerAttendanceClassificationAllDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectAllocateManpower");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);
                SqlCmd.Parameters.AddWithValue("@BranchId", objBranch.BranchId);
                SqlCmd.Parameters.AddWithValue("@SiteId", objBranch.SiteId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
                site = dbLayer.GetEntityList<ManpowerAttendanceClassificationAllDTO>(SqlCmd);
            }
            return site;
        }

        public List<ManpowerAttendance> GetAllEmployee(ManpowerAttendanceEmployeeList objBranch)
        {
            List<ManpowerAttendance> site = new List<ManpowerAttendance>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectAllocateManpower");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //SqlCmd.Parameters.AddWithValue("@Id", objBranch.Id);
                SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);
                SqlCmd.Parameters.AddWithValue("@BranchId", objBranch.BranchId);
                SqlCmd.Parameters.AddWithValue("@SiteId", objBranch.SiteId);
                //SqlCmd.Parameters.AddWithValue("@ClassificationId", objBranch.ClassificationId);
                SqlCmd.Parameters.AddWithValue("@Date", objBranch.Date);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
                site = dbLayer.GetEntityList<ManpowerAttendance>(SqlCmd);
            }
            return site;
        }

        public List<ManpowerStatusAllDTO> GetAllStatus(ManpowerStatusDTO objBranch)
        {
            List<ManpowerStatusAllDTO> site = new List<ManpowerStatusAllDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectAttendanceStatusMaster");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
                site = dbLayer.GetEntityList<ManpowerStatusAllDTO>(SqlCmd);
            }
            return site;
        }

        public bool InsertAttendanceMaster(AddManpowerAttendanceDTO objAttendance)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertManpowerAttendance");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@CustomerId", objAttendance.CustomerId);
            SqlCmd.Parameters.AddWithValue("@BranchId", objAttendance.BranchId);
            SqlCmd.Parameters.AddWithValue("@SiteId", objAttendance.SiteId);
            //SqlCmd.Parameters.AddWithValue("@ShiftMappingId", objAttendance.ShiftMappingId);
            SqlCmd.Parameters.AddWithValue("@Date", objAttendance.Date);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objAttendance.CreatedBy);
            SqlCmd.Parameters.Add(new SqlParameter("@ManpowerId", SqlDbType.Int));
            SqlCmd.Parameters.Add(new SqlParameter("@AttendanceStatus", SqlDbType.Int));
            SqlCmd.Parameters.Add(new SqlParameter("@ShiftMappingId", SqlDbType.Int));
            SqlCmd.Parameters.Add(new SqlParameter("@Reason", SqlDbType.VarChar));
            SqlCmd.Parameters.Add(new SqlParameter("@InTime", SqlDbType.DateTime));
            SqlCmd.Parameters.Add(new SqlParameter("@OutTime", SqlDbType.DateTime));
            SqlCmd.Parameters.Add(new SqlParameter("@OverTime", SqlDbType.Decimal));
            foreach (var id in objAttendance.Attendance)
            {
                if (SqlCmd.Connection != null)
                {
                    if (SqlCmd.Connection.State == ConnectionState.Closed)
                        SqlCmd.Connection.Open();
                }
                SqlCmd.Parameters["@ManpowerId"].Value = id.ManpowerId;
                SqlCmd.Parameters["@AttendanceStatus"].Value = id.StatusId;
                SqlCmd.Parameters["@ShiftMappingId"].Value = id.ShiftMappingId;
                SqlCmd.Parameters["@Reason"].Value = id.Reason;
                SqlCmd.Parameters["@InTime"].Value = ((id.InTime.Year == 1) ? (DateTime?)null : id.InTime);
                SqlCmd.Parameters["@OutTime"].Value = ((id.OutTime.Year == 1) ? (DateTime?)null : id.OutTime);
                SqlCmd.Parameters["@OverTime"].Value = id.OverTime;
                int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
                if (result != Int32.MaxValue)
                {
                    res = true;
                }
            }
            return res;
        }

        public bool UpdateAttendanceMaster(UpdateAttendance objAttendance)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateManpowerAttendance");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Date", objAttendance.Date);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", objAttendance.ModifiedBy);
            SqlCmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
            SqlCmd.Parameters.Add(new SqlParameter("@ManpowerId", SqlDbType.Int));
            SqlCmd.Parameters.Add(new SqlParameter("@AttendanceStatus", SqlDbType.Int));
            SqlCmd.Parameters.Add(new SqlParameter("@ShiftMappingId", SqlDbType.Int));
            SqlCmd.Parameters.Add(new SqlParameter("@Reason", SqlDbType.VarChar));
            SqlCmd.Parameters.Add(new SqlParameter("@InTime", SqlDbType.DateTime));
            SqlCmd.Parameters.Add(new SqlParameter("@OutTime", SqlDbType.DateTime));
            SqlCmd.Parameters.Add(new SqlParameter("@OverTime", SqlDbType.Decimal));
            foreach (var id in objAttendance.UpdateAtt)
            {
                if (SqlCmd.Connection != null)
                {
                    if (SqlCmd.Connection.State == ConnectionState.Closed)
                        SqlCmd.Connection.Open();
                }
                SqlCmd.Parameters["@Id"].Value = id.Id;
                SqlCmd.Parameters["@ManpowerId"].Value = id.ManpowerId;
                SqlCmd.Parameters["@AttendanceStatus"].Value = id.StatusId;
                SqlCmd.Parameters["@ShiftMappingId"].Value = id.ShiftMappingId;
                SqlCmd.Parameters["@Reason"].Value = id.Reason;
                SqlCmd.Parameters["@InTime"].Value = ((id.InTime.Year == 1) ? (DateTime?)null : id.InTime);
                SqlCmd.Parameters["@OutTime"].Value = ((id.OutTime.Year == 1) ? (DateTime?)null : id.OutTime);
                SqlCmd.Parameters["@OverTime"].Value = id.OverTime;
                int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
                if (result != Int32.MaxValue)
                {
                    res = true;
                }
            }
            return res;
        }


        public bool InsertAttendanceHistory(InsertAttendanceHistory objAttendance)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("sp_insert_AttendanceHistory");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@AttentanceId", objAttendance.AttendanceId);
            SqlCmd.Parameters.AddWithValue("@Status", objAttendance.Status);
            SqlCmd.Parameters.AddWithValue("@At_Year", objAttendance.At_Year);
            SqlCmd.Parameters.AddWithValue("@At_Month", objAttendance.At_Month);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objAttendance.ActionBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
    }
}
