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
    [RoutePrefix("CompanyHoliday")]
    public class CompanyHolidayController : ApiController
    {
        private readonly ICompanyHolidayService _companyServices;

        public CompanyHolidayController(ICompanyHolidayService company)
        {
            _companyServices = company;
        }
        //create new CompanyHoliday Detail
        [HttpPost]
        public HttpResponseMessage CreateCompanyHoliday(CompanyHolidayInsertDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // CompanyHolidayDataAccessLayer dal = new CompanyHolidayDataAccessLayer();
                var dynObj = new { result = _companyServices.InsertCompanyHoliday(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "Leave", "CompanyHoliday");
            }
            return message;
        }

        //Get All CompanyHoliday Details
        [HttpPost]
        public HttpResponseMessage GetAllCompanyHoliday(CompanyHolidayGetDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // CompanyHolidayDataAccessLayer dal = new CompanyHolidayDataAccessLayer();
                var dynObj = new { result = _companyServices.GetAllCompanyHoliday(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Leave", "GetAllCompanyHoliday");
            }
            return message;
        }

        //Get Leavae Detail by Id
        [HttpPost]
        public HttpResponseMessage GetCompanyHolidayById(CompanyHolidayGetDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // CompanyHolidayDataAccessLayer dal = new CompanyHolidayDataAccessLayer();
                var dynObj = new { result = _companyServices.GetCompanyHolidayById(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Leave", "CompanyHolidayById");
            }
            return message;
        }

        //Update Leave datail
        [HttpPost]
        public HttpResponseMessage UpdateCompanyHoliday(CompanyHolidayUpdateDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // CompanyHolidayDataAccessLayer dal = new CompanyHolidayDataAccessLayer();
                var dynObj = new { result = _companyServices.UpdateCompanyHoliday(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Leave", "UpdateCompanyHoliday");
            }
            return message;
        }

        //Remove Leave Detail by Id
        [HttpPost]
        public HttpResponseMessage RemoveCompanyHoliday(CompanyHolidayRemoveDTO objLeave)
        {
            HttpResponseMessage message;
            try
            {
               // CompanyHolidayDataAccessLayer dal = new CompanyHolidayDataAccessLayer();
                var dynObj = new { result = _companyServices.DeactivateCompanyHoliday(objLeave) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Leave", "DeactivateCompanyHoliday");
            }
            return message;
        }
    }
}
