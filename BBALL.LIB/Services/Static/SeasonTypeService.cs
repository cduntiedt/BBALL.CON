using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services
{
    public static class SeasonTypeService
    {
        public static List<string> PlayerSeasonTypes { get { return _PlayerSeasonTypes(); } }
        private static List<string> _PlayerSeasonTypes()
        {
            List<string> seasonTypes = new List<string>();
            seasonTypes.Add("Regular Season");
            seasonTypes.Add("Pre Season");
            seasonTypes.Add("Playoffs");
            //seasonTypes.Add("All-Star");
            //seasonTypes.Add("All Star");
            //seasonTypes.Add("Preseason");

            return seasonTypes;
        }

        public static void LoadFilterPlayer()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Regular Season" }, { "value", "Regular Season" } },
                new BsonDocument { { "label", "Pre Season" }, { "value", "Pre Season" } },
                new BsonDocument { { "label", "Playoffs" }, { "value", "Playoffs" } },
            };

            DatabaseHelper.AddFilterCollection("playerSeasonTypes", array);
        }

        //TODO: Verify endpoints
        /// <summary>
        /// Team Scopes. 
        /// Works with HomePageService.
        /// </summary>
        public static List<string> TeamSeasonTypes { get { return _TeamSeasonTypes(); } }
        private static List<string> _TeamSeasonTypes()
        {
            List<string> seasonTypes = new List<string>();
            seasonTypes.Add("Regular Season");
            seasonTypes.Add("Pre Season");
            seasonTypes.Add("Playoffs");

            return seasonTypes;
        }
        public static void LoadFilterTeam()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Regular Season" }, { "value", "Regular Season" } },
                new BsonDocument { { "label", "Pre Season" }, { "value", "Pre Season" } },
                new BsonDocument { { "label", "Playoffs" }, { "value", "Playoffs" } },
            };

            DatabaseHelper.AddFilterCollection("teamSeasonTypes", array);
        }

        public static List<string> LeagueSeasonTypes { get { return _LeagueSeasonTypes(); } }
        private static List<string> _LeagueSeasonTypes()
        {
            List<string> seasonTypes = new List<string>();
            seasonTypes.Add("Regular Season");
            seasonTypes.Add("Pre Season");
            seasonTypes.Add("Playoffs");
            seasonTypes.Add("All Star");

            return seasonTypes;
        }
        public static void LoadFilterLeague()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Regular Season" }, { "value", "Regular Season" } },
                new BsonDocument { { "label", "Pre Season" }, { "value", "Pre Season" } },
                new BsonDocument { { "label", "Playoffs" }, { "value", "Playoffs" } },
                new BsonDocument { { "label", "All Star" }, { "value", "All Star" } },
            };

            DatabaseHelper.AddFilterCollection("leagueSeasonTypes", array);
        }
    }
}
