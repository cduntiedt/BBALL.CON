using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class StarterBenchService
    {
        public static List<string> StarterBench { get { return _StarterBench(); } }
        private static List<string> _StarterBench()
        {
            List<string> starterBench = new List<string>();
            starterBench.Add("Starters");
            starterBench.Add("Bench");

            return starterBench;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Starters" }, { "value", "Starters" } },
                new BsonDocument { { "label", "Bench" }, { "value", "Bench" } },
            };

            DatabaseHelper.AddFilterCollection("starterBench", array);
        }
    }
}
