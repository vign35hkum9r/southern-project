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
    [RoutePrefix("Customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomer _Customer;

        public CustomerController(ICustomer Customer)
        {
            _Customer = Customer;
        }
        //create new Customer
        [Route("CreateCustomer")]
        [HttpPost]
        public HttpResponseMessage CreateCustomer(CustomerInsertDTO customer)
        {
            HttpResponseMessage message;
            try
            {
              //  CustomerDataAccessLayer dal = new CustomerDataAccessLayer();
                var dynObj = new { result = _Customer.InsertCustomer(customer) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "Customer", "CreateCustomer");
            }
            return message;
        }

        //Get All Customers
        [Route("GetAllCustomers")]
        [HttpPost]
        public HttpResponseMessage GetAllCustomers(CustomerGetDTO objCustomer)
        {
            HttpResponseMessage message;
            try
            {
              //  CustomerDataAccessLayer dal = new CustomerDataAccessLayer();
                var dynObj = new { result = _Customer.GetAllCustomers(objCustomer) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Customer", "GetAllCustomers");
            }
            return message;
        }

        //Get All Customers
        [Route("GetAllSuccessCustomers")]
        [HttpPost]
        public HttpResponseMessage GetAllSuccessCustomers(GetSuccessCustomerDTO objCustomer)
        {
            HttpResponseMessage message; 
            try
            {
              //  CustomerDataAccessLayer dal = new CustomerDataAccessLayer();
                var dynObj = new { result = _Customer.GetAllSuccessCustomers(objCustomer) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Customer", "GetAllSuccessCustomers");
            }
            return message;
        }

        //Get Customer by Customer Id
        [Route("GetCustomerById")]
        [HttpPost]
        public HttpResponseMessage GetCustomerById(CustomerGetDTO objCustomer)
        {
            HttpResponseMessage message;
            try
            {
              //  CustomerDataAccessLayer dal = new CustomerDataAccessLayer();
                var dynObj = new { result = _Customer.GetCustomerById(objCustomer) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Customer", "GetCustomerById");
            }
            return message;
        }

        //Get Active Customer detail 
        [Route("GetActiveCustomer")]
        [HttpPost]
        public HttpResponseMessage GetActiveCustomer(CustomerGetDTO objCustomer)
        {
            HttpResponseMessage message;
            try
            {
              //  CustomerDataAccessLayer dal = new CustomerDataAccessLayer();
                var dynObj = new { result = _Customer.GetActiveCustomer(objCustomer) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Customer", "GetActiveCustomer");
            }
            return message;
        }

        //Move to Customer
        [Route("MoveCustomer")]
        [HttpPost]
        public HttpResponseMessage MoveCustomer(CustomertoMove objCustomer)
        {
            HttpResponseMessage message;
            try
            {
              //  CustomerDataAccessLayer dal = new CustomerDataAccessLayer();
                var dynObj = new { result = _Customer.MoveCustomer(objCustomer) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Customer", "MoveCustomer");
            }
            return message;
        }


        //Get In Active Customer detail 
        [Route("GetInActiveCustomer")]
        [HttpPost]
        public HttpResponseMessage GetInActiveCustomer(CustomerGetDTO objCustomer)
        {
            HttpResponseMessage message;
            try
            {
              //  CustomerDataAccessLayer dal = new CustomerDataAccessLayer();
                var dynObj = new { result = _Customer.GetInActiveCustomer(objCustomer) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Customer", "GetInActiveCustomer");
            }
            return message;
        }

        //Update Customer datail
        [Route("UpdateCustomer")]
        [HttpPost]
        public HttpResponseMessage UpdateCustomer(CustomerUpdateDTO objCustomer)
        {
            HttpResponseMessage message;
            try
            {
              //  CustomerDataAccessLayer dal = new CustomerDataAccessLayer();
                var dynObj = new { result = _Customer.UpdateCustomer(objCustomer) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Customer", "UpdateCustomer");
            }
            return message;
        }

        //Remove Customer by Customer Id
        [Route("RemoveCustomerById")]
        [HttpPost]
        public HttpResponseMessage RemoveCustomerById(CustomerRemoveDTO objRemoveCus)
        {
            HttpResponseMessage message;
            try
            {
              //  CustomerDataAccessLayer dal = new CustomerDataAccessLayer();
                var dynObj = new { result = _Customer.RemoveCustomerById(objRemoveCus) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Customer", "RemoveCustomerById");
            }
            return message;
        }
    }
}
