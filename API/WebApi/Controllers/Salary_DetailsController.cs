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
    [RoutePrefix("Salary_Details")]
    public class Salary_DetailsController : ApiController
    {
        private readonly ISalary_Details _Salary_Dtl;

        public Salary_DetailsController(ISalary_Details Salary_Dtl)
        {
            _Salary_Dtl = Salary_Dtl;
        }

        [HttpPost]
        public HttpResponseMessage CreateSalary_Details(InsertSalary_Details obj)
        {
            HttpResponseMessage message;
            try
            {
               // Salary_DetailsDAL dal = new Salary_DetailsDAL();
                var dynObj = new { result = _Salary_Dtl.InsertSalary_Details(obj) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "Salary _Details", "Create Salary _Details");
            }
            return message;
        }


        //Get All Salary_Details
        [HttpGet]
        public HttpResponseMessage GetAllSalary_Details(int? id)
        {
            HttpResponseMessage message;
            try
            {
               // Salary_DetailsDAL dal = new Salary_DetailsDAL();
                var dynObj = new { result = _Salary_Dtl.GetAllSalary_Detailss(id) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Salary _Details", "GetAll Salary _Details");
            }
            return message;
        }





        //Get Active City detail 
        //[HttpPost]
        //public HttpResponseMessage GetActiveSalary_Details()
        //{
        //    HttpResponseMessage message;
        //    try
        //    {
        //       // Salary_DetailsDAL dal = new Salary_DetailsDAL();
        //        var dynObj = new { result = _Salary_Dtl.GetAllSalary_Detailss() };
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
        public HttpResponseMessage UpdateSalary_Details(UpdateSalary_Details obj)
        {
            HttpResponseMessage message;
            try
            {
               // Salary_DetailsDAL dal = new Salary_DetailsDAL();
                var dynObj = new { result = _Salary_Dtl.UpdateSalary_Details(obj) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Salary _Details", "Update Salary _Details");
            }
            return message;
        }

        //Remove Salary _Details
        [HttpPost]
        public HttpResponseMessage RemoveSalary_Details(int id)
        {
            HttpResponseMessage message;
            try
            {
               // Salary_DetailsDAL dal = new Salary_DetailsDAL();
                var dynObj = new { result = _Salary_Dtl.DeleteSalary_Details(id) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Salary _Details", "Remove Salary _Details");
            }
            return message;
        }
    }
}
