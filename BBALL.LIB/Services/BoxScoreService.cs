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
    public static class BoxScoreService
    {
        /// <summary>
        /// Function to load all the box score data by Game ID.
        /// </summary>
        /// <param name="GameID">The unique game ID.</param>
        public static async void BoxScoreAll(string GameID)
        {
            await BoxScoreAdvancedV2(GameID);
            await BoxScoreDefensive(GameID);
            await BoxScoreFourFactorsV2(GameID);
            await BoxScoreMatchups(GameID);
            await BoxScoreMiscV2(GameID);
            await BoxScorePlayerTrackV2(GameID);
            await BoxScoreScoringV2(GameID);
            await BoxScoreSummaryV2(GameID);
            await BoxScoreTraditionalV2(GameID);
            await BoxScoreUsageV2(GameID);
            await HustleStatsBoxScore(GameID);
        }

        public static async Task<List<BsonDocument>> BoxScoreAdvancedV2(
            string GameID,
            string EndPeriod = "10", 
            string EndRange = "28800", 
            string RangeType = "0",
            string StartPeriod = "0",
            string StartRange = "0"
        )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            parameters.Add(CreateParameterObject("EndRange", EndRange));
            parameters.Add(CreateParameterObject("RangeType", RangeType));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("StartRange", StartRange));
            
            return await BoxScoreAdvancedV2(parameters);
        }

        public static async Task<List<BsonDocument>> BoxScoreAdvancedV2(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/boxscoreadvancedv2/", "boxscoreadvancedv2", parameters);
        }

        public static async Task<List<BsonDocument>> BoxScoreDefensive(
            string GameID
        )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            return await BoxScoreDefensive(parameters);
        }

        public static async Task<List<BsonDocument>> BoxScoreDefensive(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/boxscoredefensivev2/", "boxscoredefensive", parameters, false);
        }

        public static async Task<List<BsonDocument>> BoxScoreFourFactorsV2(
            string GameID,
            string EndPeriod = "10",
            string EndRange = "28800",
            string RangeType = "0",
            string StartPeriod = "0",
            string StartRange = "0"
        )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            parameters.Add(CreateParameterObject("EndRange", EndRange));
            parameters.Add(CreateParameterObject("RangeType", RangeType));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("StartRange", StartRange));
            return await BoxScoreFourFactorsV2(parameters);
        }

        public static async Task<List<BsonDocument>> BoxScoreFourFactorsV2(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/boxscorefourfactorsv2/", "boxscorefourfactorsv2", parameters);
        }

        public static async Task<List<BsonDocument>> BoxScoreMatchups(
           string GameID
        )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            return await BoxScoreMatchups(parameters);
        }

        public static async Task<List<BsonDocument>> BoxScoreMatchups(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/boxscorematchupsv3/", "boxscorematchups", parameters, false);
        }

        public static async Task<List<BsonDocument>> BoxScoreMiscV2(
            string GameID,
            string EndPeriod = "10",
            string EndRange = "28800",
            string RangeType = "0",
            string StartPeriod = "0",
            string StartRange = "0"
        )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            parameters.Add(CreateParameterObject("EndRange", EndRange));
            parameters.Add(CreateParameterObject("RangeType", RangeType));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("StartRange", StartRange));
            return await BoxScoreMiscV2(parameters);
        }

        public static async Task<List<BsonDocument>> BoxScoreMiscV2(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/boxscoremiscv2/", "boxscoremiscv2", parameters);
        }

        public static async Task<List<BsonDocument>> BoxScorePlayerTrackV2(
           string GameID
        )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            return await BoxScorePlayerTrackV2(parameters);
        }

        public static async Task<List<BsonDocument>> BoxScorePlayerTrackV2(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/boxscoreplayertrackv2/", "boxscoreplayertrackv2", parameters);
        }

        public static async Task<List<BsonDocument>> BoxScoreScoringV2(
            string GameID,
            string EndPeriod = "10",
            string EndRange = "28800",
            string RangeType = "0",
            string StartPeriod = "0",
            string StartRange = "0"
        )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            parameters.Add(CreateParameterObject("EndRange", EndRange));
            parameters.Add(CreateParameterObject("RangeType", RangeType));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("StartRange", StartRange));
            return await BoxScoreScoringV2(parameters);
        }

        public static async Task<List<BsonDocument>> BoxScoreScoringV2(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/boxscorescoringv2/", "boxscorescoringv2", parameters);
        }

        public static async Task<List<BsonDocument>> BoxScoreSummaryV2(
           string GameID
        )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            return await BoxScoreSummaryV2(parameters);
        }

        public static async Task<List<BsonDocument>> BoxScoreSummaryV2(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/boxscoresummaryv2/", "boxscoresummaryv2", parameters);
        }

        public static async Task<List<BsonDocument>> BoxScoreTraditionalV2(
            string GameID,
            string EndPeriod = "10",
            string EndRange = "28800",
            string RangeType = "0",
            string StartPeriod = "0",
            string StartRange = "0"
        )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            parameters.Add(CreateParameterObject("EndRange", EndRange));
            parameters.Add(CreateParameterObject("RangeType", RangeType));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("StartRange", StartRange));
            return await BoxScoreTraditionalV2(parameters);
        }

        public static async Task<List<BsonDocument>> BoxScoreTraditionalV2(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/boxscoretraditionalv2/", "boxscoretraditionalv2", parameters);
        }

        public static async Task<List<BsonDocument>> BoxScoreUsageV2(
           string GameID,
           string EndPeriod = "10",
           string EndRange = "28800",
           string RangeType = "0",
           string StartPeriod = "0",
           string StartRange = "0"
       )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            parameters.Add(CreateParameterObject("EndRange", EndRange));
            parameters.Add(CreateParameterObject("RangeType", RangeType));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("StartRange", StartRange));
            return await BoxScoreUsageV2(parameters);
        }

        public static async Task<List<BsonDocument>> BoxScoreUsageV2(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/boxscoreusagev2/", "boxscoreusagev2", parameters);
        }

        public static async Task<List<BsonDocument>> HustleStatsBoxScore(
           string GameID
       )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            return await HustleStatsBoxScore(parameters);
        }

        public static async Task<List<BsonDocument>> HustleStatsBoxScore(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/hustlestatsboxscore/", "hustlestatsboxscore", parameters);
        }
    }
}
