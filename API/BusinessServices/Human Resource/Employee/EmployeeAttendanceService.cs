using BusinessEntities;
using DataModel.DBLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BusinessServives
{
   public class EmployeeAttendanceDataAccessLayer
    {
       public List<EmployeeAttendanceDTO> GetAllEmployeeAttendance()
       {
           List<EmployeeAttendanceDTO> contract = new List<EmployeeAttendanceDTO>();
           using (DbLayer dbLayer = new DbLayer())
           {
               SqlCommand SqlCmd = new SqlCommand("");
               SqlCmd.CommandType = CommandType.StoredProcedure;
               contract = dbLayer.GetEntityList<EmployeeAttendanceDTO>(SqlCmd);
           }
           return contract;
       }

       public EmployeeAttendanceDTO GetByEmployeeAttendanceId(long id)
       {
           EmployeeAttendanceDTO attendace = new EmployeeAttendanceDTO();
           using (DbLayer dbLayer = new DbLayer())
           {
               SqlCommand SqlCmd = new SqlCommand("");
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.Parameters.AddWithValue("@Id", id);
               attendace = dbLayer.GetEntityList<EmployeeAttendanceDTO>(SqlCmd).FirstOrDefault();
           }
           return attendace;
       }

       public bool InsertEmployeeAttendance(EmployeeAttendanceInsertDTO attendace)
       {
           bool res = false;
           SqlCommand SqlCmd = new SqlCommand("");
           SqlCmd.CommandType = CommandType.StoredProcedure;
           SqlCmd.Parameters.AddWithValue("@EmployeeId", attendace.EmployeeId);
           SqlCmd.Parameters.AddWithValue("@Date", attendace.Date);
           SqlCmd.Parameters.AddWithValue("@InTime", attendace.InTime);
           SqlCmd.Parameters.AddWithValue("@OutTime", attendace.OutTime);
           SqlCmd.Parameters.AddWithValue("@Status", attendace.Status);
           SqlCmd.Parameters.AddWithValue("@CreatedBy", attendace.CreatedBy);
           int result = new DbLayer().ExecuteNonQuery(SqlCmd);
           if (result != Int32.MaxValue)
           {
               res = true;
           }
           return res;
       }

       public bool UpdateEmployeeAttendance(EmployeeAttendanceUpdateDTO attendace)
       {
           bool res = false;
           SqlCommand SqlCmd = new SqlCommand("");
           SqlCmd.CommandType = CommandType.StoredProcedure;
           SqlCmd.Parameters.AddWithValue("@EmployeeId", attendace.EmployeeId);
           SqlCmd.Parameters.AddWithValue("@Date", attendace.Date);
           SqlCmd.Parameters.AddWithValue("@InTime", attendace.InTime);
           SqlCmd.Parameters.AddWithValue("@OutTime", attendace.OutTime);
           SqlCmd.Parameters.AddWithValue("@Status", attendace.Status);
           SqlCmd.Parameters.AddWithValue("@ModifiedBy", attendace.ModifiedBy);
           int result = new DbLayer().ExecuteNonQuery(SqlCmd);
           if (result != Int32.MaxValue)
           {
               res = true;
           }
           return res;
       }

       public bool DeactivateEmployeeAttendance(int id)
       {
           bool res = false;
           SqlCommand sqlcmd = new SqlCommand("");
           sqlcmd.CommandType = CommandType.StoredProcedure;
           sqlcmd.Parameters.AddWithValue("@Id", id);
           int result = new DbLayer().ExecuteNonQuery(sqlcmd);
           if (result != Int32.MaxValue)
           {
               res = true;
           }
           return res;
       }
    }
}
