using BusinessEntities;
using BusinessServices;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.ActionFilters;

namespace WebApi.Controllers
{
    // [AuthorizationRequired]
    [RoutePrefix("ManpowerAttendance")]
    public class ManpowerAttendanceController : ApiController
    {
        private readonly IManpowerAttendance _obj;

        public ManpowerAttendanceController(IManpowerAttendance obj)
        {
            _obj = obj;
        }
        //Create Attendance
        [Route("CreateAttendance")]
        [HttpPost]
        public HttpResponseMessage CreateAttendance(AddManpowerAttendanceDTO attendance)
        {
            HttpResponseMessage message;
            try
            {
               // ManpowerAttendanceDAL dal = new ManpowerAttendanceDAL();
                var dynObj = new { result = _obj.InsertAttendanceMaster(attendance) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "ManpowerAttendance", "CreateAttendance");
            }
            return message;
        }

        //get Attendance By Pivort view
        [Route("GetAllAttendance")]
        [HttpPost]
        public HttpResponseMessage GetAllAttendance(AttendancePopup Popup)
        {
            HttpResponseMessage message;
            try
            {
               // ManpowerAttendanceDAL dal = new ManpowerAttendanceDAL();
                DataSet des = _obj.getAllAttendance(Popup);
                DynamicTableDTO dyTbl;
                if(des.Tables.Count < 1)
                {
                  dyTbl=null;
                }
                else
                {
                    dyTbl = new DynamicTableDTO(des.Tables[0]);
                }              
                var dynObj = new { result = dyTbl };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "ManpowerAttendance", "CreateAttendance");
            }
            return message;
        }

        //get All Customer
        [Route("getAllCustomer")]
        [HttpPost]
        public HttpResponseMessage getAllCustomer(ManpowerAttendanceCustomerDTO customer)
        {
            HttpResponseMessage message;
            try
            {
               // ManpowerAttendanceDAL dal = new ManpowerAttendanceDAL();
                var dynObj = new { result = _obj.GetAllCustomer(customer) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "ManpowerAttendance", "getAllCustomer");
            }
            return message;
        }

        //get All Branch
        [Route("getAllBranch")]
        [HttpPost]
        public HttpResponseMessage getAllBranch(ManpowerAttendanceBranchDTO branch)
        {
            HttpResponseMessage message;
            try
            {
               // ManpowerAttendanceDAL dal = new ManpowerAttendanceDAL();
                var dynObj = new { result = _obj.GetAllBranch(branch) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "ManpowerAttendance", "getAllBranch");
            }
            return message;
        }

        //get All Aite
        [Route("getAllSite")]
        [HttpPost]
        public HttpResponseMessage getAllSite(ManpowerAttendanceSiteDTO site)
        {
            HttpResponseMessage message;
            try
            {
               // ManpowerAttendanceDAL dal = new ManpowerAttendanceDAL();
                var dynObj = new { result = _obj.GetAllSite(site) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "ManpowerAttendance", "getAllSite");
            }
            return message;
        }

        //get All Classification
        [Route("getAllClassification")]
        [HttpPost]
        public HttpResponseMessage getAllClassification(ManpowerAttendanceClassificationDTO classification)
        {
            HttpResponseMessage message;
            try
            {
               // ManpowerAttendanceDAL dal = new ManpowerAttendanceDAL();
                var dynObj = new { result = _obj.GetAllClassification(classification) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "ManpowerAttendance", "getAllClassification");
            }
            return message;
        }


        //get All Employee
        [Route("getAllEmployee")]
        [HttpPost]
        public HttpResponseMessage getAllEmployee(ManpowerAttendanceEmployeeList employee)
        {
            HttpResponseMessage message;
            try
            {
               // ManpowerAttendanceDAL dal = new ManpowerAttendanceDAL();
                var dynObj = new { result = _obj.GetAllEmployee(employee) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "ManpowerAttendance", "getAllEmployee");
            }
            return message;
        }

        //get All Status
        [Route("getAllStatus")]
        [HttpPost]
        public HttpResponseMessage getAllStatus(ManpowerStatusDTO status)
        {
            HttpResponseMessage message;
            try
            {
               // ManpowerAttendanceDAL dal = new ManpowerAttendanceDAL();
                var dynObj = new { result = _obj.GetAllStatus(status) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "ManpowerAttendance", "getAllStatus");
            }
            return message;
        }

        //Update Attendance
        [Route("UpdateAttendance")]
        [HttpPost]
        public HttpResponseMessage UpdateAttendance(UpdateAttendance status)
        {
            HttpResponseMessage message;
            try
            {
               // ManpowerAttendanceDAL dal = new ManpowerAttendanceDAL();
                var dynObj = new { result = _obj.UpdateAttendanceMaster(status) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "ManpowerAttendance", "getAllStatus");
            }
            return message;
        }

        [Route("InsertAttendanceHistory")]
        [HttpPost]
        public HttpResponseMessage InsertAttendanceHistory(InsertAttendanceHistory obj)
        {
            HttpResponseMessage message;
            try
            {
               // ManpowerAttendanceDAL dal = new ManpowerAttendanceDAL();
                var dynObj = new { result = _obj.InsertAttendanceHistory(obj) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Attendance History", "Insert Attendance History");
            }
            return message;
        }

    }
}
