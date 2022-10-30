using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class PlayerExperienceService
    {
        public static List<string> PlayerExperience { get { return _PlayerExperience(); } }
        private static List<string> _PlayerExperience()
        {
            List<string> player = new List<string>();
            player.Add("Rookie");
            player.Add("Sophomore");
            player.Add("Veteran");
            return player;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Rookie" }, { "value", "Rookie" } },
                new BsonDocument { { "label", "Sophomore" }, { "value", "Sophomore" } },
                new BsonDocument { { "label", "Veteran" }, { "value", "Veteran" } },
            };

            DatabaseHelper.AddFilterCollection("playerExperience", array);
        }
    }
}
