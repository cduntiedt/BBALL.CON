using BBALL.LIB.Helpers;
using BBALL.LIB.Services;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BBALL.CON.Logic
{
    public static class DataLogic
    {
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

                    SeasonLogic.LoadSeasonData(season, seasonTypes, dt, dt);
                }
                else
                {
                    await PlayerService.PlayerGameLogs();
                    var playerDocument = await PlayerService.PlayerIndex();

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
                //Process.Start("shutdown", "/s /t 0");
            }
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
    }
}
