using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public interface IInvoiceService
    {
        bool InsertInvoice(InvoiceSaveDTO obj);
        InvoiceDTO GetInvoiceReport(InvoiceGetDTO objInvoiceGetDTO);

    }
}
