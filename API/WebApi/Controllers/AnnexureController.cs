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
    [RoutePrefix("Annexure")]
    public class AnnexureController : ApiController
    {

        private readonly AnnexureDataAccessLayer _Annexure;

        public AnnexureController(AnnexureDataAccessLayer Annexure)
        {
            this._Annexure = Annexure;
        }
        //Get Annexure Report 
        [HttpPost]
        public HttpResponseMessage GetAnnexureReport(AnnexureGetDTO objAnnexure)
        {
            HttpResponseMessage message;
            try
            {             
                var dynObj = new { result = _Annexure.GetAnnexureReport(objAnnexure) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Annexure", "GetAnnexureReport");
            }
            return message;
        }
    }
}
