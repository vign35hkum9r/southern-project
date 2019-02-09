using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class BDMAppointmentReportDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int Calltype { get; set; }
        [DataMember]
        public String FileUrl { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string StatusName { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class BDMAppointmentReportGetIdDTO
    {
        public int Id { get; set; }
    }

    [Serializable]
    [DataContract]
    public class BDMAppointmentReportGetByIdDTO
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }


    [Serializable]
    [DataContract]
    public class BDMAppointmentReportInsertDTO
    {
        public DateTime Date { get; set; }
        [DataMember]
        public int Calltype { get; set; }       
        [DataMember]
        public string Remarks { get; set; }       
        [DataMember]
        public string CreatedBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class BDMAppointmentReportUpdateDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int Calltype { get; set; }      
        [DataMember]
        public string Remarks { get; set; }      
        [DataMember]
        public string ModifiedBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class BDMAppointmentReportRemoveDTO
    {
        [DataMember]
        public int Id { get; set; }
    }
}
