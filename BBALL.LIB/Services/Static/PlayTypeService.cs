using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services
{
    public static class PlayTypeService
    {
        public static List<string> PlayTypes { get { return _PlayTypes(); } }
        private static List<string> _PlayTypes()
        {
            List<string> types = new List<string>();
            types.Add("Isolation");
            types.Add("Transition");
            types.Add("PRBallHandler");
            types.Add("PRRollman");
            types.Add("Postup");
            types.Add("Spotup");
            types.Add("Handoff");
            types.Add("Cut");
            types.Add("OffScreen");
            types.Add("OffRebound");
            return types;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Isolation" }, { "value", "Isolation" } },
                new BsonDocument { { "label", "Transition" }, { "value", "Transition" } },
                new BsonDocument { { "label", "Pick & Roll Ball Handler" }, { "value", "PRBallHandler" } },
                new BsonDocument { { "label", "Pick & Roll Man" }, { "value", "PRRollman" } },
                new BsonDocument { { "label", "Post Up" }, { "value", "Postup" } },
                new BsonDocument { { "label", "Spot Up" }, { "value", "Spotup" } },
                new BsonDocument { { "label", "Handoff" }, { "value", "Handoff" } },
                new BsonDocument { { "label", "Cut" }, { "value", "Cut" } },
                new BsonDocument { { "label", "Off Screen" }, { "value", "OffScreen" } },
                new BsonDocument { { "label", "Putback" }, { "value", "OffRebound" } },
            };

            DatabaseHelper.AddFilterCollection("playTypes", array);
        }
    }
}
