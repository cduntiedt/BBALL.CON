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
        public static async Task<List<BsonDocument>> DraftBoard(
            string Season = null,
            string LeagueID = null, 
            string TopX = null,
            string TeamID = null,
            string RoundPick = null,
            string RoundNum = null,
            string OverallPick = null,
            string College= null)
        {
            BsonArray parameters = new BsonArray();
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

        public static async Task<List<BsonDocument>> DraftBoard(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/draftboard/", "draftboard", parameters);
        }

        public static async Task<List<BsonDocument>> DraftCombineDrillResults(string SeasonYear = null, string LeagueID = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonHelper.DefaultSeason(SeasonYear)));
            return await DraftCombineDrillResults(parameters);
        }

        public static async Task<List<BsonDocument>> DraftCombineDrillResults(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/draftcombinedrillresults/", "draftcombinedrillresults", parameters);
        }

        public static async Task<List<BsonDocument>> DraftCombineStationaryShooting(string SeasonYear = null, string LeagueID = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonHelper.DefaultSeason(SeasonYear)));
            return await DraftCombineStationaryShooting(parameters);
        }

        public static async Task<List<BsonDocument>> DraftCombineStationaryShooting(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/draftcombinenonstationaryshooting/", "draftcombinenonstationaryshooting", parameters);
        }

        public static async Task<List<BsonDocument>> DraftCombinePlayerAnthro(string SeasonYear = null, string LeagueID = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonHelper.DefaultSeason(SeasonYear)));
            return await DraftCombinePlayerAnthro(parameters);
        }

        public static async Task<List<BsonDocument>> DraftCombinePlayerAnthro(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/draftcombineplayeranthro/", "draftcombineplayeranthro", parameters);
        }

        public static async Task<List<BsonDocument>> DraftCombineSpotShooting(string SeasonYear = null, string LeagueID = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonHelper.DefaultSeason(SeasonYear)));
            return await DraftCombineSpotShooting(parameters);
        }

        public static async Task<List<BsonDocument>> DraftCombineSpotShooting(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/draftcombinespotshooting/", "draftcombinespotshooting", parameters);
        }

        public static async Task<List<BsonDocument>> DraftCombineStats(string SeasonYear = null, string LeagueID = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonHelper.DefaultSeason(SeasonYear)));
            return await DraftCombineStats(parameters);
        }

        public static async Task<List<BsonDocument>> DraftCombineStats(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/draftcombinestats/", "draftcombinestats", parameters);
        }

        public static async Task<List<BsonDocument>> DraftHistory(
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
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season).Substring(0,4)));
            parameters.Add(CreateParameterObject("TopX", TopX));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("RoundPick", RoundPick));
            parameters.Add(CreateParameterObject("RoundNum", RoundNum));
            parameters.Add(CreateParameterObject("OverallPick", OverallPick));
            parameters.Add(CreateParameterObject("College", College));
            return await DraftHistory(parameters);
        }

        public static async Task<List<BsonDocument>> DraftHistory(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/drafthistory/", "drafthistory", parameters);
        }
    }
}
