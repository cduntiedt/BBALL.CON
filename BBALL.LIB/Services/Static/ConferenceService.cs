using BBALL.LIB.Helpers;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class ConferenceService
    {
        public static List<string> Conferences { get { return _Conferences(); } }
        private static List<string> _Conferences()
        {
            List<string> conferences = new List<string>();
            conferences.Add("East");
            conferences.Add("West");

            return conferences;
        }

        public static void LoadFilter()
        {
            BsonDocument doc = new BsonDocument {
                {
                    "filter", "conferences"
                },
                {
                    "list",
                    new BsonArray
                    {
                        new BsonDocument { { "label", "East" }, { "value", "East" } },
                        new BsonDocument { { "label", "West" }, { "value", "West" } }
                    }
                }
            };

            JArray param = new JArray(ParameterHelper.CreateParameterObject("filter", "conferences"));

            DatabaseHelper.AddUpdateDocument("filters", doc, param);
        }
    }
}
