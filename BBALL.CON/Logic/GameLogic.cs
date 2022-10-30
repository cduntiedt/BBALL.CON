using BBALL.LIB.Helpers;
using BBALL.LIB.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using static BBALL.LIB.Helpers.ParameterHelper;

namespace BBALL.CON.Logic
{
    public static class GameLogic
    {
        /// <summary>
        /// Load game data.
        /// </summary>
        /// <param name="season">The season to load.</param>
        /// <param name="seasonTypes">The season types.</param>
        /// <param name="dateFrom">The start date.</param>
        /// <param name="dateTo">The end date.</param>
        public static async void LoadGameData(string season, List<string> seasonTypes, string dateFrom = null, string dateTo = null)
        {
            try
            {
                var gameIDs = DailyHelper.GetIDs("GAME_ID", "T", season, dateFrom, dateTo);

                foreach (var seasonType in seasonTypes)
                {
                    ////load the games
                    await LeagueService.LeagueGameLog(season, seasonType);

                    //obtain game data
                    JArray parameters = new JArray();
                    parameters.Add(CreateParameterObject("Season", season));
                    parameters.Add(CreateParameterObject("SeasonType", seasonType));

                    //load game data
                    var gameDocuments = GameService.ImportGames(parameters);

                    int gameCount = gameIDs.Count;
                    foreach (var gameID in gameIDs)
                    {
                        int gameIndex = gameIDs.IndexOf(gameID) + 1;
                        Console.WriteLine("Loading " + gameIndex + " of " + gameCount + " games. (" + gameID + ")");

                        await BoxScoreService.BoxScoreAdvancedV2(gameID);
                        await BoxScoreService.BoxScoreDefensive(gameID);
                        await BoxScoreService.BoxScoreFourFactorsV2(gameID);
                        await BoxScoreService.BoxScoreMatchups(gameID);
                        await BoxScoreService.BoxScoreMiscV2(gameID);
                        await BoxScoreService.BoxScorePlayerTrackV2(gameID);
                        await BoxScoreService.BoxScoreScoringV2(gameID);
                        await BoxScoreService.BoxScoreSummaryV2(gameID);
                        await BoxScoreService.BoxScoreTraditionalV2(gameID);
                        await BoxScoreService.BoxScoreUsageV2(gameID);
                        await BoxScoreService.HustleStatsBoxScore(gameID);
                        await PlayByPlayService.PlayByPlayV2(gameID);

                        await GameService.GameRotation(gameID);
                        await VideoService.VideoDetailAsset(gameID, season, seasonType);
                        await ShotChartService.ShotChartDetail(season, gameID, "0", "0", seasonType);
                    }
                }
            }
            catch (Exception ex)
            {
                DatabaseHelper.ErrorDocument(ex, "LoadGameData", null, "load");
                throw;
            }
        }
    }
}
