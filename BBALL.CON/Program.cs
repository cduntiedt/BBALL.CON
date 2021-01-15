using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static BBALL.CON.Helpers.ParameterHelper;

namespace BBALL.CON
{
    class Program
    {
        private static StatsHelper _stats = new StatsHelper();

        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            LoadData(_stats.CurrentSeason, true);

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }

        //static void ImportData(List<string> seasons, bool currentGames)
        //{
        //    var leagueID = _stats.LeagueID;

        //    DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/commonteamyears/", "commonteamyears", "");
        //    TeamsService.CommonTeamYears(leagueID);
        //    //Wait(1000);
        //    TeamsService.FranchiseHistory(leagueID);

        //    var teamIDs = TeamsService.GetTeamIDs();

        //    foreach (var season in seasons)
        //    {
        //        Wait(500);
        //        PlayersService.CommonAllPlayers(leagueID, season, 1);

        //        Wait(500);
        //        DraftService.AllDraftCombineData(leagueID, season);

        //        foreach (int teamID in teamIDs)
        //        {
        //            Wait(500);
        //            TeamsService.CommonTeamRoster(teamID, season);

        //            foreach (string seasonType in _stats.TeamSeasonTypes)
        //            {
        //                Wait(500);
        //                TeamsService.TeamGameLog(teamID, season, seasonType);
        //                TeamsService.TeamInfoCommon(teamID, season, seasonType, leagueID);

        //                foreach (string perMode in _stats.TeamPerModes)
        //                {
        //                    Wait(500);
        //                    TeamsService.TeamYearByYearStats(leagueID, seasonType, perMode, teamID);
        //                }
        //            }
        //        }
        //    }
        //}

        static void LoadData(List<string> seasons, bool currentGames)
        {
            var leagueID = _stats.LeagueID;
            
            //TeamsService.CommonTeamYears(leagueID);
            ////Wait(1000);
            //TeamsService.FranchiseHistory(leagueID);

            //var teamIDs = TeamsService.GetTeamIDs();

            //foreach (var season in seasons)
            //{
            //    Wait(500);
            //    PlayersService.CommonAllPlayers(leagueID, season, 1);

            //    Wait(500);
            //    DraftService.AllDraftCombineData(leagueID, season);

            //    foreach (int teamID in teamIDs)
            //    {
            //        Wait(500);
            //        TeamsService.CommonTeamRoster(teamID, season);

            //        foreach (string seasonType in _stats.TeamSeasonTypes)
            //        {
            //            Wait(500);
            //            TeamsService.TeamGameLog(teamID, season, seasonType);
            //            TeamsService.TeamInfoCommon(teamID, season, seasonType, leagueID);

            //            foreach (string perMode in _stats.TeamPerModes)
            //            {
            //                Wait(500);
            //                TeamsService.TeamYearByYearStats(leagueID, seasonType, perMode, teamID);
            //            }
            //        }
            //    }
            //}

            JArray parameters = new JArray();
            if (currentGames)
            {
                parameters.Add(CreateParameterObject("Season", seasons.FirstOrDefault(), ParameterType.String));
            }
            else
            {
                parameters = null;
            }
            var gameDocuments = GameService.ImportGames(parameters);
            foreach (var gameDocument in gameDocuments)
            {
                foreach (var game in (BsonArray)gameDocument["Games"])
                {
                    Wait(500);
                    GameService.LoadGameData(game["Game_ID"].ToString());
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
