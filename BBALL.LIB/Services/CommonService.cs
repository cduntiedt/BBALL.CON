using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace BBALL.LIB.Services
{
    public static class CommonService
    {
        public static async Task<List<BsonDocument>> CommonAllPlayers(string Season = null, string IsOnlyCurrentSeason = "1", string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("IsOnlyCurrentSeason", IsOnlyCurrentSeason));
            return await CommonAllPlayers(parameters);
        }

        public static async Task<List<BsonDocument>> CommonAllPlayers(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/commonallplayers/", "commonallplayers", parameters);
        }

        public static async Task<List<BsonDocument>> CommonPlayerInfo(string PlayerID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            return await CommonPlayerInfo(parameters);
        }

        public static async Task<List<BsonDocument>> CommonPlayerInfo(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/commonplayerinfo/", "commonplayerinfo", parameters);
        }

        public static async Task<List<BsonDocument>> CommonTeamRoster(string TeamID, string Season = null, string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));

            return await CommonTeamRoster(parameters);
        }

        public static async Task<List<BsonDocument>> CommonTeamRoster(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/commonteamroster/", "commonteamroster", parameters);
        }

        public static async Task<List<BsonDocument>> CommonTeamYears(string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            return await CommonTeamYears(parameters);
        }

        public static async Task<List<BsonDocument>> CommonTeamYears(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/commonteamyears/", "commonteamyears", parameters);
        }
    }
}
