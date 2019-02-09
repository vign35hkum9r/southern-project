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
    public class CompetitorsDataAccessLayer:ICompetitors
    {
        //-----Get Data----//--
        public List<CompetitorsDTO> GetAllCompetitors(CompetitorsGetDTO objCompetitors)
        {
            List<CompetitorsDTO> competitors = new List<CompetitorsDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectCompetitors");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy", objCompetitors.ActionBy);
                competitors = dbLayer.GetEntityList<CompetitorsDTO>(SqlCmd);
            }
            return competitors;
        }
        //--Get by Id Based Data
        public List<CompetitorsDTO> GetCompetitorsById(CompetitorsGetDTO objCompetitors)
        {
            List<CompetitorsDTO> competitors = new List<CompetitorsDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectCompetitors");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ClientId", objCompetitors.ClientId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objCompetitors.ActionBy);
                competitors = dbLayer.GetEntityList<CompetitorsDTO>(SqlCmd);
            }
            return competitors;
        }
        //--Get by Active data---
        public List<CompetitorsDTO> GetActiveCompetitors(CompetitorsGetDTO objCompetitors)
        {
            List<CompetitorsDTO> ActiveList = new List<CompetitorsDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectCompetitors");
                SqlCmd.CommandType = CommandType.StoredProcedure;            
                SqlCmd.Parameters.AddWithValue("@ActionBy", objCompetitors.ActionBy);
                ActiveList = dbLayer.GetEntityList<CompetitorsDTO>(SqlCmd);
            }
            return ActiveList;
        }
        //--Get by Inactive Data--
        public List<CompetitorsDTO> GetInActiveCompetitors(CompetitorsGetDTO objCompetitors)
        {
            List<CompetitorsDTO> InActiveList = new List<CompetitorsDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectCompetitors");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy", objCompetitors.ActionBy);
                InActiveList = dbLayer.GetEntityList<CompetitorsDTO>(SqlCmd);
            }
            return InActiveList;
        }
        //--Insert Data--
        public bool InsertCompetitors(CompetitorsInsertDTO objCompetitors)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertCompetitors");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ClientId", objCompetitors.ClientId);
            SqlCmd.Parameters.AddWithValue("@Designation", objCompetitors.Designation);
            SqlCmd.Parameters.AddWithValue("@Service", objCompetitors.Service);
            SqlCmd.Parameters.AddWithValue("@RatePerEmployee", objCompetitors.RatePerEmployee);
            SqlCmd.Parameters.AddWithValue("@EmployeeCount", objCompetitors.EmployeeCount);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objCompetitors.CreatedBy);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
        //---Update Data--
        public bool UpdateCompetitors(CompetitorsUpdateDTO objCompetitors)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateCompetitors");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@@ClientId", objCompetitors.ClientId);
            SqlCmd.Parameters.AddWithValue("@Designation", objCompetitors.Designation);
            SqlCmd.Parameters.AddWithValue("@Service", objCompetitors.Service);
            SqlCmd.Parameters.AddWithValue("@RatePerEmployee", objCompetitors.RatePerEmployee);
            SqlCmd.Parameters.AddWithValue("@EmployeeCount", objCompetitors.EmployeeCount);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", objCompetitors.ModifiedBy);         
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
        //---Remove Data--
        public bool RemoveCompetitors(CompetitorsRemoveDTO objCompetitors)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteCompetitors");
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@ClientId", objCompetitors.ClientId);
            sqlcmd.Parameters.AddWithValue("@Designation", objCompetitors.Designation);
            sqlcmd.Parameters.AddWithValue("@Active", objCompetitors.Active);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objCompetitors.ActionBy);
            int result = new DbLayer().ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
    }
}
