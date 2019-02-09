
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
    [RoutePrefix("LeaveFrequencyMaster")]
    public class LeaveFrequencyMasterController : ApiController
    {
        private readonly ILeaveFrequencyService _frequency;

        public LeaveFrequencyMasterController(ILeaveFrequencyService frequency)
        {
            _frequency = frequency;
        }

        //create new LeaveFrequencyMaster Detail
        [HttpPost]
        public HttpResponseMessage CreateLeaveFrequencyMaster(LeaveFrequencyMasterInsertDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // LeaveFrequencyMasterDataAccessLayer dal = new LeaveFrequencyMasterDataAccessLayer();
                var dynObj = new { result = _frequency.InsertLeaveFrequencyMaster(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "Leave", "CreateLeaveFrequencyMaster");
            }
            return message;
        }

        //Get All Leave Frequency Details
        [HttpPost]
        public HttpResponseMessage GetAllLeaveFrequencyMaster(LeaveFrequencyMasterGetDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // LeaveFrequencyMasterDataAccessLayer dal = new LeaveFrequencyMasterDataAccessLayer();
                var dynObj = new { result = _frequency.GetAllLeaveFrequencyMaster(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Leave", "GetAllLeaveFrequencyMaster");
            }
            return message;
        }

        //Get Leavae Detail by Id
        [HttpPost]
        public HttpResponseMessage GetLeaveFrequencyMasterById(LeaveFrequencyMasterGetDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // LeaveFrequencyMasterDataAccessLayer dal = new LeaveFrequencyMasterDataAccessLayer();
                var dynObj = new { result = _frequency.GetLeaveFrequencyMasterById(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Leave", "GetLeaveFrequencyMasterById");
            }
            return message;
        }

        //Update Leave Frequency detail
        [HttpPost]
        public HttpResponseMessage UpdateLeaveFrequencyMaster(LeaveFrequencyMasterUpdateDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // LeaveFrequencyMasterDataAccessLayer dal = new LeaveFrequencyMasterDataAccessLayer();
                var dynObj = new { result = _frequency.UpdateLeaveFrequencyMaster(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Leave", "UpdateLeaveFrequencyMaster");
            }
            return message;
        }

        //Remove Leave Frequency Detail by Id
        [HttpPost]
        public HttpResponseMessage RemoveLeaveFrequencyMaster(LeaveFrequencyMasterRemoveDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // LeaveFrequencyMasterDataAccessLayer dal = new LeaveFrequencyMasterDataAccessLayer();
                var dynObj = new { result = _frequency.DeactivateLeaveFrequencyMaster(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Leave", "DeactivateLeaveFrequencyMaster");
            }
            return message;
        }
    }
}
