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
    public class ClientLeadChangeDataAccessLayer:IClientLead
    {
        public List<ClientLeadChangeDTO> GetClientList(GetClientbyEmployeeDTO objEmployee)
        {
            List<ClientLeadChangeDTO> clientlist = new List<ClientLeadChangeDTO>();
            using(DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectUnSignedContract");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@EmployeeId",objEmployee.EmployeeId);
                clientlist = dbLayer.GetEntityList<ClientLeadChangeDTO>(SqlCmd);
            }
            return clientlist;
        }

        public List<OldEmployeeDTO> GetOldEmployeeList(GetOldEmployeeDTO objEmployee)
        {
            List<OldEmployeeDTO> employeelist = new List<OldEmployeeDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectEmployeeByService");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Service", objEmployee.Id);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objEmployee.ActionBy);
                employeelist = dbLayer.GetEntityList<OldEmployeeDTO>(SqlCmd);
            }
            return employeelist;
        }

        public List<NewEmployeeDTO> GetNewEmployeeList(GetNewEmployeeDTO objEmployee)
        {
            List<NewEmployeeDTO> employeelist = new List<NewEmployeeDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectLead");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@State", objEmployee.State);
                SqlCmd.Parameters.AddWithValue("@OldLead", objEmployee.OldLead);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objEmployee.ActionBy);
                employeelist = dbLayer.GetEntityList<NewEmployeeDTO>(SqlCmd);
            }
            return employeelist;
        }

        public bool ChangeLeadByClient(ChangeLeadbyClientDTO objchangelead)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spMovetoClientbyEmployee");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            if (objchangelead != null)
            {       
                SqlCmd.Parameters.AddWithValue("@ActionBy", objchangelead.ActionBy);
                SqlCmd.Parameters.AddWithValue("@ToEmployee", objchangelead.EmployeeId);
                SqlCmd.Parameters.Add(new SqlParameter("@ClientId", SqlDbType.Int));
                foreach(var client in objchangelead.ClientId)
                {
                    if (SqlCmd.Connection != null)
                    {
                        if (SqlCmd.Connection.State == ConnectionState.Closed)
                            SqlCmd.Connection.Open();
                    }
                    SqlCmd.Parameters["@ClientId"].Value = client;
                 
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
    }
}
