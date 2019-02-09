using BusinessEntities;
using DataModel.DBLayer;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BusinessServices
{
   public class LeaveFrequencyMasterDataAccessLayer:ILeaveFrequencyService
    {
        public List<LeaveFrequencyMasterDTO> GetAllLeaveFrequencyMaster(LeaveFrequencyMasterGetDTO objLeave)
        {
            List<LeaveFrequencyMasterDTO> Leave = new List<LeaveFrequencyMasterDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectLeaveFrequency");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
                Leave = dbLayer.GetEntityList<LeaveFrequencyMasterDTO>(SqlCmd);
            }
            return Leave;
        }

        public LeaveFrequencyMasterDTO GetLeaveFrequencyMasterById(LeaveFrequencyMasterGetDTO objLeave)
        {
            LeaveFrequencyMasterDTO accounts = new LeaveFrequencyMasterDTO();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectLeaveFrequencyMaster");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Id", objLeave.Id);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
                accounts = dbLayer.GetEntityList<LeaveFrequencyMasterDTO>(SqlCmd).FirstOrDefault();
            }
            return accounts;
        }

        public List<LeaveMasterDTO> GetActiveLeaveMaster(LeaveMasterGetDTO objLeave)
        {
            List<LeaveMasterDTO> ActiveList = new List<LeaveMasterDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectLeaveMaster");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 1);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
                ActiveList = dbLayer.GetEntityList<LeaveMasterDTO>(SqlCmd);
            }
            return ActiveList;
        }

        public List<LeaveFrequencyMasterDTO> GetInActiveLeaveFrequencyMaster(LeaveFrequencyMasterGetDTO objLeave)
        {
            List<LeaveFrequencyMasterDTO> InActiveList = new List<LeaveFrequencyMasterDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectLeaveFrequencyMaster");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 0);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
                InActiveList = dbLayer.GetEntityList<LeaveFrequencyMasterDTO>(SqlCmd);
            }
            return InActiveList;
        }

        public bool InsertLeaveFrequencyMaster(LeaveFrequencyMasterInsertDTO objLeave)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertLeaveFrequency");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Name", objLeave.Name);
            SqlCmd.Parameters.AddWithValue("@Description", objLeave.Description);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objLeave.CreatedBy);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
            
        }

        public bool UpdateLeaveFrequencyMaster(LeaveFrequencyMasterUpdateDTO Leave)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateLeaveFrequency");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Id", Leave.Id);
            SqlCmd.Parameters.AddWithValue("@Name", Leave.Name);
            SqlCmd.Parameters.AddWithValue("@Description", Leave.Description);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", Leave.ModifiedBy);
            SqlCmd.Parameters.AddWithValue("@Active", Leave.Active);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool DeactivateLeaveFrequencyMaster(LeaveFrequencyMasterRemoveDTO objLeave)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteLeaveFrequency");
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@Id", objLeave.Id);
            sqlcmd.Parameters.AddWithValue("@Active", objLeave.Active);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
            int result = new DbLayer().ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

    }
}
