using BBALL.LIB.Helpers;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace BBALL.LIB.Models
{
    public class StatQuery
    {
        public string Url { get; set; }
        public string Collection { get; set; }
        public BsonArray Parameters { get; set; } = null;
        public int CallCount { get; set; }
        public bool Parse { get; set; } = true;
        public int Timeout { get; set; } = 15;
        public bool SkipDate { get; set; }
        public string ResultSet { get; set; } = "resultSets";

        public StatQuery(string url, string collection, BsonArray parameters, bool parse, int timeout, string resultSet)
        {
            if (parameters == null)
            {
                var queryString = HttpUtility.ParseQueryString(url);

                foreach (var item in queryString.AllKeys)
                {
                    parameters.Add(ParameterHelper.CreateParameterObject(item, queryString[item]));
                }
            }
            else
            {
                url = StatsHelper.GenerateUrl(url, parameters);
            }

            Url = url;
            Collection = collection;
            Parameters = parameters;
            Parse = parse;
            Timeout = timeout;
            ResultSet = resultSet;
        }
    }
}
