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
    public class TargetDataAccessLayer: ITargetService
    {
        //-----Get Data Employee----//--
        public List<TargetDTO> GetAllEmployee(TargetGetDTO objTarget)
        {
            List<TargetDTO> target = new List<TargetDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectEmployeebyReportTo");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@EmployeeId", objTarget.EmployeeId);
                target = dbLayer.GetEntityList<TargetDTO>(SqlCmd);
            }
            return target;
        }          
        
        //--- Get Target Detail For Chart ----//
        // Home Page Graph
        public List<TargetGetAllChart> GetAllTargetGraph(TargetGetChart objTarget)
        {
            List<TargetGetAllChart> target = new List<TargetGetAllChart>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spGoalDetails");
                SqlCmd.CommandType = CommandType.StoredProcedure;  
                SqlCmd.Parameters.AddWithValue("@EmployeeId", objTarget.EmployeeId);                
                if (objTarget.FromDate.Year != 1)
                {
                    SqlCmd.Parameters.AddWithValue("@FromDate", objTarget.FromDate);
                    if (objTarget.ToDate.Year != 1)
                    {
                        SqlCmd.Parameters.AddWithValue("@ToDate", objTarget.ToDate);
                    }
                }
                else
                {
                    SqlCmd.Parameters.AddWithValue("@FromDate", DateTime.Now.AddDays(-90));
                    SqlCmd.Parameters.AddWithValue("@ToDate", DateTime.Now);
                }             
                target = dbLayer.GetEntityList<TargetGetAllChart>(SqlCmd);
            }
            return target;
        }

        //--- Get Target Detail By EmployeeId For Chart ----//
        // Home Page Graph 
        public List<TargetGetAllChart> GetAllTargetGraphByEmployeeId(TargetGetChart objTarget)
        {
            List<TargetGetAllChart> target = new List<TargetGetAllChart>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spGoalDetails");            
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@EmployeeId", objTarget.EmployeeId);
                if (objTarget.FromDate.Year != 1)
                {
                    SqlCmd.Parameters.AddWithValue("@FromDate", objTarget.FromDate);
                    if (objTarget.ToDate.Year != 1)
                    {
                        SqlCmd.Parameters.AddWithValue("@ToDate", objTarget.ToDate);
                    }
                }
                else
                {
                    SqlCmd.Parameters.AddWithValue("@FromDate", DateTime.Now.AddDays(-90));
                    SqlCmd.Parameters.AddWithValue("@ToDate", DateTime.Now);
                }
                target = dbLayer.GetEntityList<TargetGetAllChart>(SqlCmd);
            }
            return target;
        }



         // Home Page Grid

        public List<TargetGetAllChart> GetAllTargetCumulitive(TargetGetChart objTarget)
        {
            List<TargetGetAllChart> target = new List<TargetGetAllChart>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spGoalDetailsByRoot");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@EmployeeId", objTarget.EmployeeId);
                if (objTarget.FromDate.Year != 1)
                {
                    SqlCmd.Parameters.AddWithValue("@FromDate", objTarget.FromDate);
                    if (objTarget.ToDate.Year != 1)
                    {
                        SqlCmd.Parameters.AddWithValue("@ToDate", objTarget.ToDate);
                    }
                }
                else
                {
                    SqlCmd.Parameters.AddWithValue("@FromDate", DateTime.Now.AddDays(-90));
                    SqlCmd.Parameters.AddWithValue("@ToDate", DateTime.Now);
                }
                target = dbLayer.GetEntityList<TargetGetAllChart>(SqlCmd);
            }
            return target;
        }

        // New Gird 
        public List<TargetGetAllChart> GetAllTargetCumulitiveStacked(TargetGetChart objTarget)
        {
            List<TargetGetAllChart> target = new List<TargetGetAllChart>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("SELECT * FROM ");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                
                target = dbLayer.GetEntityList<TargetGetAllChart>(SqlCmd);
            }
            return target;
        }

        // Home Page Grid by EmployeeId

        public List<TargetGetAllChart> GetAllTargetCumulitivebyEmployeeId(TargetGetChart objTarget)
        {
            List<TargetGetAllChart> target = new List<TargetGetAllChart>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spGoalDetailsByRoot");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@EmployeeId", objTarget.EmployeeId);
                if (objTarget.FromDate.Year != 1)
                {
                    SqlCmd.Parameters.AddWithValue("@FromDate", objTarget.FromDate);
                    if (objTarget.ToDate.Year != 1)
                    {
                        SqlCmd.Parameters.AddWithValue("@ToDate", objTarget.ToDate);
                    }
                }
                else
                {
                    SqlCmd.Parameters.AddWithValue("@FromDate", DateTime.Now.AddDays(-90));
                    SqlCmd.Parameters.AddWithValue("@ToDate", DateTime.Now);
                }
                target = dbLayer.GetEntityList<TargetGetAllChart>(SqlCmd);
            }
            return target;
        }


        //-----Get Data----//--
        public List<TargetGetAllDTO> GetAllTargets(TargetGetDTO objTarget)
        {
            List<TargetGetAllDTO> target = new List<TargetGetAllDTO>();
            using(DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectTarget");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy",objTarget.ActionBy);
                target = dbLayer.GetEntityList<TargetGetAllDTO>(SqlCmd);
            }
            return target;
        }

        //-----Get Data By Month----//--
        public List<TargetGetEmployeeByAmount> GetAllEmployeeByMonth(TargetGetMonth objTarget)
        {
            List<TargetGetEmployeeByAmount> target = new List<TargetGetEmployeeByAmount>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectEmployeeMonth");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Month", objTarget.Month);
                SqlCmd.Parameters.AddWithValue("@Year", objTarget.year);
                SqlCmd.Parameters.AddWithValue("@ReportTo", objTarget.ReportTo);
                target = dbLayer.GetEntityList<TargetGetEmployeeByAmount>(SqlCmd);
            }
            return target;
        }

        //--Get by Id Based Data
        public List<TargetGetAllDTO> GetTargetById(TargetGetDTO objTarget)
        {
            List<TargetGetAllDTO> target = new List<TargetGetAllDTO>();
            using(DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectTarget");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@EmployeeId", objTarget.EmployeeId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objTarget.ActionBy);
                target = dbLayer.GetEntityList<TargetGetAllDTO>(SqlCmd);
            }
            return target;
        }
        //--Get by Active data---
        public List<TargetGetAllDTO> GetActiveTarget(TargetGetDTO objTarget)
        {
            List<TargetGetAllDTO> ActiveList = new List<TargetGetAllDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectTarget");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 1);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objTarget.ActionBy);
                ActiveList = dbLayer.GetEntityList<TargetGetAllDTO>(SqlCmd);
            }
            return ActiveList;
        }
        //--Get by Inactive Data--
        public List<TargetGetAllDTO> GetInActiveTarget(TargetGetDTO objTarget)
        {
            List<TargetGetAllDTO> InActiveList = new List<TargetGetAllDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectTarget");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 0);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objTarget.ActionBy);
                InActiveList = dbLayer.GetEntityList<TargetGetAllDTO>(SqlCmd);
            }
            return InActiveList;
        }
        //--Insert Data--
        public bool InsertTarget(TargetListDTO listTarget)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertEmployeeTarget");
            SqlCmd.CommandType = CommandType.StoredProcedure;          

            if (listTarget != null)
            {
                SqlCmd.Parameters.AddWithValue("@Month", listTarget.Month);
                SqlCmd.Parameters.AddWithValue("@Year", listTarget.Year);
                SqlCmd.Parameters.AddWithValue("@ReportTo", listTarget.ReportTo);
                SqlCmd.Parameters.AddWithValue("@CreatedBy", listTarget.CreatedBy);
                SqlCmd.Parameters.Add(new SqlParameter("@EmployeeId", SqlDbType.Int));              
                SqlCmd.Parameters.Add(new SqlParameter("@TargetAmount", SqlDbType.Int));                         
                foreach(var target in listTarget.listTarget)
                {
                    if (SqlCmd.Connection != null)
                    {
                        if (SqlCmd.Connection.State == ConnectionState.Closed)
                            SqlCmd.Connection.Open();
                    }
                    SqlCmd.Parameters["@EmployeeId"].Value = target.EmployeeId;                   
                    SqlCmd.Parameters["@TargetAmount"].Value = target.TargetAmount;                  
                    int result = new DbLayer().ExecuteNonQuery(SqlCmd);

                    if (result != Int32.MaxValue)
                    {
                        res = true;
                    }
                    else
                    {
                        res = false;
                    }
                }    
            }
            return res;
        }
        //---Update Data--
        public bool UpdateTarget(TargetUpdateDTO objTarget)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateEmployeeTarget");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Id", objTarget.Id);
            SqlCmd.Parameters.AddWithValue("@EmployeeId", objTarget.EmployeeId);
            SqlCmd.Parameters.AddWithValue("@Month", objTarget.Month);
            SqlCmd.Parameters.AddWithValue("@Year", objTarget.Year);
            SqlCmd.Parameters.AddWithValue("@TargetAmount", objTarget.TargetAmount);          
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", objTarget.ModifiedBy);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
        //---Remove Data--
        public bool RemoveTarget(TargetRemoveDTO objTarget)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteEmployeeTarget");
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@Id", objTarget.Id);            
            int result = new DbLayer().ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
    }
}
