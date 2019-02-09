
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
    public class salaryAllocationDataAccessLayer: ISalaryAllocation
    {
        public List<GetAllSalaryReport> GetAllSalaryDetail(getSalaryAllocation des)
        {
            List<GetAllSalaryReport> desList = new List<GetAllSalaryReport>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectSalaryReport");
                SqlCmd.Parameters.AddWithValue("@EmployeeId", (des.EmployeeId == 0) ? null : des.EmployeeId);
                SqlCmd.Parameters.AddWithValue("@ManpowerId", (des.ManpowerId == 0) ? null : des.ManpowerId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", des.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                desList = dbLayer.GetEntityList<GetAllSalaryReport>(SqlCmd);
            }
            return desList;
        }

        public List<getAllDepartmentByEmployeeType> GetAllDepartment(getDepartmentByEmployeeType des)
        {
            List<getAllDepartmentByEmployeeType> desList = new List<getAllDepartmentByEmployeeType>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("SpSalaryAllocationByEmployeeType");
                SqlCmd.Parameters.AddWithValue("@EmployeeType", des.EmployeeType);
                SqlCmd.Parameters.AddWithValue("@ActionBy", des.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                desList = dbLayer.GetEntityList<getAllDepartmentByEmployeeType>(SqlCmd);
            }
            return desList;
        }

        public List<getAllSalaryAllocation> GetAllSalaryAllocation(getSalaryAllocation des)
        {
            List<getAllSalaryAllocation> desList = new List<getAllSalaryAllocation>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("SpSelectSalaryAllocation");
                SqlCmd.Parameters.AddWithValue("@EmployeeId",(des.EmployeeId == 0)? null : des.EmployeeId);
                SqlCmd.Parameters.AddWithValue("@ManpowerId", (des.ManpowerId == 0) ? null : des.ManpowerId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", des.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                desList = dbLayer.GetEntityList<getAllSalaryAllocation>(SqlCmd);              
            }
            return desList;
        }

        public List<getAllSalaryAllocation> GetAllSalaryReport(getSalaryAllocation des)
        {
            List<getAllSalaryAllocation> desList = new List<getAllSalaryAllocation>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("SpSelectSalaryReport");
                SqlCmd.Parameters.AddWithValue("@EmployeeId", (des.EmployeeId == 0) ? null : des.EmployeeId);
                SqlCmd.Parameters.AddWithValue("@ManpowerId", (des.ManpowerId == 0) ? null : des.ManpowerId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", des.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                desList = dbLayer.GetEntityList<getAllSalaryAllocation>(SqlCmd);
            }
            return desList;
        }

        public List<getAllDesignationByDepartment> GetAllDesignation(getDesignationByDepartment des)
        {
            List<getAllDesignationByDepartment> desList = new List<getAllDesignationByDepartment>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("SpSalaryAllocationByEmployeeType");
                SqlCmd.Parameters.AddWithValue("@DepartmentId", des.DepartmentId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", des.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                desList = dbLayer.GetEntityList<getAllDesignationByDepartment>(SqlCmd);
            }
            return desList;
        }

        public List<getAllEmployeeByDesignation> GetAllEmployee(getEmployeeByDesignation des)
        {
            List<getAllEmployeeByDesignation> desList = new List<getAllEmployeeByDesignation>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("SpSalaryAllocationByEmployeeType");
                SqlCmd.Parameters.AddWithValue("@EmployeeType", des.EmployeeType);
                SqlCmd.Parameters.AddWithValue("@DesignationId", des.DesignationId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", des.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                desList = dbLayer.GetEntityList<getAllEmployeeByDesignation>(SqlCmd);
            }
            return desList;
        }

        public bool InsertSalaryAllocation(List<InsertSalaryAllocation> objSalary)
        {
            bool res = false;
            SqlCommand sqlCmd1 = new SqlCommand("spInsertSalaryAllocation");
            sqlCmd1.CommandType = CommandType.StoredProcedure;
            sqlCmd1.Parameters.Add(new SqlParameter("@EmployeeType", SqlDbType.Int));
            sqlCmd1.Parameters.Add(new SqlParameter("@EmployeeId", SqlDbType.Int));
            sqlCmd1.Parameters.Add(new SqlParameter("@ManpowerId", SqlDbType.Int));
            sqlCmd1.Parameters.Add(new SqlParameter("@SalaryComponentId", SqlDbType.Int));
            sqlCmd1.Parameters.Add(new SqlParameter("@Type", SqlDbType.VarChar));
            sqlCmd1.Parameters.Add(new SqlParameter("@FromDeduction", SqlDbType.Int));
            sqlCmd1.Parameters.Add(new SqlParameter("@Value", SqlDbType.VarChar));
            sqlCmd1.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime));
            sqlCmd1.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal));
            sqlCmd1.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.VarChar));
            foreach (var detail in objSalary)
            {
                if (sqlCmd1.Connection != null)
                {
                    if (sqlCmd1.Connection.State == ConnectionState.Closed)
                        sqlCmd1.Connection.Open();
                }
                sqlCmd1.Parameters["@EmployeeType"].Value = detail.EmployeeType;
                sqlCmd1.Parameters["@EmployeeId"].Value = (detail.EmployeeId == 0)?null:detail.EmployeeId;
                sqlCmd1.Parameters["@ManpowerId"].Value = (detail.ManpowerId == 0)?null:detail.ManpowerId;
                sqlCmd1.Parameters["@SalaryComponentId"].Value = detail.SalaryComponentId;
                sqlCmd1.Parameters["@Type"].Value = detail.Type;
                sqlCmd1.Parameters["@FromDeduction"].Value = (detail.FromDeduction == 0) ? null : detail.FromDeduction;
                sqlCmd1.Parameters["@Value"].Value = detail.Value;
                sqlCmd1.Parameters["@Date"].Value = detail.Date;
                sqlCmd1.Parameters["@Amount"].Value = detail.Amount;
                sqlCmd1.Parameters["@CreatedBy"].Value = (detail.CreatedBy == null) ? null : detail.CreatedBy;
                int queryRes = new DbLayer().ExecuteNonQuery(sqlCmd1);
                if (queryRes != Int32.MaxValue)
                {
                    res = true;
                }
                else
                {
                    // this part needed error handling code.
                    res = false;
                }
            }
            return res;
        }
    }
}
