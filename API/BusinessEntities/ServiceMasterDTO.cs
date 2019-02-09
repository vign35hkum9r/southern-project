using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class ServiceMasterDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string SACCode { get; set; }
        [DataMember]
        public int EmployeeTypeId { get; set; }
        [DataMember]
        public string EmployeeTypeName { get; set; }
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
    public class ServiceMasterGetDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public byte Active { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class ServiceMasterInsertDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string SACCode { get; set; }
        [DataMember]
        public int EmployeeType { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class ServiceMasterUpdateDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string SACCode { get; set; }
        [DataMember]
        public int EmployeeType { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public byte Active { get; set; }
    }
    [Serializable]
    [DataContract]
    public class ServiceMasterRemoveDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public byte Active { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
}
