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
    [RoutePrefix("ServiceMaster")]
    public class ServiceMasterController : ApiController
    {
        private readonly IServiceMasterService _Service;

        public ServiceMasterController(IServiceMasterService Service)
        {
            this._Service = Service;
        }
        //create new Service Master 
        [Route("CreateServiceMaster")]
        [HttpPost]
        public HttpResponseMessage CreateServiceMaster(ServiceMasterInsertDTO objServiceMaster)
        {
            HttpResponseMessage message;
            try
            {
             //   ServiceMasterDataAccessLayer dal = new ServiceMasterDataAccessLayer();
                var dynObj = new { result = _Service.InsertServiceMaster(objServiceMaster) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "ServiceMaster", "CreateRequirementDetail");
            }
            return message;
        }

        //Get All Service Master
        [Route("GetAllServices")]
        [HttpPost]
        public HttpResponseMessage GetAllServices(ServiceMasterGetDTO objGetServices)
        {
            HttpResponseMessage message;
            try
            {
             //   ServiceMasterDataAccessLayer dal = new ServiceMasterDataAccessLayer();
                var dynObj = new { result = _Service.GetAllServices(objGetServices) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ServiceMaster", "GetAllServices");
            }
            return message;
        }

        //Get Service Master by Id
        [Route("GetServiceMasterById")]
        [HttpPost]
        public HttpResponseMessage GetServiceMasterById(ServiceMasterGetDTO objGetServiceMasterById)
        {
            HttpResponseMessage message;
            try
            {
             //   ServiceMasterDataAccessLayer dal = new ServiceMasterDataAccessLayer();
                var dynObj = new { result = _Service.GetServiceById(objGetServiceMasterById) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ServiceMaster", "GetServiceMasterById");
            }
            return message;
        }

        //Get Active Service Master
         [Route("GetActiveServiceMaster")]
        [HttpPost]
        public HttpResponseMessage GetActiveServiceMaster(ServiceMasterGetDTO objActive)
        {
            HttpResponseMessage message;
            try
            {
             //   ServiceMasterDataAccessLayer dal = new ServiceMasterDataAccessLayer();
                var dynObj = new { result = _Service.GetActiveServiceMaster(objActive) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ServiceMaster", "GetActiveServiceMaster");
            }
            return message;
        }

        //Get In Active Service Master 
        [Route("GetInActiveServiceMaster")]
        [HttpPost]
        public HttpResponseMessage GetInActiveServiceMaster(ServiceMasterGetDTO objInActive)
        {
            HttpResponseMessage message;
            try
            {
             //   ServiceMasterDataAccessLayer dal = new ServiceMasterDataAccessLayer();
                var dynObj = new { result = _Service.GetInActiveServiceMaster(objInActive) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ServiceMaster", "GetInActiveServiceMaster");
            }
            return message;
        }
        //Update Service Master
        [Route("UpdateServiceMaster")]
        [HttpPost]
        public HttpResponseMessage UpdateServiceMaster(ServiceMasterUpdateDTO objServiceMaster)
        {
            HttpResponseMessage message;
            try
            {
             //   ServiceMasterDataAccessLayer dal = new ServiceMasterDataAccessLayer();
                var dynObj = new { result = _Service.UpdateServiceMaster(objServiceMaster) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ServiceMaster", "UpdateServiceMaster");
            }
            return message;
        }

        //Remove Service Master By Id
        [Route("RemoveServiceMaster")]
        [HttpPost]
        public HttpResponseMessage RemoveServiceMaster(ServiceMasterRemoveDTO objServiceMaster)
        {
            HttpResponseMessage message;
            try
            {
             //   ServiceMasterDataAccessLayer dal = new ServiceMasterDataAccessLayer();
                var dynObj = new { result = _Service.RemoveServiceMaster(objServiceMaster) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ServiceMaster", "RemoveServiceMaster");
            }
            return message;
        }

    }
}
