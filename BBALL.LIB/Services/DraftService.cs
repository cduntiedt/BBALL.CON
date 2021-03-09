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
    public static class DraftService
    {
        public static async void DraftCombineAll(string SeasonYear = null, string LeagueID = null)
        {
            await DraftCombineDrillResults(LeagueID, SeasonYear);
            await DraftCombineStationaryShooting(LeagueID, SeasonYear);
            await DraftCombinePlayerAnthro(LeagueID, SeasonYear);
            await DraftCombineSpotShooting(LeagueID, SeasonYear);
            await DraftCombineStats(LeagueID, SeasonYear);
        }
        public static async Task<BsonDocument> DraftBoard(
            string LeagueID = null, 
            string Season = null,
            string TopX = null,
            string TeamID = null,
            string RoundPick = null,
            string RoundNum = null,
            string OverallPick = null,
            string College= null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("TopX", TopX));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("RoundPick", RoundPick));
            parameters.Add(CreateParameterObject("RoundNum", RoundNum));
            parameters.Add(CreateParameterObject("OverallPick", OverallPick));
            parameters.Add(CreateParameterObject("College", College));
            return await DraftBoard(parameters);
        }

        public static async Task<BsonDocument> DraftBoard(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/draftboard/", "draftboard", parameters);
        }

        public static async Task<BsonDocument> DraftCombineDrillResults(string LeagueID = null, string SeasonYear = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonHelper.DefaultSeason(SeasonYear)));
            return await DraftCombineDrillResults(parameters);
        }

        public static async Task<BsonDocument> DraftCombineDrillResults(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/draftcombinedrillresults/", "draftcombinedrillresults", parameters);
        }

        public static async Task<BsonDocument> DraftCombineStationaryShooting(string LeagueID = null, string SeasonYear = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonHelper.DefaultSeason(SeasonYear)));
            return await DraftCombineStationaryShooting(parameters);
        }

        public static async Task<BsonDocument> DraftCombineStationaryShooting(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/draftcombinenonstationaryshooting/", "draftcombinenonstationaryshooting", parameters);
        }

        public static async Task<BsonDocument> DraftCombinePlayerAnthro(string LeagueID = null, string SeasonYear = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonHelper.DefaultSeason(SeasonYear)));
            return await DraftCombinePlayerAnthro(parameters);
        }

        public static async Task<BsonDocument> DraftCombinePlayerAnthro(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/draftcombineplayeranthro/", "draftcombineplayeranthro", parameters);
        }

        public static async Task<BsonDocument> DraftCombineSpotShooting(string LeagueID = null, string SeasonYear = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonHelper.DefaultSeason(SeasonYear)));
            return await DraftCombineSpotShooting(parameters);
        }

        public static async Task<BsonDocument> DraftCombineSpotShooting(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/draftcombinespotshooting/", "draftcombinespotshooting", parameters);
        }

        public static async Task<BsonDocument> DraftCombineStats(string LeagueID = null, string SeasonYear = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonHelper.DefaultSeason(SeasonYear)));
            return await DraftCombineStats(parameters);
        }

        public static async Task<BsonDocument> DraftCombineStats(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/draftcombinestats/", "draftcombinestats", parameters);
        }

        public static async Task<BsonDocument> DraftHistory(
            string Season = null,
            string TopX = null,
            string TeamID = null,
            string RoundPick = null,
            string RoundNum = null,
            string OverallPick = null,
            string College = null,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("TopX", TopX));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("RoundPick", RoundPick));
            parameters.Add(CreateParameterObject("RoundNum", RoundNum));
            parameters.Add(CreateParameterObject("OverallPick", OverallPick));
            parameters.Add(CreateParameterObject("College", College));
            return await DraftHistory(parameters);
        }

        public static async Task<BsonDocument> DraftHistory(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/drafthistory/", "drafthistory", parameters);
        }
    }
}
