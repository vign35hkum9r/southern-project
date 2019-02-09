using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class InsertSalaryComponent
    {
       
        [DataMember]
        public string ComponentName { get; set; }
        [DataMember]
        public int ActionBy { get; set; }
        [DataMember]
        public string ComponentType { get; set; }
    }

    [Serializable]
    [DataContract]
    public class UpdateSalaryComponent
    {
        [DataMember]
        public int ComponentId { get; set; }
        [DataMember]
        public string ComponentName { get; set; }
        [DataMember]
        public int ActionBy { get; set; }
        [DataMember]
        public string ComponentType { get; set; }
    }
   

    [Serializable]
    [DataContract]
    public class GetSalaryComponent
    {
        [DataMember]
        public int ComponentId { get; set; }
        [DataMember]
        public string ComponentName { get; set; }
        [DataMember]
        public int ActionBy { get; set; }
        [DataMember]
        public string ComponentType { get; set; }
    }
}
