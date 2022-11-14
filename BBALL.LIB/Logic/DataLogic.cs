using BBALL.LIB.Helpers;
using BBALL.LIB.Services;
using BBALL.LIB.Services.Static;
using MongoDB.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BBALL.LIB.Helpers.ParameterHelper;

namespace BBALL.LIB.Logic
{
    public static class DataLogic
    {
        public static async Task LoadSingleSeasonData(bool daily = true, bool shutdown = true, List<string> dataSets = null, string season = null)
        {
            var seasons = new List<string>();

            //add default season if no season was provided
            if (season == null)
            {
                seasons.Add(SeasonHelper.DefaultSeason());
            }
            else
            {
                seasons.Add(season);
            }

            await LoadData(daily, shutdown, dataSets, seasons);
        }

        /// <summary>
        /// The primary function to load data.
        /// </summary>
        /// <param name="daily">Boolean field to load the current date.</param>
        /// <param name="seasons">A list of seasons to be loaded.</param>
        public static async Task LoadData(bool daily = true, bool shutdown = true, List<string> dataSets = null, List<string> seasons = null)
        {
            //start a stopwatch to take the length of the process
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string startTime = String.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now);
            string stopTime = "";
            string restartTime = "";
            int incompleteTaskCount = 0;

            try
            {
                //add and verify the collections exist
                await LoadCollections();

                //add static filter data
                await LoadStaticData();

                //add default season if no season was provided
                if (seasons == null)
                {
                    seasons = new List<string>();
                    seasons.Add(SeasonHelper.DefaultSeason());
                }

                string dateFrom = null;
                string dateTo = null;

                //load previous days data
                if (daily)
                {
                    dateFrom = DailyHelper.GetDate();
                    dateTo = DailyHelper.GetDate();
                }

                //load all data sets, if no specific data sets are provided
                if(dataSets == null)
                {
                    dataSets = new List<string>() { "league", "game", "team", "player" };
                }

                foreach (var season in seasons)
                {
                    List<string> seasonTypes = await SeasonHelper.GetSeasonTypes(season, dateFrom, dateTo);

                    foreach (var dataSet in dataSets)
                    {
                        TimeoutHelper.Reset();

                        switch (dataSet)
                        {
                            case "league":
                                //Load game data
                                Console.WriteLine("League data load started.");
                                var tasks = new List<Task>();

                                tasks.Add(DraftService.DraftHistory(season));
                                tasks.Add(DraftService.DraftCombineDrillResults(season));
                                tasks.Add(DraftService.DraftCombineStationaryShooting(season));
                                tasks.Add(DraftService.DraftCombinePlayerAnthro(season));
                                tasks.Add(DraftService.DraftCombineSpotShooting(season));
                                tasks.Add(DraftService.DraftCombineStats(season));

                                foreach (var seasonType in seasonTypes)
                                {
                                    //team stuff
                                    tasks.Add(LeagueService.LeagueStandingsV3(season, seasonType));

                                    tasks.Add(LeagueService.LeagueGameLog(season, seasonType, "T"));
                                    tasks.Add(LeagueService.LeagueGameLog(season, seasonType, "P"));

                                    tasks.Add(TeamService.TeamEstimatedMetrics(season, seasonType));
                                    tasks.Add(PlayerService.PlayerEstimatedMetrics(season, seasonType));

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
                                                tasks.Add(SynergyService.SynergyPlayType(perMode, seasonType, playType, "P", type, season));
                                            }
                                        }

                                        foreach (var measureType in PTMeasureTypeService.PTMeasureTypes)
                                        {
                                            tasks.Add(LeagueService.LeagueDashPTStats(season, seasonType, perMode, measureType, "Team"));

                                            tasks.Add(LeagueService.LeagueDashPTStats(season, seasonType, perMode, measureType, "Player"));
                                        }

                                        foreach (var defensiveCategory in DefenseCategoryService.Categories)
                                        {
                                            tasks.Add(LeagueService.LeagueDashPTDefend(season, seasonType, perMode, defensiveCategory));
                                        }

                                        //LeagueDashTeamPtShot && LeagueDashOppPtShot has other parameters to consider (Shot Clock, Dribbles, Touch Time, Closest Defender, Closest Defender +10) https://www.nba.com/stats/players/shots-shotclock
                                        foreach (var shotRange in ShotRangeService.ShotRanges)
                                        {
                                            tasks.Add(LeagueService.LeagueDashTeamPtShot(season, seasonType, perMode, shotRange));
                                            tasks.Add(LeagueService.LeagueDashOppPtShot(season, seasonType, perMode));

                                            tasks.Add(LeagueService.LeagueDashPlayerPTShot(season, seasonType, perMode, shotRange));
                                        }

                                        foreach (var distanceRange in DistanceRangeService.DistanceRanges)
                                        {
                                            tasks.Add(LeagueService.LeagueDashTeamShotLocations(season, seasonType, perMode, distanceRange, "Base"));
                                            tasks.Add(LeagueService.LeagueDashTeamShotLocations(season, seasonType, perMode, distanceRange, "Opponent"));

                                            tasks.Add(LeagueService.LeagueDashPlayerShotLocations(season, seasonType, perMode, distanceRange, "Base"));
                                            tasks.Add(LeagueService.LeagueDashPlayerShotLocations(season, seasonType, perMode, distanceRange, "Opponent"));
                                        }

                                        tasks.Add(LeagueService.LeagueHustleStatsTeamLeaders(season, seasonType, perMode));
                                        tasks.Add(LeagueService.LeagueHustleStatsTeam(season, seasonType, perMode));

                                        tasks.Add(LeagueService.LeagueHustleStatsPlayerLeaders(season, seasonType, perMode));
                                        tasks.Add(LeagueService.LeagueDashPlayerBioStats(season, seasonType, perMode));
                                    }


                                    foreach (var defensiveCategory in DefenseCategoryService.Categories)
                                    {
                                        tasks.Add(LeagueService.LeagueDashPTTeamDefend(season, seasonType, "PerGame", defensiveCategory));
                                    }
                                }

                                tasks.Add(TeamService.CommonTeamYears());
                                tasks.Add(TeamService.FranchiseHistory());

                                await Task.WhenAll(tasks);
                                Console.WriteLine("League data load complete.");
                                break;
                            case "game":
                                //Load game data
                                Console.WriteLine("Game data load started.");
                                var gameTasks = new List<Task>();
                                var gameIDs = await DailyHelper.GetIDs("gameId", "T", season, dateFrom, dateTo);

                                foreach (var seasonType in seasonTypes)
                                {
                                    foreach (var gameID in gameIDs)
                                    {
                                        gameTasks.Add(PlayByPlayService.PlayByPlayV2(gameID));
                                        gameTasks.Add(VideoService.VideoDetailAsset(gameID, season, seasonType));
                                    }
                                }

                                await Task.WhenAll(gameTasks);
                                Console.WriteLine("Game data load complete.");
                                break;
                            case "team":
                                //Load team data 
                                Console.WriteLine("Team data load started.");
                                var teamTasks = new List<Task>();

                                var teamIDs = await DailyHelper.GetIDs("teamId", "T", season, dateFrom, dateTo);
                                int teamCount = teamIDs.Count;

                                //loop through all the teams
                                foreach (var teamID in teamIDs)
                                {
                                    //get the team details
                                    teamTasks.Add(TeamService.TeamDetails(teamID));
                                    teamTasks.Add(TeamService.TeamYearByYearStats(teamID));
                                    teamTasks.Add(CommonService.CommonTeamRoster(teamID, season));
                                    teamTasks.Add(TeamService.TeamHistoricalLeaders(teamID, season));

                                    foreach (var seasonType in seasonTypes)
                                    {
                                        teamTasks.Add(TeamService.TeamInfoCommon(teamID, season, seasonType));
                                        teamTasks.Add(ShotChartService.ShotChartDetail(season, null, "0", teamID, seasonType));

                                        foreach (var measureType in MeasureTypeService.ClutchMeasureTypes)
                                        {
                                            teamTasks.Add(PlayerService.PlayerGameLogs(season, seasonType, "Totals", measureType, teamID));
                                        }

                                        foreach (var perMode in PerModeService.PlayerPerModes)
                                        {
                                            foreach (var measureType in MeasureTypeService.PlayerMeasureTypes)
                                            {
                                                teamTasks.Add(LeagueService.LeagueDashPlayerStats(season, seasonType, perMode, measureType, teamID));
                                            }

                                            foreach (var measureType in MeasureTypeService.ClutchMeasureTypes)
                                            {
                                                teamTasks.Add(LeagueService.LeagueDashPlayerClutch(season, seasonType, perMode, measureType, teamID));
                                            }

                                            teamTasks.Add(LeagueService.LeaguePlayerOnDetails(season, seasonType, perMode, "Opponent", teamID));
                                            teamTasks.Add(LeagueService.LeagueHustleStatsPlayer(season, seasonType, perMode, teamID));
                                        }
                                    }
                                }

                                await Task.WhenAll(teamTasks);
                                Console.WriteLine("Team data load complete.");
                                break;
                            case "player":
                                //Load player data
                                Console.WriteLine("Player data load started.");
                                var playerTasks = new List<Task>();

                                //obtain player data for current season
                                var seasonPlayers = await PlayerService.PlayerIndex(season, "0");
                                var playerIDs = await DailyHelper.GetIDs("playerId", "P", season, dateFrom, dateTo);

                                foreach (var playerID in playerIDs)
                                {
                                    playerTasks.Add(CommonService.CommonPlayerInfo(playerID)); ///TODO: FIX THIS!!!

                                    foreach (var perMode in PerModeService.PlayerPerModes)
                                    {
                                        playerTasks.Add(PlayerService.PlayerProfileV2(playerID, perMode));
                                    }
                                }

                                await Task.WhenAll(playerTasks);
                                Console.WriteLine("Player data load complete.");
                                break;
                            default:
                                Console.WriteLine($"Invalid data set: {dataSet}");
                                break;
                        }
                    }
                }

                //check any records that could not be loaded due to errors
                var parameters = new BsonArray();
                parameters.Add(CreateParameterObject("completed", false, ParameterType.Bool));
                var incompleteData = await DatabaseHelper.GetDocumentsAsync("logapi", parameters);
                incompleteTaskCount = incompleteData.Count;

                if (incompleteTaskCount > 0)
                {
                    Console.WriteLine("Wait to restart incompleted tasks...");
                    stopTime = String.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now);

                    //wait five minutes
                    await TimeoutHelper.Wait(300000);
                    TimeoutHelper.Reset();

                    restartTime = String.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now);

                    Console.WriteLine("Restarting...");
                    var incompleteTasks = new List<Task>();
                    for (int i = 0; i < incompleteData.Count; i++)
                    {
                        incompleteTasks.Add(
                            DatabaseHelper.UpdateDatabaseAsync(
                                incompleteData[i]["url"].ToString(),
                                incompleteData[i]["collection"].ToString(),
                                null, //no parameters needed as they are a part of the url at this point
                                incompleteData[i]["parse"].ToBoolean(),
                                incompleteData[i]["timeout"].ToInt32(),
                                incompleteData[i]["resultSet"].ToString()
                            )
                        );
                    }

                    await Task.WhenAll(incompleteTasks);
                }
            }
            catch (Exception ex)
            {
                await DatabaseHelper.ErrorDocumentAsync(ex, "LoadData");

                Console.WriteLine("There was an error loading data...");
            }
            finally
            {
                stopWatch.Stop();
                string endTime = String.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now);

                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine($"RunTime {elapsedTime}");

                //log data load process results
                BsonDocument loadDocument = new BsonDocument
                {
                    { "daily", daily },
                    { "date", DailyHelper.GetDate() },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "elapsed", elapsedTime },
                    { "stopTime", stopTime },
                    { "restartTime", restartTime },
                    { "incompleteTasks", incompleteTaskCount },
                    { "apiCallsMade", TimeoutHelper.apiCount }
                };
                await DatabaseHelper.AddDocumentAsync("logprocess", loadDocument);

                Console.WriteLine("Process complete!");

                //shutdown computer
                if (shutdown)
                {
                    Console.WriteLine("Shutting down...");
                    Process.Start("shutdown", "/f /s /t 0");
                }
            }
        }

        public static async Task LoadStaticData()
        {
            var filtersCollection = "filters";
            await DatabaseHelper.DropCollectionAsync(filtersCollection);
            await DatabaseHelper.CreateCollectionAsync(filtersCollection);

            var tasks = new List<Task>();

            tasks.Add(Task.Run(() => { ConferenceService.LoadFilter(); }));
            tasks.Add(Task.Run(() => { ContextMeasureService.LoadFilter(); }));
            tasks.Add(Task.Run(() => { DefenseCategoryService.LoadFilter(); }));
            tasks.Add(Task.Run(() => { DirectionService.LoadFilter(); }));
            tasks.Add(Task.Run(() => { DistanceRangeService.LoadFilter(); }));
            tasks.Add(Task.Run(() => { DivisionService.LoadFilter();}));
            tasks.Add(Task.Run(() => { GameScopeService.LoadFilter();}));
            tasks.Add(Task.Run(() => { GameSegmentServices.LoadFilter();}));
            tasks.Add(Task.Run(() => { LocationService.LoadFilter();}));
            tasks.Add(Task.Run(() => { MeasureTypeService.LoadFilterLeague();}));
            tasks.Add(Task.Run(() => { MeasureTypeService.LoadFilterPlayer();}));
            tasks.Add(Task.Run(() => { MeasureTypeService.LoadFilterTeam();}));
            tasks.Add(Task.Run(() => { MeasureTypeService.LoadFilterClutch();}));
            tasks.Add(Task.Run(() => { MeasureTypeService.LoadFilterTeamClutch();}));
            tasks.Add(Task.Run(() => { OffensiveDefensiveService.LoadFilter();}));
            tasks.Add(Task.Run(() => { OutcomeService.LoadFilter();}));
            tasks.Add(Task.Run(() => { PaceAdjustService.LoadFilter();}));
            tasks.Add(Task.Run(() => { PerModeService.LoadFilterDefault();}));
            tasks.Add(Task.Run(() => { PerModeService.LoadFilterBase();}));
            tasks.Add(Task.Run(() => { PerModeService.LoadFilterFranchise();}));
            tasks.Add(Task.Run(() => { PerModeService.LoadFilterTeam();}));
            tasks.Add(Task.Run(() => { PerModeService.LoadFilterPlayer();}));
            tasks.Add(Task.Run(() => { PlayerExperienceService.LoadFilter();}));
            tasks.Add(Task.Run(() => { PlayerOrTeamService.LoadFilter();}));
            tasks.Add(Task.Run(() => { PlayerPositionService.LoadFilter();}));
            tasks.Add(Task.Run(() => { PlayerScopeService.LoadFilter();}));
            tasks.Add(Task.Run(() => { PlayTypeService.LoadFilter();}));
            tasks.Add(Task.Run(() => { PTMeasureTypeService.LoadFilter();}));
            tasks.Add(Task.Run(() => { RankService.LoadFilter();}));
            tasks.Add(Task.Run(() => { ScopeService.LoadFilter();}));
            tasks.Add(Task.Run(() => { SeasonSegmentService.LoadFilter();}));
            tasks.Add(Task.Run(() => { SeasonService.LoadFilter();}));
            tasks.Add(Task.Run(() => { SeasonTypeService.LoadFilter(); ;}));
            tasks.Add(Task.Run(() => { ShotClockRangeService.LoadFilter();}));
            tasks.Add(Task.Run(() => { ShotRangeService.LoadFilter();}));
            tasks.Add(Task.Run(() => { SorterService.LoadFilter();}));
            tasks.Add(Task.Run(() => { StarterBenchService.LoadFilter();}));
            tasks.Add(Task.Run(() => { StatCategoryService.LoadFilterDefault();}));
            tasks.Add(Task.Run(() => { StatCategoryService.LoadFilterHome();}));
            tasks.Add(Task.Run(() => { StatTypeService.LoadFilter();}));
            tasks.Add(Task.Run(() => { VsConferenceService.LoadFilter();}));
            tasks.Add(Task.Run(() => { VsDivisionService.LoadFilter();}));

            await Task.WhenAll(tasks);
        }

        public static async Task LoadCollections()
        {
            var collections = new[] {
                "logprocess",
                "logapi",
                "logerror",
                "playbyplayv2",
                "videodetailsasset",
                "draftboard",
                "draftcombinedrillresults",
                "draftcombinenonstationaryshooting",
                "draftcombineplayeranthro",
                "draftcombinespotshooting",
                "draftcombinestats",
                "playerleaguegamelog",
                "playerestimatedmetrics",
                "playergamelogs",
                "playerstats",
                "playerclutch",
                "playerondetails",
                "playerhustlestats",
                "playersynergyplaytypes",
                "playerptstats",
                "playerptdefend",
                "playerptshot",
                "playershotlocations",
                "playerhustlestatsleaders",
                "playerbiostats",
                "playerinfo",
                "playerprofilev2",
                "leaguestandingsv3",
                "teamleaguegamelog",
                "teamestimatedmetrics",
                "teamgamelogs",
                "teamstats",
                "teamclutch",
                "teamlineups",
                "teamptshot",
                "teamoppptshot",
                "teamshotlocations",
                "teamhustlestatsleaders",
                "teamhustlestats",
                "teamptdefend",
                "teamsynergyplaytypes",
                "teamptstats",
                "teamyears",
                "teamhistory",
                "teamdetails",
                "teamyearbyyearstats",
                "teamroster",
                "teamhistoricalleaders",
                "teaminfocommon",
                "shotchartdetail",
            };

            for (int i = 0; i < collections.Length; i++)
            {
                await DatabaseHelper.CreateCollectionAsync(collections[i]);
            }
        }
    }
}
