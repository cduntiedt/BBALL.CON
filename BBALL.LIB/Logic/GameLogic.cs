using BBALL.LIB.Helpers;
using BBALL.LIB.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        public static async Task LoadGameData(string season, List<string> seasonTypes, string dateFrom = null, string dateTo = null)
        {
            try
            {
                var tasks = new List<Task>();
                var gameIDs = await DailyHelper.GetIDs("GAME_ID", "T", season, dateFrom, dateTo);

                foreach (var seasonType in seasonTypes)
                {
                    ////load the games
                    tasks.Add(LeagueService.LeagueGameLog(season, seasonType));

                    foreach (var measureType in MeasureTypeService.PlayerMeasureTypes)
                    {
                        tasks.Add(PlayerService.PlayerGameLogs(season, seasonType, "Totals", measureType));
                    }

                    foreach(var measureType in MeasureTypeService.TeamMeasureTypes)
                    {
                        tasks.Add(TeamService.TeamGameLogs(null, season, seasonType, measureType));
                    }

                    foreach (var gameID in gameIDs)
                    {
                        int gameIndex = gameIDs.IndexOf(gameID) + 1;
                        tasks.Add(Task.Run(() => { Console.WriteLine($"Loading {gameIndex} of {gameIDs.Count} games. ({gameID})"); }));

                        tasks.Add(BoxScoreService.BoxScorePlayerTrackV2(gameID));
                        tasks.Add(BoxScoreService.BoxScoreSummaryV2(gameID));
                        tasks.Add(BoxScoreService.HustleStatsBoxScore(gameID));

                        tasks.Add(BoxScoreService.BoxScoreMatchups(gameID));
                        tasks.Add(BoxScoreService.BoxScoreDefensive(gameID));

                        tasks.Add(PlayByPlayService.PlayByPlayV2(gameID));

                        tasks.Add(GameService.GameRotation(gameID));
                        tasks.Add(VideoService.VideoDetailAsset(gameID, season, seasonType));
                    }
                }

                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                DatabaseHelper.ErrorDocument(ex, "LoadGameData", null, "load");
                throw;
            }
        }
    }
}
