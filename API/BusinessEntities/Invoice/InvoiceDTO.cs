using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
   
    [Serializable]
    [DataContract]
    public class CustomerInvoiceDTO
{
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string CustomerAddress { get; set; }
        [DataMember]
        public string CustomerGSTNumber { get; set; }
        [DataMember]
        public string CustomerPANNumber { get; set; }
        [DataMember]
        public string CustomerState { get; set; }
        [DataMember]
        public string StateCode { get; set; }     
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string CompanyAddress { get; set; }
        [DataMember]
        public string CompanyPANNumber { get; set; }
        [DataMember]
        public string BillingPeriod { get; set; }
        [DataMember]
        public string GSTNumber { get; set; }
        [DataMember]
        public string CompanyBankName { get; set; }
        [DataMember]
        public string BranchName { get; set; }
        [DataMember]
        public string AccountNo { get; set; }
        [DataMember]
        public string InvoiceNo { get; set; }
        [DataMember]
        public string IFSCCode { get; set; }       
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
    public class InvoiceDTO
    {
        [DataMember]
        public CustomerInvoiceDTO CustomerInvoice { get; set; }
        [DataMember]
        public List<InvoiceListDTO> InvoiceList { get; set; }
    }

    [Serializable]
    [DataContract]
    public class InvoiceListDTO
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
        public string SACCode { get; set; }
        [DataMember]
        public int ManWorkedDays { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public decimal IGSTTax { get; set; }
        [DataMember]
        public decimal CGSTTax { get; set; }
        [DataMember]
        public decimal SGSTTax { get; set; }
        [DataMember]
        public decimal IGSTTaxAmount { get; set; }
        [DataMember]
        public decimal CGSTTaxAmount { get; set; }
        [DataMember]
        public decimal SGSTTaxAmount { get; set; }
    }

    public class InvoiceGetDTO
    {
        public int CustomerId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }

    public class InvoiceSaveDTO
    {
        public int CustomerId { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public int ActionBy { get; set; }
    }
}
