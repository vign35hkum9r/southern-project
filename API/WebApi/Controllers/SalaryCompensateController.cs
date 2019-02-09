using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.ActionFilters;

namespace WebApi.Controllers
{
    [AuthorizationRequired]
    [RoutePrefix("SalaryCompensate")]
    public class SalaryCompensateController : ApiController
    {
        //create new Salary Detail
        [HttpPost]
        public HttpResponseMessage CreateSalaryComponsate(SalaryCompensateInsertDTO objSalary)
        {
            HttpResponseMessage message;
            try
            {
                SalaryCompensateDataAccessLayer dal = new SalaryCompensateDataAccessLayer();
                var dynObj = new { result = dal.InsertSalary(objSalary) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "Salary", "CreateSalary");
            }
            return message;
        }

        //Get All Salary Details
        [HttpPost]
        public HttpResponseMessage GetAllSalaryComponsate(SalaryCompensateGetDTO objSalary)
        {
            HttpResponseMessage message;
            try
            {
                SalaryCompensateDataAccessLayer dal = new SalaryCompensateDataAccessLayer();
                var dynObj = new { result = dal.GetAllSalaryCompensate(objSalary) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Salary", "GetAllSalaryComponsate");
            }
            return message;
        }

        //Get Salary Detail by Id
        [HttpPost]
        public HttpResponseMessage GetSalaryComponsateById(SalaryCompensateGetDTO objSalary)
        {
            HttpResponseMessage message;
            try
            {
                SalaryCompensateDataAccessLayer dal = new SalaryCompensateDataAccessLayer();
                var dynObj = new { result = dal.GetSalaryCompensateById(objSalary) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Salary", "GetSalaryById");
            }
            return message;
        }

        //Update Salary datail
        [HttpPost]
        public HttpResponseMessage UpdateSalaryCompensate(SalaryCompensateUpdateDTO objSalary)
        {
            HttpResponseMessage message;
            try
            {
                SalaryCompensateDataAccessLayer dal = new SalaryCompensateDataAccessLayer();
                var dynObj = new { result = dal.UpdateSalary(objSalary) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Salary", "UpdateSalaryCompensate");
            }
            return message;
        }

        //Remove Salary Detail by Id
        [HttpPost]
        public HttpResponseMessage RemoveSalaryCompensate(SalaryCompensateRemoveDTO objSalary)
        {
            HttpResponseMessage message;
            try
            {
                SalaryCompensateDataAccessLayer dal = new SalaryCompensateDataAccessLayer();
                var dynObj = new { result = dal.DeactivateSalary(objSalary) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Salary", "RemoveSalaryCompensate");
            }
            return message;
        }
    }
}
