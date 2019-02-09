using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class AssignFieldOfficerDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int FieldOfficerId { get; set; }
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public string FieldOfficerName { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public string BranchName { get; set; }
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public string SiteName { get; set; }

    }

    [Serializable]
    [DataContract]
    public class FieldOfficerDTO
    {
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FieldOfficerAllDTO
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
    public class FieldOfficerCustomerDTO
    {
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FieldOfficerCustomerAllDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FieldOfficerBranchDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FieldOfficerBranchAllDTO
    {
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public string BranchName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FieldOfficerSiteDTO
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
    public class FieldOfficerSiteAllDTO
    {
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public string SiteName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FieldOfficer
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class AddFieldOfficerDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public List<FileOfficerSit> Site { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FileOfficerSit
    {
        [DataMember]
        public int SiteId { get; set; }
    }

    [Serializable]
    [DataContract]
    public class RemoveFieldOfficer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

}
