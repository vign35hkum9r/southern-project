using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{ 
    [DataContract]
    [Serializable]
   public class OverAllAttendanceDTO
    {
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public string ManpowerName { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime ToDate { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
    [DataContract]
    [Serializable]
    public class GetManpower
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

    [DataContract]
    [Serializable]
    public class GetAllCustomer
    {
        [DataMember]
        public string ActionBy { get; set; } 
    }

    [DataContract]
    [Serializable]
    public class GetAllBranch
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [DataContract]
    [Serializable]
    public class GetAllSite
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
    [DataContract]
    [Serializable]
    public class GetManpowerList
    {
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public string ManpowerName { get; set; }
    }

    [DataContract]
    [Serializable]
    public class GetCustomerList
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
    }

    [DataContract]
    [Serializable]
    public class GetAllManpowerCustomerList
    {
        [DataMember]
        public List<GetManpowerList> ManpowerList { get; set; }
        [DataMember]
        public List<GetCustomerList> CustomerList { get; set; }
    }

    [DataContract]
    [Serializable]
    public class GetBranchList
    {
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public string BranchName { get; set; }
    }

    [DataContract]
    [Serializable]
    public class GetSiteList
    {
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public string SiteName { get; set; }
    }
    [DataContract]
    [Serializable]
    public class GetAllBranchManpowerList
    {
        [DataMember]
        public List<GetManpowerList> ManpowerList { get; set; }
        [DataMember]
        public List<GetBranchList> BranchList { get; set; }
    }
    public class GetAllSiteManpowerList
    {
        [DataMember]
        public List<GetManpowerList> ManpowerList { get; set; }
        [DataMember]
        public List<GetSiteList> SiteList { get; set; }
        [DataMember]
        public List<GetManpowerList> ManpowerSiteList { get; set; }
    }
}
