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
    public class StatusMasterDataAccessLayer:IStatusMaster
    {
        public List<StatusMasterDTO> GetAllStatus(StatusMasterGetDTO objGetStatus)
        {
            List<StatusMasterDTO> status = new List<StatusMasterDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectStatus");
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetStatus.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                status = dbLayer.GetEntityList<StatusMasterDTO>(SqlCmd);
            }
            return status;
        }
        public StatusMasterDTO GetStatusById(StatusMasterGetDTO objGetReqirementById)
        {
            StatusMasterDTO requirement = new StatusMasterDTO();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectStatus");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Id", objGetReqirementById.Id);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetReqirementById.ActionBy);
                requirement = dbLayer.GetEntityList<StatusMasterDTO>(SqlCmd).FirstOrDefault();
            }
            return requirement;
        }
        public List<StatusMasterDTO> GetActiveStatus(StatusMasterGetDTO objActive)
        {
            List<StatusMasterDTO> activeList = new List<StatusMasterDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectStatus");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                if(objActive.Position != 0)
                {
                    SqlCmd.Parameters.AddWithValue("@Position", objActive.Position);
                }               
                SqlCmd.Parameters.AddWithValue("@Active", 1);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objActive.ActionBy);
                activeList = dbLayer.GetEntityList<StatusMasterDTO>(SqlCmd);
            }
            return activeList;
        }
        public List<StatusMasterDTO> GetInActiveStatus(StatusMasterGetDTO objActive)
        {
            List<StatusMasterDTO> inactiveList = new List<StatusMasterDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectStatus");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 0);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objActive.ActionBy);
                inactiveList = dbLayer.GetEntityList<StatusMasterDTO>(SqlCmd);
            }
            return inactiveList;
        }
        public bool InsertStatus(StatusMasterInsertDTO objStatus)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertStatus");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Name", objStatus.Name);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objStatus.CreatedBy);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
        public bool UpdateStatus(StatusMasterUpdateDTO objStatus)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateStatus");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Id", objStatus.Id);
            SqlCmd.Parameters.AddWithValue("@Name", objStatus.Name);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", objStatus.ModifiedBy);
            SqlCmd.Parameters.AddWithValue("@Active", objStatus.Active);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
        public bool RemoveStatus(StatusMasterRemoveDTO objStatus)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteStatus");
            sqlcmd.Parameters.AddWithValue("@Id", objStatus.Id);
            sqlcmd.Parameters.AddWithValue("@Active", objStatus.Active);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objStatus.ActionBy);
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
