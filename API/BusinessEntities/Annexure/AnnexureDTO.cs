using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class AnnexureDTO
    {
        [DataMember]
        public AnnexureCustomerDTO CustomerDetail { get; set; }
        [DataMember]
        public List<AnnexureListDTO> AnnexureList { get; set; }
    }

    [Serializable]
    [DataContract]
    public class AnnexureCustomerDTO
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public decimal IGST { get; set; }
        [DataMember]
        public decimal CGST { get; set; }
        [DataMember]
        public decimal SGST { get; set; }
        [DataMember]
        public decimal AmountWoGST { get; set; }
        [DataMember]
        public decimal IGSTAmount { get; set; }
        [DataMember]
        public decimal CGSTAmount { get; set; }
        [DataMember]
        public decimal SGSTAmount { get; set; }
        [DataMember]
        public decimal GrandTotal { get; set; }

    }

    [Serializable]
    [DataContract]
    public class AnnexureListDTO
    {
        [DataMember]
        public string DesignationName { get; set; }
        [DataMember]
        public int NoOfManpower { get; set; }
        [DataMember]
        public int DaysPerPerson { get; set; }
        [DataMember]
        public decimal RatePerEmployee { get; set; }
        [DataMember]
        public int TotalDays { get; set; }
        [DataMember]
        public int ManWorkedDays { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
    }

    public class AnnexureGetDTO
    {
        public int CustomerId { get; set; }
        public string Date { get; set; }
    }
}
