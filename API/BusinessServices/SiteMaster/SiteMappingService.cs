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
    public class SiteMappingDataAccessLayer:ISiteMapping
    {

        public List<getAllCustomerDTO> GetAllCustomer(getCustomerDTO objCustomer)
        {
            List<getAllCustomerDTO> site = new List<getAllCustomerDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSiteMappingCustomer");           
                SqlCmd.Parameters.AddWithValue("@ActionBy", objCustomer.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                site = dbLayer.GetEntityList<getAllCustomerDTO>(SqlCmd);
            }
            return site;
        }

        public List<getAllBranchByCustomerDTO> GetAllBranch(getBranchDTO objBranch)
        {
            List<getAllBranchByCustomerDTO> barnch = new List<getAllBranchByCustomerDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectBranch");
                SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                barnch = dbLayer.GetEntityList<getAllBranchByCustomerDTO>(SqlCmd);
            }
            return barnch;
        }

        public List<getAllSiteByBranchDTO> GetAllSite(getSiteDTO objBranch)
        {
            List<getAllSiteByBranchDTO> site = new List<getAllSiteByBranchDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectSiteMaster");
                SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);
                SqlCmd.Parameters.AddWithValue("@BranchId", objBranch.BranchId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                site = dbLayer.GetEntityList<getAllSiteByBranchDTO>(SqlCmd);
            }
            return site;
        }

        public List<getAllClassficationbySiteDTO> GetAllClassification(getClassficationDTO objBranch)
        {
            List<getAllClassficationbySiteDTO> site = new List<getAllClassficationbySiteDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectCustomerSiteMapping");
                SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);
                SqlCmd.Parameters.AddWithValue("@BranchId", objBranch.BranchId);
                SqlCmd.Parameters.AddWithValue("@SiteId", objBranch.SiteId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                site = dbLayer.GetEntityList<getAllClassficationbySiteDTO>(SqlCmd);
            }
            return site;
        }

        public List<getAllServiceByCustomerDTO> GetAllService(getServiceDTO objBranch)
        {
            List<getAllServiceByCustomerDTO> site = new List<getAllServiceByCustomerDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectContractByCustomer");
                SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                site = dbLayer.GetEntityList<getAllServiceByCustomerDTO>(SqlCmd);
            }
            return site;
        }

        public List<GetAllManpowerList> GetAllManpowerList(GetManpowerListDTO objManpower)
        {
            List<GetAllManpowerList> manpower = new List<GetAllManpowerList>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectAllocateManpower");
                SqlCmd.Parameters.AddWithValue("@CustomerId", objManpower.CustomerId);
                SqlCmd.Parameters.AddWithValue("@BranchId", objManpower.BranchId);
                SqlCmd.Parameters.AddWithValue("@SiteId", objManpower.SiteId);
                SqlCmd.Parameters.AddWithValue("@ClassificationId", objManpower.ClassificationId);
                SqlCmd.Parameters.AddWithValue("@ServiceId", objManpower.ServiceId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objManpower.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                manpower = dbLayer.GetEntityList<GetAllManpowerList>(SqlCmd);
            }
            return manpower;
        }

        public bool InsertSiteAllocation(AddSiteAllocationDTO objSite)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertManpowerSiteAllocation");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@CustomerId", objSite.CustomerId);
            SqlCmd.Parameters.AddWithValue("@BranchId", objSite.BranchId);
            SqlCmd.Parameters.AddWithValue("@SiteId", objSite.SiteId);
            SqlCmd.Parameters.AddWithValue("@ClassificationId", objSite.ClassificationId);
            SqlCmd.Parameters.AddWithValue("@Service", objSite.Service);
            SqlCmd.Parameters.AddWithValue("@NoofManpower", objSite.NoofManpower);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objSite.CreatedBy);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public List<getSiteAllocationDTO> GetAllSiteAllocation(getServiceDTO objBranch)
        {
            List<getSiteAllocationDTO> site = new List<getSiteAllocationDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectManpowerSiteAllocation");
                SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                site = dbLayer.GetEntityList<getSiteAllocationDTO>(SqlCmd);
            }
            return site;
        }

        public bool removeSiteAllocation(removeSiteAllocation objSiteAllocation)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spDeleteAllocateManPower");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@CustomerId", objSiteAllocation.CustomerId);
            SqlCmd.Parameters.AddWithValue("@BranchId", objSiteAllocation.BranchId);
            SqlCmd.Parameters.AddWithValue("@SiteId", objSiteAllocation.SiteId);
            SqlCmd.Parameters.AddWithValue("@ClassificationId", objSiteAllocation.ClassificationId);
            SqlCmd.Parameters.AddWithValue("@ServiceId", objSiteAllocation.ServiceId);
            SqlCmd.Parameters.AddWithValue("@ActionBy", objSiteAllocation.ActionBy);         
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

    }
}
