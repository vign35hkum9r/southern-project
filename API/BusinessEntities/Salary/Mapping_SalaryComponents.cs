using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class InsertMapping_SalaryComponents
    {
         
        [DataMember]
        public List<Mapping_SalaryComponents> Mapping { get; set; }
    }

    [Serializable]
    [DataContract]
    public class Mapping_SalaryComponents
    {
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public int ComponentId { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public int ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class UpdateMapping_SalaryComponents
    {
        [DataMember]
        public int MappingId { get; set; }
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public int ComponentId { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public int ActionBy { get; set; }
    }


    [Serializable]
    [DataContract]
    public class GetMapping_SalaryComponents
    {
        [DataMember]
        public int MappingId { get; set; }
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public int ComponentId { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
