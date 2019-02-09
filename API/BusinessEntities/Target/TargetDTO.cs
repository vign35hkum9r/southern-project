using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class TargetDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
    }
    [Serializable]
    [DataContract]
    public class TargetGetDTO
    {
        [DataMember]
        public int EmployeeId   { get; set; }
        [DataMember]
        public int ActionBy { get; set; }
        
    }
    [Serializable]
    [DataContract]
    public class TargetGetAllDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public int Month { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public int? TargetAmount { get; set; }
        [DataMember]
        public int? ActualAmount { get; set; }
        [DataMember]
        public int ReportTo { get; set; }       
    }
    [Serializable]
    [DataContract]
    public class TargetInsertDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }      
        [DataMember]
        public int TargetAmount { get; set; }
        [DataMember]
        public int ActualAmount { get; set; }       
    }
    [Serializable]
    [DataContract]
    public class TargetListDTO
    {
        [DataMember]
        public List<TargetInsertDTO> listTarget = new List<TargetInsertDTO>();
        [DataMember]
        public int Month { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public int ReportTo { get; set; }
        [DataMember]
        public string CreatedDate { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public string ModifiedDate { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class TargetUpdateDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public int Month { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public int TargetAmount { get; set; }
        [DataMember]
        public int ActualAmount { get; set; }
        [DataMember]
        public int ReportTo { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string CreatedDate { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public string ModifiedDate { get; set; }
    }
    [Serializable]
    [DataContract]
    public class TargetRemoveDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class TargetGetChart
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime ToDate { get; set; }
    }

    [Serializable]
    [DataContract]
    public class TargetGetAllChart
    {
        [DataMember]
        public string EmployeeId { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public int Month { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public int? TargetAmount { get; set; }
        [DataMember]
        public int? ActualAmount { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public string StateName { get; set; }
        [DataMember]
        public int? Balance { get; set; }
        [DataMember]
        public List<TargetGetAllChart> Childs { get; set; }
    }

    [Serializable]
    [DataContract]
    public class TargetGetMonth
    {
        [DataMember]
        public int Month { get; set; }
        [DataMember]
        public int year { get; set; }
        [DataMember]
        public int ReportTo { get; set; }
    }

    [Serializable]
    [DataContract]
    public class TargetGetEmployeeByAmount
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public int? TargetAmount { get; set; }
    }

    [Serializable]
    [DataContract]
    public class TargetTreeGetDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public int Month { get; set; }
        [DataMember]
        public int Year { get; set; }
    }
}
