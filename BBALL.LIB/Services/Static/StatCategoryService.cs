using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services
{
    public static class StatCategoryService
    {
        public static List<string> StatCategories { get { return _StatCategories(); } }
        private static List<string> _StatCategories()
        {
            List<string> statCategory = new List<string>();
            statCategory.Add("PTS");
            statCategory.Add("MIN");
            statCategory.Add("OREB");
            statCategory.Add("DREB");
            statCategory.Add("REB");
            statCategory.Add("AST");
            statCategory.Add("STL");
            statCategory.Add("BLK");
            statCategory.Add("TOV");
            statCategory.Add("EFF");
            return statCategory;
        }

        public static void LoadFilterDefault ()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Points" }, { "value", "PTS" } },
                new BsonDocument { { "label", "Minutes" }, { "value", "MIN" } },
                new BsonDocument { { "label", "Offensive Rebounds" }, { "value", "OREB" } },
                new BsonDocument { { "label", "Defensive Rebounds" }, { "value", "DREB" } },
                new BsonDocument { { "label", "Rebounds" }, { "value", "REB" } },
                new BsonDocument { { "label", "Assists" }, { "value", "AST" } },
                new BsonDocument { { "label", "Steals" }, { "value", "STL" } },
                new BsonDocument { { "label", "Blocks" }, { "value", "BLK" } },
                new BsonDocument { { "label", "Turnovers" }, { "value", "TOV" } },
                new BsonDocument { { "label", "Efficiency" }, { "value", "EFF" } },
            };

            DatabaseHelper.AddFilterCollection("statCategories", array);
        }

        /// <summary>
        /// Get a list of stat categories.
        /// Works with the HomePageService.
        /// </summary>
        public static List<string> HomePageStatCategories { get { return _HomePageStatCategories(); } }

        private static List<string> _HomePageStatCategories()
        {
            List<string> statCategory = new List<string>();
            statCategory.Add("Points");
            statCategory.Add("Rebounds");
            statCategory.Add("Assists");
            statCategory.Add("Defense");
            statCategory.Add("Clutch");
            statCategory.Add("Playmaking");
            statCategory.Add("Efficiency");
            statCategory.Add("Fast Break");
            statCategory.Add("Scoring Breakdown");
            return statCategory;
        }

        public static void LoadFilterHome()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Points" }, { "value", "Starters" } },
                new BsonDocument { { "label", "Rebounds" }, { "value", "Rebounds" } },
                new BsonDocument { { "label", "Assists" }, { "value", "Assists" } },
                new BsonDocument { { "label", "Defense" }, { "value", "Defense" } },
                new BsonDocument { { "label", "Clutch" }, { "value", "Clutch" } },
                new BsonDocument { { "label", "Playmaking" }, { "value", "Playmaking" } },
                new BsonDocument { { "label", "Efficiency" }, { "value", "Efficiency" } },
                new BsonDocument { { "label", "Fast Break" }, { "value", "Fast Break" } },
                new BsonDocument { { "label", "Scoring Breakdown" }, { "value", "Scoring Breakdown" } },
            };

            DatabaseHelper.AddFilterCollection("homePageStatCategories", array);
        }
    }
}
