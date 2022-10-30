using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class RankService
    {
        public static List<string> RankTypes { get { return _RankTypes(); } }
        private static List<string> _RankTypes()
        {
            List<string> ranked = new List<string>();
            ranked.Add("Y");
            ranked.Add("N");
            return ranked;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Yes" }, { "value", "Y" } },
                new BsonDocument { { "label", "No" }, { "value", "N" } },
            };

            DatabaseHelper.AddFilterCollection("rankTypes", array);
        }
    }
}
