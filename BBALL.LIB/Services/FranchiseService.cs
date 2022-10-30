using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace BBALL.LIB.Services
{
    public static class FranchiseService
    {
        public static async Task<List<BsonDocument>> FranchiseHistory(string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            return await FranchiseHistory(parameters);
        }

        public static async Task<List<BsonDocument>> FranchiseHistory(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/franchisehistory/", "franchisehistory", parameters);
        }

        public static async Task<List<BsonDocument>> FranchiseLeaders(string TeamID, string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            return await FranchiseLeaders(parameters);
        }

        public static async Task<List<BsonDocument>> FranchiseLeaders(JArray parameters) {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/franchiseleaders/", "franchiseleaders", parameters);
        }

        public static async Task<List<BsonDocument>> FranchisePlayers(
            string TeamID,
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            return await FranchisePlayers(parameters);
        }

        public static async Task<List<BsonDocument>> FranchisePlayers(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/franchiseplayers/", "franchiseplayers", parameters);
        }
    }
}
