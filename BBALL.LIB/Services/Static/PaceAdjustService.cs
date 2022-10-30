using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class PaceAdjustService
    {
        public static List<string> PaceAdjustTypes { get { return _PaceAdjustTypes(); } }
        private static List<string> _PaceAdjustTypes()
        {
            List<string> paceAdjust = new List<string>();
            paceAdjust.Add("Y");
            paceAdjust.Add("N");
            return paceAdjust;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Yes" }, { "value", "Y" } },
                new BsonDocument { { "label", "No" }, { "value", "N" } },
            };

            DatabaseHelper.AddFilterCollection("paceAdjust", array);
        }
    }
}
