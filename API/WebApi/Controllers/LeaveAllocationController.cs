
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
    public class LeaveAllocationController : ApiController
    {
        private readonly ILeaveAllocation _leave;

        public LeaveAllocationController(ILeaveAllocation leave)
        {
            _leave = leave;
        }

        //create new LeaveAllocation Detail
        [HttpPost]
        public HttpResponseMessage CreateLeaveAllocation(List<LeaveAllocationInsertDTO> objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // LeaveAllocationDataAccessLayer dal = new LeaveAllocationDataAccessLayer();
                var dynObj = new { result = _leave.InsertLeaveAllocation(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "Leave", "LeaveAllocation");
            }
            return message;
        }

        //Get All LeaveAllocation Details
        [HttpPost]
        public HttpResponseMessage GetAllLeaveAllocation(LeaveAllocationGetDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // LeaveAllocationDataAccessLayer dal = new LeaveAllocationDataAccessLayer();
                var dynObj = new { result = _leave.GetAllLeaveAllocation(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Leave", "LeaveAllocationv");
            }
            return message;
        }

        //Get LeaveAllocation Detail by Id
        [HttpPost]
        public HttpResponseMessage GetLeaveAllocationById(LeaveAllocationGetDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // LeaveAllocationDataAccessLayer dal = new LeaveAllocationDataAccessLayer();
                var dynObj = new { result = _leave.GetLeaveAllocationById(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Leave", "LeaveAllocationById");
            }
            return message;
        }

        // Get All Employee type
        //Get LeaveAllocation Detail by Id
        [HttpPost]
        public HttpResponseMessage GetAllEmployeeType(getEmployeeTypeDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // LeaveAllocationDataAccessLayer dal = new LeaveAllocationDataAccessLayer();
                var dynObj = new { result = _leave.GetAllEmployeetype(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Leave", "GetAllEmployeeType");
            }
            return message;
        }

        //Update LeaveAllocation datail
        [HttpPost]
        public HttpResponseMessage UpdateLeaveAllocation(LeaveAllocationUpdateDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // LeaveAllocationDataAccessLayer dal = new LeaveAllocationDataAccessLayer();
                var dynObj = new { result = _leave.UpdateLeaveAllocation(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Leave", "UpdateLeaveAllocation");
            }
            return message;
        }

        //Remove LeaveAllocation Detail by Id
        [HttpPost]
        public HttpResponseMessage RemoveLeaveAllocation(LeaveAllocationRemoveDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // LeaveAllocationDataAccessLayer dal = new LeaveAllocationDataAccessLayer();
                var dynObj = new { result = _leave.DeactivateLeaveAllocation(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Leave", "DeactivateLeaveAllocation");
            }
            return message;
        }
    }
}
