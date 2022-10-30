using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services
{
    public static class ScopeService
    {
        public static List<string> Scopes { get { return _Scopes(); } }
        private static List<string> _Scopes()
        {
            List<string> scopes = new List<string>();
            scopes.Add("RS");
            scopes.Add("S");
            scopes.Add("Rookies");
            return scopes;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "RS" }, { "value", "RS" } },
                new BsonDocument { { "label", "S" }, { "value", "S" } },
                new BsonDocument { { "label", "Rookies" }, { "value", "Rookies" } },
            };

            DatabaseHelper.AddFilterCollection("scopes", array);
        }
    }
}
