using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.CON.Helpers;
using static BBALL.CON.Helpers.ParameterHelper;

namespace BBALL.CON.Services
{
    public static class CommonService
    {
        public static void CommonAllPlayers(string LeagueID, string Season, int IsOnlyCurrentSeason)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("IsOnlyCurrentSeason", IsOnlyCurrentSeason, ParameterType.Int));
            CommonAllPlayers(parameters);
        }

        public static void CommonAllPlayers(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/commonallplayers/", "commonallplayers", parameters);
        }

        public static void CommonPlayerInfo(int PlayerID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID, ParameterType.Int));
            CommonPlayerInfo(parameters);
        }

        public static void CommonPlayerInfo(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/commonplayerinfo/", "commonplayerinfo", parameters);
        }

        public static void CommonTeamRoster(string Season, int TeamID, string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));

            CommonTeamRoster(parameters);
        }

        public static void CommonTeamRoster(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/commonteamroster/", "commonteamroster", parameters);
        }

        public static void CommonTeamYears(string LeagueID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            CommonTeamYears(parameters);
        }

        public static void CommonTeamYears(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/commonteamyears/", "commonteamyears", parameters);
        }
    }
}
