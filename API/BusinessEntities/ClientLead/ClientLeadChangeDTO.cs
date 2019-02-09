using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class ClientLeadChangeDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string ClientName { get; set; }
        [DataMember]
        public string Calltype { get; set; }
    }
    [Serializable]
    [DataContract]
    public class OldEmployeeDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public string DesignationName { get; set; }
        [DataMember]
        public int StateId { get; set; }
        [DataMember]
        public string StateName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class NewEmployeeDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public string DesignationName { get; set; }
        [DataMember]
        public string StateName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class GetClientbyEmployeeDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }
    }
    [Serializable]
    [DataContract]
    public class ChangeLeadbyClientDTO
    {
        [DataMember]
        public List<int> ClientId { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class GetOldEmployeeDTO
    {
       
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class GetNewEmployeeDTO
    {
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public int OldLead { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
}
