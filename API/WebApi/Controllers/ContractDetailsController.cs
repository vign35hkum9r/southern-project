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
    [RoutePrefix("ContractDetails")]
    public class ContractDetailsController : ApiController
    {
        private readonly IContractorDetail _obj;
       

        public ContractDetailsController(IContractorDetail obj)
        {
            _obj = obj;
            
        }

        //Create new Contract Details
        [Route("CreateContractDetail")]
        [HttpPost]
        public HttpResponseMessage CreateContractDetail(ContractDetailsInsertDTO contract)
        {
            HttpResponseMessage message;
            try
            {
               // ContractDetailsDataAccessLayer dal = new ContractDetailsDataAccessLayer();
                var dynObj = new { result = _obj.InsertContractDetails(contract) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "ContractDetails", "CreateContractDetail");
            }
            return message;
        }

        //Create new Contract Consume Requirement Details
        [Route("CreateConsumeRequirement")]
        [HttpPost]
        public HttpResponseMessage CreateConsumeRequirement(ContractConsumeInsertDTO contract)
        {
            HttpResponseMessage message;
            try
            {
               // ContractDetailsDataAccessLayer dal = new ContractDetailsDataAccessLayer();
                var dynObj = new { result = _obj.InsertConsumeContractDetails(contract) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "ContractDetails", "CreateContractDetail");
            }
            return message;
        }

        //Update new Contract Consume Requirement Details
        [Route("UpdateConsumeRequirement")]
        [HttpPost]
        public HttpResponseMessage UpdateConsumeRequirement(ContractConsumeUpdateDTO contract)
        {
            HttpResponseMessage message;
            try
            {
               // ContractDetailsDataAccessLayer dal = new ContractDetailsDataAccessLayer();
                var dynObj = new { result = _obj.UpdateConsumeContractDetails(contract) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "ContractDetails", "CreateContractDetail");
            }
            return message;
        }

        //Get All Contract Details
        [Route("GetAllContractDetails")]
        [HttpPost]
        public HttpResponseMessage GetAllContractDetails(ContractDetailGetDTO objContract)
        {
            HttpResponseMessage message;
            try
            {
               // ContractDetailsDataAccessLayer dal = new ContractDetailsDataAccessLayer();
                var dynObj = new { result = _obj.GetAllContractDetails(objContract) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ContractDetails", "GetAllContractDetails");
            }
            return message;
        }

        //Get All Contract Details
        [Route("GetAllConsumeById")]
        [HttpPost]
        public HttpResponseMessage GetAllConsumeById(getConsumeRequirement objContract)
        {
            HttpResponseMessage message;
            try
            {
               // ContractDetailsDataAccessLayer dal = new ContractDetailsDataAccessLayer();
                var dynObj = new { result = _obj.GetConsumeRequirement(objContract) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ContractDetails", "GetAllConsumeById");
            }
            return message;
        }

        //Get Contract Detail by Contract Id
        [Route("GetContractDetailById")]
        [HttpPost]
        public HttpResponseMessage GetContractDetailById(ContractDetailGetDTO objContract)
        {
            HttpResponseMessage message;
            try
            {
               // ContractDetailsDataAccessLayer dal = new ContractDetailsDataAccessLayer();
                var dynObj = new { result = _obj.GetContractDetailById(objContract) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ContractDetails", "GetContractDetailById");
            }
            return message;
        }

        //Update Contract Master datail
        [Route("UpdateContractDetail")]
        [HttpPost]
        public HttpResponseMessage UpdateContractDetail(ContractDetailsUpdateDTO objContract)
        {
            HttpResponseMessage message;
            try
            {
               // ContractDetailsDataAccessLayer dal = new ContractDetailsDataAccessLayer();
                var dynObj = new { result = _obj.UpdateContractDetails(objContract) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ContractDetails", "UpdateContractDetail");
            }
            return message;
        }

        //Remove Contract Detail by ContractId
        [Route("RemoveContractDetail")]
        [HttpPost]
        public HttpResponseMessage RemoveContractDetail(ContractDetailsRemoveDTO objContract)
        {
            HttpResponseMessage message;
            try
            {
               // ContractDetailsDataAccessLayer dal = new ContractDetailsDataAccessLayer();
                var dynObj = new { result = _obj.RemoveContractDetail(objContract) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ContractDetails", "RemoveContractDetail");
            }
            return message;
        }
    }
}
