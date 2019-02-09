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
    [RoutePrefix("Mapping_SalaryComponents")]
    
    public class Mapping_SalaryComponentsController : ApiController
    {
        private readonly IMappingSalaryComponent _salary;

        public Mapping_SalaryComponentsController(IMappingSalaryComponent salary)
        {
            _salary = salary;
        }
        [HttpPost]
        public HttpResponseMessage CreateMapping_SalaryComponents(InsertMapping_SalaryComponents obj)
        {
            HttpResponseMessage message;
            try
            {
               // Mapping_SalaryComponentsDAL dal = new Mapping_SalaryComponentsDAL();
                var dynObj = new { result = _salary.InsertMapping_SalaryComponents(obj) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "Mapping_SalaryComponents", "Create Mapping_SalaryComponents");
            }
            return message;
        }


        //Get All SalaryComponent
        [HttpGet]
        public HttpResponseMessage GetAllMapping_SalaryComponents(int? id)
        {
            HttpResponseMessage message;
            try
            {
               // Mapping_SalaryComponentsDAL dal = new Mapping_SalaryComponentsDAL();
                var dynObj = new { result = _salary.GetAllMapping_SalaryComponentss(id) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Mapping_SalaryComponents", "GetAll Mapping_SalaryComponents");
            }
            return message;
        }





        //Get Active City detail 
        //[HttpPost]
        //public HttpResponseMessage GetActiveMapping_SalaryComponents()
        //{
        //    HttpResponseMessage message;
        //    try
        //    {
        //       // Mapping_SalaryComponentsDAL dal = new Mapping_SalaryComponentsDAL();
        //        var dynObj = new { result = _salary.GetAllMapping_SalaryComponentss() };
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
        public HttpResponseMessage UpdateSalaryComponent(UpdateMapping_SalaryComponents obj)
        {
            HttpResponseMessage message;
            try
            {
               // Mapping_SalaryComponentsDAL dal = new Mapping_SalaryComponentsDAL();
                var dynObj = new { result = _salary.UpdateMapping_SalaryComponents(obj) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Mapping_SalaryComponents", "Update Mapping_SalaryComponents");
            }
            return message;
        }

        //Remove Mapping_SalaryComponents
        [HttpPost]
        public HttpResponseMessage RemoveMapping_SalaryComponents(int id)
        {
            HttpResponseMessage message;
            try
            {
               // Mapping_SalaryComponentsDAL dal = new Mapping_SalaryComponentsDAL();
                var dynObj = new { result = _salary.DeleteMapping_SalaryComponents(id) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Mapping_SalaryComponents", "Remove Mapping_SalaryComponents");
            }
            return message;
        }
    }
}
