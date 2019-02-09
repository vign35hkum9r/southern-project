using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class SalaryDetailDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public string SalaryCompensate { get; set; }
        [DataMember]
        public string AllowanceName { get; set; }
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public int Amount { get; set; }
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
    public class SalaryDetailGetDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public byte Active { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class SalaryDetailInsertDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }     
        [DataMember]
        public string SalaryCompensate { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class SalaryDetailUpdateDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string SalaryCompensate { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public byte Active { get; set; }
    }
    [Serializable]
    [DataContract]
    public class SalaryDetailRemoveDTO
    {
        [DataMember]
        public int Id { get; set; }     
        [DataMember]
        public string ActionBy { get; set; }
    }
}
