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
    public class ServiceMasterDataAccessLayer: IServiceMasterService
    {
        public List<ServiceMasterDTO> GetAllServices(ServiceMasterGetDTO objGetServices)
        {
            List<ServiceMasterDTO> requirement = new List<ServiceMasterDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectServices");
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetServices.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                requirement = dbLayer.GetEntityList<ServiceMasterDTO>(SqlCmd);
            }
            return requirement;
        }

        public ServiceMasterDTO GetServiceById(ServiceMasterGetDTO objGetServiceById)
        {
            ServiceMasterDTO requirement = new ServiceMasterDTO();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectServices");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Id", objGetServiceById.Id);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetServiceById.ActionBy);
                requirement = dbLayer.GetEntityList<ServiceMasterDTO>(SqlCmd).FirstOrDefault();
            }
            return requirement;
        }

        public List<ServiceMasterDTO> GetActiveServiceMaster(ServiceMasterGetDTO objActive)
        {
            List<ServiceMasterDTO> activeList = new List<ServiceMasterDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectServices");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 1);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objActive.ActionBy);
                activeList = dbLayer.GetEntityList<ServiceMasterDTO>(SqlCmd);
            }
            return activeList;
        }

        public List<ServiceMasterDTO> GetInActiveServiceMaster(ServiceMasterGetDTO objInActive)
        {
            List<ServiceMasterDTO> inactiveList = new List<ServiceMasterDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectServices");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 0);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objInActive.ActionBy);
                inactiveList = dbLayer.GetEntityList<ServiceMasterDTO>(SqlCmd);
            }
            return inactiveList;
        }

        public bool InsertServiceMaster(ServiceMasterInsertDTO objServiceMater)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertServices");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Name", objServiceMater.Name);
            SqlCmd.Parameters.AddWithValue("@SACCode", objServiceMater.SACCode);
            SqlCmd.Parameters.AddWithValue("@EmployeeType", objServiceMater.EmployeeType);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objServiceMater.CreatedBy);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool UpdateServiceMaster(ServiceMasterUpdateDTO objServiceMater)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateServices");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Id", objServiceMater.Id);
            SqlCmd.Parameters.AddWithValue("@Name", objServiceMater.Name);
            SqlCmd.Parameters.AddWithValue("@SACCode", objServiceMater.SACCode);
            SqlCmd.Parameters.AddWithValue("@EmployeeType", objServiceMater.EmployeeType);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", objServiceMater.ModifiedBy);
            SqlCmd.Parameters.AddWithValue("@Active", objServiceMater.Active);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool RemoveServiceMaster(ServiceMasterRemoveDTO objServiceMater)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteServices");
            sqlcmd.Parameters.AddWithValue("@Id", objServiceMater.Id);
            sqlcmd.Parameters.AddWithValue("@Active", objServiceMater.Active);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objServiceMater.ActionBy);
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
