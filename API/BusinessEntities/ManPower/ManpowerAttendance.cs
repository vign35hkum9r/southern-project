using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class ManpowerAttendance
    {
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public string ManpowerName { get; set; }
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public int? ShiftMappingId { get; set; }
        [DataMember]
        public int? AttendanceStatus { get; set; }
        [DataMember]
        public DateTime? InTime { get; set; }
        [DataMember]
        public DateTime? OutTime { get; set; }
        [DataMember]
        public String Reason { get; set; }
        [DataMember]
        public String StatusName { get; set; }
        [DataMember]
        public int ContractId { get; set; }
        [DataMember]
        public decimal? OverTime { get; set; }
        [DataMember]
        public TimeSpan? InTimeTimeSpan
        {
            get
            {
                return (InTime.HasValue) ? InTime.Value.TimeOfDay : (TimeSpan?)null;
            }
        }
        [DataMember]
        public TimeSpan? OutTimeTimeSpan
        {
            get
            {
                return (OutTime.HasValue) ? OutTime.Value.TimeOfDay : (TimeSpan?)null;
            }
        }
    }

    [Serializable]
    [DataContract]
    public class ManpowerAttendanceCustomerDTO
    {

        [DataMember]
        public int CompanyId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerAttendanceCustomerAllDTO
    {
        
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerAttendanceBranchDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerAttendanceBranchAllDTO
    {
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public string BranchName { get; set; }
    }
    [Serializable]
    [DataContract]
    public class ManpowerAttendanceSiteDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerAttendanceSiteAllDTO
    {
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public string SiteName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerAttendanceClassificationDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerAttendanceClassificationAllDTO
    {
        [DataMember]
        public int ClassificationId { get; set; }
        [DataMember]
        public string ClassificationName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerAttendanceEmployeeList
    {
        //[DataMember]
        //public int Id { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public int SiteId { get; set; }
        //[DataMember]
        //public int ClassificationId { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerStatusDTO
    {
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerStatusAllDTO
    {
        [DataMember]
        public int StatusId { get; set; }
        [DataMember]
        public string StatusName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class AddManpowerAttendanceDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public int SiteId { get; set; }
        //[DataMember]
        //public int ShiftMappingId { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public List<AddAttendance> Attendance { get; set; }
    }
    [Serializable]
    [DataContract]
    public class AddAttendance
    {
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public int StatusId { get; set; }
        [DataMember]
        public int ShiftMappingId { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public DateTime InTime { get; set; }
        [DataMember]
        public DateTime OutTime { get; set; }
        [DataMember]
        public decimal OverTime { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getTodayAttendance
    {
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class InsertAttendanceHistory
    {
        [DataMember]
        public string AttendanceId { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string At_Year { get; set; }
        [DataMember]
        public string At_Month { get; set; }
        [DataMember]
        public int ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class UpdateAttendance
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public List<Update> UpdateAtt { get; set; }
    }
    [Serializable]
    [DataContract]
    public class Update
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public int StatusId { get; set; }
        [DataMember]
        public int ShiftMappingId { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public DateTime InTime { get; set; }
        [DataMember]
        public DateTime OutTime { get; set; }
        [DataMember]
        public decimal OverTime { get; set; }
    }

    [Serializable]
    [DataContract]
    public class GetAttendanceByManpowerId
    {
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime ToDate { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class AttendancePopup
    {
        [DataMember]
        public int? CustomerId { get; set; }
        [DataMember]
        public int? BranchId { get; set; }
        [DataMember]
        public int? SiteId { get; set; }
        [DataMember]
        public int? ManpowerId { get; set; }
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime ToDate { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
}
