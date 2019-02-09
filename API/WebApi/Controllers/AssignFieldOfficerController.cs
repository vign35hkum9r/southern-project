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
    [RoutePrefix("AssignFieldOfficer")]
    public class AssignFieldOfficerController : ApiController
    {
        private readonly IAssignFieldOfficer _FieldOfficer;

        public AssignFieldOfficerController(IAssignFieldOfficer FieldOfficer)
        {
            this._FieldOfficer = FieldOfficer;
        }
        //get Field Officer Employee List
        [Route("getAllEmployeeList")]
        [HttpPost]
        public HttpResponseMessage getAllEmployeeList(FieldOfficerDTO emp)
        {
            HttpResponseMessage message;
            try
            {
               // AssignFieldOfficerDataAccessLayer _FieldOfficer = new AssignFieldOfficerDataAccessLayer();
                var dynObj = new { result = _FieldOfficer.GetAllEmpList(emp) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "FieldOfficer", "getAllEmployeeList");
            }
            return message;
        }

        //get All Customer
        [Route("getAllCustomer")]
        [HttpPost]
        public HttpResponseMessage getAllCustomer(FieldOfficerCustomerDTO customer)
        {
            HttpResponseMessage message;
            try
            {
               // AssignFieldOfficerDataAccessLayer _FieldOfficer = new AssignFieldOfficerDataAccessLayer();
                var dynObj = new { result = _FieldOfficer.GetAllCustomer(customer) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "FieldOfficer", "getAllCustomer");
            }
            return message;
        }

        //get All Branch
        [Route("getAllBranch")]
        [HttpPost]
        public HttpResponseMessage getAllBranch(FieldOfficerBranchDTO branch)
        {
            HttpResponseMessage message;
            try
            {
               // AssignFieldOfficerDataAccessLayer _FieldOfficer = new AssignFieldOfficerDataAccessLayer();
                var dynObj = new { result = _FieldOfficer.GetAllBranch(branch) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "FieldOfficer", "getAllBranch");
            }
            return message;
        }

        //get All Aite
        [Route("getAllSite")]
        [HttpPost]
        public HttpResponseMessage getAllSite(FieldOfficerSiteDTO site)
        {
            HttpResponseMessage message;
            try
            {
               // AssignFieldOfficerDataAccessLayer _FieldOfficer = new AssignFieldOfficerDataAccessLayer();
                var dynObj = new { result = _FieldOfficer.GetAllSite(site) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "FieldOfficer", "getAllSite");
            }
            return message;
        }

        //Create Assign Field Officer
        [Route("CreateAssignFieldOfficer")]
        [HttpPost]
        public HttpResponseMessage CreateAssignFieldOfficer(AddFieldOfficerDTO assign)
        {
            HttpResponseMessage message;
            try
            {
               // AssignFieldOfficerDataAccessLayer _FieldOfficer = new AssignFieldOfficerDataAccessLayer();
                var dynObj = new { result = _FieldOfficer.InsertAssignFieldOfficer(assign) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "FieldOfficer", "CreateAssignFieldOfficer");
            }
            return message;
        }

        //Remove Assign Field Officer
        [Route("RemoveAssignFieldOfficer")]
        [HttpPost]
        public HttpResponseMessage RemoveAssignFieldOfficer(RemoveFieldOfficer assign)
        {
            HttpResponseMessage message;
            try
            {
               // AssignFieldOfficerDataAccessLayer _FieldOfficer = new AssignFieldOfficerDataAccessLayer();
                var dynObj = new { result = _FieldOfficer.RemoveAssignFieldOfficer(assign) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "FieldOfficer", "RemoveAssignFieldOfficer");
            }
            return message;
        }

        //Get All Assign Field Officer
        [Route("getAllFieldOfficer")]
        [HttpPost]
        public HttpResponseMessage getAllFieldOfficer(FieldOfficer assign)
        {
            HttpResponseMessage message;
            try
            {
               // AssignFieldOfficerDataAccessLayer _FieldOfficer = new AssignFieldOfficerDataAccessLayer();
                var dynObj = new { result = _FieldOfficer.GetAllAssignFieldOfficer(assign) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "FieldOfficer", "getAllFieldOfficer");
            }
            return message;
        }


    }
}
