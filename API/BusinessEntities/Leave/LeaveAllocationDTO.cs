using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public  class LeaveAllocationDTO
    {

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CompanyId { get; set; }
        [DataMember]
        public int ServiceId { get; set; }
        [DataMember]
        public int EmployeeType { get; set; }
        [DataMember]
        public int? LeaveMasterId { get; set; }
        [DataMember]
        public int? LeaveFrequencyId { get; set; }
        [DataMember]
        public String NoofDays { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string DepartmentName { get; set; }
        [DataMember]
        public string EmployeeTypeName { get; set; }
        [DataMember]
        public String LeaveName { get; set; }
        [DataMember]
        public String LeaveFrequencyName { get; set; }
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
    public class LeaveAllocationGetDTO
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
    public class LeaveAllocationInsertDTO
    {
        
        [DataMember]
        public int? CompanyId { get; set; }
        [DataMember]
        public int? ServiceId { get; set; }
        [DataMember]
        public int? EmployeeType { get; set; }
        [DataMember]
        public int? LeaveMasterId { get; set; }
        [DataMember]
        public int? LeaveFrequencyId { get; set; }
        [DataMember]
        public int? NoofDays { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }


    [Serializable]
    [DataContract]
    public class LeaveAllocationUpdateDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CompanyId { get; set; }
        [DataMember]
        public int ServiceId { get; set; }
        [DataMember]
        public int LeaveId { get; set; }
        [DataMember]
        public int FrequencyId { get; set; }
        [DataMember]
        public int NoOfDays { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public byte Active { get; set; }
    }

    [Serializable]
    [DataContract]
    public class LeaveAllocationRemoveDTO
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
    public class getEmployeeTypeDTO
    {
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getAllEmployeeTypeDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

}
