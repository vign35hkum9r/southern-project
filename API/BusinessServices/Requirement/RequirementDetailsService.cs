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
    public class RequirementDetailsDataAccessLayer:IRequirementServices
    {
        //-----Get Data----//--
        public List<RequirementDetailsDTO> GetAllRequirementDetails(RequirementDetailsGetDTO objRquirement)
        {
            List<RequirementDetailsDTO> requirement = new List<RequirementDetailsDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectRequirementDetails");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy", objRquirement.ActionBy);
                requirement = dbLayer.GetEntityList<RequirementDetailsDTO>(SqlCmd);
            }
            return requirement;
        }
        //--Get by Id Based Data
        public List<RequirementDetailsDTO> GetRequirementDetailsById(RequirementDetailsGetDTO objRquirement)
        {
            List<RequirementDetailsDTO> requirement = new List<RequirementDetailsDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectRequirementDetailsById");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ClientId", objRquirement.ClientId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objRquirement.ActionBy);
                requirement = dbLayer.GetEntityList<RequirementDetailsDTO>(SqlCmd);
            }
            return requirement;
        }
        //--Get by Active data---
        public List<RequirementDetailsDTO> GetActiveRequirementDetails(RequirementDetailsGetDTO objRquirement)
        {
            List<RequirementDetailsDTO> ActiveList = new List<RequirementDetailsDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectRequirementDetails");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 1);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objRquirement.ActionBy);
                ActiveList = dbLayer.GetEntityList<RequirementDetailsDTO>(SqlCmd);
            }
            return ActiveList;
        }
        //--Get by Inactive Data--
        public List<RequirementDetailsDTO> GetInActiveRequirementDetails(RequirementDetailsGetDTO objRquirement)
        {
            List<RequirementDetailsDTO> InActiveList = new List<RequirementDetailsDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectRequirementDetails");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 0);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objRquirement.ActionBy);
                InActiveList = dbLayer.GetEntityList<RequirementDetailsDTO>(SqlCmd);
            }
            return InActiveList;
        }
        //--Insert Data--
        public bool InsertRequirementDetails(RequirementDetailsInsertDTO objRquirement)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertRequirementDetails");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ClientId", objRquirement.ClientId);
            SqlCmd.Parameters.AddWithValue("@Designation", objRquirement.Designation);
            SqlCmd.Parameters.AddWithValue("@RatePerEmployee", objRquirement.RatePerEmployee);
            SqlCmd.Parameters.AddWithValue("@EmployeeCount", objRquirement.EmployeeCount);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objRquirement.CreatedBy);
            SqlCmd.Parameters.AddWithValue("@Service", objRquirement.Service);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
        //---Update Data--
        public bool UpdateRequirementDetails(RequirementDetailsUpdateDTO objRquirement)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateRequirementDetails");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@@ClientId", objRquirement.ClientId);
            SqlCmd.Parameters.AddWithValue("@Designation", objRquirement.Designation);
            SqlCmd.Parameters.AddWithValue("@RatePerEmployee", objRquirement.RatePerEmployee);
            SqlCmd.Parameters.AddWithValue("@EmployeeCount", objRquirement.EmployeeCount);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", objRquirement.ModifiedBy);           
            SqlCmd.Parameters.AddWithValue("@Service", objRquirement.Service);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
        //---Remove Data--
        public bool RemoveRequirementDetails(RequirementDetailsRemoveDTO objRquirement)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteRequirementDetails");
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@ClientId", objRquirement.ClientId);
            sqlcmd.Parameters.AddWithValue("@Designation", objRquirement.Designation);         
            sqlcmd.Parameters.AddWithValue("@ActionBy", objRquirement.ActionBy);
            int result = new DbLayer().ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
    }
}
