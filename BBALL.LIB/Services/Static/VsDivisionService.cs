using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class VsDivisionService
    {
        public static List<string> Divisions { get { return _Divisions(); } }
        private static List<string> _Divisions()
        {
            List<string> divisions = new List<string>();
            divisions.Add("Atlantic");
            divisions.Add("Central");
            divisions.Add("Northwest");
            divisions.Add("Pacific");
            divisions.Add("Southeast");
            divisions.Add("Southwest");
            divisions.Add("East");
            divisions.Add("West");

            return divisions;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Atlantic" }, { "value", "Atlantic" } },
                new BsonDocument { { "label", "Central" }, { "value", "Central" } },
                new BsonDocument { { "label", "Northwest" }, { "value", "Northwest" } },
                new BsonDocument { { "label", "Pacific" }, { "value", "Pacific" } },
                new BsonDocument { { "label", "Southeast" }, { "value", "Southeast" } },
                new BsonDocument { { "label", "Southwest" }, { "value", "Southwest" } },
                new BsonDocument { { "label", "East" }, { "value", "East" } },
                new BsonDocument { { "label", "West" }, { "value", "West" } },
            };

            DatabaseHelper.AddFilterCollection("vsDivision", array);
        }
    }
}
