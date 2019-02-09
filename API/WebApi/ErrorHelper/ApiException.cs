﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Runtime.Serialization;

namespace WebApi.ErrorHelper
{

    public class ApiException : Exception, IApiExceptions
    {

        #region Public Serializable properties.
        [DataMember]
        public int ErrorCode { get; set; }
        [DataMember]
        public string ErrorDescription { get; set; }
        [DataMember]
        public HttpStatusCode HttpStatus { get; set; }
        
        string reasonPhrase = "ApiException";
        [DataMember]
        public string ReasonPhrase
        {
            get { return this.reasonPhrase; }
            set { this.reasonPhrase = value; }
        }
        #endregion
    }
}