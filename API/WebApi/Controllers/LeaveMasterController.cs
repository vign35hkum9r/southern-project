using BusinessEntities;
using BusinessServices;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.ActionFilters;

namespace WebApi.Controllers
{
    // [AuthorizationRequired]
    [RoutePrefix("LeaveMaster")]
    public class LeaveMasterController : ApiController
    {
        private readonly ILeaveMasterService _leave;

        public LeaveMasterController(ILeaveMasterService leave)
        {
            _leave = leave;
        }

        //create new LeaveMaster Detail
        [HttpPost]
        public HttpResponseMessage CreateLeaveMaster(LeaveMasterInsertDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // LeaveMasterDataAccessLayer dal = new LeaveMasterDataAccessLayer();
                var dynObj = new { result = _leave.InsertLeaveMaster(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "Leave", "CreateLeaveMaster");
            }
            return message;
        }

        //Get All Leave Details
        [HttpPost]
        public HttpResponseMessage GetAllLeaveMaster(LeaveMasterGetDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // LeaveMasterDataAccessLayer dal = new LeaveMasterDataAccessLayer();
                var dynObj = new { result = _leave.GetAllLeaveMaster(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Leave", "GetAllLeaveMaster");
            }
            return message;
        }

        //Get Leavae Detail by Id
        [HttpPost]
        public HttpResponseMessage GetLeaveMasterById(LeaveMasterGetDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // LeaveMasterDataAccessLayer dal = new LeaveMasterDataAccessLayer();
                var dynObj = new { result = _leave.GetLeaveMasterById(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Leave", "GetLeaveMasterById");
            }
            return message;
        }

        //Update Leave datail
        [HttpPost]
        public HttpResponseMessage UpdateLeaveMaster(LeaveMasterUpdateDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // LeaveMasterDataAccessLayer dal = new LeaveMasterDataAccessLayer();
                var dynObj = new { result = _leave.UpdateLeaveMaster(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Leave", "UpdateLeaveMaster");
            }
            return message;
        }

        //Remove Leave Detail by Id
        [HttpPost]
        public HttpResponseMessage RemoveLeaveMaster(LeaveMasterRemoveDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // LeaveMasterDataAccessLayer dal = new LeaveMasterDataAccessLayer();
                var dynObj = new { result = _leave.DeactivateLeaveMaster(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Leave", "DeactivateLeaveMaster");
            }
            return message;
        }
    }
}
