using BusinessEntities;
using DataModel.DBLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BusinessServices
{
   public  class LeaveMasterDataAccessLayer:ILeaveMasterService
    {
        public List<LeaveMasterDTO> GetAllLeaveMaster(LeaveMasterGetDTO objLeave)
        {
            List<LeaveMasterDTO> Leave = new List<LeaveMasterDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectLeaveMaster");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
                Leave = dbLayer.GetEntityList<LeaveMasterDTO>(SqlCmd);
            }
            return Leave;
        }

        public LeaveMasterDTO GetLeaveMasterById(LeaveMasterGetDTO objLeave)
        {
            LeaveMasterDTO accounts = new LeaveMasterDTO();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectLeaveMaster");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Id", objLeave.Id);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
                accounts = dbLayer.GetEntityList<LeaveMasterDTO>(SqlCmd).FirstOrDefault();
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

        public List<LeaveMasterDTO> GetInActiveLeaveMaster(LeaveMasterGetDTO objLeave)
        {
            List<LeaveMasterDTO> InActiveList = new List<LeaveMasterDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectLeaveMaster");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 0);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
                InActiveList = dbLayer.GetEntityList<LeaveMasterDTO>(SqlCmd);
            }
            return InActiveList;
        }

        public bool InsertLeaveMaster(LeaveMasterInsertDTO objLeave)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertLeaveMaster");
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

        public bool UpdateLeaveMaster(LeaveMasterUpdateDTO Leave)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateLeaveMaster");
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

        public bool DeactivateLeaveMaster(LeaveMasterRemoveDTO objLeave)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteLeaveMaster");
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
