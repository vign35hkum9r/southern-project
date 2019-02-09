using BusinessEntities;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BusinessServices
{
    public class CustomerSiteMappingDataAccessLayer:ICustomerMapping
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerSiteMappingDataAccessLayer(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public bool InsertBranch(AddBranchDTO objBranch)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertBranchMaster");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);           
            SqlCmd.Parameters.AddWithValue("@Branch", objBranch.Branch);
            SqlCmd.Parameters.AddWithValue("@ContactPerson", objBranch.ContactPerson);
            SqlCmd.Parameters.AddWithValue("@ContactNumber", objBranch.ContactNumber);
            SqlCmd.Parameters.AddWithValue("@Email", objBranch.Email);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objBranch.CreatedBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public List<GetBranchByCustomerDTO> GetAllBranch(GetCustomersBranchDTO objBranch)
        {
            List<GetBranchByCustomerDTO> role = new List<GetBranchByCustomerDTO>();
           
                SqlCommand SqlCmd = new SqlCommand("spSelectBranch");
                SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                role = _unitOfWork.DbLayer.GetEntityList<GetBranchByCustomerDTO>(SqlCmd);
            
            return role;
        }

        public List<getCustomerSitebyBranchDTO> GetAllSite(getCustomerSiteDTO objBranch)
        {
            List<getCustomerSitebyBranchDTO> role = new List<getCustomerSitebyBranchDTO>();
           
                SqlCommand SqlCmd = new SqlCommand("spSelectSiteMaster");
                SqlCmd.Parameters.AddWithValue("@BranchId", objBranch.BranchId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                role = _unitOfWork.DbLayer.GetEntityList<getCustomerSitebyBranchDTO>(SqlCmd);
            
            return role;
        }

        public bool InsertSite(AddSiteDTO objSite)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertSiteMaster");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@CustomerId", objSite.CustomerId);
            SqlCmd.Parameters.AddWithValue("@BranchId", objSite.BranchId);
            SqlCmd.Parameters.AddWithValue("@Site", objSite.Site);
            SqlCmd.Parameters.AddWithValue("@ContactPerson", objSite.ContactPerson);
            SqlCmd.Parameters.AddWithValue("@ContactNumber", objSite.ContactNumber);
            SqlCmd.Parameters.AddWithValue("@Email", objSite.Email);
            SqlCmd.Parameters.AddWithValue("@Address", objSite.Address);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objSite.CreatedBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool InsertClassfication(AddClassificationDTO objClassfication)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertCustomerSiteMapping");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@CustomerId", objClassfication.CustomerId);
            SqlCmd.Parameters.AddWithValue("@BranchId", objClassfication.BranchId);
            SqlCmd.Parameters.AddWithValue("@SiteId", objClassfication.SiteId);
            SqlCmd.Parameters.AddWithValue("@Classification", objClassfication.Classfication);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objClassfication.CreatedBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool removeBranch(removeBranchDTO objBranch)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spDeleteBranchMaster");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Id", objBranch.Id);
            SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }


        public bool removeSite(removeSiteDTO objSite)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spDeleteSiteMaster");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Id", objSite.Id);
            SqlCmd.Parameters.AddWithValue("@ActionBy", objSite.ActionBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }


        public bool removeClassification(removeClassificationDTO objClassification)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spDeleteCustomerSiteMapping");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Id", objClassification.Id);
            SqlCmd.Parameters.AddWithValue("@ActionBy", objClassification.ActionBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
    }
}
