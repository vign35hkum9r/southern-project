
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataModel.DBLayer;
using DataModel.UnitOfWork;

namespace BusinessServices
{
    public class ManPowerDataAccessLayer : IManPower
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManPowerDataAccessLayer(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public List<GetAllManpowerDTO> GetAllManPowerMaster(GetManpowerDTO objGetMaster)
        {
            List<GetAllManpowerDTO> manPower = new List<GetAllManpowerDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectManPower");
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetMaster.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                manPower = dbLayer.GetEntityList<GetAllManpowerDTO>(SqlCmd);
            }
            return manPower;
        }

        public GetAgeCalculationDTO GetAgeCalculation(GetAgeDTO objGetAge)
        {
            GetAgeCalculationDTO age = new GetAgeCalculationDTO();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spAgeCalculation");
                SqlCmd.Parameters.AddWithValue("@dob", objGetAge.DateofBirth);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                age = dbLayer.GetEntityList<GetAgeCalculationDTO>(SqlCmd).FirstOrDefault();
            }
            return age;
        }

        public List<ManpowerInsertDTO> GetManPowerMasterById(GetProofDTO objGetMasterById)
        {
            List<ManpowerInsertDTO> manPower = new List<ManpowerInsertDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectManPower");
                SqlCmd.Parameters.AddWithValue("@ManPowerId", objGetMasterById.ManPowerId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetMasterById.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                manPower = dbLayer.GetEntityList<ManpowerInsertDTO>(SqlCmd);
            }
            return manPower;
        }

        public List<ProofMasterGetDTO> GetProofMaster(GetManpowerDTO objGetProof)
        {
            List<ProofMasterGetDTO> proof = new List<ProofMasterGetDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectProofMaster");
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetProof.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                proof = dbLayer.GetEntityList<ProofMasterGetDTO>(SqlCmd);
            }
            return proof;
        }

        public GetManPowerId InsertManPower(ManpowerInsertDTO objManPower)
        {
            GetManPowerId objManPowerId = new GetManPowerId();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spInsertManPower");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Name", objManPower.Name);
                SqlCmd.Parameters.AddWithValue("@Gender", objManPower.Gender);
                SqlCmd.Parameters.AddWithValue("@DateofBirth", objManPower.DateofBirth);
                SqlCmd.Parameters.AddWithValue("@Age", objManPower.Age);
                SqlCmd.Parameters.AddWithValue("@Mobile", ((objManPower.Mobile == null) ? "" : objManPower.Mobile));
                SqlCmd.Parameters.AddWithValue("@AlternateNumber", ((objManPower.AlternateNumber == null) ? "" : objManPower.AlternateNumber));
                SqlCmd.Parameters.AddWithValue("@MaritalStatus", objManPower.MaritalStatus);
                SqlCmd.Parameters.AddWithValue("@CurrentAddress", ((objManPower.CurrentAddress == null) ? "" : objManPower.CurrentAddress));
                SqlCmd.Parameters.AddWithValue("@PermanentAddress", ((objManPower.PermanentAddress == null) ? "" : objManPower.PermanentAddress));
                SqlCmd.Parameters.AddWithValue("@Photo", ((objManPower.Photo == null) ? "" : objManPower.Photo));
                SqlCmd.Parameters.AddWithValue("@FatherName", objManPower.FatherName);
                SqlCmd.Parameters.AddWithValue("@MotherName", objManPower.MotherName);
                SqlCmd.Parameters.AddWithValue("@State", objManPower.State);
                SqlCmd.Parameters.AddWithValue("@City", objManPower.City);
                SqlCmd.Parameters.AddWithValue("@JobType", ((objManPower.JobType == null) ? "" : objManPower.JobType));
                SqlCmd.Parameters.AddWithValue("@BloodGroup", ((objManPower.BloodGroup == null) ? "" : objManPower.BloodGroup));
                SqlCmd.Parameters.AddWithValue("@Company", objManPower.Company);
                SqlCmd.Parameters.AddWithValue("@DateofJoin", objManPower.DateofJoin);
                SqlCmd.Parameters.AddWithValue("@Designation", objManPower.Designation);
                SqlCmd.Parameters.AddWithValue("@PreviousCompany", ((objManPower.PreviousCompany == null) ? "" : objManPower.PreviousCompany));
                SqlCmd.Parameters.AddWithValue("@ReferenceBy", ((objManPower.ReferenceBy == null) ? "" : objManPower.ReferenceBy));
                SqlCmd.Parameters.AddWithValue("@ReferenceContact1", ((objManPower.ReferenceContact1 == null) ? "" : objManPower.ReferenceContact1));
                SqlCmd.Parameters.AddWithValue("@ReferenceContact2", ((objManPower.ReferenceContact2 == null) ? "" : objManPower.ReferenceContact2));
                SqlCmd.Parameters.AddWithValue("@TotalExperience", objManPower.TotalExperience);
                SqlCmd.Parameters.AddWithValue("@VerificationStatus", objManPower.VerificationStatus);
                SqlCmd.Parameters.AddWithValue("@Payment", objManPower.Payment);
                SqlCmd.Parameters.AddWithValue("@CreatedBy", objManPower.CreatedBy);

                objManPowerId = dbLayer.GetEntityList<GetManPowerId>(SqlCmd).FirstOrDefault();
            }
            return objManPowerId;
        }


        public bool UpdateManPower(ManpowerUpdateDTO objManPower)
        {
            bool res = false;
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spUpdateManPower");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Id", objManPower.ManPowerId);
                SqlCmd.Parameters.AddWithValue("@Name", objManPower.Name);
                SqlCmd.Parameters.AddWithValue("@Gender", objManPower.Gender);
                SqlCmd.Parameters.AddWithValue("@FatherName", objManPower.FatherName);
                SqlCmd.Parameters.AddWithValue("@MotherName", objManPower.MotherName);
                SqlCmd.Parameters.AddWithValue("@DateofBirth", objManPower.DateofBirth);
                SqlCmd.Parameters.AddWithValue("@Age", objManPower.Age);
                SqlCmd.Parameters.AddWithValue("@Mobile", ((objManPower.Mobile == null) ? "" : objManPower.Mobile));
                SqlCmd.Parameters.AddWithValue("@AlternateNumber", ((objManPower.AlternateNumber == null) ? "" : objManPower.AlternateNumber));
                SqlCmd.Parameters.AddWithValue("@MaritalStatus", objManPower.MaritalStatus);
                SqlCmd.Parameters.AddWithValue("@CurrentAddress", ((objManPower.CurrentAddress == null) ? "" : objManPower.CurrentAddress));
                SqlCmd.Parameters.AddWithValue("@PermanentAddress", ((objManPower.PermanentAddress == null) ? "" : objManPower.PermanentAddress));
                SqlCmd.Parameters.AddWithValue("@Photo", ((objManPower.Photo == null) ? "" : objManPower.Photo));
                SqlCmd.Parameters.AddWithValue("@State", objManPower.State);
                SqlCmd.Parameters.AddWithValue("@City", objManPower.City);
                SqlCmd.Parameters.AddWithValue("@JobType", ((objManPower.JobType == null) ? "" : objManPower.JobType));
                SqlCmd.Parameters.AddWithValue("@BloodGroup", ((objManPower.BloodGroup == null) ? "" : objManPower.BloodGroup));
                SqlCmd.Parameters.AddWithValue("@Company", objManPower.Company);
                SqlCmd.Parameters.AddWithValue("@DateofJoin", objManPower.DateofJoin);
                SqlCmd.Parameters.AddWithValue("@Designation", objManPower.Designation);
                SqlCmd.Parameters.AddWithValue("@PreviousCompany", ((objManPower.PreviousCompany == null) ? "" : objManPower.PreviousCompany));
                SqlCmd.Parameters.AddWithValue("@ReferenceBy", ((objManPower.ReferenceBy == null) ? "" : objManPower.ReferenceBy));
                SqlCmd.Parameters.AddWithValue("@ReferenceContact1", ((objManPower.ReferenceContact1 == null) ? "" : objManPower.ReferenceContact1));
                SqlCmd.Parameters.AddWithValue("@ReferenceContact2", ((objManPower.ReferenceContact2 == null) ? "" : objManPower.ReferenceContact2));
                SqlCmd.Parameters.AddWithValue("@TotalExperience", ((objManPower.TotalExperience == null) ? "" : objManPower.TotalExperience));
                SqlCmd.Parameters.AddWithValue("@VerificationStatus", objManPower.VerificationStatus);
                SqlCmd.Parameters.AddWithValue("@Payment", objManPower.Payment);
                SqlCmd.Parameters.AddWithValue("@Active", objManPower.Active);
                SqlCmd.Parameters.AddWithValue("@ModifiedBy", objManPower.ModifiedBy);
                int result = dbLayer.ExecuteNonQuery(SqlCmd);
                if (result != Int32.MaxValue)
                {
                    res = true;
                }

            }
            return res;
        }

        public bool InsertVerifyProof(ManpowerProofInsertDTO objVerifyProof)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertManPowerProof");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ManpowerId", objVerifyProof.ManpowerId);
            SqlCmd.Parameters.AddWithValue("@ProofId", objVerifyProof.ProofId);
            SqlCmd.Parameters.AddWithValue("@ProofCardNo", objVerifyProof.ProofCardNo);
            SqlCmd.Parameters.AddWithValue("@ProofUrl", objVerifyProof.ProofUrl);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objVerifyProof.CreatedBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }


        public bool InsertManpowerFamily(ManpowerFamilyInsertDTO objFamily)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertManPowerFamily");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ManpowerId", objFamily.ManpowerId);
            SqlCmd.Parameters.AddWithValue("@MemberName", objFamily.MemberName);
            SqlCmd.Parameters.AddWithValue("@Relationship", objFamily.Relationship);
            SqlCmd.Parameters.AddWithValue("@Age", objFamily.Age);
            SqlCmd.Parameters.AddWithValue("@NomineeStatus", objFamily.NomineeStatus);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objFamily.CreatedBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public List<GetManpowerFamilyDTO> GetManpowerFamily(GetProofDTO objGetFamily)
        {
            List<GetManpowerFamilyDTO> family = new List<GetManpowerFamilyDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectManPowerFamily");
                SqlCmd.Parameters.AddWithValue("@ManPowerId", objGetFamily.ManPowerId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetFamily.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                family = dbLayer.GetEntityList<GetManpowerFamilyDTO>(SqlCmd);
            }
            return family;
        }

        public List<GetManpowerProofDTO> GetVerifyDetail(GetProofDTO objGetVerify)
        {
            List<GetManpowerProofDTO> verify = new List<GetManpowerProofDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectManPowerProof");
                SqlCmd.Parameters.AddWithValue("@ManPowerId", objGetVerify.ManPowerId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetVerify.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                verify = dbLayer.GetEntityList<GetManpowerProofDTO>(SqlCmd);
            }
            return verify;
        }

        public bool RemoveManpowerFamily(RemoveFamilyDTO objfamily)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteManPowerFamily");
            sqlcmd.Parameters.AddWithValue("@Id", objfamily.Id);
            sqlcmd.Parameters.AddWithValue("@ManPowerId", objfamily.ManPowerId);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objfamily.ActionBy);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool RemoveManpowerVerify(RemoveVerifyDTO objVerify)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteManPowerProof");
            sqlcmd.Parameters.AddWithValue("@Id", objVerify.Id);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objVerify.ActionBy);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool RemoveManpower(GetProofDTO objManpower)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteManPower");
            sqlcmd.Parameters.AddWithValue("@ManpowerId", objManpower.ManPowerId);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objManpower.ActionBy);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public SearchManpowerDTO SearchManpower(GetVerifyDTO objSearch)
        {
            SearchManpowerDTO manPower = new SearchManpowerDTO();
            DataSet ds = new DataSet();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSearchManPower");
                SqlCmd.Parameters.AddWithValue("@ProofCardNo", objSearch.ProofCardNo);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objSearch.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //manPower = dbLayer.GetEntityList<SearchManpowerDTO>(SqlCmd);
                ds = dbLayer.fillDataSet(SqlCmd);
                manPower = DataModel.Utilities.Utility.ConvertDataTableToEntityList<SearchManpowerDTO>(ds.Tables[0]).FirstOrDefault();
                manPower.ProofDetails = DataModel.Utilities.Utility.ConvertDataTableToEntityList<GetManpowerProofDTO>(ds.Tables[1]);
                manPower.FamilyDetails = DataModel.Utilities.Utility.ConvertDataTableToEntityList<GetManpowerFamilyDTO>(ds.Tables[2]);

            }
            return manPower;
        }

        public List<GetAllPayment> GetAllManPayment()
        {
            List<GetAllPayment> manPower = new List<GetAllPayment>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("sp_SelectPayment");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                manPower = dbLayer.GetEntityList<GetAllPayment>(SqlCmd);
            }
            return manPower;
        }
        #region Insert Manpower bank details
        public bool InsertManpowerBankDetails(ManpowerBankDetailsInsertDTO objBankDetails)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("[dbo].[spInsertManpowerBankDetails]");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ManpowerId", objBankDetails.ManpowerId);
            SqlCmd.Parameters.AddWithValue("@BankId", objBankDetails.BankId);
            SqlCmd.Parameters.AddWithValue("@AccountType", objBankDetails.AccountType);
            SqlCmd.Parameters.AddWithValue("@IFSCCode", objBankDetails.IFSCCode);
            SqlCmd.Parameters.AddWithValue("@AccountNumber", objBankDetails.AccountNumber);
            SqlCmd.Parameters.AddWithValue("@PassbookUrl", objBankDetails.PassbookUrl);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objBankDetails.CreatedBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        #endregion

        //#region get Manpower bank details
        //public bool GetManpowerBankDetails(ManpowerBankDetailsGetDTO objBankDetails)
        //{
        //    bool res = false;
        //    SqlCommand SqlCmd = new SqlCommand("[dbo].[spGetManpowerBankDetails]");
        //    SqlCmd.CommandType = CommandType.StoredProcedure;
        //    SqlCmd.Parameters.AddWithValue("@ManpowerId", objBankDetails.ManpowerId);
        //    int result = DbLayer.ExecuteNonQuery(SqlCmd);
        //    if (result != Int32.MaxValue)
        //    {
        //        res = true;
        //    }
        //    return res;
        //}

        public List<ManpowerBankDetailsGetDTO> GetManpowerBankDetails(ManpowerBankDetailsGetDTO objBankDetails)
        {
            List<ManpowerBankDetailsGetDTO> bank = new List<ManpowerBankDetailsGetDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spGetManpowerBankDetails");
                SqlCmd.Parameters.AddWithValue("@ManpowerId", objBankDetails.ManpowerId);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                bank = dbLayer.GetEntityList<ManpowerBankDetailsGetDTO>(SqlCmd);
            }
            return bank;
        }

        #region bank name list
        public List<BankNameListGetDTO> GetAllBankNameList()
        {
            List<BankNameListGetDTO> manPower = new List<BankNameListGetDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("[dbo].[spGetAllBankNameList]");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                manPower = dbLayer.GetEntityList<BankNameListGetDTO>(SqlCmd);
            }
            return manPower;
        }
        #endregion

        #region Account type list
        public List<AccountTypeGetDTO> GetAllAccountTypeList()
        {
            List<AccountTypeGetDTO> accounttype = new List<AccountTypeGetDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("[dbo].[spGetAllAccountType]");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                accounttype = dbLayer.GetEntityList<AccountTypeGetDTO>(SqlCmd);
            }
            return accounttype;
        }
        #endregion

        public bool RemoveManpowerBank(RemoveBankDTO objBank)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteManpowerBank");
            sqlcmd.Parameters.AddWithValue("@Id", objBank.Id);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objBank.ActionBy);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

    }
}
