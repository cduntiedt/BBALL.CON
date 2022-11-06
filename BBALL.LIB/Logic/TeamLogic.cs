using BBALL.LIB.Helpers;
using BBALL.LIB.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
                var teamIDs = DailyHelper.GetIDs("TEAM_ID", "T", season, dateFrom, dateTo);
               
                var tasks = new List<Task>();

                tasks.Add(TeamService.CommonTeamYears());
                tasks.Add(TeamService.FranchiseHistory());

                int teamCount = teamIDs.Count;

                //loop through all the teams
                foreach (var teamID in teamIDs)
                {
                    int teamIndex = teamIDs.IndexOf(teamID) + 1;
                    Console.WriteLine($"Loading {teamIndex} of {teamCount} teams. ({teamID})");

                    //get the team details
                    tasks.Add(TeamService.TeamDetails(teamID));

                    tasks.Add(TeamService.TeamYearByYearStats(teamID));

                    tasks.Add(CommonService.CommonTeamRoster(teamID, season));

                    tasks.Add(TeamService.TeamHistoricalLeaders(teamID, season));

                    foreach (var seasonType in seasonTypes)
                    {
                        tasks.Add(TeamService.TeamInfoCommon(teamID, season, seasonType));
                        tasks.Add(ShotChartService.ShotChartDetail(season, null, "0", teamID, seasonType));
                    }
                }

                await Task.WhenAll(tasks);
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
