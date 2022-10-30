using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class LocationService
    {
        public static List<string> Locations { get { return _Locations(); } }
        private static List<string> _Locations()
        {
            List<string> locations = new List<string>();
            locations.Add("Home");
            locations.Add("Road");

            return locations;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Home" }, { "value", "Home" } },
                new BsonDocument { { "label", "Road" }, { "value", "Road" } },
            };

            DatabaseHelper.AddFilterCollection("locations", array);
        }
    }
}
