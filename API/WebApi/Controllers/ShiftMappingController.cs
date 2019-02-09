
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
    [RoutePrefix("ShiftMapping")]
    public class ShiftMappingController : ApiController
    {
        private readonly IShiftMapping _Shift;

        public ShiftMappingController(IShiftMapping Shift)
        {
            this._Shift = Shift;
        }
        //create new shiftMapping Detail
        [HttpPost]
        public HttpResponseMessage InsertShiftMapping(ShiftMappingInsertDTO shiftmapping)
        {
            HttpResponseMessage message;
            try
            {
              //  ShiftMappingDataAccessLayer dal = new ShiftMappingDataAccessLayer();
                var dynObj = new { result = _Shift.InsertShiftMapping(shiftmapping) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "ShiftMapping", "InsertShiftMapping");
            }
            return message;
        }
        //Get All ShiftMapping Details
        [HttpPost]
        public HttpResponseMessage GetAllShiftMapping(ShiftMappingGetDTO objGetShiftMapping)
        {
            HttpResponseMessage message;
            try
            {
              //  ShiftMappingDataAccessLayer dal = new ShiftMappingDataAccessLayer();
                var dynObj = new { result = _Shift.GetAllShiftMapping(objGetShiftMapping) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ShiftMapping", "GetAllShiftMapping");
            }
            return message;
        }

        //Get All Shift By Contract
        [HttpPost]
        public HttpResponseMessage GetAllShiftByContract(ShiftMappingGetDTO objGetShiftMapping)
        {
            HttpResponseMessage message;
            try
            {
              //  ShiftMappingDataAccessLayer dal = new ShiftMappingDataAccessLayer();
                var dynObj = new { result = _Shift.GetAllShiftByContract(objGetShiftMapping) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ShiftMapping", "GetAllShiftByContract");
            }
            return message;
        }
        //get All Customer 
        [HttpPost]
        public HttpResponseMessage GetAllCustomerShiftMapping(ShiftMappingGetDTO objGetAllCustomer)
        {
            HttpResponseMessage message;
            try
            {
              //  ShiftMappingDataAccessLayer dal = new ShiftMappingDataAccessLayer();
                var dynObj = new { result = _Shift.GetAllCustomerShiftMapping(objGetAllCustomer) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ShiftMapping", "GetAllCustomerShiftMapping");
            }
            return message;
        }
        //Get ShiftMapping detail by ShiftId
        [HttpPost]
        public HttpResponseMessage GetShiftMappingById(ShiftMappingGetDTO objGetShiftMappingById)
        {
            HttpResponseMessage message;
            try
            {
              //  ShiftMappingDataAccessLayer dal = new ShiftMappingDataAccessLayer();
                var dynObj = new { result = _Shift.GetShiftMappingById(objGetShiftMappingById) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ShiftMapping", "GetShiftMappingById");
            }
            return message;
        }
        //Update Shift mapping datail
        [HttpPost]
        public HttpResponseMessage UpdateShiftMapping(ShiftMappingUpdateDTO shiftmapping)
        {
            HttpResponseMessage message;
            try
            {
              //  ShiftMappingDataAccessLayer dal = new ShiftMappingDataAccessLayer();
                var dynObj = new { result = _Shift.UpdateShiftMapping(shiftmapping) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ShiftMapping", "UpdateShiftMapping");
            }
            return message;
        }
        //remove All Shift mapping Detail
        [HttpPost]
        public HttpResponseMessage RemoveAllShiftMapping(ShiftMappingRemoveDTO objRemoveShiftMapping)
        {
            HttpResponseMessage message;
            try
            {
              //  ShiftMappingDataAccessLayer dal = new ShiftMappingDataAccessLayer();
                var dynObj = new { result = _Shift.RemoveAllShiftMapping(objRemoveShiftMapping) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ShiftMapping", "RemoveAllShiftMapping");
            }
            return message;
        }
        //Remove Shift mapping Detail By Id
        [HttpPost]
        public HttpResponseMessage RemoveShiftMappingById(ShiftMappingRemoveDTO objRemoveShiftMapping)
        {
            HttpResponseMessage message;
            try
            {
              //  ShiftMappingDataAccessLayer dal = new ShiftMappingDataAccessLayer();
                var dynObj = new { result = _Shift.RemoveShiftMapping(objRemoveShiftMapping) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ShiftMapping", "RemoveShiftMappingById");
            }
            return message;
        }
    }
}
