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
    public class ContractDetailsDataAccessLayer: IContractorDetail
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContractDetailsDataAccessLayer(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public List<ContractDetailsDTO> GetAllContractDetails(ContractDetailGetDTO objContract)
        {
            List<ContractDetailsDTO> contract = new List<ContractDetailsDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectContractDetail");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy", objContract.ActionBy);
                contract = dbLayer.GetEntityList<ContractDetailsDTO>(SqlCmd);
            }
            return contract;
        }

        public List<getConsumeRequirementById> GetConsumeRequirement(getConsumeRequirement objContract)
        {
            List<getConsumeRequirementById> contract = new List<getConsumeRequirementById>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectConsumableRequirement");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ContractId", objContract.ContractId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objContract.ActionBy);
                contract = dbLayer.GetEntityList<getConsumeRequirementById>(SqlCmd);
            }
            return contract;
        }
        public List<ContractDetailsDTO> GetContractDetailById(ContractDetailGetDTO objContract)
        {
            List<ContractDetailsDTO> contract = new List<ContractDetailsDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectContractDetail");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ContractId", objContract.ContractId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objContract.ActionBy);
                contract = dbLayer.GetEntityList<ContractDetailsDTO>(SqlCmd);
            }
            return contract;
        }

        public List<ContractDetailsDTO> GetActiveContractDetail(ContractDetailGetDTO objContract)
        {
            List<ContractDetailsDTO> ActiveList = new List<ContractDetailsDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectContractDetail");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 1);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objContract.ActionBy);
                ActiveList = dbLayer.GetEntityList<ContractDetailsDTO>(SqlCmd);
            }
            return ActiveList;
        }

        public List<ContractDetailsDTO> GetInActiveContractDetail(ContractDetailGetDTO objContract)
        {
            List<ContractDetailsDTO> InActiveList = new List<ContractDetailsDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectContractDetail");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 0);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objContract.ActionBy);
                InActiveList = dbLayer.GetEntityList<ContractDetailsDTO>(SqlCmd);
            }
            return InActiveList;
        }


        public bool InsertContractDetails(ContractDetailsInsertDTO objContract)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertContractDetail");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ContractId", objContract.ContractId);
            SqlCmd.Parameters.AddWithValue("@Designation", objContract.Designation);
            SqlCmd.Parameters.AddWithValue("@CustomerId", objContract.CustomerId);
            SqlCmd.Parameters.AddWithValue("@Service", objContract.Service);
            SqlCmd.Parameters.AddWithValue("@RatePerEmployee", objContract.RatePerEmployee);
            SqlCmd.Parameters.AddWithValue("@EmployeeCount", objContract.EmployeeCount);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objContract.CreatedBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool InsertConsumeContractDetails(ContractConsumeInsertDTO objContract)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertConsumableRequirement");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ContractId", objContract.ContractId);
            SqlCmd.Parameters.AddWithValue("@SuppliedByCustomer", objContract.SuppliedByCustomer);
            SqlCmd.Parameters.AddWithValue("@PF", objContract.PF);
            SqlCmd.Parameters.AddWithValue("@ESIC", objContract.ESIC);
            SqlCmd.Parameters.AddWithValue("@Uniform", objContract.Uniform);
            SqlCmd.Parameters.AddWithValue("@LeaveWithWages", objContract.LeaveWithWages);
            SqlCmd.Parameters.AddWithValue("@Bonus", objContract.Bonus);
            SqlCmd.Parameters.AddWithValue("@Conveyance", objContract.Conveyance);
            SqlCmd.Parameters.AddWithValue("@Gratuity", objContract.Gratuity);
            SqlCmd.Parameters.AddWithValue("@ContractAmount", objContract.ContractAmount);
            SqlCmd.Parameters.AddWithValue("@ServiceTax", objContract.ServiceTax);
            SqlCmd.Parameters.AddWithValue("@ServiceCharge", objContract.ServiceCharge);
            SqlCmd.Parameters.AddWithValue("@TotalAmount", objContract.TotalAmount);
            SqlCmd.Parameters.AddWithValue("@Remarks", objContract.Remarks);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objContract.CreatedBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool UpdateConsumeContractDetails(ContractConsumeUpdateDTO objContract)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateConsumableRequirement");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Id", objContract.Id);
            SqlCmd.Parameters.AddWithValue("@ContractId", objContract.ContractId);
            SqlCmd.Parameters.AddWithValue("@SuppliedByCustomer", objContract.SuppliedByCustomer);
            SqlCmd.Parameters.AddWithValue("@PF", objContract.PF);
            SqlCmd.Parameters.AddWithValue("@ESIC", objContract.ESIC);
            SqlCmd.Parameters.AddWithValue("@Uniform", objContract.Uniform);
            SqlCmd.Parameters.AddWithValue("@LeaveWithWages", objContract.LeaveWithWages);
            SqlCmd.Parameters.AddWithValue("@Bonus", objContract.Bonus);
            SqlCmd.Parameters.AddWithValue("@Conveyance", objContract.Conveyance);
            SqlCmd.Parameters.AddWithValue("@Gratuity", objContract.Gratuity);
            SqlCmd.Parameters.AddWithValue("@ContractAmount", objContract.ContractAmount);
            SqlCmd.Parameters.AddWithValue("@ServiceTax", objContract.ServiceTax);
            SqlCmd.Parameters.AddWithValue("@ServiceCharge", objContract.ServiceCharge);
            SqlCmd.Parameters.AddWithValue("@TotalAmount", objContract.TotalAmount);
            SqlCmd.Parameters.AddWithValue("@Remarks", objContract.Remarks);
            SqlCmd.Parameters.AddWithValue("@Active", objContract.Active);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", objContract.ModifiedBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool UpdateContractDetails(ContractDetailsUpdateDTO objContract)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateContractDetail");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Id", objContract.Id);
            SqlCmd.Parameters.AddWithValue("@Designation", objContract.Designation);
            SqlCmd.Parameters.AddWithValue("@Service", objContract.Service);
            SqlCmd.Parameters.AddWithValue("@RatePerEmployee", objContract.RatePerEmployee);
            SqlCmd.Parameters.AddWithValue("@EmployeeCount", objContract.EmployeeCount);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", objContract.ModifiedBy);
            SqlCmd.Parameters.AddWithValue("@Active", objContract.Active);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool RemoveContractDetail(ContractDetailsRemoveDTO objContract)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteContractDetail");
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@ContractId", objContract.ContractId);
            sqlcmd.Parameters.AddWithValue("@Designation", objContract.Designation);
            sqlcmd.Parameters.AddWithValue("@Active", objContract.Active);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objContract.ActionBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

    }
}
