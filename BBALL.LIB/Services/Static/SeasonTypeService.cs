using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services
{
    public static class SeasonTypeService
    {
        public static List<string> SeasonTypes { get { return _SeasonTypes(); } }
        private static List<string> _SeasonTypes()
        {
            List<string> seasonTypes = new List<string>();
            seasonTypes.Add("Regular Season");
            seasonTypes.Add("Playoffs");

            return seasonTypes;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Regular Season" }, { "value", "Regular Season" } },
                new BsonDocument { { "label", "Playoffs" }, { "value", "Playoffs" } },
            };

            DatabaseHelper.AddFilterCollection("seasonTypes", array);
        }
    }
}
