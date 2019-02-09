using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class EmployeeAccountsDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int EmployeeId { get; set; } 
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }      
        [DataMember]
        public string AccountNo { get; set; }
        [DataMember]
        public string PaymentMode { get; set; }
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
    public class GetEmployeeDTO
    {
       
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class EmplyoeeAccountsGetDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
        [DataMember]
        public byte Active { get; set; }
    }

    [Serializable]
    [DataContract]
    public class EmployeeAccountsInsertDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string AccountNo { get; set; }
        [DataMember]
        public string PaymentMode { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class EmployeeAccountsUpdateDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string AccountNo { get; set; }
        [DataMember]
        public string PaymentMode { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public byte Active { get; set; }
    }

    [Serializable]
    [DataContract]
    public class EmployeeAccountRemoveDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public byte Active { get; set; }
        [DataMember]
        public string ActionBy { get; set; }     
       
    }

    [Serializable]
    [DataContract]
    public class CheckAccountDTO
    {
         [DataMember]
        public int Count { get; set; }
    }
      
}
