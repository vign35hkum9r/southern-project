using BusinessEntities;
using BusinessServives;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class EmployeeAttendanceController : ApiController
    {

        //Create new Employee Attendance
        [HttpPost]
        public HttpResponseMessage CreateEmployeeAttendance(EmployeeAttendanceInsertDTO attendance)
        {
            HttpResponseMessage message;
            try
            {
                EmployeeAttendanceDataAccessLayer dal = new EmployeeAttendanceDataAccessLayer();
                var dynObj = new { result = dal.InsertEmployeeAttendance(attendance) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "EmployeeAttendance", "CreateEmployeeAttendance");
            }
            return message;
        }

        //Get All Employee Attendance Details
        [HttpPost]
        public HttpResponseMessage GetAllEmployeeAttendance()
        {
            HttpResponseMessage message;
            try
            {
                EmployeeAttendanceDataAccessLayer dal = new EmployeeAttendanceDataAccessLayer();
                var dynObj = new { result = dal.GetAllEmployeeAttendance() };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "EmployeeAttendance", "GetAllEmployeeAttendance");
            }
            return message;
        }

        //Get Customer by Customer Id
        [HttpPost]
        public HttpResponseMessage GetEmployeeAttendanceById(int id)
        {
            HttpResponseMessage message;
            try
            {
                EmployeeAttendanceDataAccessLayer dal = new EmployeeAttendanceDataAccessLayer();
                var dynObj = new { result = dal.GetByEmployeeAttendanceId(id) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "EmployeeAttendance", "GetEmployeeAttendanceById");
            }
            return message;
        }

        //Update Contract Master datail
        [HttpPost]
        public HttpResponseMessage UpdateEmployeeAttendance(EmployeeAttendanceUpdateDTO attendance)
        {
            HttpResponseMessage message;
            try
            {
                EmployeeAttendanceDataAccessLayer dal = new EmployeeAttendanceDataAccessLayer();
                var dynObj = new { result = dal.UpdateEmployeeAttendance(attendance) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "EmployeeAttendance", "UpdateEmployeeAttendance");
            }
            return message;
        }

        //Deactive Contract Master by Contract Master Id
        [HttpPost]
        public HttpResponseMessage DeactivateEmployeeAttendanceById(int id)
        {
            HttpResponseMessage message;
            try
            {
                EmployeeAttendanceDataAccessLayer dal = new EmployeeAttendanceDataAccessLayer();
                var dynObj = new { result = dal.DeactivateEmployeeAttendance(id) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "EmployeeAttendance", "DeactivateEmployeeAttendanceById");
            }
            return message;
        }

    }
}
