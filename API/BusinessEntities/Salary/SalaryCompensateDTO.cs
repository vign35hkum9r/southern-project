using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class SalaryCompensateDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ComponentType { get; set; }       
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
    public class SalaryCompensateGetDTO
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
    public class SalaryCompensateInsertDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ComponentType { get; set; }        
        [DataMember]
        public string CreatedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class SalaryCompensateUpdateDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ComponentType { get; set; }       
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public byte Active { get; set; }
    }

    [Serializable]
    [DataContract]
    public class SalaryCompensateRemoveDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public byte Active { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }


}
