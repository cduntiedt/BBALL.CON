using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class PlayerPositionService
    {
        public static List<string> PlayerPositions { get { return _PlayerPositions(); } }
        private static List<string> _PlayerPositions()
        {
            List<string> positions = new List<string>();
            positions.Add("F");
            positions.Add("C");
            positions.Add("G");
            positions.Add("C-F");
            positions.Add("F-C");
            positions.Add("F-G");
            positions.Add("G-F");

            return positions;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "F" }, { "value", "F" } },
                new BsonDocument { { "label", "C" }, { "value", "C" } },
                new BsonDocument { { "label", "G" }, { "value", "G" } },
                new BsonDocument { { "label", "C-F" }, { "value", "C-F" } },
                new BsonDocument { { "label", "F-C" }, { "value", "F-C" } },
                new BsonDocument { { "label", "F-G" }, { "value", "F-G" } },
                new BsonDocument { { "label", "G-F" }, { "value", "G-F" } },
            };

            DatabaseHelper.AddFilterCollection("playerPositions", array);
        }
    }
}
