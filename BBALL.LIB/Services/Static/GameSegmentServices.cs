using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class GameSegmentServices
    {
        public static List<string> GameSegments { get { return _GameSegments(); } }
        private static List<string> _GameSegments()
        {
            List<string> gameSegments = new List<string>();
            gameSegments.Add("First Half");
            gameSegments.Add("Overtime");
            gameSegments.Add("Second Half");

            return gameSegments;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "First Half" }, { "value", "First Half" } },
                new BsonDocument { { "label", "Overtime" }, { "value", "Overtime" } },
                new BsonDocument { { "label", "Second Half" }, { "value", "Second Half" } },
            };

            DatabaseHelper.AddFilterCollection("gameSegments", array);
        }
    }
}
