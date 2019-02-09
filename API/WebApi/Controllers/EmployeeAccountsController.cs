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
    [RoutePrefix("EmployeeAccounts")]
    public class EmployeeAccountsController : ApiController
    {
        private readonly IEmployeeAccountService _employee;

        public EmployeeAccountsController(IEmployeeAccountService employee)
        {
            _employee = employee;
        }

        //create new Employee Account Detail
        [HttpPost]
        public HttpResponseMessage CreateEmployeeAccount(EmployeeAccountsInsertDTO account)
        {
            HttpResponseMessage message;
            try
            {
               // EmployeeAccountsDataAccessLayer dal = new EmployeeAccountsDataAccessLayer();
                var dynObj = new { result = _employee.InsertEmployeeAccounts(account) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "EmployeeAccounts", "CreateEmployeeAccounts");
            }
            return message;
        }

        //Get All Employee Accounts Details
        [HttpPost]
        public HttpResponseMessage GetAllEmployeeAccounts(EmplyoeeAccountsGetDTO objGetAccount)
        {
            HttpResponseMessage message;
            try
            {
               // EmployeeAccountsDataAccessLayer dal = new EmployeeAccountsDataAccessLayer();
                var dynObj = new { result = _employee.GetAllEmployeeAccounts(objGetAccount) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "EmployeeAccounts", "GetAllEmplloyeeAccounts");
            }
            return message;
        }

        //Get Employee Account detail by Id
        [HttpPost]
        public HttpResponseMessage GetEmployeeAccountById(EmplyoeeAccountsGetDTO objGetAccById)
        {
            HttpResponseMessage message;
            try
            {
               // EmployeeAccountsDataAccessLayer dal = new EmployeeAccountsDataAccessLayer();
                var dynObj = new { result = _employee.GetEmployeeAccountsById(objGetAccById) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "EmployeeAccount", "GetEmployeeAccounById");
            }
            return message;
        }

        //Check Employee Account detail by Id
        [HttpPost]
        public HttpResponseMessage CheckAccount(GetEmployeeDTO objCheck)
        {
            HttpResponseMessage message;
            try
            {
               // EmployeeAccountsDataAccessLayer dal = new EmployeeAccountsDataAccessLayer();
                var dynObj = new { result = _employee.CheckAccount(objCheck) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "EmployeeAccount", "CheckAccount");
            }
            return message;
        }

        //Get Active Account detail 
        [HttpPost]
        public HttpResponseMessage GetActiveEmployeeAccount(EmplyoeeAccountsGetDTO objActive)
        {
            HttpResponseMessage message;
            try
            {
               // EmployeeAccountsDataAccessLayer dal = new EmployeeAccountsDataAccessLayer();
                var dynObj = new { result = _employee.GetActiveEmployeeAccount(objActive) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "EmployeeAccounts", "GetActiveEmployeeAccount");
            }
            return message;
        }

        //Get In Active Account detail 
        [HttpPost]
        public HttpResponseMessage GetInActiveEmployeeAccount(EmplyoeeAccountsGetDTO objInActive)
        {
            HttpResponseMessage message;
            try
            {
               // EmployeeAccountsDataAccessLayer dal = new EmployeeAccountsDataAccessLayer();
                var dynObj = new { result = _employee.GetInActiveEmployeeAccount(objInActive) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "EmployeeAccount", "GetInActiveEmployeeAccount");
            }
            return message;
        }

        //Update Employee datail
        [HttpPost]
        public HttpResponseMessage UpdateEmployeeAccount(EmployeeAccountsUpdateDTO account)
        {
            HttpResponseMessage message;
            try
            {
               // EmployeeAccountsDataAccessLayer dal = new EmployeeAccountsDataAccessLayer();
                var dynObj = new { result = _employee.UpdateEmployeeAccounts(account) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "EmployeeAccounts", "UpdateEmployeeAccount");
            }
            return message;
        }

        //Deactive Employee Account Detail by Id
        [HttpPost]
        public HttpResponseMessage RemoveEmployeeAccountById(EmployeeAccountRemoveDTO objRemoveAcc)
        {
            HttpResponseMessage message;
            try
            {
               // EmployeeAccountsDataAccessLayer dal = new EmployeeAccountsDataAccessLayer();
                var dynObj = new { result = _employee.RemoveEmployeeAccount(objRemoveAcc) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "EmployeeAccounts", "RemoveEmployeeAccountById");
            }
            return message;
        }

       

        //Get Active Employee detail 
        [HttpPost]
        public HttpResponseMessage GetEmployee(EmplyoeeAccountsGetDTO objGetEmployee)
        {
            HttpResponseMessage message;
            try
            {
               // EmployeeAccountsDataAccessLayer dal = new EmployeeAccountsDataAccessLayer();
                var dynObj = new { result = _employee.GetEmployee(objGetEmployee) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "EmployeeAccounts", "GetEmployee");
            }
            return message;
        }




    }
}
