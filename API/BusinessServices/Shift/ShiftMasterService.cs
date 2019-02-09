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
    public class ShiftMasterDataAccessLayer:IShiftMaster
    {
        public List<ShiftMasterDTO> GetAllShifts (ShiftGetDTO objGetShift)
        {
            List<ShiftMasterDTO> ShiftMaster = new List<ShiftMasterDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectShift");
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetShift.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                ShiftMaster = dbLayer.GetEntityList<ShiftMasterDTO>(SqlCmd);
            }
            return ShiftMaster;
        }
        public ShiftMasterDTO GetShiftById(ShiftGetDTO objGetShiftById)
        {
            ShiftMasterDTO ShiftMaster = new ShiftMasterDTO();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectShift");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ShiftId", objGetShiftById.ShiftId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetShiftById.ActionBy);
                ShiftMaster = dbLayer.GetEntityList<ShiftMasterDTO>(SqlCmd).FirstOrDefault();
            }
            return ShiftMaster;
        }
        public bool InsertShift(ShiftInsertDTO shift)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertShift");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ShiftName", shift.ShiftName);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", shift.CreatedBy);
            //SqlCmd.Parameters.AddWithValue("@ModifiedBy", shift.ModifiedBy);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
        public bool UpdateShift(ShiftUpdateDTO shift)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateShift");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ShiftId", shift.ShiftId);
            SqlCmd.Parameters.AddWithValue("@ShiftName", shift.ShiftName);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", shift.ModifiedBy);
            SqlCmd.Parameters.AddWithValue("@Active", shift.Active);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
        public bool RemoveAllShift(ShiftRemoveDTO objRemoveShift)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteShift");
            sqlcmd.Parameters.AddWithValue("@Active", objRemoveShift.Active);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            int result = new DbLayer().ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
        public bool RemoveShift(ShiftRemoveDTO objRemoveShift)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteShift");
            sqlcmd.Parameters.AddWithValue("@ShiftId", objRemoveShift.ShiftId);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objRemoveShift.ActionBy);
            sqlcmd.Parameters.AddWithValue("@Active", objRemoveShift.Active);
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
