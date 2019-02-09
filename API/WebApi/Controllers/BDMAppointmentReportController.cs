using BusinessEntities;
using BusinessServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    [RoutePrefix("BDMAppointmentReport")]
    public class BDMAppointmentReportController : ApiController
    {
        private readonly IBDMAppoinmentReport _obj;
        private readonly IBDMAttachment _attach;


        public BDMAppointmentReportController(IBDMAppoinmentReport obj, IBDMAttachment attach)
        {
            _obj = obj;
            _attach = attach;
           
        }
        //Create New BDm Appointment Reports--
        [HttpPost]
        public HttpResponseMessage CreateBDMAppointmentReport() 
        {
            HttpResponseMessage message;     
                var BDMAttachments = HttpContext.Current.Request.Files;
                var ClientId = HttpContext.Current.Request.Form[0];
                var Date = HttpContext.Current.Request.Form[1];
                var Calltype = HttpContext.Current.Request.Form[2];             
                var Remarks = HttpContext.Current.Request.Form[3];             
                var CreatedBy = HttpContext.Current.Request.Form[4];
                BDMAppointmentReportDTO objAppointmentReport = new BDMAppointmentReportDTO();
                objAppointmentReport.ClientId = Convert.ToInt32(ClientId);
                objAppointmentReport.Date = Convert.ToDateTime(Date);
                objAppointmentReport.Calltype = Convert.ToInt32(Calltype);             
                objAppointmentReport.Remarks = Remarks;              
                objAppointmentReport.CreatedBy = CreatedBy;
                // BDMAppointmentReportDataAccessLayer dal=new BDMAppointmentReportDataAccessLayer();
                 BDMAttachmentDTO objAttachment = new BDMAttachmentDTO();
                 bool res = false;
                 try
                 {
                     int id =_obj.InsertBDMAppointmentReport(objAppointmentReport);
                     if ( id != -1)
                     {
                         SqlCommand cmd = new SqlCommand("Select Id from BDMAppoinmentReport where Id =" +id + "");
                         List<string> file_urlList = new List<string>();
                         for (int i = 0; i < BDMAttachments.Count; i++)
                         {
                             string fileName = id+"_"+BDMAttachments[i].FileName;
                             string path = Path.Combine(HostingEnvironment.MapPath("~/ServeyImages"), fileName);
                             file_urlList.Add(path);
                             (BDMAttachments[i] as HttpPostedFile).SaveAs(path);
                        //  BDMAttachmentDataAccessLayer dalAttachment = new BDMAttachmentDataAccessLayer();
                        _attach.InsertBDMAttachment(new BDMAttachmentDTO
                             {
                                 AppointmentId = id,                                
                                 FileUrl=fileName,
                             });                             
                         }
                         res = true;
                     }
                 }

                 catch (Exception ex)
                 {
                     message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });
                     ErrorLog.CreateErrorMessage(ex, "BDMAppointmentReport", "CreateBDMAppointmentReport");
                 }
                 return message = Request.CreateResponse(HttpStatusCode.OK, new { msgText = "Success!", result = res });
        }

        //Get All Report By Client Id
        [HttpPost]
        public HttpResponseMessage GetAllReportByClientId(BDMAppointmentReportGetByIdDTO report)
        {
            HttpResponseMessage message;
            try
            {
              //  BDMAppointmentReportDataAccessLayer dal = new BDMAppointmentReportDataAccessLayer();
                var dynObj = new { result = _obj.GetAllAppointmentReports(report) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "BDMAppointmentReport", "GetAllReportByClientId");
            }
            return message;
        }

        //Get Attachment By Client Id
        [HttpPost]
        public HttpResponseMessage GetAllAttachmentByClientId(BDMAttachmentGetDTO attachment)
        {
            HttpResponseMessage message;
            try
            {
               // BDMAttachmentDataAccessLayer dal = new BDMAttachmentDataAccessLayer();
                var dynObj = new { result = _attach.GetAllAttachmentById(attachment) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "BDMAppointmentReport", "GetAllAttachmentByClientId");
            }
            return message;
        }
    }
}
