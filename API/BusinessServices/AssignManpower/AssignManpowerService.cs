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
   public class AssignManpowerDataAccessLayer: IAssignManpower
    {

       public List<ManPowerListDTO> GetAllManpowerList(ManpowerAssignDTO objCustomer)
       {
           List<ManPowerListDTO> manpower = new List<ManPowerListDTO>();
           using (DbLayer dbLayer = new DbLayer())
           {
               SqlCommand SqlCmd = new SqlCommand("spCreateOperation");             
               SqlCmd.Parameters.AddWithValue("@ServiceId", objCustomer.ServiceId);
               SqlCmd.Parameters.AddWithValue("@ActionBy", objCustomer.ActionBy);
               SqlCmd.CommandType = CommandType.StoredProcedure;
               manpower = dbLayer.GetEntityList<ManPowerListDTO>(SqlCmd);
           }
           return manpower;
       }

       public List<AssignManpowerDTO> GetAllAssignManPower(ManpowerBranchDTO objCustomer)
       {
           List<AssignManpowerDTO> manpower = new List<AssignManpowerDTO>();
           using (DbLayer dbLayer = new DbLayer())
           {
               SqlCommand SqlCmd = new SqlCommand("spSelectAllocateManpowerByCustomer");
               SqlCmd.Parameters.AddWithValue("@CustomerId", objCustomer.CustomerId);
               SqlCmd.Parameters.AddWithValue("@ActionBy", objCustomer.ActionBy);
               SqlCmd.CommandType = CommandType.StoredProcedure;
               manpower = dbLayer.GetEntityList<AssignManpowerDTO>(SqlCmd);         
           }
           return manpower;
       }
       public List<AssignManpowerDTO> GetContractByAllCustomer(GetContractByAllCustomer objCustomer)
       {
           List<AssignManpowerDTO> manpower = new List<AssignManpowerDTO>();
           using (DbLayer dbLayer = new DbLayer())
           {
               SqlCommand SqlCmd = new SqlCommand("spSelectContractByAllCustomer");
               SqlCmd.Parameters.AddWithValue("@ActionBy", objCustomer.ActionBy);
               SqlCmd.CommandType = CommandType.StoredProcedure;
               manpower = dbLayer.GetEntityList<AssignManpowerDTO>(SqlCmd);
           }
           return manpower;
       }

       public List<ManpowerCustomerAllDTO> GetAllCustomer(ManpowerCustomerDTO objCustomer)
       {
           List<ManpowerCustomerAllDTO> site = new List<ManpowerCustomerAllDTO>();
           using (DbLayer dbLayer = new DbLayer())
           {
               SqlCommand SqlCmd = new SqlCommand("spCreateOperation");
               SqlCmd.Parameters.AddWithValue("@ActionBy", objCustomer.ActionBy);
               SqlCmd.CommandType = CommandType.StoredProcedure;
               site = dbLayer.GetEntityList<ManpowerCustomerAllDTO>(SqlCmd);
           }
           return site;
       }

       public List<ManpowerBranchAllDTO> GetAllBranch(ManpowerBranchDTO objBranch)
       {
           List<ManpowerBranchAllDTO> branch = new List<ManpowerBranchAllDTO>();
           using (DbLayer dbLayer = new DbLayer())
           {
               SqlCommand SqlCmd = new SqlCommand("spCreateOperation");
               SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);
               SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
               SqlCmd.CommandType = CommandType.StoredProcedure;
               branch = dbLayer.GetEntityList<ManpowerBranchAllDTO>(SqlCmd);
           }
           return branch;
       }

       public List<ManpowerSiteAllDTO> GetAllSite(ManpowerSiteDTO objSite)
       {
           List<ManpowerSiteAllDTO> branch = new List<ManpowerSiteAllDTO>();
           using (DbLayer dbLayer = new DbLayer())
           {
               SqlCommand SqlCmd = new SqlCommand("spCreateOperation");
               SqlCmd.Parameters.AddWithValue("@CustomerId",objSite.CustomerId);
               SqlCmd.Parameters.AddWithValue("@BranchId", objSite.BranchId);
               SqlCmd.Parameters.AddWithValue("@ActionBy", objSite.ActionBy);
               SqlCmd.CommandType = CommandType.StoredProcedure;
               branch = dbLayer.GetEntityList<ManpowerSiteAllDTO>(SqlCmd);
           }
           return branch;
       }

       public List<ManpowerClassificationAllDTO> GetAllClassification(ManpowerClassificationDTO objClassification)
       {
           List<ManpowerClassificationAllDTO> site = new List<ManpowerClassificationAllDTO>();
           using (DbLayer dbLayer = new DbLayer())
           {
               SqlCommand SqlCmd = new SqlCommand("spCreateOperation");
               SqlCmd.Parameters.AddWithValue("@CustomerId", objClassification.CustomerId);
               SqlCmd.Parameters.AddWithValue("@BranchId", objClassification.BranchId);
               SqlCmd.Parameters.AddWithValue("@SiteId", objClassification.SiteId);
               SqlCmd.Parameters.AddWithValue("@ActionBy", objClassification.ActionBy);
               SqlCmd.CommandType = CommandType.StoredProcedure;
               site = dbLayer.GetEntityList<ManpowerClassificationAllDTO>(SqlCmd);
           }
           return site;
       }

       public List<ManpowerServiceAllDTO> GetAllService(ManpowerServiceDTO objService)
       {
           List<ManpowerServiceAllDTO> service = new List<ManpowerServiceAllDTO>();
           using (DbLayer dbLayer = new DbLayer())
           {
               SqlCommand SqlCmd = new SqlCommand("spCreateOperation");
               SqlCmd.Parameters.AddWithValue("@CustomerId", objService.CustomerId);
               SqlCmd.Parameters.AddWithValue("@BranchId", objService.BranchId);
               SqlCmd.Parameters.AddWithValue("@SiteId", objService.SiteId);
               SqlCmd.Parameters.AddWithValue("@ClassificationId", objService.ClassificationId);
               SqlCmd.Parameters.AddWithValue("@ActionBy", objService.ActionBy);
               SqlCmd.CommandType = CommandType.StoredProcedure;
               service = dbLayer.GetEntityList<ManpowerServiceAllDTO>(SqlCmd);
           }
           return service;
       }

       public bool InsertAssignManpower(AddManpowerDTO objSite)
       {
           bool res = false;
           SqlCommand SqlCmd = new SqlCommand("spInsertAllocateManPower");
           SqlCmd.CommandType = CommandType.StoredProcedure;
           SqlCmd.Parameters.AddWithValue("@ContractId", objSite.ContractId);
           SqlCmd.Parameters.AddWithValue("@CustomerId", objSite.CustomerId);
           SqlCmd.Parameters.AddWithValue("@BranchId", objSite.BranchId);
           SqlCmd.Parameters.AddWithValue("@SiteId", objSite.SiteId);
           SqlCmd.Parameters.AddWithValue("@ClassificationId", objSite.ClassificationId);
           SqlCmd.Parameters.AddWithValue("@Service", objSite.ServiceId);
           SqlCmd.Parameters.AddWithValue("@CreatedBy", objSite.CreatedBy);
           SqlCmd.Parameters.Add(new SqlParameter("@ManPowerId", SqlDbType.Int));
           foreach (var id in objSite.ManPower)
           {
               if (SqlCmd.Connection != null)
               {
                   if (SqlCmd.Connection.State == ConnectionState.Closed)
                       SqlCmd.Connection.Open();
               }
               SqlCmd.Parameters["@ManPowerId"].Value = id.ManPowerId;
               int result = new DbLayer().ExecuteNonQuery(SqlCmd);
               if (result != Int32.MaxValue)
               {
                   res = true;
               }
           }          
          
           return res;
       }

       public bool RemoveAssignManpower(RemoveManPowerDTO objRemoveManPower)
       {
           bool res = false;
           SqlCommand sqlcmd = new SqlCommand("spDeleteAllocateManPower");
           sqlcmd.Parameters.AddWithValue("@AllocationId", objRemoveManPower.AllocationId);
           sqlcmd.Parameters.AddWithValue("@ActionBy", objRemoveManPower.ActionBy);
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
