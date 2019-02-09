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
    [RoutePrefix("ClientLeadChange")]
    public class ClientLeadChangeController : ApiController
    {
        private readonly IClientLead _clientServices;

        public ClientLeadChangeController(IClientLead client)
        {
            _clientServices = client;
        }

        [HttpPost]
        public HttpResponseMessage GetAllClientByEmployee(GetClientbyEmployeeDTO objClient)
        {
            HttpResponseMessage message;
            try
            {
               // ClientLeadChangeDataAccessLayer dal = new ClientLeadChangeDataAccessLayer();
                var dynObj = new { result =_clientServices.GetClientList(objClient) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ClientLeadChange", "GetAllReportByClientId");
            }
            return message;
        }

        [HttpPost]
        public HttpResponseMessage GetOldEmployeeList(GetOldEmployeeDTO objEmployee)
        {
            HttpResponseMessage message;
            try
            {
               // ClientLeadChangeDataAccessLayer dal = new ClientLeadChangeDataAccessLayer();
                var dynObj = new { result =_clientServices.GetOldEmployeeList(objEmployee) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ClientLeadChange", "GetOldEmployeeList");
            }
            return message;
        }

        [HttpPost]
        public HttpResponseMessage GetNewEmployeeList(GetNewEmployeeDTO objEmployee)
        {
            HttpResponseMessage message;
            try
            {
               // ClientLeadChangeDataAccessLayer dal = new ClientLeadChangeDataAccessLayer();
                var dynObj = new { result =_clientServices.GetNewEmployeeList(objEmployee) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ClientLeadChange", "GetOldEmployeeList");
            }
            return message;
        }

        [HttpPost]
        public HttpResponseMessage ChangeLead(ChangeLeadbyClientDTO objChangeLead)
        {
            HttpResponseMessage message;
            try
            {
               // ClientLeadChangeDataAccessLayer dal = new ClientLeadChangeDataAccessLayer();
                var dynObj = new { result =_clientServices.ChangeLeadByClient(objChangeLead) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ClientLeadChange", "ChangeClientLead");
            }
            return message;
        }
        
    }
}
