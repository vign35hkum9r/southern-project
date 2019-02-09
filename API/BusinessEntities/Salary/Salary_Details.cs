using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class InsertSalary_Details
    {
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public string sal_Year { get; set; }
        [DataMember]
        public string sal_Month { get; set; }
        [DataMember]
        public string SalaryDetails { get; set; }
        [DataMember]
        public int ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class UpdateSalary_Details
    {
        [DataMember]
        public int SalaryId { get; set; }
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public string sal_Year { get; set; }
        [DataMember]
        public string sal_Month { get; set; }
        [DataMember]
        public string SalaryDetails { get; set; }
        [DataMember]
        public int ActionBy { get; set; }
    }


    [Serializable]
    [DataContract]
    public class GetSalary_Details
    {
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public string sal_Year { get; set; }
        [DataMember]
        public string sal_Month { get; set; }
        [DataMember]
        public string SalaryDetails { get; set; }
        [DataMember]
        public string IsActive { get; set; }
    }
}
