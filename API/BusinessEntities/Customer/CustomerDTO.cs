using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class CustomerDTO
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string ConcernPerson { get; set; }
        [DataMember]
        public string ContactPerson { get; set; }
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public int City { get; set; }
        [DataMember]
        public int CompanyId { get; set; }
        [DataMember]
        public double IGST { get; set; }
        [DataMember]
        public double CGST { get; set; }
        [DataMember]
        public double SGST { get; set; }
        [DataMember]
        public string GSTNo { get; set; }
        [DataMember]
        public string PANNumber { get; set; }
        [DataMember]
        public string CINNumber { get; set; }
        [DataMember]
        public string StateName { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
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
    public class CustomerGetDTO
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
    public class CustomerInsertDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ClientId { get; set; }
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public int City { get; set; }
        [DataMember]
        public int CompanyId { get; set; }
        [DataMember]
        public double IGST { get; set; }
        [DataMember]
        public double CGST { get; set; }
        [DataMember]
        public double SGST { get; set; }
        [DataMember]       
        public string GSTNo { get; set; }
        [DataMember]
        public string PANNumber { get; set; }
        [DataMember]
        public string CINNumber { get; set; }
        [DataMember]
        public string ConcernPerson { get; set; }
        [DataMember]
        public string ContactPerson { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class CustomerUpdateDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public int City { get; set; }
        [DataMember]
        public int CompanyId { get; set; }
        [DataMember]
        public double IGST { get; set; }
        [DataMember]
        public double CGST { get; set; }
        [DataMember]
        public double SGST { get; set; }
        [DataMember]
        public string GSTNo { get; set; }
        [DataMember]
        public string PANNumber { get; set; }
        [DataMember]
        public string CINNumber { get; set; }
        [DataMember]
        public string ConcernPerson { get; set; }
        [DataMember]
        public string ContactPerson { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public byte Active { get; set; }
    }
    [Serializable]
    [DataContract]
    public class CustomerRemoveDTO
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
    public class GetSuccessCustomerDTO
    {
        [DataMember]
        public string ActionBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class GetAllSuccessCustomerDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String ClientName { get; set; }
        [DataMember]
        public int ClientId { get; set; }
    }

    [Serializable]
    [DataContract]
    public class CustomertoMove
    {
        [DataMember]
        public int? ClientId { get; set; }
        [DataMember]
        public int? CustomerId { get; set; }
        [DataMember]
        public DateTime DateOfCommencement { get; set; }
        [DataMember]
        public string AgreementSigned { get; set; }
        [DataMember]
        public string TypeofContract { get; set;}       
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime ToDate { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public int ClientType { get; set; }
        [DataMember]
        public List<ClientInfoDTO> ClientDetail { get; set; }
        [DataMember]
        public List<ShiftMappingInsertDTO> ShiftMapping { get; set; }
    }

    [Serializable]
    [DataContract]
    public class CustomerDetailDTO
    {
        [DataMember]
        public int Customer { get; set; }
        [DataMember]
        public int ContractId { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ClientInfoDTO
    {
        [DataMember]
        public string Department { get; set; }
        [DataMember]
        public string ContactPersonName { get; set; }
        [DataMember]
        public string ContactNumber { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address { get; set; }
    }
}
