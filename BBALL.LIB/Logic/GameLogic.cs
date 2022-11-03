﻿using BBALL.LIB.Helpers;
using BBALL.LIB.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using static BBALL.LIB.Helpers.ParameterHelper;

namespace BBALL.LIB.Logic
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
                    var games = await LeagueService.LeagueGameLog(season, seasonType);

                    foreach (var measureType in MeasureTypeService.PlayerMeasureTypes)
                    {
                        await PlayerService.PlayerGameLogs(season, seasonType, "Totals", measureType);
                    }

                    foreach(var measureType in MeasureTypeService.TeamMeasureTypes)
                    {
                        await TeamService.TeamGameLogs(null, season, seasonType, measureType);
                    }

                    foreach (var gameID in gameIDs)
                    {
                        int gameIndex = gameIDs.IndexOf(gameID) + 1;
                        Console.WriteLine($"Loading {gameIndex} of {gameIDs.Count} games. ({gameID})");

                        await BoxScoreService.BoxScorePlayerTrackV2(gameID);
                        await BoxScoreService.BoxScoreSummaryV2(gameID);
                        await BoxScoreService.HustleStatsBoxScore(gameID);

                        await BoxScoreService.BoxScoreMatchups(gameID);
                        await BoxScoreService.BoxScoreDefensive(gameID);

                        await PlayByPlayService.PlayByPlayV2(gameID);

                        await GameService.GameRotation(gameID);
                        await VideoService.VideoDetailAsset(gameID, season, seasonType);
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
