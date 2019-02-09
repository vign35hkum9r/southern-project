using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class SiteMappingDTO
    {

    }

    [Serializable]
    [DataContract]
    public class getBranchDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getAllBranchByCustomerDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Branch { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getSiteDTO
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
    public class getAllSiteByBranchDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public string SiteName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getClassficationDTO
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
    public class getAllClassficationbySiteDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public string BranchName { get; set; }
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public string SiteName { get; set; }
        [DataMember]
        public int ClassificationId { get; set; }
        [DataMember]
        public string Classification { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getServiceDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getAllServiceByCustomerDTO
    {
        [DataMember]
        public int? DesignationId { get; set; }
        [DataMember]
        public string Service { get; set; }
        [DataMember]
        public int? EmployeeCount { get; set; }
    }

    [Serializable]
    [DataContract]
    public class AddSiteAllocationDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public int ClassificationId { get; set; }
        [DataMember]
        public int Service { get; set; }
        [DataMember]
        public int NoofManpower { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getCustomerDTO
    {
        [DataMember]
        public int ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getAllCustomerDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getSiteAllocationDTO
    {
        [DataMember]
        public int Id { get; set; }
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
        [DataMember]
        public int ClassificationId { get; set; }
        [DataMember]
        public string ClassificationName { get; set; }
        [DataMember]
        public int ServiceId { get; set; }
        [DataMember]
        public string Service { get; set; }
        [DataMember]
        public int NoofManpower { get; set; }
    }

    [Serializable]
    [DataContract]
    public class removeSiteAllocation
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public int ClassificationId { get; set; }
        [DataMember]
        public int ServiceId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class GetManpowerListDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public int ClassificationId { get; set; }
        [DataMember]
        public int ServiceId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class GetAllManpowerList
    {
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public string ManpowerName { get; set; }
    }

}
