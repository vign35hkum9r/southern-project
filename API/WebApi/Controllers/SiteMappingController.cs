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
    [RoutePrefix("SiteMapping")]
    public class SiteMappingController : ApiController
    {
        private readonly ISiteMapping _Site;

        public SiteMappingController(ISiteMapping Site)
        {
            this._Site = Site;
        }

        //get BranchMaster
        [Route("getAllCustomer")]
        [HttpPost]
        public HttpResponseMessage getAllCustomer(getCustomerDTO branch)
        {
            HttpResponseMessage message;
            try
            {
               // SiteMappingDataAccessLayer dal = new SiteMappingDataAccessLayer();
                var dynObj = new { result = _Site.GetAllCustomer(branch) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "SiteMapping", "getAllCustomer");
            }
            return message;
        }

        //get BranchMaster
        [Route("getBranch")]
        [HttpPost]
        public HttpResponseMessage getBranch(getBranchDTO branch)
        {
            HttpResponseMessage message;
            try
            {
               // SiteMappingDataAccessLayer dal = new SiteMappingDataAccessLayer();
                var dynObj = new { result = _Site.GetAllBranch(branch) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "SiteMapping", "getBranch");
            }
            return message;
        }


        //get Site Master
        [Route("getSite")]
        [HttpPost]
        public HttpResponseMessage getSite(getSiteDTO site)
        {
            HttpResponseMessage message;
            try
            {
               // SiteMappingDataAccessLayer dal = new SiteMappingDataAccessLayer();
                var dynObj = new { result = _Site.GetAllSite(site) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "SiteMapping", "getSite");
            }
            return message;
        }

        //get Classification Master
        [Route("getClassification")]
        [HttpPost]
        public HttpResponseMessage getClassification(getClassficationDTO classification)
        {
            HttpResponseMessage message;
            try
            {
               // SiteMappingDataAccessLayer dal = new SiteMappingDataAccessLayer();
                var dynObj = new { result = _Site.GetAllClassification(classification) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "SiteMapping", "getClassification");
            }
            return message;
        }

        //get Service Master
        [Route("getService")]
        [HttpPost]
        public HttpResponseMessage getService(getServiceDTO service)
        {
            HttpResponseMessage message;
            try
            {
               // SiteMappingDataAccessLayer dal = new SiteMappingDataAccessLayer();
                var dynObj = new { result = _Site.GetAllService(service) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "SiteMapping", "getService");
            }
            return message;
        }

        //get All ManpowerList
        [Route("getManpowerList")]
        [HttpPost]
        public HttpResponseMessage getManpowerList(GetManpowerListDTO manpower)
        {
            HttpResponseMessage message;
            try
            {
               // SiteMappingDataAccessLayer dal = new SiteMappingDataAccessLayer();
                var dynObj = new { result = _Site.GetAllManpowerList(manpower) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "SiteMapping", "getManpowerList");
            }
            return message;
        }

        //Create Site Allocation
        [Route("CreateSiteAllocation")]
        [HttpPost]
        public HttpResponseMessage CreateSiteAllocation(AddSiteAllocationDTO service)
        {
            HttpResponseMessage message;
            try
            {
               // SiteMappingDataAccessLayer dal = new SiteMappingDataAccessLayer();
                var dynObj = new { result = _Site.InsertSiteAllocation(service) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "SiteMapping", "CreateSiteAllocation");
            }
            return message;
        }

        //Get All Site Allocation
        [Route("getAllSiteAllocation")]
        [HttpPost]
        public HttpResponseMessage getAllSiteAllocation(getServiceDTO service)
        {
            HttpResponseMessage message;
            try
            {
               // SiteMappingDataAccessLayer dal = new SiteMappingDataAccessLayer();
                var dynObj = new { result = _Site.GetAllSiteAllocation(service) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "SiteMapping", "getAllSiteAllocation");
            }
            return message;
        }

        //Remove Site Allocation
        [Route("removeSiteAllocation")]
        [HttpPost]
        public HttpResponseMessage removeSiteAllocation(removeSiteAllocation service)
        {
            HttpResponseMessage message;
            try
            {
               // SiteMappingDataAccessLayer dal = new SiteMappingDataAccessLayer();
                var dynObj = new { result = _Site.removeSiteAllocation(service) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "SiteMapping", "removeSiteAllocation");
            }
            return message;
        }
    }
}
