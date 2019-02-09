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
    [RoutePrefix("SalaryComponent")]
    public class SalaryComponentController : ApiController
    {
        private readonly ISalaryComponent _salaryServices;

        public SalaryComponentController(ISalaryComponent salary)
        {
            _salaryServices = salary;
        }

        [HttpPost]
        public HttpResponseMessage CreateSalaryComponent(InsertSalaryComponent obj)
        {
            HttpResponseMessage message;
            try
            {
               // SalaryComponentDAL dal = new SalaryComponentDAL();
                var dynObj = new { result = _salaryServices.InsertSalaryComponent(obj) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "Salary Component", "Create Salary Component");
            }
            return message;
        }


        //Get All SalaryComponent
        [HttpGet]
        public HttpResponseMessage GetAllSalaryComponent(int? id)
        {
            HttpResponseMessage message;
            try
            {
               // SalaryComponentDAL dal = new SalaryComponentDAL();
                var dynObj = new { result = _salaryServices.GetAllSalaryComponents(id) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Salary Component", "GetAll Salary Component");
            }
            return message;
        }

        

       

        //Get Active City detail 
        //[HttpPost]
        //public HttpResponseMessage GetActiveSalaryComponent()
        //{
        //    HttpResponseMessage message;
        //    try
        //    {
        //       // SalaryComponentDAL dal = new SalaryComponentDAL();
        //        var dynObj = new { result = _salaryServices.GetAllSalaryComponents() };
        //        message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
        //    }
        //    catch (Exception ex)
        //    {
        //        message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
        //        ErrorLog.CreateErrorMessage(ex, "CityMaster", "GetActiveCity");
        //    }
        //    return message;
        //}

       

        //Update City datail
        [HttpPost]
        public HttpResponseMessage UpdateSalaryComponent(UpdateSalaryComponent obj)
        {
            HttpResponseMessage message;
            try
            {
               // SalaryComponentDAL dal = new SalaryComponentDAL();
                var dynObj = new { result = _salaryServices.UpdateSalaryComponent(obj) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Salary Component", "Update Salary Component");
            }
            return message;
        }

        //Remove Salary Component
        [HttpPost]
        public HttpResponseMessage RemoveSalaryComponent(int id)
        {
            HttpResponseMessage message;
            try
            {
               // SalaryComponentDAL dal = new SalaryComponentDAL();
                var dynObj = new { result = _salaryServices.DeleteSalaryComponent(id) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Salary Component", "Remove Salary Component");
            }
            return message;
        }
    }
}
