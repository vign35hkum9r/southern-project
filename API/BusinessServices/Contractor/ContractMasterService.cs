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
    public class ContractMasterDataAccessLayer: IContractorMaster
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContractMasterDataAccessLayer(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public List<ContractMasterDTO> GetAllContractMasters(ContractMasterGetDTO objGetContract)
        {
            List<ContractMasterDTO> contract = new List<ContractMasterDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectContract");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetContract.ActionBy);
                contract = dbLayer.GetEntityList<ContractMasterDTO>(SqlCmd);
            }
            return contract;
        }

        public ContractMasterDTO GetContractMasterById(ContractMasterGetDTO objGetContractById)
        {
            ContractMasterDTO contract = new ContractMasterDTO();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectContract");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Id", objGetContractById.Id);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetContractById.ActionBy);
                contract = dbLayer.GetEntityList<ContractMasterDTO>(SqlCmd).FirstOrDefault();
            }
            return contract;
        }

        public List<ContractMasterDTO> GetActiveContractMaster(ContractMasterGetDTO objActive)
        {
            List<ContractMasterDTO> ActiveList = new List<ContractMasterDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectContract");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 1);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objActive.ActionBy);
                ActiveList = dbLayer.GetEntityList<ContractMasterDTO>(SqlCmd);
            }
            return ActiveList;
        }

        public List<ContractMasterDTO> GetInActiveContractMaster(ContractMasterGetDTO objInActive)
        {
            List<ContractMasterDTO> InActiveList = new List<ContractMasterDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectContract");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 0);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objInActive.ActionBy);
                InActiveList = dbLayer.GetEntityList<ContractMasterDTO>(SqlCmd);
            }
            return InActiveList;
        }


        public bool InsertContractMaster(ContractMasterInsertDTO objContract)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertContract");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@CustomerId", objContract.CustomerId);
            SqlCmd.Parameters.AddWithValue("@StartDate", objContract.StartDate);
            SqlCmd.Parameters.AddWithValue("@EndDate", objContract.EndDate);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objContract.CreatedBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool UpdateContractMaster(ContractMasterUpdateDTO objContract)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateContract");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Id", objContract.Id);
            SqlCmd.Parameters.AddWithValue("@CustomerId", objContract.CustomerId);
            SqlCmd.Parameters.AddWithValue("@StartDate", objContract.StartDate);
            SqlCmd.Parameters.AddWithValue("@EndDate", objContract.EndDate);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", objContract.ModifiedBy);
            SqlCmd.Parameters.AddWithValue("@Active", objContract.Active);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool RemoveContractMasterById(ContractMasterRemoveDTO objRemoveContractById)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteContract");
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@Id", objRemoveContractById.Id);
            sqlcmd.Parameters.AddWithValue("@Active", objRemoveContractById.Active);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objRemoveContractById.ActionBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
    }
}
