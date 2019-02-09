using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class GetAllManpowerDTO
    {
        [DataMember]
        public int ManPowerId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string MotherName { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public DateTime DateofBirth { get; set; }
        [DataMember]
        public short Age { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string AlternateNumber { get; set; }
        [DataMember]
        public string MaritalStatus { get; set; }
        [DataMember]
        public string CurrentAddress { get; set; }
        [DataMember]
        public string PermanentAddress { get; set; }
        [DataMember]
        public string Photo { get; set; }
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public string StateName { get; set; }
        [DataMember]
        public int City { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public string JobType { get; set; }
        [DataMember]
        public DateTime DateofJoin { get; set; }
        [DataMember]
        public int Company { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public int Designation { get; set; }
        [DataMember]
        public string DesignationName { get; set; }
        [DataMember]
        public string ReferenceBy { get; set; }
        [DataMember]
        public string PreviousCompany { get; set; }
        [DataMember]
        public string ReferenceContact1 { get; set; }
        [DataMember]
        public string ReferenceContact2 { get; set; }
        [DataMember]
        public string TotalExperience { get; set; }
        [DataMember]
        public byte VerificationStatus { get; set; }
        [DataMember]
        public int Payment { get; set; }
        [DataMember]
        public string PaymentMode { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public byte Active { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }
    }


    [Serializable]
    [DataContract]
    public class ManpowerInsertDTO
    {
        public int ManPowerId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public DateTime DateofBirth { get; set; }
        [DataMember]
        public short? Age { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string AlternateNumber { get; set; }
        [DataMember]
        public byte MaritalStatus { get; set; }
        [DataMember]
        public string CurrentAddress { get; set; }
        [DataMember]
        public string PermanentAddress { get; set; }
        [DataMember]
        public string Photo { get; set; }
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public int City { get; set; }
        [DataMember]
        public string JobType { get; set; }
        [DataMember]
        public DateTime DateofJoin { get; set; }
        [DataMember]
        public int Company { get; set; }
        [DataMember]
        public int Designation { get; set; }
        [DataMember]
        public string ReferenceBy { get; set; }
        [DataMember]
        public string PreviousCompany { get; set; }
        [DataMember]
        public string ReferenceContact1 { get; set; }
        [DataMember]
        public string ReferenceContact2 { get; set; }
        [DataMember]
        public string TotalExperience { get; set; }
        [DataMember]
        public byte VerificationStatus { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string MotherName { get; set; }
        [DataMember]
        public int Payment { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }
    }



    [Serializable]
    [DataContract]
    public class ManpowerUpdateDTO
    {
        [DataMember]
        public int ManPowerId { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string MotherName { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public DateTime DateofBirth { get; set; }
        [DataMember]
        public short? Age { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string AlternateNumber { get; set; }
        [DataMember]
        public byte MaritalStatus { get; set; }
        [DataMember]
        public string CurrentAddress { get; set; }
        [DataMember]
        public string PermanentAddress { get; set; }
        [DataMember]
        public string Photo { get; set; }
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public int City { get; set; }
        [DataMember]
        public string JobType { get; set; }
        [DataMember]
        public DateTime DateofJoin { get; set; }
        [DataMember]
        public int Company { get; set; }
        [DataMember]
        public int Designation { get; set; }
        [DataMember]
        public string ReferenceBy { get; set; }
        [DataMember]
        public string PreviousCompany { get; set; }
        [DataMember]
        public string ReferenceContact1 { get; set; }
        [DataMember]
        public string ReferenceContact2 { get; set; }
        [DataMember]
        public string TotalExperience { get; set; }
        [DataMember]
        public byte VerificationStatus { get; set; }
        [DataMember]
        public int Payment { get; set; }
        [DataMember]
        public byte Active { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }
    }


    [Serializable]
    [DataContract]
    public class GetManpowerProofDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public int ProofId { get; set; }
        [DataMember]
        public string ProofName { get; set; }
        [DataMember]
        public string ProofCardNo { get; set; }
        [DataMember]
        public string ProofUrl { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerProofInsertDTO
    {
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public int ProofId { get; set; }
        [DataMember]
        public string ProofCardNo { get; set; }
        [DataMember]
        public string ProofUrl { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerFamilyInsertDTO
    {
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public string MemberName { get; set; }
        [DataMember]
        public string Relationship { get; set; }
        [DataMember]
        public short Age { get; set; }
        [DataMember]
        public byte NomineeStatus { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class GetManpowerFamilyDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public string MemberName { get; set; }
        [DataMember]
        public string Relationship { get; set; }
        [DataMember]
        public short Age { get; set; }
        [DataMember]
        public byte NomineeStatus { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }


    [Serializable]
    [DataContract]
    public class ProofMasterGetDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ProofName { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
    }

    [Serializable]
    [DataContract]
    public class GetManpowerDTO
    {
        [DataMember]
        public string ActionBy { get; set; }
    }


    [Serializable]
    [DataContract]
    public class GetManPowerId
    {
        [DataMember]
        public int ManPowerId { get; set; }

    }

    [Serializable]
    [DataContract]
    public class GetProofDTO
    {
        [DataMember]
        public int ManPowerId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class RemoveFamilyDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ManPowerId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class GetVerifyDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ManPowerId { get; set; }
        [DataMember]
        public int ProofId { get; set; }
        [DataMember]
        public string ProofCardNo { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }


    [Serializable]
    [DataContract]
    public class RemoveVerifyDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ProofUrl { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class GetAgeDTO
    {
        [DataMember]
        public DateTime DateofBirth { get; set; }
    }
    [Serializable]
    [DataContract]
    public class GetAgeCalculationDTO
    {
        [DataMember]
        public int Age { get; set; }
    }


    [Serializable]
    [DataContract]
    public class SearchManpowerDTO
    {
        [DataMember]
        public int ManPowerId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public DateTime DateofBirth { get; set; }
        [DataMember]
        public short Age { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string AlternateNumber { get; set; }
        [DataMember]
        public byte MaritalStatus { get; set; }
        [DataMember]
        public string CurrentAddress { get; set; }
        [DataMember]
        public string PermanentAddress { get; set; }
        [DataMember]
        public string Photo { get; set; }
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public string StateName { get; set; }
        [DataMember]
        public int City { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public string JobType { get; set; }
        [DataMember]
        public int Company { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public DateTime DateofJoin { get; set; }
        [DataMember]
        public int Designation { get; set; }
        [DataMember]
        public string DesignationName { get; set; }
        [DataMember]
        public string ReferenceBy { get; set; }
        [DataMember]
        public string PreviousCompany { get; set; }
        [DataMember]
        public string ReferenceContact1 { get; set; }
        [DataMember]
        public string ReferenceContact2 { get; set; }
        [DataMember]
        public string TotalExperience { get; set; }
        [DataMember]
        public byte VerificationStatus { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public byte Active { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }

        [DataMember]
        public List<GetManpowerProofDTO> ProofDetails { get; set; }
        [DataMember]
        public List<GetManpowerFamilyDTO> FamilyDetails { get; set; }

    }

    [Serializable]
    [DataContract]
    public class GetAllPayment
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Payment { get; set; }
    }
    #region ManpowerBankDetails
    [Serializable]
    [DataContract]
    public class ManpowerBankDetailsInsertDTO
    {
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public int AccountType { get; set; }
        [DataMember]
        public string IFSCCode { get; set; }
        [DataMember]
        public int BankId { get; set; }
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public string PassbookUrl { get; set; }
        [DataMember]
        public string Active { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }
    }
    #endregion

    #region ManpowerBankDetails
    [Serializable]
    [DataContract]
    public class ManpowerBankDetailsGetDTO
    {
        [DataMember]
        public int ManpowerBankDetailId { get; set; }
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public int AccountType { get; set; }
        [DataMember]
        public string IFSCCode { get; set; }
        [DataMember]
        public int BankId { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public string PassbookUrl { get; set; }
        [DataMember]
        public string Active { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }
    }
    #endregion

    #region BankNameList
    [Serializable]
    [DataContract]
    public class BankNameListGetDTO
    {

        [DataMember]
        public int BankId { get; set; }
        [DataMember]
        public string BankName { get; set; }

    }
    #endregion

    #region AccountType List
    [Serializable]
    [DataContract]
    public class AccountTypeGetDTO
    {

        [DataMember]
        public int AccountTypeMasterId { get; set; }
        [DataMember]
        public string AccountTypeName { get; set; }

    }
    #endregion

    [Serializable]
    [DataContract]
    public class RemoveBankDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string PassbookUrl { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
}
