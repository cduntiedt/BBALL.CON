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
    }
}
