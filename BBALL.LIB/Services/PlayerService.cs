using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace BBALL.LIB.Services
{
    public static class PlayerService
    {
        public static async void ImportPlayers(List<string> seasons)
        {
            try
            {
                foreach (var season in seasons)
                {
                    var players = await CommonService.CommonAllPlayers(season);

                    foreach (var player in players)
                    {
                        Console.WriteLine(player);
                        await CommonService.CommonPlayerInfo(player["PlayerID"].ToString());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Player > Career
        public static async Task<List<BsonDocument>> PlayerAwards(string PlayerID)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            return await PlayerAwards(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerAwards(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playerawards/", "playerawards", parameters);
        }

        public static async Task<List<BsonDocument>> PlayerCareerByCollege(
           string Season = null,
           string SeasonType = "Regular Season",
           string PerMode = null,
           string College = null,
           string LeagueID = null
        )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("College", College));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));

            return await PlayerCareerByCollege(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerCareerByCollege(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playercareerbycollege/", "playercareerbycollege", parameters);
        }

        public static async Task<List<BsonDocument>> PlayerCareerByCollegeRollup(
           string Season = null,
           string SeasonType = "Regular Season",
           string PerMode = null,
           string LeagueID = null
        )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));

            return await PlayerCareerByCollegeRollup(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerCareerByCollegeRollup(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playercareerbycollegerollup/", "playercareerbycollegerollup", parameters);
        }

        //PLayer > Career
        public static async Task<List<BsonDocument>> PlayerCareerStats(
            string PlayerID,
            string PerMode = "PerGame",
            string LeagueID = null
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            return await PlayerCareerStats(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerCareerStats(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playercareerstats/", "playercareerstats", parameters);
        }

        public static async Task<List<BsonDocument>> PlayerCompare(
           string Season = null,
           string SeasonType = "Regular Season",
           string PerMode = "PerGame",
           string MeasureType = "Base",
           string LastNGames = "0",
           string Month = "0",
           string OpponentTeamID = "0",
           string PaceAdjust = "N",
           string Period = "0",
           string PlayerIDList = null,
           string PlusMinus = "N",
           string VsPlayerIDList = null,
           string VsDivision = null,
           string VsConference = null,
           string ShotClockRange = null,
           string SeasonSegment = null,
           string Outcome = null,
           string Location = null,
           string GameSegment = null,
           string Division = null,
           string DateTo = null,
           string DateFrom = null,
           string Conference = null,
           string LeagueID = null
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlayerIDList", PlayerIDList));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("VsPlayerIDList", VsPlayerIDList));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("Conference", Conference));
            return await PlayerCompare(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerCompare(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playercompare/", "playercompare", parameters);
        }

        public static async Task<List<BsonDocument>> PlayDashPTPass(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string Period = "0",
            string SeasonSegment = null,
            string TeamID = "0",
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
         )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return await PlayDashPTPass(parameters);
        }

        public static async Task<List<BsonDocument>> PlayDashPTPass(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playerdashptpass/", "playerdashptpass", parameters);
        }
        public static async Task<List<BsonDocument>> PlayDashPTReb(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string Period = "0",
            string SeasonSegment = null,
            string TeamID = "0",
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
          )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return await PlayDashPTReb(parameters);
        }

        public static async Task<List<BsonDocument>> PlayDashPTReb(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playerdashptreb/", "playerdashptreb", parameters);
        }

        public static async Task<List<BsonDocument>> PlayDashPTShotDefend(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string Period = "0",
            string SeasonSegment = null,
            string TeamID = "0",
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return await PlayDashPTShotDefend(parameters);
        }

        public static async Task<List<BsonDocument>> PlayDashPTShotDefend(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playerdashptshotdefend/", "playerdashptshotdefend", parameters);
        }

        public static async Task<List<BsonDocument>> PlayDashPTShots(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string Period = "0",
            string SeasonSegment = null,
            string TeamID = "0",
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return await PlayDashPTShots(parameters);
        }

        public static async Task<List<BsonDocument>> PlayDashPTShots(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playerdashptshots/", "playerdashptshots", parameters);
        }

        public static async Task<List<BsonDocument>> PlayerDashboardByClutch(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season", 
            string PerMode = "Totals",
            string MeasureType = "Base",
            string LastNGames = "0",
            string Month = "0",
            string OpponentTeamID = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string VsDivision = null,
            string VsConference = null,
            string ShotClockRange = null,
            string SeasonSegment = null,
            string PORound = null,
            string Outcome = null,
            string Location = null,
            string GameSegment = null,
            string DateTo = null,
            string DateFrom = null,
            string LeagueID = null
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            return await PlayerDashboardByClutch(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerDashboardByClutch(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playerdashboardbyclutch/", "playerdashboardbyclutch", parameters);
        }

        public static async Task<List<BsonDocument>> PlayerDashboardByGameSplits(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string MeasureType = "Base",
            string LastNGames = "0",
            string Month = "0",
            string OpponentTeamID = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string VsDivision = null,
            string VsConference = null,
            string ShotClockRange = null,
            string SeasonSegment = null,
            string PORound = null,
            string Outcome = null,
            string Location = null,
            string GameSegment = null,
            string DateTo = null,
            string DateFrom = null,
            string LeagueID = null
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            return await PlayerDashboardByGameSplits(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerDashboardByGameSplits(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playerdashboardbygamesplits/", "playerdashboardbygamesplits", parameters);
        }

        //Player > Splits
        public static async Task<List<BsonDocument>> PlayerDashboardByGeneralSplits(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string MeasureType = "Base",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return await PlayerDashboardByGeneralSplits(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerDashboardByGeneralSplits(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playerdashboardbygeneralsplits/", "playerdashboardbygeneralsplits", parameters);
        }

        public static async Task<List<BsonDocument>> PlayerDashboardByLastNGames(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string MeasureType = "Base",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return await PlayerDashboardByLastNGames(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerDashboardByLastNGames(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playerdashboardbylastngames/", "playerdashboardbylastngames", parameters);
        }

        public static async Task<List<BsonDocument>> PlayerDashboardByOpponent(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string MeasureType = "Base",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return await PlayerDashboardByOpponent(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerDashboardByOpponent(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playerdashboardbyopponent/", "playerdashboardbyopponent", parameters);
        }

        public static async Task<List<BsonDocument>> PlayerDashboardByShootingSplits(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string MeasureType = "Base",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return await PlayerDashboardByShootingSplits(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerDashboardByShootingSplits(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playerdashboardbyshootingsplits/", "playerdashboardbyshootingsplits", parameters);
        }

        public static async Task<List<BsonDocument>> PlayerDashboardByTeamPerformance(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string MeasureType = "Base",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return await PlayerDashboardByTeamPerformance(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerDashboardByTeamPerformance(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playerdashboardbyteamperformance/", "playerdashboardbyteamperformance", parameters);
        }

        //Player > Profile
        public static async Task<List<BsonDocument>> PlayerDashboardByYearOverYear(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string MeasureType = "Base",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return await PlayerDashboardByYearOverYear(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerDashboardByYearOverYear(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playerdashboardbyyearoveryear/", "playerdashboardbyyearoveryear", parameters);
        }

        public static async Task<List<BsonDocument>> PlayerEstimatedMetrics(
           string Season = null,
           string SeasonType = "Regular Season",
           string LeagueID = null
           )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));

            return await PlayerEstimatedMetrics(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerEstimatedMetrics(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playerestimatedmetrics/", "playerestimatedmetrics", parameters, true, 15, "resultSet");
        }

        public static async Task<List<BsonDocument>> PlayerGameLog(
            string PlayerID,
            string Season = null, 
            string SeasonType = "Regular Season",
            string DateFrom = null,
            string DateTo = null,
            string LeagueID = null
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            return await PlayerGameLog(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerGameLog(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playergamelog/", "playergamelog", parameters);
        }

        public static async Task<List<BsonDocument>> PlayerGameLogs(
            string Season = null,
            string SeasonType = null,
            string PerMode = null,
            string MeasureType = null,
            string TeamID = null,
            string DateFrom = null,
            string DateTo = null,
            string PlayerID = null,
            string GameSegment = null,
            string LastNGames = null,
            string Location = null,
            string Month = null,
            string OppTeamID = null,
            string Outcome = null,
            string PORound = null,
            string Period = null,
            string SeasonSegment = null,
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OppTeamID", OppTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return await PlayerGameLogs(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerGameLogs(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playergamelogs/", "playergamelogs", parameters);
        }

        //Players > Player Index
        public static async Task<List<BsonDocument>> PlayerIndex(
            string Season = null,
            string Historical = "1",
            string Active = null,
            string AllStar = null,
            string College = null,
            string Country = null,
            string DraftPick = null,
            string DraftYear = null,
            string Height = null,
            string PlayerPosition = null,
            string TeamID = "0",
            string Weight = null,
            string LeagueID = null
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("Active", Active));
            parameters.Add(CreateParameterObject("AllStar", AllStar));
            parameters.Add(CreateParameterObject("College", College));
            parameters.Add(CreateParameterObject("Country", Country));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear));
            parameters.Add(CreateParameterObject("Height", Height));
            parameters.Add(CreateParameterObject("Historical", Historical));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("Weight", Weight));

            return await PlayerIndex(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerIndex(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playerindex/", "playerindex", parameters);
        }

        public static async Task<List<BsonDocument>> PlayerNextNGames(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string NumberOfGames = "5",
            string LeagueID = null
        )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("NumberOfGames", NumberOfGames));
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            return await PlayerNextNGames(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerNextNGames(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playernextngames/", "playernextngames", parameters);
        }

        //Player > Career
        public static async Task<List<BsonDocument>> PlayerProfileV2(
            string PlayerID,
            string PerMode = "PerGame",
            string LeagueID = null
        )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            return await PlayerProfileV2(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerProfileV2(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playerprofilev2/", "playerprofilev2", parameters);
        }

        public static async Task<List<BsonDocument>> PlayerVsPlayer(
            string PlayerID,
            string VsPlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string PerMode = "PerGame",
            string DateFrom = null,
            string DateTo = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
        )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("VsPlayerID", VsPlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return await PlayerVsPlayer(parameters);
        }

        public static async Task<List<BsonDocument>> PlayerVsPlayer(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playervsplayer/", "playervsplayer", parameters);
        }
    }
}
