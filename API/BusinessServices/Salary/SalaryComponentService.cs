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
    public class SalaryComponentDAL: ISalaryComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalaryComponentDAL(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public bool InsertSalaryComponent(InsertSalaryComponent obj)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("sp_InsertSalaryComponent");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ComponentName", obj.ComponentName);
            SqlCmd.Parameters.AddWithValue("@ComponentType", obj.ComponentType);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", obj.ActionBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool UpdateSalaryComponent(UpdateSalaryComponent obj)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("sp_UpdateSalaryComponent");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ComponentName", obj.ComponentName);
            SqlCmd.Parameters.AddWithValue("@ComponentType", obj.ComponentType);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", obj.ActionBy);
            SqlCmd.Parameters.AddWithValue("@ComponentId", obj.ComponentId);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool DeleteSalaryComponent(int id)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("sp_DeleteSalaryComponent");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ComponentId", id);
            //  SqlCmd.Parameters.AddWithValue("@CreatedBy", obj.ActionBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public List<GetSalaryComponent> GetAllSalaryComponents(int? id)
        {
            List<GetSalaryComponent> sal = new List<GetSalaryComponent>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("sp_SelectSalaryComponent");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ComponentId", id);
                //   SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
                sal = dbLayer.GetEntityList<GetSalaryComponent>(SqlCmd);
            }
            return sal;
        }
    }
}
