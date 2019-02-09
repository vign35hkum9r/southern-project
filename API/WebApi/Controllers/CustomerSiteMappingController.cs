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
    [RoutePrefix("CustomerSiteMapping")]
    public class CustomerSiteMappingController : ApiController
    {
        private readonly ICustomerMapping _Customermapping;

        public CustomerSiteMappingController(ICustomerMapping Customermapping)
        {
            _Customermapping = Customermapping;
        }
        //create new BranchMaster
        [Route("CreateBranch")]
        [HttpPost]
        public HttpResponseMessage CreateBranch(AddBranchDTO branch)
        {
            HttpResponseMessage message;
            try
            {
              //  CustomerSiteMappingDataAccessLayer dal = new CustomerSiteMappingDataAccessLayer();
                var dynObj = new { result = _Customermapping.InsertBranch(branch) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "CustomerSiteMapping", "CreateBranch");
            }
            return message;
        }

        //get BranchMaster
        [Route("getBranch")]
        [HttpPost]
        public HttpResponseMessage getBranch(GetCustomersBranchDTO branch)
        {
            HttpResponseMessage message;
            try
            {
              //  CustomerSiteMappingDataAccessLayer dal = new CustomerSiteMappingDataAccessLayer();
                var dynObj = new { result = _Customermapping.GetAllBranch(branch) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "CustomerSiteMapping", "getBranch");
            }
            return message;
        }

        //get Site Master
        [Route("getSite")]
        [HttpPost]
        public HttpResponseMessage getSite(getCustomerSiteDTO site)
        {
            HttpResponseMessage message;
            try
            {
              //  CustomerSiteMappingDataAccessLayer dal = new CustomerSiteMappingDataAccessLayer();
                var dynObj = new { result = _Customermapping.GetAllSite(site) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "CustomerSiteMapping", "getSite");
            }
            return message;
        }

        //Create Site Master
        [Route("CreateSite")]
        [HttpPost]
        public HttpResponseMessage CreateSite(AddSiteDTO site)
        {
            HttpResponseMessage message;
            try
            {
              //  CustomerSiteMappingDataAccessLayer dal = new CustomerSiteMappingDataAccessLayer();
                var dynObj = new { result = _Customermapping.InsertSite(site) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "CustomerSiteMapping", "CreateSite");
            }
            return message;
        }

        //Create Classfication 
        [Route("CreateClassfication")]
        [HttpPost]
        public HttpResponseMessage CreateClassfication(AddClassificationDTO classfication)
        {
            HttpResponseMessage message;
            try
            {
              //  CustomerSiteMappingDataAccessLayer dal = new CustomerSiteMappingDataAccessLayer();
                var dynObj = new { result = _Customermapping.InsertClassfication(classfication) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "CustomerSiteMapping", "CreateClassfication");
            }
            return message;
        }


        //Remove Branch 
        [Route("removeBranch")]
        [HttpPost]
        public HttpResponseMessage removeBranch(removeBranchDTO branch)
        {
            HttpResponseMessage message;
            try
            {
              //  CustomerSiteMappingDataAccessLayer dal = new CustomerSiteMappingDataAccessLayer();
                var dynObj = new { result = _Customermapping.removeBranch(branch) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "CustomerSiteMapping", "removeBranch");
            }
            return message;
        }

        //Remove Site 
        [Route("removeSite")]
        [HttpPost]
        public HttpResponseMessage removeSite(removeSiteDTO site)
        {
            HttpResponseMessage message;
            try
            {
              //  CustomerSiteMappingDataAccessLayer dal = new CustomerSiteMappingDataAccessLayer();
                var dynObj = new { result = _Customermapping.removeSite(site) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "CustomerSiteMapping", "removeSite");
            }
            return message;
        }

        //Remove Classification 
        [Route("removeClassification")]
        [HttpPost]
        public HttpResponseMessage removeClassification(removeClassificationDTO classification)
        {
            HttpResponseMessage message;
            try
            {
              //  CustomerSiteMappingDataAccessLayer dal = new CustomerSiteMappingDataAccessLayer();
                var dynObj = new { result = _Customermapping.removeClassification(classification) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "CustomerSiteMapping", "removeClassification");
            }
            return message;
        }
    }
}
