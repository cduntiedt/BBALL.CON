using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services
{
    public static class PerModeService
    {
        public static List<string> PerModes { get { return _PerModes(); } }
        private static List<string> _PerModes()
        {
            List<string> perModes = new List<string>();
            perModes.Add("Totals");
            perModes.Add("PerGame");
            perModes.Add("Per36"); //TO DO: Verify this works with league leaders
            perModes.Add("Per48"); //TO DO: Verify this works
            return perModes;
        }

        public static void LoadFilterDefault()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Totals" }, { "value", "Totals" } },
                new BsonDocument { { "label", "Per Game" }, { "value", "PerGame" } },
                new BsonDocument { { "label", "Per 36" }, { "value", "Per36" } },
                new BsonDocument { { "label", "Per 48" }, { "value", "Per48" } },
            };

            DatabaseHelper.AddFilterCollection("perModes", array);
        }

        public static List<string> PlayerPerModes { get { return _PlayerPerModes(); } }
        private static List<string> _PlayerPerModes()
        {
            List<string> perModes = new List<string>();
            perModes.Add("Totals");
            perModes.Add("PerGame");
            perModes.Add("Per36");
            return perModes;
        }

        public static void LoadFilterPlayer()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Totals" }, { "value", "Totals" } },
                new BsonDocument { { "label", "Per Game" }, { "value", "PerGame" } },
                new BsonDocument { { "label", "Per 36" }, { "value", "Per36" } },
            };

            DatabaseHelper.AddFilterCollection("playerPerModes", array);
        }


        public static List<string> TeamPerModes { get { return _TeamPerModes(); } }
        private static List<string> _TeamPerModes()
        {
            List<string> perModes = new List<string>();
            perModes.Add("Totals");
            perModes.Add("PerGame");
            return perModes;
        }

        public static void LoadFilterTeam()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Totals" }, { "value", "Totals" } },
                new BsonDocument { { "label", "Per Game" }, { "value", "PerGame" } },
            };

            DatabaseHelper.AddFilterCollection("teamPerModes", array);
        }

        public static List<string> FranchisePerModes { get { return _FranchisePerModes(); } }
        private static List<string> _FranchisePerModes()
        {
            List<string> perModes = new List<string>();
            perModes.Add("Totals");
            perModes.Add("PerGame");
            perModes.Add("MinutesPer");
            perModes.Add("Per48");
            perModes.Add("Per40");
            perModes.Add("Per36");
            perModes.Add("PerMinute");
            perModes.Add("PerPossession");
            perModes.Add("PerPlay");
            perModes.Add("Per100Possessions");
            perModes.Add("Per100Plays");
            return perModes;
        }

        public static void LoadFilterFranchise()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Totals" }, { "value", "Totals" } },
                new BsonDocument { { "label", "Per Game" }, { "value", "PerGame" } },
                new BsonDocument { { "label", "Minutes Per" }, { "value", "MinutesPer" } },
                new BsonDocument { { "label", "Per 36" }, { "value", "Per36" } },
                new BsonDocument { { "label", "Per 48" }, { "value", "Per48" } },
                new BsonDocument { { "label", "Per 40" }, { "value", "Per40" } },
                new BsonDocument { { "label", "Per Minute" }, { "value", "PerMinute" } },
                new BsonDocument { { "label", "Per Possession" }, { "value", "PerPossession" } },
                new BsonDocument { { "label", "Per Play" }, { "value", "PerPlay" } },
                new BsonDocument { { "label", "Per 100 Possessions" }, { "value", "Per100Possessions" } },
                new BsonDocument { { "label", "Per 100 Plays" }, { "value", "Per100Plays" } },
            };

            DatabaseHelper.AddFilterCollection("franchisePerModes", array);
        }
    }
}
