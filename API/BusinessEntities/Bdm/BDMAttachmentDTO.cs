using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class BDMAttachmentDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int AppointmentId { get; set; }
        [DataMember]
        public string FileUrl { get; set; }
     
    }
    [Serializable]
    [DataContract]
    public class BDMAttachmentInsertDTO
    {
        [DataMember]
        public int AppointmentId { get; set; }
        [DataMember]
        public string FileUrl { get; set; }
       
    }

    [Serializable]
    [DataContract]
    public class BDMAttachmentGetDTO
    {
        [DataMember]
        public int AppoinmentId { get; set; }
        [DataMember]
        public string FileUrl { get; set; }
    }


    [Serializable]
    [DataContract]
    public class BDMAttachmentUpdateDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int AppointmentId { get; set; }
        [DataMember]
        public string FileUrl { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class BDMAttachmentRemoveDTO
    {
        [DataMember]
        public int Id { get; set; }
    }

    [Serializable]
    [DataContract]
    public class BDMAttachmentInsertQuotation
    {      
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string QuoteFileUrl { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class BDMAttachementGetQuotation
    {
        [DataMember]
        public int Id { get; set; }      
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string QuoteFileUrl { get; set; }
        [DataMember]
        public DateTime Date { get; set; }

    }

    [Serializable]
    [DataContract]
    public class BDMAppoinmentGetById
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
}
