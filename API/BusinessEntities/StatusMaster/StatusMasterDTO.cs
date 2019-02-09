using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class StatusMasterDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
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
    public class StatusMasterGetDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Position { get; set; }
        [DataMember]
        public byte Active { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class StatusMasterInsertDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class StatusMasterUpdateDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public byte Active { get; set; }
    }
    [Serializable]
    [DataContract]
    public class StatusMasterRemoveDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public byte Active { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
}
