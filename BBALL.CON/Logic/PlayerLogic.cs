using BBALL.LIB.Helpers;
using BBALL.LIB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBALL.CON.Logic
{
    public static class PlayerLogic
    {
        /// <summary>
        /// Load player game logs.
        /// </summary>
        /// <param name="season">The season to load.</param>
        /// <param name="seasonTypes">The season types.</param>
        public static async void LoadPlayerGameLogs(string season, List<string> seasonTypes)
        {
            var perMode = "Totals";
            foreach (var seasonType in seasonTypes)
            {
                foreach (var measureType in MeasureTypeService.PlayerMeasureTypes)
                {
                    await PlayerService.PlayerGameLogs(season, seasonType, perMode, measureType);
                }
            }
        }

        /// <summary>
        /// Load player data to the database.
        /// </summary>
        /// <param name="season">The season to load.</param>
        /// <param name="seasonTypes">The season types.</param>
        /// <param name="dateFrom">The start date.</param>
        /// <param name="dateTo">The end date.</param>
        public static async void LoadPlayerData(string season, List<string> seasonTypes, string dateFrom = null, string dateTo = null)
        {
            try
            {
                //obtain player data for current season
                var commonDocument = await PlayerService.PlayerIndex(season, "0");
                var seasonPlayers = commonDocument["resultSets"][0]["data"].AsBsonArray;
                var playerIDs = DailyHelper.GetIDs("PLAYER_ID", "P", season, dateFrom, dateTo);

                int playerCount = playerIDs.Count;

                foreach (var playerID in playerIDs)
                {
                    int playerIndex = playerIDs.IndexOf(playerID) + 1;
                    Console.WriteLine("Loading " + playerIndex + " of " + playerCount + " players. (" + playerID + ")");

                    var playerInfo = seasonPlayers.Where(x => x["PERSON_ID"] == playerID).FirstOrDefault();
                    //var playerSlug = playerInfo["PLAYER_SLUG"].ToString();

                    await CommonService.CommonPlayerInfo(playerID); ///TODO: FIX THIS!!!
                    await ShotChartService.ShotChartDetail(null, null, playerID);

                    foreach (var perMode in PerModeService.PlayerPerModes)
                    {
                        await PlayerService.PlayerCareerStats(playerID, perMode);
                        await PlayerService.PlayerProfileV2(playerID, perMode);
                    }

                    foreach (var seasonType in seasonTypes)
                    {
                        //await PlayerService.PlayerGameLog(playerID, season, seasonType); //same data found by team
                        await PlayerService.PlayerNextNGames(playerID, season, seasonType);
                        await ShotChartService.ShotChartDetail(season, null, playerID, "0", seasonType);

                        foreach (var perMode in PerModeService.PerModes)
                        {
                            //LoadAdditionalPlayerData(playerID, season, seasonType, perMode);

                            await PlayerService.PlayerDashboardByYearOverYear(playerID, season, seasonType, perMode, "Base");
                            await PlayerService.PlayerDashboardByYearOverYear(playerID, season, seasonType, perMode, "Advanced");
                        }

                        //var totals = "Totals";
                        //foreach (var measureType in MeasureTypeService.PlayerMeasureTypes)
                        //{
                        //    await PlayerService.PlayerGameLogs(season, seasonType, totals, measureType, playerID);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                DatabaseHelper.ErrorDocument(ex, "LoadPlayerData", null, "load");
                throw;
            }
        }

        static async void LoadAdditionalPlayerData(string playerID, string season, string seasonType, string perMode)
        {
            await PlayerService.PlayDashPTShotDefend(playerID, season, seasonType, perMode);

            if (perMode == "Per36" || perMode == "Per48")
            {
                Console.WriteLine("skip");
            }
            else
            {
                await PlayerService.PlayDashPTPass(playerID, season, seasonType, perMode);
                await PlayerService.PlayDashPTReb(playerID, season, seasonType, perMode);
                await PlayerService.PlayDashPTShots(playerID, season, seasonType, perMode);
            }

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
