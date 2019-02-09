using BusinessEntities;
using BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebApi.Controllers
{
    public class InvoiceController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage GetInvoiceReport(InvoiceGetDTO invoice)
        {
            HttpResponseMessage message;
            try
            {
                InvoiceDataAccessLayer dal = new InvoiceDataAccessLayer();
                var dynObj = new { result = dal.GetInvoiceReport(invoice) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Annexure", "GetAnnexureReport");
            }
            return message;
        }

        [HttpPost]
        public HttpResponseMessage saveInvoice(InvoiceSaveDTO invoice)
        {
            HttpResponseMessage message;
            try
            {
                InvoiceDataAccessLayer dal = new InvoiceDataAccessLayer();
                var dynObj = new { result = dal.InsertInvoice(invoice) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Annexure", "GetAnnexureReport");
            }
            return message;
        }
    }
}
