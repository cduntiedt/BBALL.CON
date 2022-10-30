using System;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;
using System.Threading.Tasks;

namespace BBALL.LIB.Services
{
    public static class HomePageService
    {
        public static async Task<List<BsonDocument>> HomePageLeaders(
            string Season = null,
            string SeasonType = "Regular Season",
            string GameScope = "Season", 
            string PlayerOrTeam = "Player", 
            string PlayerScope = "All Players",
            string StatCategory = "Traditional",
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
            return await HomePageLeaders(parameters);
        }

        public static async Task<List<BsonDocument>> HomePageLeaders(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/homepageleaders/", "homepageleaders", parameters);
        }

        public static async Task<List<BsonDocument>> HomePageV2(
           string Season = null,
           string SeasonType = "Regular Season",
           string StatType = "Traditional",
           string GameScope = "Season",
           string PlayerOrTeam = "Player",
           string PlayerScope = "All Players",
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
            return await HomePageV2(parameters);
        }

        public static async Task<List<BsonDocument>> HomePageV2(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/homepagev2/", "homepagev2", parameters);
        }
    }
}
