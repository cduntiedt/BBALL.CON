using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.CON.Services.Static
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
    }
}
