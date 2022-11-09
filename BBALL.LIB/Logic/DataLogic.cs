using BBALL.LIB.Helpers;
using BBALL.LIB.Services;
using BBALL.LIB.Services.Static;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBALL.LIB.Logic
{
    public static class DataLogic
    {
        /// <summary>
        /// The primary function to load data.
        /// </summary>
        /// <param name="daily">Boolean field to load the current date.</param>
        /// <param name="seasons">A list of seasons to be loaded.</param>
        public static async Task LoadData(bool daily = true, bool shutdown = true, List<string> dataSets = null, List<string> seasons = null)
        {
            try
            {
                //start a stopwatch to take the length of the process
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                string startTime = String.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now);

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
                    dataSets = new List<string>() { "game", "team", "player" };
                }

                var tasks = new List<Task>();

                foreach (var season in seasons)
                {
                    List<string> seasonTypes = await SeasonHelper.GetSeasonTypes(season, dateFrom, dateTo);

                    foreach (var dataSet in dataSets)
                    {
                        switch (dataSet)
                        {
                            case "game":
                                //Load game data
                                Console.WriteLine("Game data load started.");
                                tasks.Add(GameLogic.LoadGameData(season, seasonTypes, dateFrom, dateTo));
                                Console.WriteLine("Game data load complete.");
                                break;
                            case "team":
                                //Load team data 
                                Console.WriteLine("Team data load started.");
                                tasks.Add(TeamLogic.LoadTeamData(season, seasonTypes, dateFrom, dateTo));
                                Console.WriteLine("Team data load complete.");
                                break;
                            case "player":
                                //Load player data
                                Console.WriteLine("Player data load started.");
                                tasks.Add(PlayerLogic.LoadPlayerData(season, seasonTypes, dateFrom, dateTo));
                                Console.WriteLine("Player data load complete.");
                                break;
                            default:
                                Console.WriteLine($"Invalid data set: {dataSet}");
                                break;
                        }
                    }
                }

                await Task.WhenAll(tasks);

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
                    { "Daily", daily },
                    { "Date", DailyHelper.GetDate() },
                    { "StartTime", startTime },
                    { "EndTime", endTime },
                    { "Elapsed", elapsedTime },
                    { "CallsMade", TimeoutHelper.callCount }
                };
                await DatabaseHelper.AddDocumentAsync("dataload", loadDocument);
            }
            catch (Exception)
            {
                Console.WriteLine("There was an error loading data...");
            }
            finally
            {
                //shutdown computer
                if (shutdown)
                {
                    Process.Start("shutdown", "/f /s /t 0");
                }
            }
        }

        public static async Task LoadStaticData()
        {
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
    }
}
