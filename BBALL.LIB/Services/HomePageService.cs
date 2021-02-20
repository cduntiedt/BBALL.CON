using System;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;

namespace BBALL.LIB.Services
{
    public static class HomePageService
    {
        public static void HomePageLeaders(
            string Season = null,
            string SeasonType = "Regular Season",
            string GameScope = "Season", 
            string PlayerOrTeam = "Player", 
            string PlayerScope = "All Players",
            string StatCategory = "Points",
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("GameScope", GameScope));
            parameters.Add(CreateParameterObject("PlayerOrTeam", PlayerOrTeam));
            parameters.Add(CreateParameterObject("PlayerScope", PlayerScope));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("StatCategory", StatCategory));
            HomePageLeaders(parameters);
        }

        public static void HomePageLeaders(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/homepageleaders/", "homepageleaders", parameters);
        }

        public static void HomePageV2(
           string Season = null,
           string SeasonType = "Regular Season",
           string GameScope = "Season",
           string PlayerOrTeam = "Player",
           string PlayerScope = "All Players",
           string StatType = "Points",
           string LeagueID = null
           )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("GameScope", GameScope));
            parameters.Add(CreateParameterObject("PlayerOrTeam", PlayerOrTeam));
            parameters.Add(CreateParameterObject("PlayerScope", PlayerScope));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("StatType", StatType));
            HomePageV2(parameters);
        }

        public static void HomePageV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/homepagev2/", "homepagev2", parameters);
        }
    }
}
