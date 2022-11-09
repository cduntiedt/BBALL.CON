using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class OffensiveDefensiveService
    {
        public static List<string> OffensiveDefensive { get { return _OffensiveDefensive(); } }
        private static List<string> _OffensiveDefensive()
        {
            List<string> outcomes = new List<string>();
            outcomes.Add("offensive");
            outcomes.Add("defensive");

            return outcomes;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Offensive" }, { "value", "offensive" } },
                new BsonDocument { { "label", "Defensive" }, { "value", "defensive" } },
            };

            DatabaseHelper.AddFilterCollection("offensiveDefensive", array);
        }
    }
}
