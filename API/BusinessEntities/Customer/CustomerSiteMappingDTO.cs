using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class CustomerSiteMappingDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
    }

    [Serializable]
    [DataContract]
    public class GetCustomersBranchDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class GetBranchByCustomerDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Branch { get; set; }
        [DataMember]
        public int CityId { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public String StateName { get; set; }
        [DataMember]
        public String ContactPerson { get; set; }
        [DataMember]
        public String ContactNumber { get; set; }
        [DataMember]
        public String Email { get; set; }
    }


    [Serializable]
    [DataContract]
    public class AddBranchDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]     
        public string Branch { get; set; }
        [DataMember]
        public string ContactPerson { get; set; }
        [DataMember]
        public string ContactNumber { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class AddSiteDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public string Site { get; set; }
        [DataMember]
        public string ContactPerson { get; set; }
        [DataMember]
        public string ContactNumber { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class AddClassificationDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public string Classfication { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getCustomerSiteDTO
    {
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getCustomerSitebyBranchDTO
    {
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public string BranchName { get; set; }
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public String SiteName { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public String ContactPerson { get; set; }
        [DataMember]
        public String ContactNumber { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String Address { get; set; }
    }

    [Serializable]
    [DataContract]
    public class removeBranchDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class removeSiteDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class removeClassificationDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }


}
