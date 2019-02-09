using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class RequirementDetailsDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int Designation { get; set; }
        [DataMember]
        public string DesignationName { get; set; }
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
        public int Service { get; set; }
        [DataMember]
        public string ServiceName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class RequirementDetailsGetDTO
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class RequirementDetailsInsertDTO
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int Designation { get; set; }
        [DataMember]
        public int RatePerEmployee { get; set; }
        [DataMember]
        public int EmployeeCount { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public int Service { get; set; }
    }

    [Serializable]
    [DataContract]
    public class RequirementDetailsUpdateDTO
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int Designation { get; set; }
        [DataMember]
        public int RatePerEmployee { get; set; }
        [DataMember]
        public int EmployeeCount { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }      
        [DataMember]
        public int Service { get; set; }
    }

    [Serializable]
    [DataContract]
    public class RequirementDetailsRemoveDTO
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int Designation { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
}
