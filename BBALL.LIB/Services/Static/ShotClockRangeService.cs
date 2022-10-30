using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class ShotClockRangeService
    {
        public static List<string> ShotClockRanges { get { return _ShotClockRanges(); } }
        private static List<string> _ShotClockRanges()
        {
            List<string> shotClockRanges = new List<string>();
            shotClockRanges.Add("24-22");
            shotClockRanges.Add("22-18 Very Early");
            shotClockRanges.Add("18-15 Early");
            shotClockRanges.Add("15-7 Average");
            shotClockRanges.Add("7-4 Late");
            shotClockRanges.Add("4-0 Very Late");
            shotClockRanges.Add("ShotClock Off");

            return shotClockRanges;
        }
        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "24-22" }, { "value", "24-22" } },
                new BsonDocument { { "label", "22-18 Very Early" }, { "value", "22-18 Very Early" } },
                new BsonDocument { { "label", "18-15 Early" }, { "value", "18-15 Early" } },
                new BsonDocument { { "label", "15-7 Average" }, { "value", "15-7 Average" } },
                new BsonDocument { { "label", "7-4 Late" }, { "value", "7-4 Late" } },
                new BsonDocument { { "label", "4-0 Very Late" }, { "value", "4-0 Very Late" } },
                new BsonDocument { { "label", "ShotClock Off" }, { "value", "ShotClock Off" } },
            };

            DatabaseHelper.AddFilterCollection("shotClockRanges", array);
        }
    }
}
