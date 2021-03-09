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
    public static class LeadersService
    {
        //Players > All Time Summary
        public static async Task<BsonDocument> AllTimeLeadersGrid(
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
            string TopX = "10",
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("TopX", TopX));

            return await AllTimeLeadersGrid(parameters);
        }

        public static async Task<BsonDocument> AllTimeLeadersGrid(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/alltimeleadersgrids/", "alltimeleadersgrids", parameters);
        }


        //Players > Official Leaders
        public static async Task<BsonDocument> LeagueLeaders(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string ActiveFlag = null,
            string Scope = "S",
            string StatCategory = "PTS",
            string LeagueID = null
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("ActiveFlag", ActiveFlag));
            parameters.Add(CreateParameterObject("Scope", Scope));
            parameters.Add(CreateParameterObject("StatCategory", StatCategory));
            return await LeagueLeaders(parameters);
        }

        public static async Task<BsonDocument> LeagueLeaders(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leagueleaders/", "leagueleaders", parameters, true, 15, "resultSet");
        }
    }
}
