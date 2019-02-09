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
    [RoutePrefix("ContractMaster")]
    public class ContractMasterController : ApiController
    {
        private readonly IContractorMaster _obj;


        public ContractMasterController(IContractorMaster obj)
        {
            _obj = obj;

        }

        //Create new Contract Master
        [Route("CreateContractMaster")]
        [HttpPost]
        public HttpResponseMessage CreateContractMaster(ContractMasterInsertDTO contract)
        {
            HttpResponseMessage message;
            try
            {
              //  ContractMasterDataAccessLayer dal = new ContractMasterDataAccessLayer();
                var dynObj = new { result = _obj.InsertContractMaster(contract) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "ContractMaster", "CreateContractMaster");
            }
            return message;
        }

        //Get All Contract Masters
        [Route("GetAllContractMasters")]
        [HttpPost]
        public HttpResponseMessage GetAllContractMasters(ContractMasterGetDTO objContract)
        {
            HttpResponseMessage message;
            try
            {
              //  ContractMasterDataAccessLayer dal = new ContractMasterDataAccessLayer();
                var dynObj = new { result = _obj.GetAllContractMasters(objContract) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ContractMaster", "GetAllContractMasters");
            }
            return message;
        }

        //Get Customer by Customer Id
        [Route("GetContractMasterById")]
        [HttpPost]
        public HttpResponseMessage GetContractMasterById(ContractMasterGetDTO objContract)
        {
            HttpResponseMessage message;
            try
            {
              //  ContractMasterDataAccessLayer dal = new ContractMasterDataAccessLayer();
                var dynObj = new { result = _obj.GetContractMasterById(objContract) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ContactMaster", "GetContractMasterById");
            }
            return message;
        }

        //Get Active Contract Master detail 
        [Route("GetActiveContractMaster")]
        [HttpPost]
        public HttpResponseMessage GetActiveContractMaster(ContractMasterGetDTO objContract)
        {
            HttpResponseMessage message;
            try
            {
              //  ContractMasterDataAccessLayer dal = new ContractMasterDataAccessLayer();
                var dynObj = new { result = _obj.GetActiveContractMaster(objContract) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ContactMaster", "GetActiveContractMaster");
            }
            return message;
        }

        //Get In Active Contract Detail detail 
        [Route("GetInActiveCustomer")]
        [HttpPost]
        public HttpResponseMessage GetInActiveCustomer(ContractMasterGetDTO objContract)
        {
            HttpResponseMessage message;
            try
            {
              //  ContractMasterDataAccessLayer dal = new ContractMasterDataAccessLayer();
                var dynObj = new { result = _obj.GetInActiveContractMaster(objContract) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Customer", "GetInActiveCustomer");
            }
            return message;
        }


        //Update Contract Master datail
        [Route("UpdateContractMaster")]
        [HttpPost]
        public HttpResponseMessage UpdateContractMaster(ContractMasterUpdateDTO contract)
        {
            HttpResponseMessage message;
            try
            {
              //  ContractMasterDataAccessLayer dal = new ContractMasterDataAccessLayer();
                var dynObj = new { result = _obj.UpdateContractMaster(contract) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ContractMaster", "UpdateContractMaster");
            }
            return message;
        }

        //Deactive Contract Master by Contract Master Id
        [Route("RemoveContractMasterById")]
        [HttpPost]
        public HttpResponseMessage RemoveContractMasterById(ContractMasterRemoveDTO objRemoveContractById)
        {
            HttpResponseMessage message;
            try
            {
              //  ContractMasterDataAccessLayer dal = new ContractMasterDataAccessLayer();
                var dynObj = new { result = _obj.RemoveContractMasterById(objRemoveContractById) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ContractMaster", "RemoveContractMasterById");
            }
            return message;
        }
    }
}
