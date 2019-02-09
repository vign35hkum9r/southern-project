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
    public class Mapping_SalaryComponentsDAL:IMappingSalaryComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public Mapping_SalaryComponentsDAL(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public bool InsertMapping_SalaryComponents(InsertMapping_SalaryComponents obj)
        {
            bool res = false;
            foreach (var c in obj.Mapping)
            {
                SqlCommand SqlCmd = new SqlCommand("sp_InsertMappingComponents");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                if (SqlCmd.Connection != null)
                {
                    if (SqlCmd.Connection.State == ConnectionState.Closed)
                        SqlCmd.Connection.Open();
                }
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ComponentId", c.ComponentId);
                SqlCmd.Parameters.AddWithValue("@ManpowerId", c.ManpowerId);
                SqlCmd.Parameters.AddWithValue("@Amount", c.Amount);
                SqlCmd.Parameters.AddWithValue("@CreatedBy", c.ActionBy);
                int queryRes = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
                if (queryRes != Int32.MaxValue)
                {
                    res = true;
                    SqlCmd.Connection.Close();
                }
                else
                {
                    // this part needed error handling code.
                    res = false;
                }
            }           
            return res;
        }

        public bool UpdateMapping_SalaryComponents(UpdateMapping_SalaryComponents obj)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("sp_UpdateMappingComponents");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@MappingId", obj.MappingId);
            SqlCmd.Parameters.AddWithValue("@ComponentId", obj.ComponentId);
            SqlCmd.Parameters.AddWithValue("@ManpowerId", obj.ManpowerId);
            SqlCmd.Parameters.AddWithValue("@Amount", obj.Amount);
            SqlCmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", obj.ActionBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool DeleteMapping_SalaryComponents(int id)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("sp_DeleteMappingComponents");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@MappingId", id);
            //  SqlCmd.Parameters.AddWithValue("@CreatedBy", obj.ActionBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public List<GetMapping_SalaryComponents> GetAllMapping_SalaryComponentss(int? id)
        {
            List<GetMapping_SalaryComponents> sal = new List<GetMapping_SalaryComponents>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("sp_SelectMappingComponents");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@MappingId", id);
                //   SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
                sal = dbLayer.GetEntityList<GetMapping_SalaryComponents>(SqlCmd);
            }
            return sal;
        }
    }
}
