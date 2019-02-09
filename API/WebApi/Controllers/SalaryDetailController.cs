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
    [RoutePrefix("SalaryDetail")]
    public class SalaryDetailController : ApiController
    {
        //create new Salary Detail
        [HttpPost]
        public HttpResponseMessage CreateSalaryDetail(SalaryDetailInsertDTO objSalary)
        {
            HttpResponseMessage message;
            try
            {
                SalaryDetailDataAccessLayer dal = new SalaryDetailDataAccessLayer();
                var dynObj = new { result = dal.InsertSalaryDetail(objSalary) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "SalaryDetail", "CreateSalaryDetail");
            }
            return message;
        }

        //Get All Salary Detail
        [HttpPost]
        public HttpResponseMessage GetAllSalaryDetail(SalaryDetailGetDTO objSalary)
        {
            HttpResponseMessage message;
            try
            {
                SalaryDetailDataAccessLayer dal = new SalaryDetailDataAccessLayer();
                var dynObj = new { result = dal.GetAllSalaryDetail(objSalary) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "SalaryDetail", "GetAllSalaryDetail");
            }
            return message;
        }

        //Get Salary Detail by Employee Id
        [HttpPost]
        public HttpResponseMessage GetSalaryDetailById(SalaryDetailGetDTO objSalary)
        {
            HttpResponseMessage message;
            try
            {
                SalaryDetailDataAccessLayer dal = new SalaryDetailDataAccessLayer();
                var dynObj = new { result = dal.GetSalaryDetailById(objSalary) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "SalaryDetail", "GetSalaryDetailById");
            }
            return message;
        }

        //Get All Active Salary Detail 
        [HttpPost]
        public HttpResponseMessage GetActiveSalaryDetail(SalaryDetailGetDTO objSalary)
        {
            HttpResponseMessage message;
            try
            {
                SalaryDetailDataAccessLayer dal = new SalaryDetailDataAccessLayer();
                var dynObj = new { result = dal.GetActiveSalaryDetail(objSalary) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "SalaryDetail", "GetActiveSalaryDetail");
            }
            return message;
        }

        //Get All In Active Salary Detail 
        [HttpPost]
        public HttpResponseMessage GetInActiveSalaryDetail(SalaryDetailGetDTO objSalary)
        {
            HttpResponseMessage message;
            try
            {
                SalaryDetailDataAccessLayer dal = new SalaryDetailDataAccessLayer();
                var dynObj = new { result = dal.GetInActiveSalaryDetail(objSalary) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "SalaryDetail", "GetInActiveSalaryDetail");
            }
            return message;
        }

        //Update Salary Detail by Employee Id 
        [HttpPost]
        public HttpResponseMessage UpdateSalaryDetail(SalaryDetailUpdateDTO objSalary)
        {
            HttpResponseMessage message;
            try
            {
                SalaryDetailDataAccessLayer dal = new SalaryDetailDataAccessLayer();
                var dynObj = new { result = dal.UpdateSalaryDetail(objSalary) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "SalaryDetail", "GetInActiveSalary");
            }
            return message;
        }

        //Remove Salary Detail by Employee Id 
        [HttpPost]
        public HttpResponseMessage RemoveSalaryDetail(SalaryDetailRemoveDTO objSalary)
        {
            HttpResponseMessage message;
            try
            {
                SalaryDetailDataAccessLayer dal = new SalaryDetailDataAccessLayer();
                var dynObj = new { result = dal.RemoveSalaryDetail(objSalary) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "SalaryDetail", "RemoveSalaryDetail");
            }
            return message;
        }
    }
}
