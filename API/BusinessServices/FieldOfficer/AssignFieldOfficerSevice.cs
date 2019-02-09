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
   public class AssignFieldOfficerDataAccessLayer:IAssignFieldOfficer
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssignFieldOfficerDataAccessLayer(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public List<AssignFieldOfficerDTO> GetAllAssignFieldOfficer(FieldOfficer objEmpList)
       {
           List<AssignFieldOfficerDTO> empList = new List<AssignFieldOfficerDTO>();
           using (DbLayer dbLayer = new DbLayer())
           {
               SqlCommand SqlCmd = new SqlCommand("spSelectFieldOfficerByCustomer");
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.Parameters.AddWithValue("@FieldOfficerId", objEmpList.EmployeeId);
               SqlCmd.Parameters.AddWithValue("@ActionBy", objEmpList.ActionBy);
               empList = dbLayer.GetEntityList<AssignFieldOfficerDTO>(SqlCmd);
           }
           return empList;
       }

       public List<FieldOfficerAllDTO> GetAllEmpList(FieldOfficerDTO objEmpList)
       {
           List<FieldOfficerAllDTO> empList = new List<FieldOfficerAllDTO>();
           using (DbLayer dbLayer = new DbLayer())
           {
               SqlCommand SqlCmd = new SqlCommand("spSelectFieldOfficer");
               SqlCmd.CommandType = CommandType.StoredProcedure;      
               SqlCmd.Parameters.AddWithValue("@ActionBy", objEmpList.ActionBy);
               empList = dbLayer.GetEntityList<FieldOfficerAllDTO>(SqlCmd);
           }
           return empList;
       }

       public List<FieldOfficerCustomerAllDTO> GetAllCustomer(FieldOfficerCustomerDTO objCustomer)
       {
           List<FieldOfficerCustomerAllDTO> customer = new List<FieldOfficerCustomerAllDTO>();
           using (DbLayer dbLayer = new DbLayer())
           {
               SqlCommand SqlCmd = new SqlCommand("spAssignFieldOfficer");
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.Parameters.AddWithValue("@ActionBy", objCustomer.ActionBy);
               customer = dbLayer.GetEntityList<FieldOfficerCustomerAllDTO>(SqlCmd);
           }
           return customer;
       }

       public List<FieldOfficerBranchAllDTO> GetAllBranch(FieldOfficerBranchDTO objBranch)
       {
           List<FieldOfficerBranchAllDTO> branch = new List<FieldOfficerBranchAllDTO>();
           using (DbLayer dbLayer = new DbLayer())
           {
               SqlCommand SqlCmd = new SqlCommand("spAssignFieldOfficer");
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);
               SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
               branch = dbLayer.GetEntityList<FieldOfficerBranchAllDTO>(SqlCmd);
           }
           return branch;
       }

       public List<FieldOfficerSiteAllDTO> GetAllSite(FieldOfficerSiteDTO objBranch)
       {
           List<FieldOfficerSiteAllDTO> site = new List<FieldOfficerSiteAllDTO>();
           using (DbLayer dbLayer = new DbLayer())
           {
               SqlCommand SqlCmd = new SqlCommand("spAssignFieldOfficer");
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);
               SqlCmd.Parameters.AddWithValue("@BranchId", objBranch.BranchId);
               SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
               site = dbLayer.GetEntityList<FieldOfficerSiteAllDTO>(SqlCmd);
           }
           return site;
       }

       public bool InsertAssignFieldOfficer(AddFieldOfficerDTO objFieldOfficer)
       {
           bool res = false;
           SqlCommand SqlCmd = new SqlCommand("spInsertFieldOfficerByCustomer");
           SqlCmd.CommandType = CommandType.StoredProcedure;
           SqlCmd.Parameters.AddWithValue("@FieldOfficerId", objFieldOfficer.EmployeeId);
           SqlCmd.Parameters.AddWithValue("@CustomerId", objFieldOfficer.CustomerId);
           SqlCmd.Parameters.AddWithValue("@BranchId", objFieldOfficer.BranchId);
           SqlCmd.Parameters.AddWithValue("@CreatedBy", objFieldOfficer.CreatedBy);
           SqlCmd.Parameters.Add(new SqlParameter("@SiteId", SqlDbType.Int));
           foreach (var id in objFieldOfficer.Site)
           {
               if (SqlCmd.Connection != null)
               {
                   if (SqlCmd.Connection.State == ConnectionState.Closed)
                       SqlCmd.Connection.Open();
               }
               SqlCmd.Parameters["@SiteId"].Value = id.SiteId;
               int result = new DbLayer().ExecuteNonQuery(SqlCmd);
               if (result != Int32.MaxValue)
               {
                   res = true;
               }
           }
           return res;
       }

       public bool RemoveAssignFieldOfficer(RemoveFieldOfficer objRemoveFieldOfficer)
       {
           bool res = false;
           SqlCommand sqlcmd = new SqlCommand("spDeleteFieldOfficerByCustomer");
           sqlcmd.Parameters.AddWithValue("@Id", objRemoveFieldOfficer.Id);
           sqlcmd.Parameters.AddWithValue("@ActionBy", objRemoveFieldOfficer.ActionBy);
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
