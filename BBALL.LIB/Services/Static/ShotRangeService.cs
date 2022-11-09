using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class ShotRangeService
    {
        public static List<string> ShotRanges { get { return _ShotRanges(); } }
        private static List<string> _ShotRanges()
        {
            List<string> shotClockRanges = new List<string>();
            shotClockRanges.Add("Overall");
            shotClockRanges.Add("Catch and Shoot");
            shotClockRanges.Add("Pullups");
            shotClockRanges.Add("Less Than 10 ft");

            return shotClockRanges;
        }
        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Overall" }, { "value", "Overall" } },
                new BsonDocument { { "label", "Catch and Shoot" }, { "value", "Catch and Shoot" } },
                new BsonDocument { { "label", "Pullups" }, { "value", "Pullups" } },
                new BsonDocument { { "label", "Less Than 10 ft" }, { "value", "Less Than 10 ft" } },
            };

            DatabaseHelper.AddFilterCollection("shotRanges", array);
        }
    }
}
