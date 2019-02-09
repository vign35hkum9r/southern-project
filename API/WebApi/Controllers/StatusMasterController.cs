using BusinessEntities;
using BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.ActionFilters;

namespace WebApi.Controllers
{
    // [AuthorizationRequired]
    [RoutePrefix("StatusMaster")]
    public class StatusMasterController : ApiController
    {
        private readonly IStatusMaster _status;

        public StatusMasterController(IStatusMaster status)
        {
            this._status = status;
        }
        //create new Status 
        [HttpPost]
        public HttpResponseMessage CreateStatus(StatusMasterInsertDTO objStatus)
        {
            HttpResponseMessage message;
            try
            {
               // StatusMasterDataAccessLayer dal = new StatusMasterDataAccessLayer();
                var dynObj = new { result = _status.InsertStatus(objStatus) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "StatusMaster", "CreateStatus");
            }
            return message;
        }
        //Get All Status
        [HttpPost]
        public HttpResponseMessage GetAllStatus(StatusMasterGetDTO objGetStatus)
        {
            HttpResponseMessage message;
            try
            {
               // StatusMasterDataAccessLayer dal = new StatusMasterDataAccessLayer();
                var dynObj = new { result = _status.GetAllStatus(objGetStatus) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "StatusMaster", "GetAllStatus");
            }
            return message;
        }
        //Get Status by Id
        [HttpPost]
        public HttpResponseMessage GetStatusById(StatusMasterGetDTO objGetStatusById)
        {
            HttpResponseMessage message;
            try
            {
               // StatusMasterDataAccessLayer dal = new StatusMasterDataAccessLayer();
                var dynObj = new { result = _status.GetStatusById(objGetStatusById) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "StatusMaster", "GetStatusById");
            }
            return message;
        }

        //Get Active Status 
        [HttpPost]
        public HttpResponseMessage GetActiveStatus(StatusMasterGetDTO objActive)
        {
            HttpResponseMessage message;
            try
            {
               // StatusMasterDataAccessLayer dal = new StatusMasterDataAccessLayer();
                var dynObj = new { result = _status.GetActiveStatus(objActive) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "StatusMaster", "GetActiveStatus");
            }
            return message;
        }

        //Get zIn Active Status 
        [HttpPost]
        public HttpResponseMessage GetInActiveStatus(StatusMasterGetDTO objInActive)
        {
            HttpResponseMessage message;
            try
            {
               // StatusMasterDataAccessLayer dal = new StatusMasterDataAccessLayer();
                var dynObj = new { result = _status.GetInActiveStatus(objInActive) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "StatusMaster", "GetInActiveStatus");
            }
            return message;
        }

        //Update Status
        [HttpPost]
        public HttpResponseMessage UpdateStatus(StatusMasterUpdateDTO objStatus)
        {
            HttpResponseMessage message;
            try
            {
               // StatusMasterDataAccessLayer dal = new StatusMasterDataAccessLayer();
                var dynObj = new { result = _status.UpdateStatus(objStatus) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "StatusMaster", "UpdateStatus");
            }
            return message;
        }
        //Remove Status By Id
        [HttpPost]
        public HttpResponseMessage RemoveStatus(StatusMasterRemoveDTO objStatus)
        {
            HttpResponseMessage message;
            try
            {
               // StatusMasterDataAccessLayer dal = new StatusMasterDataAccessLayer();
                var dynObj = new { result = _status.RemoveStatus(objStatus) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "StatusMaster", "RemoveStatus");
            }
            return message;
        }

    }
}
