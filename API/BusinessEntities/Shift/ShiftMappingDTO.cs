using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class ShiftMappingDTO
    {
        [DataMember]
        public int MappingId { get; set; }
        [DataMember]
        public int ContractId { get; set; }
        [DataMember]
        public int ShiftId { get; set; }
        [DataMember]
        public TimeSpan StartTime { get; set; }
        [DataMember]
        public TimeSpan EndTime { get; set; }
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
        [DataMember]
        public string ShiftName { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
    }
    [Serializable]
    [DataContract]
    public class ShiftMappingInsertDTO
    {
        [DataMember]
        public int ContractId { get; set; }
        [DataMember]
        public int ShiftId { get; set; }
        [DataMember]
        public string StartTime { get; set; }
        [DataMember]
        public string EndTime { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class ShiftMappingUpdateDTO
    {
        [DataMember]
        public int MappingId { get; set; }
        [DataMember]
        public int ContractId { get; set; }
        [DataMember]
        public int ShiftId { get; set; }
        [DataMember]
        public TimeSpan StartTime { get; set; }
        [DataMember]
        public TimeSpan EndTime { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public byte Active { get; set; }
    }
    public class ShiftMappingGetDTO
    {
        [DataMember]
        public int MappingId { get; set; }
        [DataMember]
        public int ContractId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
    public class ShiftMappingRemoveDTO
    {
        [DataMember]
        public int MappingId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
        [DataMember]
        public byte Active { get; set; }
    }
}
