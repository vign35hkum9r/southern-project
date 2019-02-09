
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
    public class Salary_DetailsDAL: ISalary_Details
    {
        private readonly IUnitOfWork _unitOfWork;

        public Salary_DetailsDAL(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        public bool InsertSalary_Details(InsertSalary_Details obj)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("sp_InsertSalaryDetails");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ManpowerId", obj.ManpowerId);
            SqlCmd.Parameters.AddWithValue("@sal_Year", obj.sal_Year);
            SqlCmd.Parameters.AddWithValue("@sal_Month", obj.sal_Month);
            SqlCmd.Parameters.AddWithValue("@SalaryDetails", obj.SalaryDetails);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", obj.ActionBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool UpdateSalary_Details(UpdateSalary_Details obj)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("sp_UpdateSalaryDetails");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@SalaryId", obj.SalaryId);
            SqlCmd.Parameters.AddWithValue("@ManpowerId", obj.ManpowerId);
            SqlCmd.Parameters.AddWithValue("@sal_Year", obj.sal_Year);
            SqlCmd.Parameters.AddWithValue("@sal_Month", obj.sal_Month);
            SqlCmd.Parameters.AddWithValue("@SalaryDetails", obj.SalaryDetails);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", obj.ActionBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool DeleteSalary_Details(int id)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("sp_DeleteSalaryDetails");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@SalaryId", id);
            //  SqlCmd.Parameters.AddWithValue("@CreatedBy", obj.ActionBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public List<GetSalary_Details> GetAllSalary_Detailss(int? id)
        {
            List<GetSalary_Details> sal = new List<GetSalary_Details>();
            using (DbLayer dbLayer =new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("sp_SelectSalaryDetails");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@SalaryId", id);
                //   SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
                sal = dbLayer.GetEntityList<GetSalary_Details>(SqlCmd);
            }
            return sal;
        }
    }
}
