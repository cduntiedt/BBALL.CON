using BBALL.LIB.Helpers;
using BBALL.LIB.Services;
using BBALL.LIB.Services.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBALL.LIB.Logic
{
    public static class PlayerLogic
    {
        /// <summary>
        /// Load player data to the database.
        /// </summary>
        /// <param name="season">The season to load.</param>
        /// <param name="seasonTypes">The season types.</param>
        /// <param name="dateFrom">The start date.</param>
        /// <param name="dateTo">The end date.</param>
        public static async Task LoadPlayerData(string season, List<string> seasonTypes = null, string dateFrom = null, string dateTo = null)
        {
            try
            {
                var tasks = new List<Task>();
                DraftService.DraftCombineAll(season);

                foreach (var seasonType in seasonTypes)
                {
                    //player stuff
                    tasks.Add(LeagueService.LeagueGameLog(season, seasonType, "P"));
                    tasks.Add(PlayerService.PlayerEstimatedMetrics(season, seasonType));

                    foreach (var measureType in MeasureTypeService.ClutchMeasureTypes)
                    {
                        tasks.Add(PlayerService.PlayerGameLogs(season, seasonType, "Totals", measureType));
                    }

                    foreach (var perMode in PerModeService.PlayerPerModes)
                    {
                        foreach (var measureType in MeasureTypeService.PlayerMeasureTypes)
                        {
                            tasks.Add(LeagueService.LeagueDashPlayerStats(season, seasonType, perMode, measureType));
                        }

                        foreach (var measureType in MeasureTypeService.ClutchMeasureTypes)
                        {
                            tasks.Add(LeagueService.LeagueDashPlayerClutch(season, seasonType, perMode, measureType));
                        }

                        tasks.Add(LeagueService.LeaguePlayerOnDetails(season, seasonType, perMode, "Opponent"));
                        tasks.Add(LeagueService.LeagueHustleStatsPlayer(season, seasonType, perMode));

                    }

                    foreach (var perMode in PerModeService.BasePerModes)
                    {
                        foreach (var playType in PlayTypeService.PlayTypes)
                        {
                            foreach (var type in OffensiveDefensiveService.OffensiveDefensive)
                            {
                                tasks.Add(SynergyService.SynergyPlayType(perMode, seasonType, playType, "P", type, season));
                            }
                        }

                        foreach (var measureType in PTMeasureTypeService.PTMeasureTypes)
                        {
                            tasks.Add(LeagueService.LeagueDashPTStats(season, seasonType, perMode, measureType, "Player"));
                        }

                        foreach (var defensiveCategory in DefenseCategoryService.Categories)
                        {
                            tasks.Add(LeagueService.LeagueDashPTDefend(season, seasonType, perMode, defensiveCategory));
                        }

                        //LeagueDashPlayerPTShot has other parameters to consider (Shot Clock, Dribbles, Touch Time, Closest Defender, Closest Defender +10) https://www.nba.com/stats/players/shots-shotclock
                        foreach (var shotRange in ShotRangeService.ShotRanges)
                        {
                            tasks.Add(LeagueService.LeagueDashPlayerPTShot(season, seasonType, perMode, shotRange));
                        }

                        foreach (var distanceRange in DistanceRangeService.DistanceRanges)
                        {
                            tasks.Add(LeagueService.LeagueDashPlayerShotLocations(season, seasonType, perMode, distanceRange, "Base"));
                            tasks.Add(LeagueService.LeagueDashPlayerShotLocations(season, seasonType, perMode, distanceRange, "Opponent"));
                        }

                        tasks.Add(LeagueService.LeagueHustleStatsPlayerLeaders(season, seasonType, perMode));
                        tasks.Add(LeagueService.LeagueDashPlayerBioStats(season, seasonType, perMode));
                    }
                }

                //obtain player data for current season
                var seasonPlayers = await PlayerService.PlayerIndex(season, "0");
                var playerIDs = await DailyHelper.GetIDs("PLAYER_ID", "P", season, dateFrom, dateTo);

                foreach (var playerID in playerIDs)
                {
                    int playerIndex = playerIDs.IndexOf(playerID) + 1;
                    tasks.Add(Task.Run(async() => {
                        await TimeoutHelper.Count();
                        Console.WriteLine($"Loading {playerIndex} of {playerIDs.Count} players. ({playerID})"); 
                    }));

                    tasks.Add(CommonService.CommonPlayerInfo(playerID)); ///TODO: FIX THIS!!!

                    foreach (var perMode in PerModeService.PlayerPerModes)
                    {
                        tasks.Add(PlayerService.PlayerProfileV2(playerID, perMode));
                    }
                }

                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                DatabaseHelper.ErrorDocument(ex, "LoadPlayerData", null, "load");
                throw;
            }
        }

        static async void LoadAdditionalPlayerData(string playerID, string season, string seasonType, string perMode)
        {
            foreach (var measureType in MeasureTypeService.PlayerMeasureTypes)
            {
                await PlayerService.PlayerDashboardByClutch(playerID, season, seasonType, perMode, measureType);
                await PlayerService.PlayerDashboardByGameSplits(playerID, season, seasonType, perMode, measureType);
                await PlayerService.PlayerDashboardByGeneralSplits(playerID, season, seasonType, perMode, measureType);
                await PlayerService.PlayerDashboardByLastNGames(playerID, season, seasonType, perMode, measureType);
                await PlayerService.PlayerDashboardByOpponent(playerID, season, seasonType, perMode, measureType);
                await PlayerService.PlayerDashboardByShootingSplits(playerID, season, seasonType, perMode, measureType);
                await PlayerService.PlayerDashboardByTeamPerformance(playerID, season, seasonType, perMode, measureType);
            }
        }
    }
}
