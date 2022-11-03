using BBALL.LIB.Helpers;
using BBALL.LIB.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Logic
{
    public static class TeamLogic
    {
        /// <summary>
        /// Load team data to the database.
        /// </summary>
        /// <param name="season">The season to laod.</param>
        /// <param name="seasonTypes">The season types.</param>
        /// <param name="dateFrom">The start date.</param>
        /// <param name="dateTo">The end date.</param>
        public static async void LoadTeamData(string season, List<string> seasonTypes, string dateFrom = null, string dateTo = null)
        {
            try
            {
                var teams = await TeamService.CommonTeamYears();
                var franchisesDocument = await TeamService.FranchiseHistory();

                var teamIDs = DailyHelper.GetIDs("TEAM_ID", "T", season, dateFrom, dateTo);

                int teamCount = teamIDs.Count;

                //loop through all the teams
                foreach (var teamID in teamIDs)
                {
                    int teamIndex = teamIDs.IndexOf(teamID) + 1;
                    Console.WriteLine($"Loading {teamIndex} of {teamCount} teams. ({teamID})");

                    //get the team details
                    await TeamService.TeamDetails(teamID);
                    
                    await TeamService.TeamYearByYearStats(teamID);

                    await CommonService.CommonTeamRoster(teamID, season);

                    await TeamService.TeamHistoricalLeaders(teamID, season);

                    foreach (var seasonType in seasonTypes)
                    {
                        await TeamService.TeamInfoCommon(teamID, season, seasonType);
                        await ShotChartService.ShotChartDetail(season, null, teamID, "0", seasonType);
                    }
                }
            }
            catch (Exception ex)
            {
                DatabaseHelper.ErrorDocument(ex, "LoadTeamData", null, "load");
                throw;
            }
        }

        static async void LoadAdditionalTeamData(string teamID, string season, string seasonType)
        {
            //loop through different team per modes
            foreach (var perMode in PerModeService.TeamPerModes)
            {

                if (seasonType != "Pre Season")
                {
                    await FranchiseService.FranchisePlayers(teamID, perMode, seasonType);
                }

                await TeamService.TeamDashboardByShootingSplits(teamID, season, "Usage", perMode, seasonType);
                await TeamService.TeamPlayerOnOffSummary(teamID, season, "Usage", perMode, seasonType);

                //loop thorough different team measure types
                foreach (var measureType in MeasureTypeService.TeamMeasureTypes)
                {
                    await TeamService.TeamDashLineups(teamID, season, measureType, perMode, seasonType);
                    //await TeamService.TeamDashboardByClutch(teamID, season, measureType, perMode, seasonType);
                    await TeamService.TeamDashboardByGameSplits(teamID, season, measureType, perMode, seasonType);
                    await TeamService.TeamDashboardByGeneralSplits(teamID, season, measureType, perMode, seasonType);
                    //await TeamService.TeamDashboardByLastNGames(teamID, season, measureType, perMode, seasonType);
                    await TeamService.TeamDashboardByOpponent(teamID, season, measureType, perMode, seasonType);
                    await TeamService.TeamDashboardByShootingSplits(teamID, season, measureType, perMode, seasonType);
                    await TeamService.TeamDashboardByTeamPerformance(teamID, season, measureType, perMode, seasonType);
                    await TeamService.TeamDashboardByYearOverYear(teamID, season, measureType, perMode, seasonType);

                    if (measureType == "Opponent" || measureType == "Four Factors")
                    {
                        Console.WriteLine("Skip teamplayerdashboard.");
                    }
                    else
                    {
                        await TeamService.TeamPlayerDashboard(teamID, season, measureType, perMode, seasonType);
                    }
                    await TeamService.TeamPlayerOnOffDetails(teamID, season, measureType, perMode, seasonType);
                    await TeamService.TeamPlayerOnOffSummary(teamID, season, measureType, perMode, seasonType);
                }
            }
        }
    }
}
