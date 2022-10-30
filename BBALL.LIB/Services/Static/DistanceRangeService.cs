using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class DistanceRangeService
    {
        public static List<string> DistanceRanges { get { return _DistanceRanges(); } }
        private static List<string> _DistanceRanges()
        {
            List<string> ranges = new List<string>();
            ranges.Add("5ft Range");
            ranges.Add("8ft Range");
            ranges.Add("By Zone");
            return ranges;
        }
        
        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "5ft Range" }, { "value", "5ft Range" } },
                new BsonDocument { { "label", "8ft Range" }, { "value", "8ft Range" } },
                new BsonDocument { { "label", "By Zone" }, { "value", "By Zone" } },
            };

            DatabaseHelper.AddFilterCollection("distanceRange", array);
        }
    }
}
