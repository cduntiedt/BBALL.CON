using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Models
{
    /// <summary>
    /// The stat endpoint to call from the api.
    /// </summary>
    public class StatEndpoint
    {
        /// <summary>
        /// The url endpoint.
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// The query parameters of the endpoint
        /// </summary>
        public BsonArray parameters { get; set; }
    }
}
