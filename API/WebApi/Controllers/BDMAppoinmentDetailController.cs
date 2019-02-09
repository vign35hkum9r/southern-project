using BusinessEntities;
using BusinessServices;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using WebApi.ActionFilters;

namespace WebApi.Controllers
{
    // [AuthorizationRequired]
    [RoutePrefix("BDMAppoinmentDetail")]
    public class BDMAppoinmentDetailController : ApiController
    {
        private readonly IBDMAppointment _obj;
        private readonly IBDMAttachment _attach;

        public BDMAppoinmentDetailController(IBDMAppointment obj, IBDMAttachment attach)
        {
            _obj = obj;
            _attach = attach;
        }
        // Create New BDM Appointment Detail
        [HttpPost]
        public HttpResponseMessage CreateBDMAppointmentDetail(BDMAppointmentDetailInsertDTO objAppointmentDetail)
        {
            HttpResponseMessage message;
            try
            {
                // // BDMAppointmentDetailDAL dal = new BDMAppointmentDetailDAL();
                var dynObj = new { result = _obj.InsertBDMAppointmentDetail(objAppointmentDetail) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "BDMAppoinmentDetail", "CreateBDMAppointmentDetail");
            }
            return message;
        }

        // Get All BDM Appointment Detail 
        [HttpPost]
        public HttpResponseMessage GetAllBDMAppointmentDetails(BDMAppoinmentDetailGetDetailDTO objAppointmentDetail)
        {
            HttpResponseMessage message;
            try
            {
                // BDMAppointmentDetailDAL dal = new BDMAppointmentDetailDAL();
                var dynObj = new { result = _obj.GetAllAppointmentDetails(objAppointmentDetail) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "BDMAppoinmentDetail", "GetAllBDMAppointmentDetails");
            }
            return message;
        }

        // Create Quotation for Client
        [HttpPost]
        public HttpResponseMessage CreateBDMAppointmentQuotation()
        {
            HttpResponseMessage message;
            var BDMAttachmentQuotes = HttpContext.Current.Request.Files;
            var clientId = HttpContext.Current.Request.Form[0];
            var CreatedBy = HttpContext.Current.Request.Form[1];
            bool res = false;
            try
            {
                for (int i = 0; i < BDMAttachmentQuotes.Count; i++)
                {
                    List<string> file_urlList = new List<string>();
                    string fileName = BDMAttachmentQuotes[i].FileName;
                    string path = Path.Combine(HostingEnvironment.MapPath("~/QuotationFile"), fileName);
                    file_urlList.Add(path);
                    (BDMAttachmentQuotes[i] as HttpPostedFile).SaveAs(path);
                    // BDMAttachmentService dalAttachment = new BDMAttachmentService();
                    _attach.InsertBDMAttachmentQuote(new BDMAttachmentInsertQuotation
                    {
                        ClientId = Convert.ToInt32(clientId),
                        CreatedBy = CreatedBy,
                        QuoteFileUrl = fileName,
                    });
                }
                res = true;
            }

            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "BDMAppoinmentDetail", "CreateBDMAppointmentQuotation");
            }
            return message = Request.CreateResponse(HttpStatusCode.OK, new { msgText = "Success!", result = res });
        }

        // Get BDM Appointment Quotation By Id
        [HttpPost]
        public HttpResponseMessage GetBDMAppointmentQuotationById(BDMAppoinmentGetById objQuote)
        {
            HttpResponseMessage message;
            try
            {
                // BDMAttachmentService dalAttachment = new BDMAttachmentService();
                var dynObj = new { result = _attach.GetAllQuoteById(objQuote) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "BDMAppoinmentDetail", "GetBDMAppointmentQuotationById");
            }
            return message;
        }



        // Get BDM Appointment Detail By Id
        [HttpPost]
        public HttpResponseMessage GetBDMAppointmentDetailById(GetBDMAppointmentDetailDTO objAppointmentDetail)
        {
            HttpResponseMessage message;
            try
            {
                // BDMAppointmentDetailDAL dal = new BDMAppointmentDetailDAL();
                var dynObj = new { result = _obj.GetAppointmentDetailById(objAppointmentDetail) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "BDMAppoinmentDetail", "GetBDMAppointmentDetailById");
            }
            return message;
        }

        // Get BDM Appointment Detail By Client Id
        [HttpPost]
        public HttpResponseMessage GetBDMAppointmentDetailByClientId(BDMAppointmentGetIdDTO objSurveyAppointmentDetail)
        {
            HttpResponseMessage message;
            try
            {
                // BDMAppointmentDetailDAL dal = new BDMAppointmentDetailDAL();
                var dynObj = new { result = _obj.GetAppointmentDetailByClientId(objSurveyAppointmentDetail) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "BDMAppoinmentDetail", "GetBDMAppointmentDetailById");
            }
            return message;
        }

        // Get BDM Appointment Detail Co ordinator
        [HttpPost]
        public HttpResponseMessage GetBDMAppointmentDetailByStatus(GetStatus objSurveyAppointmentDetail)
        {
            HttpResponseMessage message;
            try
            {
                // BDMAppointmentDetailDAL dal = new BDMAppointmentDetailDAL();
                var dynObj = new { result = _obj.GetAllStatusCoordinator(objSurveyAppointmentDetail) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "BDMAppoinmentDetail", "GetBDMAppointmentDetailById");
            }
            return message;
        }



        // Update BDM Appointment Detail
        [HttpPost]
        public HttpResponseMessage UpdateBDMAppointmentDetail(BDMAppointmentDetailUpdateDTO objAppointmentDetail)
        {
            HttpResponseMessage message;
            try
            {
                // BDMAppointmentDetailDAL dal = new BDMAppointmentDetailDAL();
                var dynObj = new { result = _obj.UpdateBDMAppointmentDetail(objAppointmentDetail) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "BDMAppoinmentDetail", "UpdateBDMAppointmentDetail");
            }
            return message;
        }

        //Remove BDM Appointment Detail By Id
        [HttpPost]
        public HttpResponseMessage RemoveBDMAppointmentDetail(BDMAppoinmentDetailRemoveDTO objAppointmentDetail)
        {
            HttpResponseMessage message;
            try
            {
                // BDMAppointmentDetailDAL dal = new BDMAppointmentDetailDAL();
                var dynObj = new { result = _obj.RemoveBDMAppointmentDetail(objAppointmentDetail) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "BDMAppoinmentDetail", "RemoveBDMAppointmentDetail");
            }
            return message;
        }

        //Export Detail to Excel using Id,Date,Name
        [HttpPost]
        public HttpResponseMessage GetAppoinmentDetailtoExport(BDMAppoinmentDetailExport objAppointmentDetail)
        {
            HttpResponseMessage message;
            try
            {
                // BDMAppointmentDetailDAL dal = new BDMAppointmentDetailDAL();
                var dynObj = new { result = _obj.GetAppoinmentDetailtoExport(objAppointmentDetail) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "BDMAppoinmentDetail", "GetAppoinmentDetailtoExport");
            }
            return message;
        }

        //Export Report to Excel using Client Id
        [HttpPost]
        public HttpResponseMessage GetAppoinmentReporttoExport(BDMReportExport objAppointmentDetail)
        {
            HttpResponseMessage message;
            try
            {
                // BDMAppointmentDetailDAL dal = new BDMAppointmentDetailDAL();
                var dynObj = new { result = _obj.GetAppoinmentReporttoExport(objAppointmentDetail) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "BDMAppoinmentDetail", "GetAppoinmentReporttoExport");
            }
            return message;
        }

        //Server Side Filter Detail to using Id,Name
        [HttpPost]
        public HttpResponseMessage GetAppoinmentDetailfromServerFilter(BDMAppointmentFilter objAppointmentDetail)
        {
            HttpResponseMessage message;
            try
            {
                // BDMAppointmentDetailDAL dal = new BDMAppointmentDetailDAL();
                var dynObj = new { result = _obj.GetAppoinmentDetailfromServerFilter(objAppointmentDetail) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "BDMAppoinmentDetail", "GetAppoinmentDetailfromServerFilter");
            }
            return message;
        }

        //Get Distinct EmployeeId
        [HttpPost]
        public HttpResponseMessage GetDistinctEmployeeId(BDMGetDistinctEmployeeId objId)
        {
            HttpResponseMessage message;
            try
            {
                // BDMAppointmentDetailDAL dal = new BDMAppointmentDetailDAL();
                var dynObj = new { result = _obj.GetDistinctEmployeeId(objId) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "BDMAppoinmentDetail", "GetDistinctEmployeeId");
            }
            return message;
        }


        //Get Distinct EmployeeId
        [HttpPost]
        public HttpResponseMessage GetDistinctEmployeeName(BDMDistinctEmployeeName objbdmName)
        {
            HttpResponseMessage message;
            try
            {
                // BDMAppointmentDetailDAL dal = new BDMAppointmentDetailDAL();
                var dynObj = new { result = _obj.GetDistinctEmployeeName(objbdmName) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "BDMAppoinmentDetail", "GetDistinctEmployeeName");
            }
            return message;
        }
    }
}
