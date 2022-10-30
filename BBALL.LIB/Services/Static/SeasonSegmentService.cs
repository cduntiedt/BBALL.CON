using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class SeasonSegmentService
    {
        public static List<string> SeasonSegments { get { return _SeasonSegments(); } }
        private static List<string> _SeasonSegments()
        {
            List<string> conferences = new List<string>();
            conferences.Add("Post All-Star");
            conferences.Add("Pre All-Star");

            return conferences;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Post All-Star" }, { "value", "Post All-Star" } },
                new BsonDocument { { "label", "Pre All-Star" }, { "value", "Pre All-Star" } },
            };

            DatabaseHelper.AddFilterCollection("seasonSegments", array);
        }
    }
}
