﻿using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BBALL.LIB.Services;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;
using System.Threading.Tasks;
using BBALL.LIB.Services.Static;

namespace BBALL.CON
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadData();
        }

        /// <summary>
        /// Load the filtering objects to the database. Use this to rebuild the filters in the database.
        /// </summary>
        static void LoadFilters()
        {
            ConferenceService.LoadFilter();
            ContextMeasureService.LoadFilter();
        }

        /// <summary>
        /// One time load of player data.
        /// </summary>
        static async void OneTimeLoad()
        {
            var season = SeasonService.CurrentSeason.FirstOrDefault();
            //obtain player data for current season
            var commonDocument = await PlayerService.PlayerIndex(season, "0");
            var seasonPlayers = commonDocument["resultSets"][0]["data"].AsBsonArray;
            var playerIDs = DailyHelper.GetIDs("PLAYER_ID", "P", season);

            foreach (var playerID in playerIDs)
            {
                var playerInfo = seasonPlayers.Where(x => x["PERSON_ID"] == playerID).FirstOrDefault();
                Console.WriteLine(playerID + " | started");

                foreach (var seasonType in SeasonTypeService.PlayerSeasonTypes)
                {
                    var totals = "Totals";
                    foreach (var measureType in MeasureTypeService.PlayerMeasureTypes)
                    {
                        await PlayerService.PlayerGameLogs(season, seasonType, totals, measureType, playerID);
                    }
                }

                Console.WriteLine(playerID + " | completed");
            }
        }

        /// <summary>
        /// The primary function to load data.
        /// </summary>
        /// <param name="daily">Boolean field to load the current date.</param>
        /// <param name="seasons">A list of seasons to be loaded.</param>
        static async void LoadData(bool daily = true, List<string> seasons = null)
        {
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                string startTime = String.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now);

                string dt = null;

                if (daily)
                {
                    string season = SeasonHelper.DefaultSeason();
                    //var dateStart = DailyHelper.GetDate(-14);
                    dt = DailyHelper.GetDate();
                    List<string> seasonTypes = SeasonHelper.GetSeasonTypes(season, dt, dt);

                    LoadSeasonData(season, seasonTypes, dt, dt);
                }
                else
                {
                    await PlayerService.PlayerGameLogs();
                    var playerDocument = await PlayerService.PlayerIndex();

                    foreach (var season in seasons)
                    {
                        List<string> seasonTypes = SeasonHelper.GetSeasonTypes(season);

                        LoadSeasonData(season, seasonTypes);
                    }
                }

                stopWatch.Stop();
                string endTime = String.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now);

                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine("RunTime " + elapsedTime);

                BsonDocument loadDocument = new BsonDocument();
                loadDocument.Add(new BsonElement("Daily", daily));
                loadDocument.Add(new BsonElement("Date", dt));
                loadDocument.Add(new BsonElement("StartTime", startTime));
                loadDocument.Add(new BsonElement("EndTime", endTime));
                loadDocument.Add(new BsonElement("Elapsed", elapsedTime));

                DatabaseHelper.AddDocument("dataload", loadDocument);
            }
            catch (Exception)
            {
                Console.WriteLine("There was an error loading data...");
            }
            finally
            {
                ////shutdown computer
                Process.Start("shutdown", "/s /t 0");
            }
        }

        /// <summary>
        /// Load the data for a given season.
        /// </summary>
        /// <param name="season">The season to laod data for.</param>
        /// <param name="seasonTypes">The different season types.</param>
        /// <param name="dateFrom">The start date.</param>
        /// <param name="dateTo">The end date.</param>
        static void LoadSeasonData(string season, List<string> seasonTypes, string dateFrom = null, string dateTo = null)
        {
            try
            {
                //Load player game logs
                Console.WriteLine("Player game log load started.");
                LoadPlayerGameLogs(season, seasonTypes);
                Console.WriteLine("Player game log load complete.");

                //Load team data 
                Console.WriteLine("Team data load started.");
                LoadTeamData(season, seasonTypes, dateFrom, dateTo);
                Console.WriteLine("Team data load complete.");

                //Load player data
                Console.WriteLine("Player data load started.");
                LoadPlayerData(season, seasonTypes, dateFrom, dateTo);
                Console.WriteLine("Player data load complete.");

                //Load game data
                Console.WriteLine("Game data load started.");
                LoadGameData(season, seasonTypes, dateFrom, dateTo);
                Console.WriteLine("Game data load complete.");

                //Load season data
                Console.WriteLine("League data load started.");
                LoadLeagueData(season, seasonTypes);
                Console.WriteLine("League data load complete.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Load team data to the database.
        /// </summary>
        /// <param name="season">The season to laod.</param>
        /// <param name="seasonTypes">The season types.</param>
        /// <param name="dateFrom">The start date.</param>
        /// <param name="dateTo">The end date.</param>
        static async void LoadTeamData(string season, List<string> seasonTypes, string dateFrom = null, string dateTo = null)
        {
            try
            {
                var teamsDocument = await TeamService.CommonTeamYears();
                var franchisesDocument = await TeamService.FranchiseHistory();
                var teams = teamsDocument["resultSets"][0]["data"].AsBsonArray;

                var teamIDs = DailyHelper.GetIDs("TEAM_ID", "T", season, dateFrom, dateTo);

                int teamCount = teamIDs.Count;

                //loop through all the teams
                foreach (var teamID in teamIDs)
                {
                    int teamIndex = teamIDs.IndexOf(teamID) + 1;
                    Console.WriteLine("Loading " + teamIndex + " of " + teamCount + " teams. (" + teamID + ")");

                    //get the team details
                    await TeamService.TeamDetails(teamID);
                    await TeamService.TeamYearByYearStats(teamID);
                    await FranchiseService.FranchiseLeaders(teamID);
                    //var playersDocument = CommonService.CommonAllPlayers(season);

                    await CommonService.CommonTeamRoster(teamID, season);

                    await TeamService.TeamGameLogs(teamID, season);
                    await TeamService.TeamHistoricalLeaders(teamID, season);

                    foreach (var seasonType in seasonTypes)
                    {
                        ///TODO: loop through season types
                        await TeamService.TeamGameLog(teamID, season, seasonType);
                        await TeamService.TeamInfoCommon(teamID, season, seasonType);
                        await ShotChartService.ShotChartDetail(season, null, "0", teamID, seasonType);

                        //loop through different team per modes
                        foreach (var perMode in PerModeService.TeamPerModes)
                        {
                            await FranchiseService.FranchisePlayers(teamID, perMode, seasonType); 

                            await TeamService.TeamDashPtPass(teamID, season, perMode, seasonType);
                            await TeamService.TeamDashPtReb(teamID, season, perMode, seasonType);
                            await TeamService.TeamDashPtShots(teamID, season, perMode, seasonType);

                            await TeamService.TeamDashboardByShootingSplits(teamID, season, "Usage", perMode, seasonType);
                            await TeamService.TeamPlayerOnOffSummary(teamID, season, "Usage", perMode, seasonType);

                            //loop thorough different team measure types
                            foreach (var measureType in MeasureTypeService.TeamMeasureTypes)
                            {
                                await TeamService.TeamDashLineups(teamID, season, measureType, perMode, seasonType);
                                await TeamService.TeamDashboardByClutch(teamID, season, measureType, perMode, seasonType);
                                await TeamService.TeamDashboardByGameSplits(teamID, season, measureType, perMode, seasonType);
                                await TeamService.TeamDashboardByGeneralSplits(teamID, season, measureType, perMode, seasonType);
                                await TeamService.TeamDashboardByLastNGames(teamID, season, measureType, perMode, seasonType);
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
            catch (Exception ex)
            {
                DatabaseHelper.ErrorDocument(ex, "LoadTeamData", null, "load");
                throw;
            }
        }

        /// <summary>
        /// Load player game logs.
        /// </summary>
        /// <param name="season">The season to load.</param>
        /// <param name="seasonTypes">The season types.</param>
        static async void LoadPlayerGameLogs(string season, List<string> seasonTypes)
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
        static async void LoadPlayerData(string season, List<string> seasonTypes, string dateFrom = null, string dateTo = null)
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
                        await PlayerService.PlayerGameLog(playerID, season, seasonType);
                        await PlayerService.PlayerNextNGames(playerID, season, seasonType);
                        await ShotChartService.ShotChartDetail(season, null, playerID, "0", seasonType);

                        foreach (var perMode in PerModeService.PerModes)
                        {
                            //LoadAdditionalPlayerData(playerID, season, seasonType, perMode);

                            await PlayerService.PlayerDashboardByYearOverYear(playerID, season, seasonType, perMode, "Base");
                            await PlayerService.PlayerDashboardByYearOverYear(playerID, season, seasonType, perMode, "Advanced");
                        }

                        var totals = "Totals";
                        foreach (var measureType in MeasureTypeService.PlayerMeasureTypes)
                        {
                            await PlayerService.PlayerGameLogs(season, seasonType, totals, measureType, playerID);
                        }
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

        /// <summary>
        /// Load game data.
        /// </summary>
        /// <param name="season">The season to load.</param>
        /// <param name="seasonTypes">The season types.</param>
        /// <param name="dateFrom">The start date.</param>
        /// <param name="dateTo">The end date.</param>
        static async void LoadGameData(string season, List<string> seasonTypes, string dateFrom = null, string dateTo = null)
        {
            try
            {
                var gameIDs = DailyHelper.GetIDs("GAME_ID", "T", season, dateFrom, dateTo);

                foreach (var seasonType in seasonTypes)
                {
                    //load the games
                    await LeagueService.LeagueGameLog(season, seasonType);

                    //obtain game data
                    JArray parameters = new JArray();
                    parameters.Add(CreateParameterObject("Season", season));
                    parameters.Add(CreateParameterObject("SeasonType", seasonType));

                    //load game data
                    var gameDocuments = GameService.ImportGames(parameters);

                    int gameCount = gameIDs.Count;
                    foreach (var gameID in gameIDs)
                    {
                        int gameIndex = gameIDs.IndexOf(gameID) + 1;
                        Console.WriteLine("Loading " + gameIndex + " of " + gameCount + " games. (" + gameID + ")");

                        await BoxScoreService.BoxScoreAdvancedV2(gameID);
                        await BoxScoreService.BoxScoreDefensive(gameID);
                        await BoxScoreService.BoxScoreFourFactorsV2(gameID);
                        await BoxScoreService.BoxScoreMatchups(gameID);
                        await BoxScoreService.BoxScoreMiscV2(gameID);
                        await BoxScoreService.BoxScorePlayerTrackV2(gameID);
                        await BoxScoreService.BoxScoreScoringV2(gameID);
                        await BoxScoreService.BoxScoreSummaryV2(gameID);
                        await BoxScoreService.BoxScoreTraditionalV2(gameID);
                        await BoxScoreService.BoxScoreUsageV2(gameID);
                        await BoxScoreService.HustleStatsBoxScore(gameID);
                        //await PlayByPlayService.PlayByPlay(gameID);
                        await PlayByPlayService.PlayByPlayV2(gameID);

                        await GameService.GameRotation(gameID);
                        await VideoService.VideoDetailAsset(gameID, season, seasonType);
                        await ShotChartService.ShotChartDetail(season, gameID, "0", "0", seasonType);
                    }
                }
            }
            catch (Exception ex)
            {
                DatabaseHelper.ErrorDocument(ex, "LoadGameData", null, "load");
                throw;
            }
        }

        /// <summary>
        /// Load entire league data.
        /// </summary>
        /// <param name="season">The season to load.</param>
        /// <param name="seasonTypes">The season types.</param>
        static async void LoadLeagueData(string season, List<string> seasonTypes)
        {
            try
            {
                await TeamService.TeamEstimatedMetrics(season);
                DraftService.DraftCombineAll(season);

                foreach (var seasonType in seasonTypes)
                {
                    ///season type
                    //await LeagueService.LeagueStandings(season, seasonType);
                    await LeagueService.LeagueStandingsV3(season, seasonType);

                    foreach (var statType in StatTypeService.StatTypes)
                    {
                        await HomePageService.HomePageV2(season, seasonType, statType);
                    }

                    await PlayerService.PlayerEstimatedMetrics(season, seasonType);

                    foreach (var perMode in PerModeService.PerModes)
                    {
                        ///per mode, and season type
                        await LeagueService.LeagueDashPlayerBioStats(season, seasonType, perMode);
                        await LeagueService.LeagueDashOppPtShot(season, seasonType, perMode);
                        await LeagueService.LeagueDashPlayerPTShot(season, seasonType, perMode);
                        await LeagueService.LeagueDashTeamPtShot(season, seasonType, perMode);
                        await LeagueService.LeagueHustleStatsPlayer(season, seasonType, perMode);

                        await LeagueService.LeagueHustleStatsPlayerLeaders(season, seasonType, perMode);
                        await LeagueService.LeagueHustleStatsTeam(season, seasonType, perMode);
                        await LeagueService.LeagueHustleStatsTeamLeaders(season, seasonType, perMode);
                        //LeagueService.LeagueSeasonMatchups(season, seasonType, perMode);

                        await LeadersService.LeagueLeaders(season, seasonType, perMode); ///TODO: loop through stat category

                        await MatchupsService.MatchupsRollup(season, seasonType, perMode);

                        await LeagueService.LeagueDashPlayerShotLocations(season, seasonType, perMode);
                        await LeagueService.LeagueDashTeamShotLocations(season, seasonType, perMode);

                        //PlayerService.PlayerCareerByCollege(season, seasonType, perMode); ///TODO: would need to loop through categories
                        //PlayerService.PlayerCareerByCollegeRollup(season, seasonType, perMode); ///TODO: would need to loop through categories

                        foreach (var measureType in MeasureTypeService.LeagueMeasureTypes)
                        {
                            ///season type, per mode, measure type (teams might be different)
                            await LeagueService.LeagueDashLineups(season, seasonType, perMode, measureType);

                            if (measureType != "Four Factors")
                            {
                                await LeagueService.LeagueDashPlayerStats(season, seasonType, perMode, measureType);
                            }

                            await LeagueService.LeagueDashTeamStats(season, seasonType, perMode, measureType);
                            await LeagueService.LeagueLineupViz(season, seasonType, perMode, measureType);

                            if (measureType != "Defense" && measureType != "Usage")
                            {
                                await LeagueService.LeagueDashPlayerClutch(season, seasonType, perMode, measureType);
                                await LeagueService.LeagueDashTeamClutch(season, seasonType, perMode, measureType);
                                await LeagueService.LeaguePlayerOnDetails(season, seasonType, perMode, measureType);
                            }
                        }

                        if (perMode != "Per36" && perMode != "Per48")
                        {
                            foreach (var ptMeasureType in PTMeasureTypeService.PTMeasureTypes)
                            {
                                ///season type, per mode, pt measure type
                                await LeagueService.LeagueDashPTStats(season, seasonType, perMode, ptMeasureType);
                            }

                            foreach (var defensiveCategory in DefenseCategoryService.Categories)
                            {
                                ///season type, per mode, defensive category
                                await LeagueService.LeagueDashPTDefend(season, seasonType, perMode, defensiveCategory);
                                await LeagueService.LeagueDashPTTeamDefend(season, seasonType, perMode, defensiveCategory);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DatabaseHelper.ErrorDocument(ex, "LoadLeagueData", null, "load");
                throw;
            }
        }
    }
}
