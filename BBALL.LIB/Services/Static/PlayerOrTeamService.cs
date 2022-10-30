using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class PlayerOrTeamService
    {
        /// <summary>
        /// Get the player or team options.
        /// Works with HomePageService.
        /// </summary>
        public static List<string> PlayerOrTeam { get { return _PlayerOrTeam(); } }
        private static List<string> _PlayerOrTeam()
        {
            List<string> playerOrTeam = new List<string>();
            playerOrTeam.Add("Player"); 
            playerOrTeam.Add("Team");
            return playerOrTeam;
        }

        public static List<string> PorT { get { return _PorT(); } }
        private static List<string> _PorT()
        {
            List<string> playerOrTeam = new List<string>();
            playerOrTeam.Add("P");
            playerOrTeam.Add("T");
            return playerOrTeam;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Player" }, { "value", "Player" } },
                new BsonDocument { { "label", "Team" }, { "value", "Team" } },
            };

            DatabaseHelper.AddFilterCollection("playerOrTeam", array);
        }
    }
}
