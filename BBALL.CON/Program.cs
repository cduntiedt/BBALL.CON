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
            PlayerService.PlayerGameLogs();

            var teams = teamsDocument["resultSets"][0]["data"].AsBsonArray;

            //loop through all the teams
            foreach (var team in teams)
            {
                //the team abbreviation
                var abbr = team["ABBREVIATION"];
                //the first year the team started
                var minYear = Convert.ToInt64(team["MIN_YEAR"]);
                //the unique team id
                var teamID = team["TEAM_ID"].ToString();

                Console.WriteLine(teamID + " - " + abbr);

                //get the team details
                TeamService.TeamDetails(teamID);
                TeamService.TeamYearByYearStats(teamID);
                FranchiseService.FranchiseLeaders(teamID);
                FranchiseService.FranchisePlayers(teamID); ///TODO: could loop through per mode & season type
                Wait(500);

                //loop through all the seaons
                foreach (var season in seasons)
                {
                    //var playersDocument = CommonService.CommonAllPlayers(season);

                    //get the first year of the season (ex: 2020 in 2020-21)
                    var seasonYear1 = Convert.ToInt64(season.Substring(0, 4));
                    Console.WriteLine(seasonYear1);

                    if (!abbr.IsBsonNull && minYear <= seasonYear1)
                    {
                        Console.WriteLine(teamID + " - " + abbr + " - " + season);

                        CommonService.CommonTeamRoster(teamID, season);
                        TeamService.TeamGameLog(teamID, season);
                        TeamService.TeamGameLogs(teamID, season);
                        TeamService.TeamHistoricalLeaders(teamID, season);
                        TeamService.TeamInfoCommon(teamID, season);

                        ShotChartService.ShotChartDetail(season, null, "0", teamID); ///TODO: loop through season types
                        Wait(500);

                        //loop through different team per modes
                        foreach (var perMode in PerModeService.TeamPerModes)
                        {
                            Console.WriteLine(teamID + " - " + abbr + " - " + season + " - " + perMode);

                            TeamService.TeamDashPtPass(teamID, season, perMode);
                            TeamService.TeamDashPtReb(teamID, season, perMode);
                            TeamService.TeamDashPtShots(teamID, season, perMode);
                            Wait(500);

                            //loop thorough different team measure types
                            foreach (var measureType in MeasureTypeService.TeamMeasureTypes)
                            {
                                Console.WriteLine(teamID + " - " + abbr + " - " + season + " - " + perMode + " - " + measureType);

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
                        }
                    }
                }
            }

            //loop through all the seasons
            foreach (var season in seasons)
            {
                Console.WriteLine(season);
                
                TeamService.TeamEstimatedMetrics(season);
                DraftService.DraftCombineAll(season);
                Wait(500);
                
                foreach (var seasonType in SeasonTypeService.LeagueSeasonTypes)
                {
                    Console.WriteLine(season + " - " + seasonType);
                    ///season type
                    LeagueService.LeagueGameLog(season, seasonType);
                    LeagueService.LeagueStandings(season, seasonType);
                    LeagueService.LeagueStandingsV3(season, seasonType);
                    
                    ///TODO: Loop through stat type
                    HomePageService.HomePageLeaders(season, seasonType);
                    HomePageService.HomePageV2(season, seasonType);
                    
                    PlayerService.PlayerEstimatedMetrics(season, seasonType);
                    Wait(500);

                    foreach (var perMode in PerModeService.PerModes)
                    {
                        Console.WriteLine(season + " - " + seasonType + " - " + perMode);
                        ///per mode, and season type
                        LeagueService.LeagueDashPlayerBioStats(season, seasonType, perMode);
                        LeagueService.LeagueDashOppPtShot(season, seasonType, perMode);
                        LeagueService.LeagueDashPlayerPTShot(season, seasonType, perMode);
                        LeagueService.LeagueDashTeamPtShot(season, seasonType, perMode);
                        LeagueService.LeagueHustleStatsPlayer(season, seasonType, perMode);
                        LeagueService.LeagueHustleStatsPlayerLeaders(season, seasonType, perMode);
                        LeagueService.LeagueHustleStatsTeam(season, seasonType, perMode);
                        LeagueService.LeagueHustleStatsTeamLeaders(season, seasonType, perMode);
                        LeagueService.LeagueSeasonMatchups(season, seasonType, perMode);

                        LeadersService.LeagueLeaders(season, seasonType, perMode); ///TODO: loop through stat category
                        Wait(500);

                        MatchupsService.MatchupsRollup(season, seasonType, perMode);

                        PlayerService.PlayerCareerByCollege(season, seasonType, perMode);
                        PlayerService.PlayerCareerByCollegeRollup(season, seasonType, perMode);
                        Wait(500);

                        foreach (var measureType in MeasureTypeService.LeagueMeasureTypes)
                        {
                            Console.WriteLine(season + " - " + seasonType + " - " + perMode + " - " + measureType);
                            ///season type, per mode, measure type (teams might be different)
                            LeagueService.LeagueDashLineups(season, seasonType, perMode, measureType);
                            LeagueService.LeagueDashPlayerClutch(season, seasonType, perMode, measureType);
                            LeagueService.LeagueDashPlayerShotLocations(season, seasonType, perMode, measureType);
                            LeagueService.LeagueDashPlayerStats(season, seasonType, perMode, measureType);
                            LeagueService.LeagueDashTeamClutch(season, seasonType, perMode, measureType);
                            LeagueService.LeagueDashTeamShotLocations(season, seasonType, perMode, measureType);
                            LeagueService.LeagueDashTeamStats(season, seasonType, perMode, measureType);
                            LeagueService.LeagueDashOpponentShotLocations(season, seasonType, perMode, measureType);
                            LeagueService.LeagueLineupViz(season, seasonType, perMode, measureType);
                            LeagueService.LeaguePlayerOnDetails(season, seasonType, perMode, measureType);
                            Wait(500);
                        }

                        foreach (var ptMeasureType in PTMeasureTypeService.PTMeasureTypes)
                        {
                            Console.WriteLine(season + " - " + seasonType + " - " + perMode + " - " + ptMeasureType);
                            ///season type, per mode, pt measure type
                            LeagueService.LeagueDashPTStats(season, seasonType, perMode, ptMeasureType);
                            Wait(500);
                        }

                        foreach (var defensiveCategory in DefenseCategoryService.Categories)
                        {
                            Console.WriteLine(season + " - " + seasonType + " - " + perMode + " - " + defensiveCategory);
                            ///season type, per mode, defensive category
                            LeagueService.LeagueDashPTDefend(season, seasonType, perMode, defensiveCategory);
                            LeagueService.LeagueDashPTTeamDefend(season, seasonType, perMode, defensiveCategory);
                            Wait(500);
                        }
                    }
                }

                //obtain game data
                JArray parameters = new JArray();
                parameters.Add(CreateParameterObject("Season", season));

                var gameDocuments = GameService.ImportGames(parameters);
                foreach (var gameDocument in gameDocuments)
                {
                    var seasonType = gameDocument["SeasonType"].ToString();

                    foreach (var game in gameDocument["Games"].AsBsonArray)
                    {
                        var gameId = game["Game_ID"].ToString();
                        Console.WriteLine(season + " - " + gameId);

                        BoxScoreService.BoxScoreAll(gameId);
                        Wait(500);

                        GameService.GameRotation(gameId);
                        PlayByPlayService.PlayByPlayAll(gameId);
                        VideoService.VideoDetailAsset(gameId, season, seasonType);
                        ShotChartService.ShotChartDetail(season, gameId, "0", "0", seasonType);
                        Wait(500);
                    }
                }

                //obtain player data
                var commonDocument = CommonService.CommonAllPlayers(season);
                var seasonPlayers = commonDocument["resultSets"][0]["data"].AsBsonArray;
                if (!seasonPlayers.IsBsonNull)
                {
                    foreach (var player in seasonPlayers)
                    {
                        var playerID = player["PlayerID"].ToString();

                        foreach (var seasonType in SeasonTypeService.PlayerSeasonTypes)
                        {
                            Console.WriteLine(playerID + " - " + season + " - " + seasonType);

                            PlayerService.PlayerGameLog(playerID, season, seasonType);
                            PlayerService.PlayerNextNGames(playerID, season, seasonType);
                            ShotChartService.ShotChartDetail(season, null, playerID, "0", seasonType);
                            Wait(500);

                            foreach (var perMode in PerModeService.PerModes)
                            {
                                Console.WriteLine(playerID + " - " + season + " - " + seasonType + " - " + perMode);
                                
                                PlayerService.PlayDashPTPass(playerID, season, seasonType, perMode);
                                PlayerService.PlayDashPTReb(playerID, season, seasonType, perMode);
                                PlayerService.PlayDashPTShotDefend(playerID, season, seasonType, perMode);
                                PlayerService.PlayDashPTShots(playerID, season, seasonType, perMode);
                                Wait(500);

                                foreach (var measureType in MeasureTypeService.PlayerMeasureTypes)
                                {
                                    Console.WriteLine(playerID + " - " + season + " - " + seasonType + " - " + perMode + " - " + measureType);
                                    
                                    PlayerService.PlayerDashboardByClutch(playerID, season, seasonType, perMode, measureType);
                                    PlayerService.PlayerDashboardByGameSplits(playerID, season, seasonType, perMode, measureType);
                                    PlayerService.PlayerDashboardByGeneralSplits(playerID, season, seasonType, perMode, measureType);
                                    PlayerService.PlayerDashboardByLastNGames(playerID, season, seasonType, perMode, measureType);
                                    PlayerService.PlayerDashboardByOpponent(playerID, season, seasonType, perMode, measureType);
                                    PlayerService.PlayerDashboardByShootingSplits(playerID, season, seasonType, perMode, measureType);
                                    PlayerService.PlayerDashboardByTeamPerformance(playerID, season, seasonType, perMode, measureType);
                                    PlayerService.PlayerDashboardByYearOverYear(playerID, season, seasonType, perMode, measureType);
                                    Wait(500);
                                }
                            }
                        }
                    }
                }
            }

            var playerDocument = PlayerService.PlayerIndex();
            var allPlayers = playerDocument["resultSets"][0]["data"].AsBsonArray;
            //loop through all players
            foreach (var player in allPlayers)
            {
                var playerID = player["PERSON_ID"].ToString();

                CommonService.CommonPlayerInfo(playerID);
                ShotChartService.ShotChartDetail(null, null, playerID);

                foreach (var perMode in PerModeService.PerModes)
                {
                    PlayerService.PlayerCareerStats(playerID, perMode);
                    PlayerService.PlayerProfileV2(playerID, perMode);
                    Wait(500);
                }
            }
        }

        static void Wait(int milliseconds)
        {
            Console.WriteLine("Wait...");
            System.Threading.Thread.Sleep(milliseconds);
        }
    }
}
