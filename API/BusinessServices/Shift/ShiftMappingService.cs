
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
    public class ShiftMappingDataAccessLayer:IShiftMapping
    {
        public List<ShiftMappingDTO> GetAllShiftMapping(ShiftMappingGetDTO objGetShiftMapping)
        {
            List<ShiftMappingDTO> ShiftMapping = new List<ShiftMappingDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectShiftMapping");
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetShiftMapping.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                ShiftMapping = dbLayer.GetEntityList<ShiftMappingDTO>(SqlCmd);
            }
            return ShiftMapping;
        }

        public List<ShiftMappingDTO> GetAllShiftByContract(ShiftMappingGetDTO objGetShiftMapping)
        {
            List<ShiftMappingDTO> ShiftMapping = new List<ShiftMappingDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spselectShiftByContract");
                SqlCmd.Parameters.AddWithValue("@ContractId", objGetShiftMapping.ContractId);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                ShiftMapping = dbLayer.GetEntityList<ShiftMappingDTO>(SqlCmd);
            }
            return ShiftMapping;
        }

        
        public ShiftMappingDTO GetShiftMappingById(ShiftMappingGetDTO objGetShiftMappingById)
        {
            ShiftMappingDTO ShiftMapping = new ShiftMappingDTO();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectShiftMapping");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@MappingId", objGetShiftMappingById.MappingId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetShiftMappingById.ActionBy);
                ShiftMapping = dbLayer.GetEntityList<ShiftMappingDTO>(SqlCmd).FirstOrDefault();
            }
            return ShiftMapping;
        }
        public List<ShiftMappingDTO> GetAllCustomerShiftMapping(ShiftMappingGetDTO objGetAllCustomer)
        {
            List<ShiftMappingDTO> ShiftMapping = new List<ShiftMappingDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectAllCustomer");
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetAllCustomer.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                ShiftMapping = dbLayer.GetEntityList<ShiftMappingDTO>(SqlCmd);
            }
            return ShiftMapping;
        }
        public bool InsertShiftMapping(ShiftMappingInsertDTO shiftMapping)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertShiftMapping");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ContractId", shiftMapping.ContractId);
            SqlCmd.Parameters.AddWithValue("@ShiftId", shiftMapping.ShiftId);
            SqlCmd.Parameters.AddWithValue("@StartTime", shiftMapping.StartTime);
            SqlCmd.Parameters.AddWithValue("@EndTime", shiftMapping.EndTime);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", shiftMapping.CreatedBy);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
        public bool UpdateShiftMapping(ShiftMappingUpdateDTO shiftmapping)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateShiftMapping");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@MappingId", shiftmapping.MappingId);
            SqlCmd.Parameters.AddWithValue("@ContractId", shiftmapping.ContractId);
            SqlCmd.Parameters.AddWithValue("@ShiftId", shiftmapping.ShiftId);
            SqlCmd.Parameters.AddWithValue("@StartTime", shiftmapping.StartTime);
            SqlCmd.Parameters.AddWithValue("@EndTime", shiftmapping.EndTime);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", shiftmapping.ModifiedBy);
            SqlCmd.Parameters.AddWithValue("@Active", shiftmapping.Active);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
        public bool RemoveAllShiftMapping(ShiftMappingRemoveDTO objRemoveShiftMapping)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteShiftMapping");
            sqlcmd.Parameters.AddWithValue("@Active", objRemoveShiftMapping.Active);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            int result = new DbLayer().ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
        public bool RemoveShiftMapping(ShiftMappingRemoveDTO objRemoveShiftMapping)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteShiftMapping");
            sqlcmd.Parameters.AddWithValue("@MappingId", objRemoveShiftMapping.MappingId);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objRemoveShiftMapping.ActionBy);
            sqlcmd.Parameters.AddWithValue("@Active", objRemoveShiftMapping.Active);
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
