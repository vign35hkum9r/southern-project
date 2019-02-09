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
    [RoutePrefix("Target")]
    public class TargetController : ApiController
    {
        private readonly ITargetService _target;

        public TargetController(ITargetService target)
        {
            this._target = target;
        }
        //Create new Target 
        [HttpPost]
        public HttpResponseMessage CreateTarget(TargetListDTO objTarget)
        {
            HttpResponseMessage message;
            try
            {
               // TargetDataAccessLayer dal = new TargetDataAccessLayer();
                var dynObj = new { result = _target.InsertTarget(objTarget) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "Target", "CreateTarget");
            }
            return message;
        }

        //Get All Employee by ReportTo Id
        [HttpPost]
        public HttpResponseMessage GetAllEmployeeByReportTo(TargetGetDTO objTarget)
        {
            HttpResponseMessage message;
            try
            {
               // TargetDataAccessLayer dal = new TargetDataAccessLayer();
                var dynObj = new { result = _target.GetAllEmployee(objTarget) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Target", "GetAllTarget");
            }
            return message;
        }



        //Get All RequirementDetail
        [HttpPost]
        public HttpResponseMessage GetAllTarget(TargetGetDTO objTarget)
        {
            HttpResponseMessage message;
            try
            {
               // TargetDataAccessLayer dal = new TargetDataAccessLayer();
                var dynObj = new { result = _target.GetAllTargets(objTarget) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Target", "GetAllTarget");
            }
            return message;
        }
        //Get Target by Employee Id
        [HttpPost]
        public HttpResponseMessage GetTargetById(TargetGetDTO objTarget)
        {
            HttpResponseMessage message;
            try
            {
               // TargetDataAccessLayer dal = new TargetDataAccessLayer();
                var dynObj = new { result = _target.GetTargetById(objTarget) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Target", "GetTargetById");
            }
            return message;
        }

        //Get All Target For Chart
        [HttpPost]
        public HttpResponseMessage GetAllTargetGraph(TargetGetChart objTarget)
        {
            HttpResponseMessage message;
            try
            {
               // TargetDataAccessLayer dal = new TargetDataAccessLayer();
                var dynObj = new { result = _target.GetAllTargetGraph(objTarget) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Target", "GetAllTargetGraph");
            }
            return message;
        }

        //Get All Target For Chart by EmployeeId
        [HttpPost]
        public HttpResponseMessage GetAllTargetGraphByEmployeeId(TargetGetChart objTarget)
        {
            HttpResponseMessage message;
            try
            {
               // TargetDataAccessLayer dal = new TargetDataAccessLayer();
                var dynObj = new { result = _target.GetAllTargetGraphByEmployeeId(objTarget) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Target", "GetAllTargetGraphByEmployeeId");
            }
            return message;
        }

        //Get All Target For Grid
        [HttpPost]
        public HttpResponseMessage GetAllTargetforGrid(TargetGetChart objTarget)
        {
            HttpResponseMessage message;
            try
            {
               // TargetDataAccessLayer dal = new TargetDataAccessLayer();
                var dynObj = new { result = _target.GetAllTargetCumulitive(objTarget) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Target", "GetAllTargetforGrid");
            }
            return message;
        }

        //Get All Target For Grid by EmployeeId
        [HttpPost]
        public HttpResponseMessage GetAllTargetByEmployeeId(TargetGetChart objTarget)
        {
            HttpResponseMessage message;
            try
            {
               // TargetDataAccessLayer dal = new TargetDataAccessLayer();
                var dynObj = new { result = _target.GetAllTargetCumulitivebyEmployeeId(objTarget) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Target", "GetAllTargetGraph");
            }
            return message;
        }


        //Get All Target For Chart
        [HttpPost]
        public HttpResponseMessage GetAllEmployeeByMonth(TargetGetMonth objTarget)
        {
            HttpResponseMessage message;
            try
            {
               // TargetDataAccessLayer dal = new TargetDataAccessLayer();
                var dynObj = new { result = _target.GetAllEmployeeByMonth(objTarget) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Target", "GetAllEmployeeByMonth");
            }
            return message;
        }


        //Update Target
        [HttpPost]
        public HttpResponseMessage UpdateTarget(TargetUpdateDTO objTarget)
        {
            HttpResponseMessage message;
            try
            {
               // TargetDataAccessLayer dal = new TargetDataAccessLayer();
                var dynObj = new { result = _target.UpdateTarget(objTarget) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Target", "UpdateTaget");
            }
            return message;
        }
        //Remove Target by Employee
        [HttpPost]
        public HttpResponseMessage RemoveTarget(TargetRemoveDTO objTarget)
        {
            HttpResponseMessage message;
            try
            {
               // TargetDataAccessLayer dal = new TargetDataAccessLayer();
                var dynObj = new { result = _target.RemoveTarget(objTarget) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Target", "RemoveTarget");
            }
            return message;
        }
    }
}
