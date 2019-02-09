using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IBDMAttachment
    {
        bool InsertBDMAttachment(BDMAttachmentDTO objAttachment);
        bool InsertBDMAttachmentQuote(BDMAttachmentInsertQuotation objAttachment);
        List<BDMAttachementGetQuotation> GetAllQuoteById(BDMAppoinmentGetById objAppointmentDetail);
        List<BDMAttachmentGetDTO> GetAllAttachmentById(BDMAttachmentGetDTO objAppointmentDetail);
    }
}
