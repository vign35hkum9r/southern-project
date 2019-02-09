using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class AssignManpowerDTO
    {
        [DataMember]
        public int AllocationId { get; set; }
        [DataMember]
        public int ContractId { get; set; }
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
        public int NoofManpower { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string BranchName { get; set; }
        [DataMember]
        public string SiteName { get; set; }
        [DataMember]
        public string ClassificationName { get; set; }
        [DataMember]
        public string ServiceName { get; set; }
        [DataMember]
        public int ManPowerId { get; set; }
        [DataMember]
        public string ManPowerName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerCustomerDTO
    {
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerCustomerAllDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerBranchDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerBranchAllDTO
    {
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public string BranchName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerSiteDTO
    {
        //[DataMember]
        //public int ContractId { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerSiteAllDTO
    {
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public string SiteName { get; set; }
    }
    [Serializable]
    [DataContract]
    public class ManpowerClassificationDTO
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
    public class ManpowerClassificationAllDTO
    {
        [DataMember]
        public int ClassificationId { get; set; }
        [DataMember]
        public string ClassificationName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerServiceDTO
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
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerServiceAllDTO
    {
        [DataMember]
        public int ServiceId { get; set; }
        [DataMember]
        public string Service { get; set; }
        [DataMember]
        public int NoofManpower { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerAssignDTO
    {
        [DataMember]
        public int ServiceId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManPowerListDTO
    {
        [DataMember]
        public int ManPowerId { get; set; }
        [DataMember]
        public string ManPowerName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class AddManpowerDTO
    {

        [DataMember]
        public int ContractId { get; set; }
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
        public string CreatedBy { get; set; }
        [DataMember]
        public List<ManpowerAdd> ManPower { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ManpowerAdd
    {
        [DataMember]
        public int ManPowerId { get; set; }
    }

    [Serializable]
    [DataContract]
    public class RemoveManPowerDTO
    {
        [DataMember]
        public int AllocationId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class GetContractByAllCustomer
    {
        [DataMember]
        public int ActionBy { get; set; }
    }

}
