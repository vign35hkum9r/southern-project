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
    [RoutePrefix("RequirementDetails")]
    public class RequirementDetailsController : ApiController
    {
        private readonly IRequirementServices _requirment;

        public RequirementDetailsController(IRequirementServices requirment)
        {
            _requirment = requirment;
        }
        //Create new RequirementDetail 
        [HttpPost]
        public HttpResponseMessage CreateRequirementDetails(RequirementDetailsInsertDTO objRequirement)
        {
            HttpResponseMessage message;
            try
            {
              //  RequirementDetailsDataAccessLayer dal = new RequirementDetailsDataAccessLayer();
                var dynObj = new { result = _requirment.InsertRequirementDetails(objRequirement) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "RequirementDetails", "CreateRequirementDetails");
            }
            return message;
        }
        //Get All RequirementDetail
        [HttpPost]
        public HttpResponseMessage GetAllRequirementDetails(RequirementDetailsGetDTO objRequirement)
        {
            HttpResponseMessage message;
            try
            {
              //  RequirementDetailsDataAccessLayer dal = new RequirementDetailsDataAccessLayer();
                var dynObj = new { result = _requirment.GetAllRequirementDetails(objRequirement) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "RequirementDetails", "GetAllRequirementDetails");
            }
            return message;
        }
        //Get RequirementDetail by Client Id
        [HttpPost]
        public HttpResponseMessage GetRequirementDetailsById(RequirementDetailsGetDTO objRequirement)
        {
            HttpResponseMessage message;
            try
            {
              //  RequirementDetailsDataAccessLayer dal = new RequirementDetailsDataAccessLayer();
                var dynObj = new { result = _requirment.GetRequirementDetailsById(objRequirement) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "RequirementDetails", "GetAllRequirementDetails");
            }
            return message;
        }

        //Update RequirementDetails
        [HttpPost]
        public HttpResponseMessage UpdateRequirementDetails(RequirementDetailsUpdateDTO objRequirement)
        {
            HttpResponseMessage message;
            try
            {
              //  RequirementDetailsDataAccessLayer dal = new RequirementDetailsDataAccessLayer();
                var dynObj = new { result = _requirment.UpdateRequirementDetails(objRequirement) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "RequirementDetails", "UpdateRequirementDetails");
            }
            return message;
        }

        //Remove RequirementDetails by Client Id
        [HttpPost]
        public HttpResponseMessage RemoveRequirementDetails(RequirementDetailsRemoveDTO objRequirement)
        {
            HttpResponseMessage message;
            try
            {
              //  RequirementDetailsDataAccessLayer dal = new RequirementDetailsDataAccessLayer();
                var dynObj = new { result = _requirment.RemoveRequirementDetails(objRequirement) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "RequirementDetails", "RemoveRequirementDetails");
            }
            return message;
        }
    }
}
