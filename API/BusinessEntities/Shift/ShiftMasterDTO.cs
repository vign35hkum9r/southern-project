using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class ShiftMasterDTO
    {
        [DataMember]
        public int ShiftId { get; set; }
        [DataMember]
        public string ShiftName { get; set; }
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
    public class ShiftInsertDTO
    {
        [DataMember]
        public string ShiftName { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class ShiftUpdateDTO
    {
        [DataMember]
        public int ShiftId { get; set; }
        [DataMember]
        public string ShiftName { get; set; }
        [DataMember]
        public DateTime ModifiedDate { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public byte Active { get; set; }
    }
    [Serializable]
    [DataContract]
    public class ShiftRemoveDTO
    {
        [DataMember]
        public int ShiftId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
        [DataMember]
        public byte Active { get; set; }
    }
    [Serializable]
    [DataContract]
    public class ShiftGetDTO
    {
        [DataMember]
        public int ShiftId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
}
