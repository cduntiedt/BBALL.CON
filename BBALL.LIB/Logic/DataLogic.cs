using BBALL.LIB.Helpers;
using BBALL.LIB.Services;
using BBALL.LIB.Services.Static;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BBALL.LIB.Logic
{
    public static class DataLogic
    {
        /// <summary>
        /// The primary function to load data.
        /// </summary>
        /// <param name="daily">Boolean field to load the current date.</param>
        /// <param name="seasons">A list of seasons to be loaded.</param>
        public static async void LoadData(bool daily = true, List<string> seasons = null)
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

                    SeasonLogic.LoadSeasonData(season, seasonTypes, dt, dt);
                }
                else
                {
                    foreach (var season in seasons)
                    {
                        List<string> seasonTypes = SeasonHelper.GetSeasonTypes(season);

                        SeasonLogic.LoadSeasonData(season, seasonTypes);
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
                Console.WriteLine($"RunTime {elapsedTime}");

                BsonDocument loadDocument = new BsonDocument
                {
                    { "Daily", daily },
                    { "Date", dt },
                    { "StartTime", startTime },
                    { "EndTime", endTime },
                    { "Elapsed", elapsedTime }
                };

                DatabaseHelper.AddDocument("dataload", loadDocument);
            }
            catch (Exception)
            {
                Console.WriteLine("There was an error loading data...");
            }
            finally
            {
                //shutdown computer
                Process.Start("shutdown", "/f /s /t 0");
            }
        }

        /// <summary>
        /// One time load of player data.
        /// </summary>
        public static async void OneTimeLoad()
        {
            var season = SeasonService.CurrentSeason.FirstOrDefault();
            //obtain player data for current season
            var seasonPlayers = await PlayerService.PlayerIndex(season, "0");
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

        public static async void LoadStaticData()
        {
            ConferenceService.LoadFilter();
            ContextMeasureService.LoadFilter();
            DefenseCategoryService.LoadFilter();
            DirectionService.LoadFilter();
            DistanceRangeService.LoadFilter();
            DivisionService.LoadFilter();
            GameScopeService.LoadFilter();
            GameSegmentServices.LoadFilter();
            LocationService.LoadFilter();
            MeasureTypeService.LoadFilterLeague();
            MeasureTypeService.LoadFilterPlayer();
            MeasureTypeService.LoadFilterTeam();
            OutcomeService.LoadFilter();
            PaceAdjustService.LoadFilter();
            PerModeService.LoadFilterDefault();
            PerModeService.LoadFilterFranchise();
            PerModeService.LoadFilterTeam();
            PerModeService.LoadFilterPlayer();
            PlayerExperienceService.LoadFilter();
            PlayerOrTeamService.LoadFilter();
            PlayerPositionService.LoadFilter();
            PlayerScopeService.LoadFilter();
            PTMeasureTypeService.LoadFilter();
            RankService.LoadFilter();
            ScopeService.LoadFilter();
            SeasonSegmentService.LoadFilter();
            SeasonService.LoadFilter();
            SeasonTypeService.LoadFilterTeam();
            SeasonTypeService.LoadFilterPlayer();
            SeasonTypeService.LoadFilterLeague();
            ShotClockRangeService.LoadFilter();
            SorterService.LoadFilter();
            StarterBenchService.LoadFilter();
            StatCategoryService.LoadFilterDefault();
            StatCategoryService.LoadFilterHome();
            StatTypeService.LoadFilter();
            VsConferenceService.LoadFilter();
            VsDivisionService.LoadFilter();
        }
    }
}
