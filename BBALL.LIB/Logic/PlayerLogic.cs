using BBALL.LIB.Helpers;
using BBALL.LIB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public static async void LoadPlayerData(string season, List<string> seasonTypes, string dateFrom = null, string dateTo = null)
        {
            try
            {
                //obtain player data for current season
                var seasonPlayers = await PlayerService.PlayerIndex(season, "0");
                var playerIDs = DailyHelper.GetIDs("PLAYER_ID", "P", season, dateFrom, dateTo);

                foreach (var playerID in playerIDs)
                {
                    int playerIndex = playerIDs.IndexOf(playerID) + 1;
                    Console.WriteLine($"Loading {playerIndex} of {playerIDs.Count} players. ({playerID})");

                    await CommonService.CommonPlayerInfo(playerID); ///TODO: FIX THIS!!!

                    foreach (var perMode in PerModeService.PlayerPerModes)
                    {
                        await PlayerService.PlayerCareerStats(playerID, perMode);
                        await PlayerService.PlayerProfileV2(playerID, perMode);

                        //LoadAdditionalPlayerData(playerID, season, seasonType, perMode);
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
