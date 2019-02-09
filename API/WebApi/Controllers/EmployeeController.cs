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
    [RoutePrefix("Employee")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employee;

        public EmployeeController(IEmployeeService employee)
        {
            _employee = employee;
        }
        //create new Employee Detail
        [Route("CreateEmployee")]
        [HttpPost]
        public HttpResponseMessage CreateEmployee(EmployeeInsertDTO employee)
        {
            HttpResponseMessage message;
            try
            {
              //  EmployeeDataAccessLayer dal = new EmployeeDataAccessLayer();
                var dynObj = new { result = _employee.InsertEmployee(employee) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "Employee", "CreateEmployee");
            }
            return message;
        }

        //create new Employee Detail
        [Route("CreateEmployeeBankDtl")]
        [HttpPost]
        public HttpResponseMessage CreateEmployeeBankDtl(EmployeeBankDetailInsertDTO employee)
        {
            HttpResponseMessage message;
            try
            {
              //  EmployeeDataAccessLayer dal = new EmployeeDataAccessLayer();
                var dynObj = new { result = _employee.InsertEmployeeBankDtl(employee) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "Employee", "CreateEmployee");
            }
            return message;
        }

        //update  Employee bank Detail
        [Route("UpdateEmployeeBankDtl")]
        [HttpPost]
        public HttpResponseMessage UpdateEmployeeBankDtl(EmployeeBankDetailInsertDTO employee)
        {
            HttpResponseMessage message;
            try
            {
              //  EmployeeDataAccessLayer dal = new EmployeeDataAccessLayer();
                var dynObj = new { result = _employee.UpdateEmployeeBankDtl(employee) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "Employee", "CreateEmployee");
            }
            return message;
        }

        //Get All Employee Details
        [Route("GetAllEmployees")]
        [HttpPost]
        public HttpResponseMessage GetAllEmployees(EmployeeGetDTO ObjGetEmp)
        {
            HttpResponseMessage message;
            try
            {
              //  EmployeeDataAccessLayer dal = new EmployeeDataAccessLayer();
                var dynObj = new { result = _employee.GetAllEmployees(ObjGetEmp) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Employee", "GetAllEmplloyees");
            }
            return message;
        }

        //Get Employee detail by Employee Id
        [Route("GetEmployeeById")]
        [HttpPost]
        public HttpResponseMessage GetEmployeeById(EmployeeGetDTO ObjGetEmpById)
        {
            HttpResponseMessage message;
            try
            {
              //  EmployeeDataAccessLayer dal = new EmployeeDataAccessLayer();
                var dynObj = new { result = _employee.GetEmployeeById(ObjGetEmpById) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Employee", "GetEmployeeById");
            }
            return message;
        }

        //Get Employee Bank detail by Employee Id
        [Route("GetEmployeeBankDtlById")]
        [HttpGet]
        public HttpResponseMessage GetEmployeeBankDtlById(int id)
        {
            HttpResponseMessage message;
            try
            {
              //  EmployeeDataAccessLayer dal = new EmployeeDataAccessLayer();
                var dynObj = new { result = _employee.GetActiveEmployeeBankDetails(id) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Employee", "GetEmployeeBankById");
            }
            return message;
        }

        //Get All Active Employee Detail
        [Route("GetAllEmployeeDetail")]
        [HttpPost]
        public HttpResponseMessage GetAllEmployeeDetail(EmployeeGetDTO ObjGetEmpById)
        {
            HttpResponseMessage message;
            try
            {
              //  EmployeeDataAccessLayer dal = new EmployeeDataAccessLayer();
                var dynObj = new { result = _employee.GetActiveEmployee(ObjGetEmpById) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Employee", "GetEmployeeById");
            }
            return message;
        }

        //Delete Employee Account Detail by Id
        [Route("RemoveEmployeeBankDtl")]
        [HttpDelete]
        public HttpResponseMessage RemoveEmployeeBankDtl(int id)
        {
            HttpResponseMessage message;
            try
            {
              //  EmployeeDataAccessLayer dal = new EmployeeDataAccessLayer();
                var dynObj = new { result = _employee.RemoveEmployeeBankDtl(id) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "EmployeeAccounts", "RemoveEmployeeAccountById");
            }
            return message;
        }

        //Update Employee datail
        [Route("UpdateEmployee")]
        [HttpPost]
        public HttpResponseMessage UpdateEmployee(EmployeeUpdateDTO employee)
        {
            HttpResponseMessage message;
            try
            {
              //  EmployeeDataAccessLayer dal = new EmployeeDataAccessLayer();
                var dynObj = new { result = _employee.UpdateEmployee(employee) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Employee", "UpdateEmployee");
            }
            return message;
        }


        //Remove Employee Detail 
        [Route("RemoveEmployee")]
        [HttpPost]
        public HttpResponseMessage RemoveEmployee(EmployeeRemoveDTO employee)
        {
            HttpResponseMessage message;
            try
            {
              //  EmployeeDataAccessLayer dal = new EmployeeDataAccessLayer();
                var dynObj = new { result = _employee.RemoveEmployee(employee) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Employee", "DeactiveEmployeeById");
            }
            return message;
        }



    }
}
