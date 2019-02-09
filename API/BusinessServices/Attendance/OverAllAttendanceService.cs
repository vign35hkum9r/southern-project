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
    public class OverAllAttendanceDataAccessLayer:IOverallAttentance
    {
        //public List<GetManpowerList> GetManpowerBySite(GetManpower objManpower)
        //{
        //    List<GetManpowerList> manpower = new List<GetManpowerList>();
        //    using (DbLayer dbLayer = new DbLayer())
        //    {
        //        SqlCommand SqlCmd = new SqlCommand("spSelectManpowerAttendanceByManpower");
        //        SqlCmd.CommandType = CommandType.StoredProcedure;
        //        SqlCmd.Parameters.AddWithValue("@CustomerId", objManpower.CustomerId);
        //        SqlCmd.Parameters.AddWithValue("@BranchId", objManpower.BranchId);
        //        SqlCmd.Parameters.AddWithValue("@SiteId", objManpower.SiteId);
        //        SqlCmd.Parameters.AddWithValue("@ActionBy", objManpower.ActionBy);
        //        manpower = dbLayer.GetEntityList<GetManpowerList>(SqlCmd);
        //    }
        //    return manpower;
        //}

        //public List<GetCustomerList> GetAllCustomer(GetAllCustomer objCustomer)
        //{
        //    List<GetCustomerList> customer = new List<GetCustomerList>();
        //    using (DbLayer dbLayer = new DbLayer())
        //    {
        //        SqlCommand SqlCmd = new SqlCommand("spSelectManpowerAttendanceByCustomer");
        //        SqlCmd.CommandType = CommandType.StoredProcedure;
        //        SqlCmd.Parameters.AddWithValue("@ActionBy", objCustomer.ActionBy);
        //        customer = dbLayer.GetEntityList<GetCustomerList>(SqlCmd);
        //    }
        //    return customer;
        //}

        //public List<GetBranchList> GetAllBranch(GetAllBranch objBranch)
        //{
        //    List<GetBranchList> branch = new List<GetBranchList>();
        //    using (DbLayer dbLayer = new DbLayer())
        //    {
        //        SqlCommand SqlCmd = new SqlCommand("spSelectManpowerAttendanceByCustomer");
        //        SqlCmd.CommandType = CommandType.StoredProcedure;
        //        SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);
        //        SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
        //        branch = dbLayer.GetEntityList<GetBranchList>(SqlCmd);
        //    }
        //    return branch;
        //}

        //public List<GetSiteList> GetAllSite(GetAllSite objBranch)
        //{
        //    List<GetSiteList> site = new List<GetSiteList>();
        //    using (DbLayer dbLayer = new DbLayer())
        //    {
        //        SqlCommand SqlCmd = new SqlCommand("spSelectManpowerAttendanceByCustomer");
        //        SqlCmd.CommandType = CommandType.StoredProcedure;
        //        SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);
        //        SqlCmd.Parameters.AddWithValue("@BranchId", objBranch.BranchId);
        //        SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
        //        site = dbLayer.GetEntityList<GetSiteList>(SqlCmd);
        //    }
        //    return site;
        //}
        public GetAllManpowerCustomerList GetAllManpowerCustomer(GetAllCustomer objManpower)
        {
            GetAllManpowerCustomerList getAllDetails = new GetAllManpowerCustomerList();
            List<GetCustomerList> customer = new List<GetCustomerList>();
            List<GetManpowerList> manpower = new List<GetManpowerList>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectManpowerAttendanceByCustomer");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy", objManpower.ActionBy);
                customer = dbLayer.GetEntityList<GetCustomerList>(SqlCmd);
                getAllDetails.CustomerList = customer;
            }
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectManpowerAttendanceByManpower");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy", objManpower.ActionBy);
                manpower = dbLayer.GetEntityList<GetManpowerList>(SqlCmd);
                getAllDetails.ManpowerList = manpower;
            }
            return getAllDetails;
        }

        public GetAllBranchManpowerList GetAllBranchManpower(GetAllBranch objBranch)
        {
            GetAllBranchManpowerList getAllDetails = new GetAllBranchManpowerList();
            List<GetBranchList> branch = new List<GetBranchList>();
            List<GetManpowerList> manpower = new List<GetManpowerList>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectManpowerAttendanceByCustomer");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
                branch = dbLayer.GetEntityList<GetBranchList>(SqlCmd);
                getAllDetails.BranchList = branch;
            }
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectManpowerAttendanceByManpower");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@CustomerId", objBranch.CustomerId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objBranch.ActionBy);
                manpower = dbLayer.GetEntityList<GetManpowerList>(SqlCmd);
                getAllDetails.ManpowerList = manpower;
            }
            return getAllDetails;
        }
        public GetAllSiteManpowerList GetAllSiteManpower(GetManpower objSite)
        {
            GetAllSiteManpowerList getAllDetails = new GetAllSiteManpowerList();
            List<GetSiteList> site = new List<GetSiteList>();
            List<GetManpowerList> manpower = new List<GetManpowerList>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectManpowerAttendanceByCustomer");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@CustomerId", objSite.CustomerId);
                SqlCmd.Parameters.AddWithValue("@BranchId", objSite.BranchId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objSite.ActionBy);
                site = dbLayer.GetEntityList<GetSiteList>(SqlCmd);
                getAllDetails.SiteList = site;
            }
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectManpowerAttendanceByManpower");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@CustomerId", objSite.CustomerId);
                SqlCmd.Parameters.AddWithValue("@BranchId", objSite.BranchId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objSite.ActionBy);
                manpower = dbLayer.GetEntityList<GetManpowerList>(SqlCmd);
                getAllDetails.ManpowerList = manpower;
            }
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectManpowerAttendanceByManpower");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@CustomerId", objSite.CustomerId);
                SqlCmd.Parameters.AddWithValue("@BranchId", objSite.BranchId);
                SqlCmd.Parameters.AddWithValue("@SiteId", objSite.SiteId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objSite.ActionBy);
                manpower = dbLayer.GetEntityList<GetManpowerList>(SqlCmd);
                getAllDetails.ManpowerSiteList = manpower;
            }
            return getAllDetails;
        }
    }
}