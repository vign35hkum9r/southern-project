﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApi.Helpers
{
    public class ServiceStatus
    {
        /// <summary>
        /// Get/Set property for accessing Status Code
        /// </summary>
        [JsonProperty("StatusCode")]
        [DataMember]
        public int StatusCode { get; set; }
        /// <summary>
        /// Get/Set property for accessing Status Message
        /// </summary>
        [JsonProperty("StatusMessage")]
        [DataMember]
        public string StatusMessage { get; set; }
        /// <summary>
        /// Get/Set property for accessing Status Message
        /// </summary>
        [JsonProperty("ReasonPhrase")]
        [DataMember]
        public string ReasonPhrase { get; set; }

    }
}