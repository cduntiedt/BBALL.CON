using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services
{
    public static class MeasureTypeService
    {
        public static List<string> PlayerMeasureTypes { get { return _PlayerMeasureTypes(); } }
        private static List<string> _PlayerMeasureTypes()
        {
            List<string> measureTypes = new List<string>();
            measureTypes.Add("Base"); //traditional
            measureTypes.Add("Advanced");
            measureTypes.Add("Misc");
            measureTypes.Add("Scoring");
            measureTypes.Add("Usage");
            measureTypes.Add("Defense");
            return measureTypes;
        }

        public static void LoadFilterPlayer()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Base" }, { "value", "Base" } },
                new BsonDocument { { "label", "Advanced" }, { "value", "Advanced" } },
                new BsonDocument { { "label", "Misc" }, { "value", "Misc" } },
                new BsonDocument { { "label", "Scoring" }, { "value", "Scoring" } },
                new BsonDocument { { "label", "Usage" }, { "value", "Usage" } },
                new BsonDocument { { "label", "Defense" }, { "value", "Defense" } },
            };

            DatabaseHelper.AddFilterCollection("playerMeasureTypes", array);
        }

        //used with league services
        public static List<string> TeamMeasureTypes { get { return _TeamMeasureTypes(); } }
        private static List<string> _TeamMeasureTypes()
        {
            List<string> measureTypes = new List<string>();
            measureTypes.Add("Base"); //traditional
            measureTypes.Add("Advanced");
            measureTypes.Add("Four Factors");
            measureTypes.Add("Misc");
            measureTypes.Add("Scoring");
            measureTypes.Add("Opponent");
            measureTypes.Add("Defense");
            return measureTypes;
        }

        public static void LoadFilterTeam()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Base" }, { "value", "Base" } },
                new BsonDocument { { "label", "Advanced" }, { "value", "Advanced" } },
                new BsonDocument { { "label", "Four Factors" }, { "value", "Four Factors" } },
                new BsonDocument { { "label", "Misc" }, { "value", "Misc" } },
                new BsonDocument { { "label", "Scoring" }, { "value", "Scoring" } },
                new BsonDocument { { "label", "Opponent" }, { "value", "Opponent" } },
                new BsonDocument { { "label", "Defense" }, { "value", "Defense" } },
            };

            DatabaseHelper.AddFilterCollection("teamMeasureTypes", array);
        }

        /// <summary>
        /// Used with LeagueService.
        /// </summary>
        public static List<string> LeagueMeasureTypes { get { return _LeagueMeasureTypes(); } }
        private static List<string> _LeagueMeasureTypes()
        {
            List<string> measureTypes = new List<string>();
            measureTypes.Add("Base"); //traditional
            measureTypes.Add("Advanced");
            measureTypes.Add("Misc");
            measureTypes.Add("Four Factors");
            measureTypes.Add("Scoring");
            measureTypes.Add("Opponent");
            measureTypes.Add("Usage");
            measureTypes.Add("Defense");
            return measureTypes;
        }

        public static void LoadFilterLeague()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Base" }, { "value", "Base" } },
                new BsonDocument { { "label", "Advanced" }, { "value", "Advanced" } },
                new BsonDocument { { "label", "Misc" }, { "value", "Misc" } },
                new BsonDocument { { "label", "Scoring" }, { "value", "Scoring" } },
                new BsonDocument { { "label", "Four Factors" }, { "value", "Four Factors" } },
                new BsonDocument { { "label", "Opponent" }, { "value", "Opponent" } },
                new BsonDocument { { "label", "Usage" }, { "value", "Usage" } },
                new BsonDocument { { "label", "Defense" }, { "value", "Defense" } },
            };

            DatabaseHelper.AddFilterCollection("leagueMeasureTypes", array);
        }

        /// <summary>
        /// Used with clutch.
        /// </summary>
        public static List<string> ClutchMeasureTypes { get { return _ClutchMeasureTypes(); } }
        private static List<string> _ClutchMeasureTypes()
        {
            List<string> measureTypes = new List<string>();
            measureTypes.Add("Base"); //traditional
            measureTypes.Add("Advanced");
            measureTypes.Add("Misc");
            measureTypes.Add("Scoring");
            measureTypes.Add("Usage");
            return measureTypes;
        }

        public static void LoadFilterClutch()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Base" }, { "value", "Base" } },
                new BsonDocument { { "label", "Advanced" }, { "value", "Advanced" } },
                new BsonDocument { { "label", "Misc" }, { "value", "Misc" } },
                new BsonDocument { { "label", "Scoring" }, { "value", "Scoring" } },
                new BsonDocument { { "label", "Usage" }, { "value", "Usage" } },
            };

            DatabaseHelper.AddFilterCollection("clutchMeasureTypes", array);
        }

        public static List<string> TeamClutchMeasureTypes { get { return _TeamClutchMeasureTypes(); } }
        private static List<string> _TeamClutchMeasureTypes()
        {
            List<string> measureTypes = new List<string>();
            measureTypes.Add("Base"); //traditional
            measureTypes.Add("Advanced");
            measureTypes.Add("Four Factors");
            measureTypes.Add("Misc");
            measureTypes.Add("Scoring");
            measureTypes.Add("Opponent");
            return measureTypes;
        }

        public static void LoadFilterTeamClutch()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Base" }, { "value", "Base" } },
                new BsonDocument { { "label", "Advanced" }, { "value", "Advanced" } },
                new BsonDocument { { "label", "Four Factors" }, { "value", "Four Factors" } },
                new BsonDocument { { "label", "Misc" }, { "value", "Misc" } },
                new BsonDocument { { "label", "Scoring" }, { "value", "Scoring" } },
                new BsonDocument { { "label", "Opponent" }, { "value", "Opponent" } },
            };

            DatabaseHelper.AddFilterCollection("teamClutchMeasureTypes", array);
        }
    }
}
