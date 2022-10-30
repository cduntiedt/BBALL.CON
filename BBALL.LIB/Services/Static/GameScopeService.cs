using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class GameScopeService
    {
        //TODO: Verify this works for alternate endpoints (works for HomePageService)
        /// <summary>
        /// Get a list of game scopes. 
        /// Works with HomePageService.
        /// </summary>
        public static List<string> GameScopes { get { return _GameScopes(); } }
        private static List<string> _GameScopes()
        {
            List<string> gameScopes = new List<string>();
            gameScopes.Add("Season");
            gameScopes.Add("Last 10");
            gameScopes.Add("Yesterday");
            gameScopes.Add("Finals");
            return gameScopes;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Season" }, { "value", "Season" } },
                new BsonDocument { { "label", "Last 10" }, { "value", "Last 10" } },
                new BsonDocument { { "label", "Yesterday" }, { "value", "Yesterday" } },
                new BsonDocument { { "label", "Finals" }, { "value", "Finals" } },
            };

            DatabaseHelper.AddFilterCollection("gameScopes", array);
        }
    }
}
