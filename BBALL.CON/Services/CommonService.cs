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
        public static void CommonAllPlayers(string LeagueID, string Season, string IsOnlyCurrentSeason)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("IsOnlyCurrentSeason", IsOnlyCurrentSeason));
            CommonAllPlayers(parameters);
        }

        public static void CommonAllPlayers(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/commonallplayers/", "commonallplayers", parameters);
        }

        public static void CommonPlayerInfo(string PlayerID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            CommonPlayerInfo(parameters);
        }

        public static void CommonPlayerInfo(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/commonplayerinfo/", "commonplayerinfo", parameters);
        }

        public static void CommonTeamRoster(string Season, string TeamID, string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));

            CommonTeamRoster(parameters);
        }

        public static void CommonTeamRoster(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/commonteamroster/", "commonteamroster", parameters);
        }

        public static void CommonTeamYears(string LeagueID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            CommonTeamYears(parameters);
        }

        public static void CommonTeamYears(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/commonteamyears/", "commonteamyears", parameters);
        }
    }
}
