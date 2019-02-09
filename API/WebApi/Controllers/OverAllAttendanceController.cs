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
    [RoutePrefix("OverAllAttendance")]
    public class OverAllAttendanceController : ApiController
    {

        private readonly IOverallAttentance _Attentance;

        public OverAllAttendanceController(IOverallAttentance Attentance)
        {
            _Attentance = Attentance;
        }
        //get All Manpower
        //[HttpPost]
        //public HttpResponseMessage getManpowerBySite(GetManpower manpower)
        //{
        //    HttpResponseMessage message;
        //    try
        //    {
        //      //  OverAllAttendanceDataAccessLayer dal = new OverAllAttendanceDataAccessLayer();
        //        var dynObj = new { result = _Attentance.GetManpowerBySite(manpower) };
        //        message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
        //    }
        //    catch (Exception ex)
        //    {
        //        message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

        //        ErrorLog.CreateErrorMessage(ex, "OverAllAttendance", "getManpowerBySite");
        //    }
        //    return message;
        //}
        //get All Customer
        [HttpPost]
        public HttpResponseMessage getAllManpowerCustomer(GetAllCustomer customer)
        {
            HttpResponseMessage message;
            try
            {
              //  OverAllAttendanceDataAccessLayer dal = new OverAllAttendanceDataAccessLayer();
                var dynObj = new { result = _Attentance.GetAllManpowerCustomer(customer) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "OverAllAttendance", "getAllManpowerCustomer");
            }
            return message;
        }

        //get All Branch
        [HttpPost]
        public HttpResponseMessage getAllBranchManpower(GetAllBranch branch)
        {
            HttpResponseMessage message;
            try
            {
              //  OverAllAttendanceDataAccessLayer dal = new OverAllAttendanceDataAccessLayer();
                var dynObj = new { result = _Attentance.GetAllBranchManpower(branch) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "OverAllAttendance", "getAllBranchManpower");
            }
            return message;
        }

        //get All Aite
        [HttpPost]
        public HttpResponseMessage getAllSiteManpower(GetManpower site)
        {
            HttpResponseMessage message;
            try
            {
              //  OverAllAttendanceDataAccessLayer dal = new OverAllAttendanceDataAccessLayer();
                var dynObj = new { result = _Attentance.GetAllSiteManpower(site) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "OverAllAttendance", "getAllSiteManpower");
            }
            return message;
        }
    }
}