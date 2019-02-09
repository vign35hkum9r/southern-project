using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class ContractDetailsDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ContractId { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int Service { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public string DesignationName { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public int RatePerEmployee { get; set; }
        [DataMember]
        public int EmployeeCount { get; set; }
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
    public class ContractDetailGetDTO
    {
        [DataMember]
        public int ContractId { get; set; }       
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ContractDetailsInsertDTO
    {
        [DataMember]
        public int ContractId { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int Service { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public int RatePerEmployee { get; set; }
        [DataMember]
        public int EmployeeCount { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ContractDetailsUpdateDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Service { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public int RatePerEmployee { get; set; }
        [DataMember]
        public int EmployeeCount { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public byte Active { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ContractDetailsRemoveDTO
    {
        [DataMember]
        public int ContractId { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public byte Active { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ContractConsumeInsertDTO
    {
        [DataMember]
        public int ContractId { get; set; }
        [DataMember]        
        public byte SuppliedByCustomer { get; set; }
        [DataMember]
        public byte PF { get; set; }
        [DataMember]
        public byte ESIC { get; set; }
        [DataMember]
        public byte Uniform { get; set; }
        [DataMember]
        public byte LeaveWithWages { get; set; }
        [DataMember]
        public byte Bonus { get; set; }
        [DataMember]
        public byte Conveyance { get; set; }
        [DataMember]
        public byte Gratuity { get; set; }
        [DataMember]
        public int ContractAmount { get; set; }
        [DataMember]
        public int ServiceCharge { get; set; }
        [DataMember]
        public decimal ServiceTax { get; set; }
        [DataMember]
        public int TotalAmount { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ContractConsumeUpdateDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ContractId { get; set; }
        [DataMember]
        public byte SuppliedByCustomer { get; set; }
        [DataMember]
        public byte PF { get; set; }
        [DataMember]
        public byte ESIC { get; set; }
        [DataMember]
        public byte Uniform { get; set; }
        [DataMember]
        public byte LeaveWithWages { get; set; }
        [DataMember]
        public byte Bonus { get; set; }
        [DataMember]
        public byte Conveyance { get; set; }
        [DataMember]
        public byte Gratuity { get; set; }
        [DataMember]
        public int ContractAmount { get; set; }
        [DataMember]
        public int ServiceCharge { get; set; }
        [DataMember]
        public decimal ServiceTax { get; set; }
        [DataMember]
        public int TotalAmount { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getConsumeRequirement
    {
        [DataMember]
        public int ContractId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getConsumeRequirementById
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public int ContractId { get; set; }
        [DataMember]
        public byte SuppliedByCustomer { get; set; }
        [DataMember]
        public byte PF { get; set; }
        [DataMember]
        public byte ESIC { get; set; }
        [DataMember]
        public byte Uniform { get; set; }
        [DataMember]      
        public byte LeaveWithWages { get; set; }
        [DataMember]
        public byte Bonus { get; set; }
        [DataMember]
        public byte Conveyance { get; set; }
        [DataMember]
        public byte Gratuity { get; set; }
        [DataMember]
        public int? ContractAmount { get; set; }
        [DataMember]
        public int? ServiceCharge { get; set; }
        [DataMember]
        public Decimal ServiceTax { get; set; }
        [DataMember]
        public String Remarks { get; set; }
        [DataMember]
        public int TotalAmount { get; set; }
        [DataMember]
        public byte Active { get; set; }
    }

    [Serializable]
    [DataContract]
    public class UpdateConsumeRequirement
    {
        [DataMember]
        public int ContractId { get; set; }
        [DataMember]
        public byte SuppliedByCustomer { get; set; }
        [DataMember]
        public byte PF { get; set; }
        [DataMember]
        public byte ESI { get; set; }
        [DataMember]
        public byte LeaveWithWages { get; set; }
        [DataMember]
        public byte Bonus { get; set; }
        [DataMember]
        public byte Conveyance { get; set; }
        [DataMember]
        public byte Gratuity { get; set; }
        [DataMember]
        public int TotalAmount { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }
}
