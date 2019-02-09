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
    [RoutePrefix("AssignManpower")]
    public class AssignManpowerController : ApiController
    {
        private readonly IAssignManpower _manPower;

        public AssignManpowerController(IAssignManpower manPower)
        {
            this._manPower = manPower;
        }

        /// Get All AssignManpower
        [Route("GetAllManpowerList")]
        [HttpPost]
        public HttpResponseMessage GetAllManpowerList(ManpowerAssignDTO objGetManPower)
        {
            HttpResponseMessage message;
            try
            {
               // AssignManpowerDataAccessLayer _manPower = new AssignManpowerDataAccessLayer();
                var dynObj = new { result = _manPower.GetAllManpowerList(objGetManPower) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "AssignManpower", "GetAllAssignManpower");
            }
            return message;
        }

        [Route("GetContractByAllCustomer")]
        [HttpPost]
        public HttpResponseMessage GetContractByAllCustomer(GetContractByAllCustomer objGetManPower)
        {
            HttpResponseMessage message;
            try
            {
               // AssignManpowerDataAccessLayer _manPower = new AssignManpowerDataAccessLayer();
                var dynObj = new { result = _manPower.GetContractByAllCustomer(objGetManPower) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "AssignManpower", "GetContractByAllCustomer");
            }
            return message;
        }

        // Get All SiteAllocation Customer
        [Route("GetAllCustomer")]
        [HttpPost]
        public HttpResponseMessage GetAllCustomer(ManpowerCustomerDTO objGetManPower)
        {
            HttpResponseMessage message;
            try
            {
               // AssignManpowerDataAccessLayer _manPower = new AssignManpowerDataAccessLayer();
                var dynObj = new { result = _manPower.GetAllCustomer(objGetManPower) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "AssignManpower", "GetAllCustomer");
            }
            return message;
        }

        // Get All SiteAllocation Branch
        [Route("GetAllBranch")]
        [HttpPost]
        public HttpResponseMessage GetAllBranch(ManpowerBranchDTO objGetManPower)
        {
            HttpResponseMessage message;
            try
            {
               // AssignManpowerDataAccessLayer _manPower = new AssignManpowerDataAccessLayer();
                var dynObj = new { result = _manPower.GetAllBranch(objGetManPower) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "AssignManpower", "GetAllBranch");
            }
            return message;
        }

        // Get All SiteAllocation Site
        [Route("GetAllSite")]
        [HttpPost]
        public HttpResponseMessage GetAllSite(ManpowerSiteDTO objGetManPower)
        {
            HttpResponseMessage message;
            try
            {
               // AssignManpowerDataAccessLayer _manPower = new AssignManpowerDataAccessLayer();
                var dynObj = new { result = _manPower.GetAllSite(objGetManPower) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "AssignManpower", "GetAllSite");
            }
            return message;
        }
        // Get All SiteAllocation Classification
        [Route("GetAllClassification")]
        [HttpPost]
        public HttpResponseMessage GetAllClassification(ManpowerClassificationDTO objGetManPower)
        {
            HttpResponseMessage message;
            try
            {
               // AssignManpowerDataAccessLayer _manPower = new AssignManpowerDataAccessLayer();
                var dynObj = new { result = _manPower.GetAllClassification(objGetManPower) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "AssignManpower", "GetAllClassification");
            }
            return message;
        }

        // Get All SiteAllocation Service
        [Route("GetAllService")]
        [HttpPost]
        public HttpResponseMessage GetAllService(ManpowerServiceDTO objGetManPower)
        {
            HttpResponseMessage message;
            try
            {    
               // AssignManpowerDataAccessLayer _manPower = new AssignManpowerDataAccessLayer();
                var dynObj = new { result = _manPower.GetAllService(objGetManPower) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "AssignManpower", "GetAllService");
            }
            return message;
        }

        // Add Assign ManPower
        [Route("CreateManpower")]
        [HttpPost]
        public HttpResponseMessage CreateManpower(AddManpowerDTO objGetManPower)
        {
            HttpResponseMessage message;
            try
            {
               // AssignManpowerDataAccessLayer _manPower = new AssignManpowerDataAccessLayer();
                var dynObj = new { result = _manPower.InsertAssignManpower(objGetManPower) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "AssignManpower", "CreateManpower");
            }
            return message;
        }

        // Get All Assign ManPower
        [Route("getAllAssignManPower")]
        [HttpPost]
        public HttpResponseMessage getAllAssignManPower(ManpowerBranchDTO objGetManPower)
        {
            HttpResponseMessage message;
            try
            {
               // AssignManpowerDataAccessLayer _manPower = new AssignManpowerDataAccessLayer();
                var dynObj = new { result = _manPower.GetAllAssignManPower(objGetManPower) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "AssignManpower", "getAllAssignManPower");
            }
            return message;
        }

        // Remove Assign ManPower
        [Route("RemoveAssignManpower")]
        [HttpPost]
        public HttpResponseMessage RemoveAssignManpower(RemoveManPowerDTO objGetManPower)
        {
            HttpResponseMessage message;
            try
            {
               // AssignManpowerDataAccessLayer _manPower = new AssignManpowerDataAccessLayer();
                var dynObj = new { result = _manPower.RemoveAssignManpower(objGetManPower) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "AssignManpower", "RemoveAssignManpower");
            }
            return message;
        }

    }
}
