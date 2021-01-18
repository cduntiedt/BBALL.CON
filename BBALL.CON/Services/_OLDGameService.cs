using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBALL.CON.Helpers;
using static BBALL.CON.Helpers.ParameterHelper;

namespace BBALL.CON
{
    public static class _OLDGameService
    {
        /// <summary>
        /// Get a list of game IDs
        /// </summary>
        /// <returns>A list of string</returns>
        public static List<BsonDocument> ImportGames(JArray parameters = null)
        {
            try
            {
                List<BsonDocument> gameLogs = DatabaseHelper.GetAllDocuments("teamgamelog", parameters);

                var seasons = gameLogs.GroupBy(x => new
                {
                    Season = x["Season"].ToString(),
                    SeasonType = x["SeasonType"].ToString()
                }).Select(x => x.First()).ToList();

                List<BsonDocument> seasonDocuments = new List<BsonDocument>();

                foreach (var season in seasons)
                {
                    var seasonGames = gameLogs.Where(x => x["Season"] == season["Season"] && x["SeasonType"] == season["SeasonType"]).ToList();

                    BsonDocument seasonDocument = new BsonDocument();
                    seasonDocument.Add("Season", season["Season"].ToString());
                    seasonDocument.Add("SeasonType", season["SeasonType"].ToString());
                    
                    BsonArray gameArray = new BsonArray();
                    
                    foreach (var seasonGame in seasonGames)
                    {
                        var gameLog = (BsonArray)seasonGame["resultSets"][0]["data"];
                        if (!gameLog.IsBsonNull)
                        {
                            foreach (var item in gameLog)
                            {
                                if (!item["MATCHUP"].ToString().Contains("@"))
                                {
                                    BsonDocument game = new BsonDocument();
                                    game.Add("Game_ID", item["Game_ID"].ToString());
                                    game.Add("GAME_DATE", item["GAME_DATE"].ToString());
                                    game.Add("MATCHUP", item["MATCHUP"].ToString());

                                    var existingGame = gameArray.Where(x => x["Game_ID"].ToString() == item["Game_ID"].ToString()).FirstOrDefault();
                                    if (existingGame != game)
                                    {
                                        gameArray.Add(game);
                                    }
                                }
                            }
                        }
                    }

                    seasonDocument.Add("Games", gameArray);
                    seasonDocuments.Add(seasonDocument);

                    JArray seasonParameters = new JArray();
                    seasonParameters.Add(CreateParameterObject("Season", season["Season"].ToString(), ParameterType.String));
                    seasonParameters.Add(CreateParameterObject("SeasonType", season["SeasonType"].ToString(), ParameterType.String));

                    DatabaseHelper.AddUpdateDocument("games", seasonDocument, seasonParameters, "Games - " + season["Season"].ToString() + " - " + season["SeasonType"].ToString());
                }

                return seasonDocuments;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private static JArray _BoxScoreParameters(string gameID, int startPeriod, int endPeriod, int startRange, int endRange, int rangeType)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", gameID, ParameterType.String));
            parameters.Add(CreateParameterObject("StartPeriod", startPeriod, ParameterType.Int));
            parameters.Add(CreateParameterObject("EndPeriod", endPeriod, ParameterType.Int));
            parameters.Add(CreateParameterObject("StartRange", startRange, ParameterType.Int));
            parameters.Add(CreateParameterObject("EndRange", endRange, ParameterType.Int));
            parameters.Add(CreateParameterObject("RangeType", rangeType, ParameterType.Int));

            return parameters;
        }

        public static void BoxScoreAdvanced(string gameID, int startPeriod = 0, int endPeriod = 10, int startRange = 0, int endRange = 28800, int rangeType = 0)
        {
            JArray parameters = _BoxScoreParameters(gameID, startPeriod, endPeriod, startRange, endRange, rangeType);
            BoxScoreAdvanced(parameters);
        }

        public static void BoxScoreAdvanced(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoreadvancedv2/", "boxscoreadvancedv2", parameters);
        }

        public static void BoxScoreTraditional(string gameID, int startPeriod = 0, int endPeriod = 10, int startRange = 0, int endRange = 28800, int rangeType = 0)
        {
            JArray parameters = _BoxScoreParameters(gameID, startPeriod, endPeriod, startRange, endRange, rangeType);
            BoxScoreTraditional(parameters);
        }

        public static void BoxScoreTraditional(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoretraditionalv2/", "boxscoretraditionalv2", parameters);
        }

        public static void BoxScoreMisc(string gameID, int startPeriod = 0, int endPeriod = 10, int startRange = 0, int endRange = 28800, int rangeType = 0)
        {
            JArray parameters = _BoxScoreParameters(gameID, startPeriod, endPeriod, startRange, endRange, rangeType);
            BoxScoreMisc(parameters);
        }

        public static void BoxScoreMisc(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoremiscv2/", "boxscoremiscv2", parameters);
        }


        public static void BoxScoreScoring(string gameID, int startPeriod = 0, int endPeriod = 10, int startRange = 0, int endRange = 28800, int rangeType = 0)
        {
            JArray parameters = _BoxScoreParameters(gameID, startPeriod, endPeriod, startRange, endRange, rangeType);
            BoxScoreScoring(parameters);
        }

        public static void BoxScoreScoring(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscorescoringv2/", "boxscorescoringv2", parameters);
        }

        public static void BoxScoreUsage(string gameID, int startPeriod = 0, int endPeriod = 10, int startRange = 0, int endRange = 28800, int rangeType = 0)
        {
            JArray parameters = _BoxScoreParameters(gameID, startPeriod, endPeriod, startRange, endRange, rangeType);
            BoxScoreUsage(parameters);
        }

        public static void BoxScoreUsage(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoreusagev2/", "boxscoreusagev2", parameters);
        }

        public static void BoxScoreFourFactors(string gameID, int startPeriod = 0, int endPeriod = 10, int startRange = 0, int endRange = 28800, int rangeType = 0)
        {
            JArray parameters = _BoxScoreParameters(gameID, startPeriod, endPeriod, startRange, endRange, rangeType);
            BoxScoreFourFactors(parameters);
        }

        public static void BoxScoreFourFactors(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscorefourfactorsv2/", "boxscorefourfactorsv2", parameters);
        }

        public static void BoxScorePlayerTrack(string gameID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", gameID, ParameterType.String));
            BoxScorePlayerTrack(parameters);
        }

        public static void BoxScorePlayerTrack(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoreplayertrackv2/", "boxscoreplayertrackv2", parameters);
        }

        public static void BoxScoreSummary(string gameID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", gameID, ParameterType.String));
            BoxScoreSummary(parameters);
        }

        public static void BoxScoreSummary(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoresummaryv2/", "boxscoresummaryv2", parameters);
        }

        public static void PlayByPlay(string gameID, int startPeriod = 0, int endPeriod = 10)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", gameID, ParameterType.String));
            parameters.Add(CreateParameterObject("StartPeriod", startPeriod, ParameterType.Int));
            parameters.Add(CreateParameterObject("EndPeriod", endPeriod, ParameterType.Int));
            PlayByPlay(parameters);
        }

        public static void PlayByPlay(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playbyplayv2/", "playbyplayv2", parameters);
        }

        public static void LoadGameData(string gameID)
        {
            BoxScoreAdvanced(gameID);
            BoxScoreTraditional(gameID);
            BoxScoreMisc(gameID);
            BoxScoreScoring(gameID);
            BoxScoreUsage(gameID);
            BoxScoreFourFactors(gameID);
            BoxScorePlayerTrack(gameID);
            BoxScoreSummary(gameID);
            PlayByPlay(gameID);
        }

        public static void ScoreboardV2(string dayOffset, string gameDate, string leagueID)
        {
            //scoreboardv2
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("DayOffset", dayOffset, ParameterType.String));
            parameters.Add(CreateParameterObject("GameDate", gameDate, ParameterType.String));
            parameters.Add(CreateParameterObject("LeagueID", leagueID, ParameterType.String));
            ScoreboardV3(parameters);
        }

        public static void ScoreboardV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/scoreboardv2/", "scoreboardv2", parameters);
        }

        public static void ScoreboardV3(string gameDate, string leagueID)
        {
            //scoreboardv3
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameDate", gameDate, ParameterType.String));
            parameters.Add(CreateParameterObject("LeagueID", leagueID, ParameterType.String));
            ScoreboardV3(parameters);
        }

        public static void ScoreboardV3(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/scoreboardv3/", "scoreboardv3", parameters);
        }

        public static void PlayoffPicture(string leagueID, string seasonID)
        {

        }

        public static void PlayoffPicture(JArray parameters)
        {

        }

        public static void VideoStatus(string leagueID, string gameDate)
        {

        }
        public static void VideoStatus(JArray parameters)
        {

        }
    }
}
