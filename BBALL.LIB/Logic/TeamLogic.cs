using BBALL.LIB.Helpers;
using BBALL.LIB.Services;
using BBALL.LIB.Services.Static;
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
        public static async Task LoadTeamData(string season, List<string> seasonTypes, string dateFrom = null, string dateTo = null)
        {
            try
            { 
                var tasks = new List<Task>();
                foreach (var seasonType in seasonTypes)
                {
                    //team stuff
                    tasks.Add(LeagueService.LeagueStandingsV3(season, seasonType));

                    foreach (var statType in StatTypeService.StatTypes)
                    {
                        if (statType != "Tracking")
                        {
                            tasks.Add(HomePageService.HomePageV2(season, seasonType, statType));
                        }
                    }

                    tasks.Add(LeagueService.LeagueGameLog(season, seasonType, "T"));
                    tasks.Add(TeamService.TeamEstimatedMetrics(season, seasonType));

                    foreach (var measureType in MeasureTypeService.TeamClutchMeasureTypes)
                    {
                        if (measureType != "Opponent")
                        {
                            tasks.Add(TeamService.TeamGameLogs(season, seasonType, measureType));
                        }
                    }

                    foreach (var perMode in PerModeService.TeamPerModes)
                    {
                        foreach (var measureType in MeasureTypeService.TeamMeasureTypes)
                        {
                            tasks.Add(LeagueService.LeagueDashTeamStats(season, seasonType, perMode, measureType));
                        }

                        foreach (var measureType in MeasureTypeService.TeamClutchMeasureTypes)
                        {
                            tasks.Add(LeagueService.LeagueDashTeamClutch(season, seasonType, perMode, measureType));
                            tasks.Add(LeagueService.LeagueDashLineups(season, seasonType, perMode, measureType));
                        }
                    }

                    foreach (var perMode in PerModeService.BasePerModes)
                    {
                        //there is an additional play type for teams called Misc which is not included
                        foreach (var playType in PlayTypeService.PlayTypes)
                        {
                            foreach (var type in OffensiveDefensiveService.OffensiveDefensive)
                            {
                                tasks.Add(SynergyService.SynergyPlayType(perMode, seasonType, playType, "T", type, season));
                            }
                        }

                        foreach (var measureType in PTMeasureTypeService.PTMeasureTypes)
                        {
                            tasks.Add(LeagueService.LeagueDashPTStats(season, seasonType, perMode, measureType, "Team"));
                        }

                        //LeagueDashTeamPtShot && LeagueDashOppPtShot has other parameters to consider (Shot Clock, Dribbles, Touch Time, Closest Defender, Closest Defender +10) https://www.nba.com/stats/players/shots-shotclock
                        foreach (var shotRange in ShotRangeService.ShotRanges)
                        {
                            tasks.Add(LeagueService.LeagueDashTeamPtShot(season, seasonType, perMode, shotRange));
                            tasks.Add(LeagueService.LeagueDashOppPtShot(season, seasonType, perMode));
                        }

                        foreach (var distanceRange in DistanceRangeService.DistanceRanges)
                        {
                            tasks.Add(LeagueService.LeagueDashTeamShotLocations(season, seasonType, perMode, distanceRange, "Base"));
                            tasks.Add(LeagueService.LeagueDashTeamShotLocations(season, seasonType, perMode, distanceRange, "Opponent"));
                        }

                        tasks.Add(LeagueService.LeagueHustleStatsTeamLeaders(season, seasonType, perMode));
                        tasks.Add(LeagueService.LeagueHustleStatsTeam(season, seasonType, perMode));
                    }


                    foreach (var defensiveCategory in DefenseCategoryService.Categories)
                    {
                        tasks.Add(LeagueService.LeagueDashPTTeamDefend(season, seasonType, "PerGame", defensiveCategory));
                    }
                }


                tasks.Add(TeamService.CommonTeamYears());
                tasks.Add(TeamService.FranchiseHistory());

                var teamIDs = await DailyHelper.GetIDs("TEAM_ID", "T", season, dateFrom, dateTo);
                int teamCount = teamIDs.Count;

                //loop through all the teams
                foreach (var teamID in teamIDs)
                {
                    int teamIndex = teamIDs.IndexOf(teamID) + 1;
                    tasks.Add(Task.Run(async () => {
                        await TimeoutHelper.Count();
                        Console.WriteLine($"Loading {teamIndex} of {teamCount} teams. ({teamID})"); 
                    }));

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
                await DatabaseHelper.ErrorDocumentAsync(ex, "LoadTeamData", null, "load");
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
