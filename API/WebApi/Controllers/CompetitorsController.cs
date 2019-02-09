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
    [RoutePrefix("Competitors")]
    public class CompetitorsController : ApiController
    {
        private readonly ICompetitors _CompetitorsServices;

        public CompetitorsController(ICompetitors Competitors)
        {
            _CompetitorsServices = Competitors;
        }

        //Create new Competitors 
        [HttpPost]
        public HttpResponseMessage CreateCompetitors(CompetitorsInsertDTO objCompetitors)
        {
            HttpResponseMessage message;
            try
            {
                CompetitorsDataAccessLayer dal = new CompetitorsDataAccessLayer();
                var dynObj = new { result = dal.InsertCompetitors(objCompetitors) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Something wrong. Try Again!" });

                ErrorLog.CreateErrorMessage(ex, "Competitors", "CreateCompetitors");
            }
            return message;
        }
        //Get All Competitors
        [HttpPost]
        public HttpResponseMessage GetAllCompetitors(CompetitorsGetDTO objCompetitors)
        {
            HttpResponseMessage message;
            try
            {
                CompetitorsDataAccessLayer dal = new CompetitorsDataAccessLayer();
                var dynObj = new { result = dal.GetAllCompetitors(objCompetitors) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Competitors", "GetAllCompetitors");
            }
            return message;
        }
        //Get Competitors by Client Id
        [HttpPost]
        public HttpResponseMessage GetCompetitorsById(CompetitorsGetDTO objCompetitors)
        {
            HttpResponseMessage message;
            try
            {
                CompetitorsDataAccessLayer dal = new CompetitorsDataAccessLayer();
                var dynObj = new { result = dal.GetCompetitorsById(objCompetitors) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Competitors", "GetAllCompetitors");
            }
            return message;
        }
        //Update Competitors
        [HttpPost]
        public HttpResponseMessage UpdateCompetitors(CompetitorsUpdateDTO objCompetitors)
        {
            HttpResponseMessage message;
            try
            {
                CompetitorsDataAccessLayer dal = new CompetitorsDataAccessLayer();
                var dynObj = new { result = dal.UpdateCompetitors(objCompetitors) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Somthing wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Competitors", "UpdateCompetitors");
            }
            return message;
        }
        //Remove Competitors by Client Id
        [HttpPost]
        public HttpResponseMessage RemoveCompetitors(CompetitorsRemoveDTO objCompetitors)
        {
            HttpResponseMessage message;
            try
            {
                CompetitorsDataAccessLayer dal = new CompetitorsDataAccessLayer();
                var dynObj = new { result = dal.RemoveCompetitors(objCompetitors) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "Competitors", "RemoveCompetitors");
            }
            return message;
        }

    }
}
