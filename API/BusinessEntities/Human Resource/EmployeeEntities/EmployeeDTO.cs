using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class EmployeeDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string EmployeeId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public DateTime DateOfBirth { get; set; }     
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string CurrentAddress { get; set; }
        [DataMember]
        public string PermanentAddress { get; set; }
        [DataMember]
        public string NativePlace { get; set; }
        [DataMember]
        public short MedicalExam { get; set; }
        [DataMember]
        public int DesignationId { get; set; }
        [DataMember]
        public int ReportTo { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }
        [DataMember]
        public string ReportToName { get; set; }
         [DataMember]
        public int CompanyId { get; set; }
        [DataMember]
        public string DesignationName { get; set; }       
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public int StateId { get; set; }
        [DataMember]
        public int CityId { get; set; }
        [DataMember]
        public string City { get; set; } 
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public DateTime ModifiedDate { get; set; }
        [DataMember]
        public byte Active { get; set; }
       
    }

    [Serializable]
    [DataContract]
    public class EmployeeGetDTO
    {
        [DataMember]
        public int EmpId { get; set; }
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string EmployeeId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class EmployeeInsertDTO
    {
        [DataMember]
        public string ReferenceId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public DateTime DateOfBirth { get; set; }
        [DataMember]
        public string Gender { get; set; }     
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string CurrentAddress { get; set; }
        [DataMember]
        public string PermanentAddress { get; set; }
        [DataMember]
        public string NativePlace { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }
        [DataMember]
        public short MedicalExam { get; set; }
        [DataMember]
        public int DesignationId { get; set; }
        [DataMember]
        public int ReportTo { get; set; }
        [DataMember]
        public int CompanyId { get; set; }
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public int City { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string AdhaarNo { get; set; }
        [DataMember]
        public string AlternateContactNo { get; set; }
        [DataMember]
        public string Photo { get; set; }
        [DataMember]
        public string PreviousCompany { get; set; }
        [DataMember]
        public string JobType { get; set; }
        [DataMember]
        public DateTime DOJ { get; set; }
        [DataMember]
        public string ReferenceBy { get; set; }
        [DataMember]
        public string ReferenceContact1 { get; set; }
        [DataMember]
        public string ReferenceContact2 { get; set; }
        [DataMember]
        public string MaritalStatus { get; set; }
        [DataMember]
        public string MotherName { get; set; }
               
        public List<EmployeeBankDetailInsertDTO> BankDetail { get; set; }
    }

    [Serializable]
    [DataContract]
    public class EmployeeBankDetailInsertDTO
    {
        [DataMember]
        public int? EmployeeBankId { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string AccountNo { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string IFSC { get; set; }
        [DataMember]
        public string MICR { get; set; }
        [DataMember]
        public string Branch { get; set; }
        [DataMember]
        public string isPrimary { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class GetEmployeeBankDetail
    {
        [DataMember]
        public int EmployeeBankId { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string AccountNo { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string IFSC { get; set; }
        [DataMember]
        public string MICR { get; set; }
        [DataMember]
        public string Branch { get; set; }
        [DataMember]
        public string isPrimary { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }


        [Serializable]
    [DataContract]
    public class EmployeeUpdateDTO
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string ReferenceId { get; set; }
        [DataMember]
        public string EmployeeId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public DateTime DateOfBirth { get; set; }      
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }
        [DataMember]
        public string CurrentAddress { get; set; }
        [DataMember]
        public string PermanentAddress { get; set; }
        [DataMember]
        public string NativePlace { get; set; }
        [DataMember]
        public short MedicalExam { get; set; }
        [DataMember]
        public int DesignationId { get; set; }
        [DataMember]
        public int ReportTo { get; set; }
        [DataMember]
        public int CompanyId { get; set; }
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public int City { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public byte Active { get; set; }
    }

    [Serializable]
    [DataContract]
    public class EmployeeRemoveDTO
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
        [DataMember]
        public byte Active { get; set; }

    }
}
