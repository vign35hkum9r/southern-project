﻿
//using System.Net;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;

//namespace WebApi.Filters
//{
//    public class ValidationActionFilter : ActionFilterAttribute
//    {
//        public override void OnActionExecuting(HttpActionContext actionContext)
//        {
//            var modelState = actionContext.ModelState;

//            if (!modelState.IsValid)
//                actionContext.Response = actionContext.Request
//                     .CreateErrorResponse(HttpStatusCode.BadRequest, modelState);
//        }
//    }
//}