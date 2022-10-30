using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class PlayerScopeService
    {
        //TODO: Verify this works for alternate endpoints (works for HomePageService)
        /// <summary>
        /// Get a list of player scopes. 
        /// Works with HomePageService.
        /// </summary>
        public static List<string> PlayerScopes { get { return _PlayerScopes(); } }
        private static List<string> _PlayerScopes()
        {
            List<string> playerScopes = new List<string>();
            playerScopes.Add("All Players");
            playerScopes.Add("Rookies");
            return playerScopes;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "All Players" }, { "value", "All Players" } },
                new BsonDocument { { "label", "Rookies" }, { "value", "Rookies" } },
            };

            DatabaseHelper.AddFilterCollection("playerScopes", array);
        }
    }
}
