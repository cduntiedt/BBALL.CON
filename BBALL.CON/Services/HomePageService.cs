using System;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBALL.CON.Helpers;
using static BBALL.CON.Helpers.ParameterHelper;

namespace BBALL.CON.Services
{
    public static class HomePageService
    {
        public static void HomePageLeaders(
            string LeagueID = null,
            string Season = null,
            string GameScope = "Season", 
            string PlayerOrTeam = "Player", 
            string PlayerScope = "All Players",
            string SeasonType = "Regular Season",
            string StatCategory = "Points"
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID), ParameterType.String));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season), ParameterType.String));
            parameters.Add(CreateParameterObject("GameScope", GameScope, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerOrTeam", PlayerOrTeam, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerScope", PlayerScope, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("StatCategory", StatCategory, ParameterType.String));
            HomePageLeaders(parameters);
        }

        public static void HomePageLeaders(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/homepageleaders/", "homepageleaders", parameters);
        }

        public static void HomePageV2(
           string LeagueID = null,
           string Season = null,
           string GameScope = "Season",
           string PlayerOrTeam = "Player",
           string PlayerScope = "All Players",
           string SeasonType = "Regular Season",
           string StatType = "Points"
           )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID), ParameterType.String));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season), ParameterType.String));
            parameters.Add(CreateParameterObject("GameScope", GameScope, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerOrTeam", PlayerOrTeam, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerScope", PlayerScope, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("StatType", StatType, ParameterType.String));
            HomePageV2(parameters);
        }

        public static void HomePageV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/homepagev2/", "homepagev2", parameters);
        }
    }
}
