using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class OutcomeService
    {
        public static List<string> Outcomes { get { return _Outcomes(); } }
        private static List<string> _Outcomes()
        {
            List<string> outcomes = new List<string>();
            outcomes.Add("W");
            outcomes.Add("L");

            return outcomes;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Win" }, { "value", "W" } },
                new BsonDocument { { "label", "Loss" }, { "value", "L" } },
            };

            DatabaseHelper.AddFilterCollection("outcomes", array);
        }
    }
}
