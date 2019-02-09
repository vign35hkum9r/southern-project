using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class CompetitorsDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public string Service { get; set; }
        [DataMember]
        public string Name { get; set; }
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
    public class CompetitorsGetDTO
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class CompetitorsInsertDTO
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]   
        public string Service { get; set; }
        [DataMember]
        public int RatePerEmployee { get; set; }
        [DataMember]
        public int EmployeeCount { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class CompetitorsUpdateDTO
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public string Service { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int RatePerEmployee { get; set; }
        [DataMember]
        public int EmployeeCount { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }    
    }
    [Serializable]
    [DataContract]
    public class CompetitorsRemoveDTO
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public byte Active { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

}
