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
    [RoutePrefix("ShiftMaster")]
    public class ShiftMasterController : ApiController
    {
        private readonly IShiftMaster _Shift;

        public ShiftMasterController(IShiftMaster Shift)
        {
            this._Shift = Shift;
        }
        //create new shift Detail
        [HttpPost]
        public HttpResponseMessage InsertShift(ShiftInsertDTO shift)
        {
            HttpResponseMessage message;
            try
            {
               // ShiftMasterDataAccessLayer dal = new ShiftMasterDataAccessLayer();
                var dynObj = new { result = _Shift.InsertShift(shift) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "Shift", "InsertShift");
            }
            return message;
        }
        //Get All Shift Details
        [HttpPost]
        public HttpResponseMessage GetAllShifts(ShiftGetDTO objGetShift)
        {
            HttpResponseMessage message;
            try
            {
               // ShiftMasterDataAccessLayer dal = new ShiftMasterDataAccessLayer();
                var dynObj = new { result = _Shift.GetAllShifts(objGetShift) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Shift", "GetAllShifts");
            }
            return message;
        }

        //Get Shift detail by ShiftId
        [HttpPost]
        public HttpResponseMessage GetShiftById(ShiftGetDTO objGetShiftById)
        {
            HttpResponseMessage message;
            try
            {
               // ShiftMasterDataAccessLayer dal = new ShiftMasterDataAccessLayer();
                var dynObj = new { result = _Shift.GetShiftById(objGetShiftById) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Shift", "GetShiftById");
            }
            return message;
        }
        //Update Shift datail
        [HttpPost]
        public HttpResponseMessage UpdateShift(ShiftUpdateDTO shift)
        {
            HttpResponseMessage message;
            try
            {
               // ShiftMasterDataAccessLayer dal = new ShiftMasterDataAccessLayer();
                var dynObj = new { result = _Shift.UpdateShift(shift) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Shift", "UpdateShift");
            }
            return message;
        }
        //remove All Shift Detail
        [HttpPost]
        public HttpResponseMessage RemoveAllShift(ShiftRemoveDTO objRemoveShift)
        {
            HttpResponseMessage message;
            try
            {
               // ShiftMasterDataAccessLayer dal = new ShiftMasterDataAccessLayer();
                var dynObj = new { result = _Shift.RemoveAllShift(objRemoveShift) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Shift", "RemoveAllShift");
            }
            return message;
        }

        //Remove Shift Detail By Id
        [HttpPost]
        public HttpResponseMessage RemoveShiftById(ShiftRemoveDTO objRemoveShift)
        {
            HttpResponseMessage message;
            try
            {
               // ShiftMasterDataAccessLayer dal = new ShiftMasterDataAccessLayer();
                var dynObj = new { result = _Shift.RemoveShift(objRemoveShift) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Shift", "RemoveShiftById");
            }
            return message;
        }
    }
}
