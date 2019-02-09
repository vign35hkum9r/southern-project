using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class EmployeeAttendanceDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public TimeSpan InTime { get; set; }
        [DataMember]
        public TimeSpan OutTime { get; set; }
        [DataMember]
        public byte Status { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public DateTime ModifiedDate { get; set; }
    }
    [Serializable]
    [DataContract]
    public class EmployeeAttendanceInsertDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public TimeSpan InTime { get; set; }
        [DataMember]
        public TimeSpan OutTime { get; set; }
        [DataMember]
        public byte Status { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class EmployeeAttendanceUpdateDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public TimeSpan InTime { get; set; }
        [DataMember]
        public TimeSpan OutTime { get; set; }
        [DataMember]
        public byte Status { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
    }
}
