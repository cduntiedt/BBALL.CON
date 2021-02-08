using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BBALL.LIB.Services;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;

namespace BBALL.CON
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            List<string> seasons = new List<string>();
            seasons.Add(SeasonHelper.DefaultSeason());

            LoadData(seasons);

            //LoadData(SeasonService.Seasons);

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }

        static void LoadData(List<string> seasons)
        {
            var teamsDocument = TeamService.CommonTeamYears();
            var franchisesDocument = TeamService.FranchiseHistory();

            var teams = teamsDocument["resultSets"][0]["data"].AsBsonArray;

            //loop through all the teams
            foreach (var team in teams)
            {
                var abbr = team["ABBREVIATION"];
                var minYear = Convert.ToInt64(team["MIN_YEAR"]);
                var teamID = team["TEAM_ID"].ToString();

                TeamService.TeamDetails(teamID);
                TeamService.TeamYearByYearStats(teamID);
                Wait(500);

                foreach (var season in seasons)
                {
                    //var playersDocument = CommonService.CommonAllPlayers(season);

                    //get the first year of the season (ex: 2020 in 2020-21)
                    var seasonYear1 = Convert.ToInt64(season.Substring(0, 4));
                    Console.WriteLine(seasonYear1);

                    if (!abbr.IsBsonNull && minYear <= seasonYear1)
                    {
                        Console.WriteLine(team);

                        CommonService.CommonTeamRoster(teamID, season);
                        TeamService.TeamGameLog(teamID, season);
                        TeamService.TeamGameLogs(teamID, season);
                        TeamService.TeamHistoricalLeaders(teamID, season);
                        TeamService.TeamInfoCommon(teamID, season);
                        Wait(500);

                        //loop through different team per modes
                        foreach (var perMode in PerModeService.TeamPerModes)
                        {
                            //loop thorough different team measure types
                            foreach (var measureType in MeasureTypeService.TeamMeasureTypes)
                            {
                                TeamService.TeamDashLineups(teamID, season, measureType, perMode);
                                TeamService.TeamDashboardByClutch(teamID, season, measureType, perMode);
                                TeamService.TeamDashboardByGameSplits(teamID, season, measureType, perMode);
                                TeamService.TeamDashboardByGeneralSplits(teamID, season, measureType, perMode);
                                TeamService.TeamDashboardByLastNGames(teamID, season, measureType, perMode);
                                TeamService.TeamDashboardByOpponent(teamID, season, measureType, perMode);
                                TeamService.TeamDashboardByShootingSplits(teamID, season, measureType, perMode);
                                TeamService.TeamDashboardByTeamPerformance(teamID, season, measureType, perMode);
                                TeamService.TeamDashboardByYearOverYear(teamID, season, measureType, perMode);
                                TeamService.TeamPlayerDashboard(teamID, season, measureType, perMode);
                                TeamService.TeamPlayerOnOffDetails(teamID, season, measureType, perMode);
                                TeamService.TeamPlayerOnOffSummary(teamID, season, measureType, perMode);
                                Wait(500);
                            }

                            TeamService.TeamDashPtPass(teamID, season, perMode);
                            TeamService.TeamDashPtReb(teamID, season, perMode);
                            TeamService.TeamDashPtShots(teamID, season, perMode);
                            Wait(500);
                        }
                    }
                }
            }

            //loop through all the seasons
            foreach (var season in seasons)
            {
                TeamService.TeamEstimatedMetrics(season);
                Wait(500);
            }

            //JArray parameters = new JArray();
            //if (currentGames)
            //{
            //    parameters.Add(CreateParameterObject("Season", seasons.FirstOrDefault()));
            //}
            //else
            //{
            //    parameters = null;
            //}
            //var gameDocuments = GameService.ImportGames(parameters);
            //foreach (var gameDocument in gameDocuments)
            //{
            //    foreach (var game in (BsonArray)gameDocument["Games"])
            //    {
            //        var gameID = game["Game_ID"].ToString();

            //        Wait(500);
            //        BoxScoreService.BoxScoreAll(gameID);
            //        Wait(500);
            //        PlayByPlayService.PlayByPlayAll(gameID);
            //    }
            //}
        }

        static void Wait(int milliseconds)
        {
            Console.WriteLine("Wait...");
            System.Threading.Thread.Sleep(milliseconds);
        }
    }
}
