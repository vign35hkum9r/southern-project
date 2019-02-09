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
    [RoutePrefix("SalaryAllocation")]
    
    public class SalaryAllocationController : ApiController
    {

        private readonly ISalaryAllocation _SalaryAllocation;
        
        public SalaryAllocationController(ISalaryAllocation SalaryAllocation)
        {
            _SalaryAllocation = SalaryAllocation;
        }

        //Get All Department
        [HttpPost]
        public HttpResponseMessage GetAllSalaryAllocation(getSalaryAllocation obj)
        {
            HttpResponseMessage message;
            try
            {
               // salaryAllocationDataAccessLayer dal = new salaryAllocationDataAccessLayer();
                var dynObj = new { result = _SalaryAllocation.GetAllSalaryDetail(obj) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "SalaryAllocation", "GetAllDepartment");
            }
            return message;
        }

        //Get All Department
        [HttpPost]
        public HttpResponseMessage GetAllDepartment(getDepartmentByEmployeeType obj)
        {
            HttpResponseMessage message;
            try
            {
               // salaryAllocationDataAccessLayer dal = new salaryAllocationDataAccessLayer();
                var dynObj = new { result = _SalaryAllocation.GetAllDepartment(obj) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "SalaryAllocation", "GetAllDepartment");
            }
            return message;
        }

        //Get All Salary By Employee
        [HttpPost]
        public HttpResponseMessage GetAllSalaryByEmployee(getSalaryAllocation obj)
        {
            HttpResponseMessage message;
            try
            {
               // salaryAllocationDataAccessLayer dal = new salaryAllocationDataAccessLayer();
                var dynObj = new { result = _SalaryAllocation.GetAllSalaryAllocation(obj) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "SalaryAllocation", "GetAllSalaryByEmployee");
            }
            return message;
        }

        //Get All Designation
        [HttpPost]
        public HttpResponseMessage GetAllDesignation(getDesignationByDepartment obj)
        {
            HttpResponseMessage message;
            try
            {
               // salaryAllocationDataAccessLayer dal = new salaryAllocationDataAccessLayer();
                var dynObj = new { result = _SalaryAllocation.GetAllDesignation(obj) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "SalaryAllocation", "GetAllDesignation");
            }
            return message;
        }

          //Get All Employee
        [HttpPost]
        public HttpResponseMessage GetAllEmployee(getEmployeeByDesignation obj)
        {
            HttpResponseMessage message;
            try
            {
               // salaryAllocationDataAccessLayer dal = new salaryAllocationDataAccessLayer();
                var dynObj = new { result = _SalaryAllocation.GetAllEmployee(obj) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "SalaryAllocation", "GetAllEmployee");
            }
            return message;
        }

        //Create Salary Allocation
        [HttpPost]
        public HttpResponseMessage CreateSalaryAllocation(List<InsertSalaryAllocation> obj)
        {
            HttpResponseMessage message;
            try
            {
               // salaryAllocationDataAccessLayer dal = new salaryAllocationDataAccessLayer();
                var dynObj = new { result = _SalaryAllocation.InsertSalaryAllocation(obj) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "SalaryAllocation", "CreateSalaryAllocation");
            }
            return message;
        }
    }
}
