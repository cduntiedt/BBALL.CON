using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.Linq;

namespace BBALL.LIB.Services
{
    public static class LeagueService
    {
        public static async Task<List<BsonDocument>> LeagueDashLineups(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string MeasureType = "Base",
            string TeamID = null,
            string GroupQuantity = "5",
            string LastNGames = "0",
            string Month = "0",
            string OpponentTeamID = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string LeagueID = null,
            string VsConference = null,
            string VsDivision = null,
            string ShotClockRange = null,
            string Conference = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string GameSegment = null,
            string SeasonSegment = null,
            string Location = null,
            string Outcome = null,
            string PORound = null
        )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("GroupQuantity", GroupQuantity));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            return await LeagueDashLineups(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashLineups(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguedashlineups/", "teamlineups", parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashPlayerBioStats(
           string Season = null,
           string SeasonType = "Regular Season",
           string PerMode = "PerGame",
           string TeamID = null,
           string LeagueID = null,
           string College = null,
           string Conference = null,
           string Country = null,
           string DateFrom = null,
           string DateTo = null,
           string Division = null,
           string DraftPick = null,
           string DraftYear = null,
           string GameScope = null,
           string GameSegment = null,
           string Height = null,
           string LastNGames = null,
           string Location = null,
           string Month = null,
           string OpponentTeamID = null,
           string Outcome = null,
           string PORound = null,
           string Period = null,
           string PlayerExperience = null,
           string PlayerPosition = null,
           string SeasonSegment = null,
           string ShotClockRange = null,
           string StarterBench = null,
           string VsConference = null,
           string VsDivision = null,
           string Weight = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("College", College));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("Country", Country));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear));
            parameters.Add(CreateParameterObject("GameScope", GameScope));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Height", Height));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("Weight", Weight));

            return await LeagueDashPlayerBioStats(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashPlayerBioStats(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguedashplayerbiostats/", "playerbiostats", parameters);
        }

        //Players > Clutch
        public static async Task<List<BsonDocument>> LeagueDashPlayerClutch(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string MeasureType = "Base",
            string TeamID = "0",
            string ClutchTime = "Last 5 Minutes",
            string AheadBehind = "Ahead or Behind",
            string LeagueID = null,
            string College = null,
            string Conference = null,
            string Country = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string DraftPick = null,
            string DraftYear = null,
            string GameScope = null,
            string GameSegment = null,
            string Height = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlayerExperience = null,
            string PlayerPosition = null,
            string PlusMinus = "N",
            string PointDiff = "5",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string StarterBench = null,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("AheadBehind", AheadBehind));
            parameters.Add(CreateParameterObject("ClutchTime", ClutchTime));
            parameters.Add(CreateParameterObject("College", College));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("Country", Country));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear));
            parameters.Add(CreateParameterObject("GameScope", GameScope));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Height", Height));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("PointDiff", PointDiff));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("Weight", Weight));

            return await LeagueDashPlayerClutch(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashPlayerClutch(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguedashplayerclutch/", "playerclutch", parameters);
        }

        //Players > Shot Dashboard
        public static async Task<List<BsonDocument>> LeagueDashOppPtShot(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string TeamID = "0",
            string LeagueID = null,
            string CloseDefDistRange = null,
            string College = null,
            string Conference = null,
            string Country = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string DraftPick = null,
            string DraftYear = null,
            string DribbleRange = null,
            string GameSegment = null,
            string GeneralRange = "Overall",
            string Height = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlayerExperience = null,
            string PlayerPosition = null,
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string ShotDistRange = null,
            string StarterBench = null,
            string TouchTimeRange = null,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("CloseDefDistRange", CloseDefDistRange));
            parameters.Add(CreateParameterObject("College", College));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("Country", Country));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear));
            parameters.Add(CreateParameterObject("DribbleRange", DribbleRange));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("GeneralRange", GeneralRange));
            parameters.Add(CreateParameterObject("Height", Height));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("ShotDistRange", ShotDistRange));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("TouchTimeRange", TouchTimeRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("Weight", Weight));

            return await LeagueDashOppPtShot(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashOppPtShot(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguedashoppptshot/", "teamoppptshot", parameters);
        }

        //Players > Shot Dashboard
        public static async Task<List<BsonDocument>> LeagueDashPlayerPTShot(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string GeneralRange = "Overall",
            string TeamID = "0",
            string LeagueID = null,
            string CloseDefDistRange = null,
            string College = null,
            string Conference = null,
            string Country = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string DraftPick = null,
            string DraftYear = null,
            string DribbleRange = null,
            string GameSegment = null,
            string Height = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlayerExperience = null,
            string PlayerPosition = null,
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string ShotDistRange = null,
            string StarterBench = null,
            string TouchTimeRange = null,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("CloseDefDistRange", CloseDefDistRange));
            parameters.Add(CreateParameterObject("College", College));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("Country", Country));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear));
            parameters.Add(CreateParameterObject("DribbleRange", DribbleRange));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("GeneralRange", GeneralRange));
            parameters.Add(CreateParameterObject("Height", Height));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("ShotDistRange", ShotDistRange));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("TouchTimeRange", TouchTimeRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("Weight", Weight));

            return await LeagueDashPlayerPTShot(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashPlayerPTShot(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguedashplayerptshot/", "playerptshot", parameters);
        }

        //Players > Shooting
        public static async Task<List<BsonDocument>> LeagueDashPlayerShotLocations(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string DistanceRange = "By Zone",
            string MeasureType = "Base",
            string TeamID = "0",
            string LeagueID = null,
            string College = null,
            string Conference = null,
            string Country = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string DraftPick = null,
            string DraftYear = null,
            string GameScope = null,
            string GameSegment = null,
            string Height = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string Period = "0",
            string PlayerExperience = null,
            string PLayerOrTeam = "Player",
            string PlayerPosition = null,
            string PlusMinus = "N",
            string PaceAdjust = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string StarterBench = null,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("DistanceRange", DistanceRange));
            parameters.Add(CreateParameterObject("College", College));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("Country", Country));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear));
            parameters.Add(CreateParameterObject("GameScope", GameScope));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Height", Height));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience));
            parameters.Add(CreateParameterObject("PLayerOrTeam", PLayerOrTeam));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("Weight", Weight));

            return await LeagueDashPlayerShotLocations(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashPlayerShotLocations(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguedashplayershotlocations/", "playershotlocations", parameters, false);
        }

        //Players > Traditional Stats
        public static async Task<List<BsonDocument>> LeagueDashPlayerStats(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string MeasureType = "Base",
            string TeamID = "0",
            string LeagueID = null,
            string College = null,
            string Conference = null,
            string Country = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string DraftPick = null,
            string DraftYear = null,
            string GameScope = null,
            string GameSegment = null,
            string Height = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlayerExperience = null,
            string PlayerPosition = null,
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string StarterBench = null,
            string TwoWay = "0",
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("College", College));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("Country", Country));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear));
            parameters.Add(CreateParameterObject("GameScope", GameScope));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Height", Height));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("TwoWay", TwoWay));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("Weight", Weight));

            return await LeagueDashPlayerStats(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashPlayerStats(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguedashplayerstats/", "playerstats", parameters);
        }

        //Players > Defensive Dashboard
        public static async Task<List<BsonDocument>> LeagueDashPTDefend(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string DefenseCategory = "Overall",
            string TeamID = "0",
            string LeagueID = null,
            string College = null,
            string Conference = null,
            string Country = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string DraftPick = null,
            string DraftYear = null,
            string GameScope = null,
            string GameSegment = null,
            string Height = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlayerExperience = null,
            string PlayerPosition = null,
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string StarterBench = null,
            string TwoWay = "0",
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DefenseCategory", DefenseCategory));
            parameters.Add(CreateParameterObject("College", College));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("Country", Country));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear));
            parameters.Add(CreateParameterObject("GameScope", GameScope));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Height", Height));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("TwoWay", TwoWay));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("Weight", Weight));

            return await LeagueDashPTDefend(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashPTDefend(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguedashptdefend/", "playerptdefend", parameters);
        }

        //Players > Tracking
        public static async Task<List<BsonDocument>> LeagueDashPTStats(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string PtMeasureType = "CatchShoot",
            string PlayerOrTeam = "Player",
            string TeamID = "0",
            string LeagueID = null,
            string College = null,
            string Conference = null,
            string Country = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string DraftPick = null,
            string DraftYear = null,
            string GameScope = null,
            string Height = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PlayerExperience = null,
            string PlayerPosition = null,
            string SeasonSegment = null,
            string StarterBench = null,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("PtMeasureType", PtMeasureType));
            parameters.Add(CreateParameterObject("College", College));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("Country", Country));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear));
            parameters.Add(CreateParameterObject("GameScope", GameScope));
            parameters.Add(CreateParameterObject("Height", Height));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience));
            parameters.Add(CreateParameterObject("PlayerOrTeam", PlayerOrTeam));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("Weight", Weight));

            return await LeagueDashPTStats(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashPTStats(BsonArray parameters)
        {
            var collection = "player";
            if(parameters.Where(x => x["Key"] == "playerOrTeam" && x["Value"] == "Team").ToList().Count > 0)
            {
                collection = "team";
            }
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguedashptstats/", $"{collection}ptstats", parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashPTTeamDefend(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string DefenseCategory = "Overall",
            string TeamID = "0",
            string LeagueID = null,
            string Conference = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string Period = "0",
            string SeasonSegment = null,
            string VsConference = null,
            string VsDivision = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DefenseCategory", DefenseCategory));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
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

            return await LeagueDashPTTeamDefend(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashPTTeamDefend(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguedashptteamdefend/", "teamptdefend", parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashTeamClutch(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string MeasureType = "Base",
            string TeamID = "0",
            string AheadBehind = "Ahead or Behind",
            string ClutchTime = "Last 5 Minutes",
            string LeagueID = null,
            string Conference = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string GameScope = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlayerExperience = null,
            string PlayerPosition = null,
            string PlusMinus = "N",
            string PointDiff = "5",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string StarterBench = null,
            string VsConference = null,
            string VsDivision = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("AheadBehind", AheadBehind));
            parameters.Add(CreateParameterObject("ClutchTime", ClutchTime));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("GameScope", GameScope));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("PointDiff", PointDiff));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            return await LeagueDashTeamClutch(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashTeamClutch(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguedashteamclutch/", "teamclutch", parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashTeamPtShot(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string GeneralRange = "Overall",
            string TeamID = "0",
            string LeagueID = null,
            string CloseDefDistRange = null,
            string Conference = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string DribbleRange = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string Period = "0",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string ShotDistRange = null,
            string TouchTimeRange = null,
            string VsConference = null,
            string VsDivision = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("CloseDefDistRange", CloseDefDistRange));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("DribbleRange", DribbleRange));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("GeneralRange", GeneralRange));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("ShotDistRange", ShotDistRange));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("TouchTimeRange", TouchTimeRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            return await LeagueDashTeamPtShot(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashTeamPtShot(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguedashteamptshot/", "teamptshot", parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashTeamShotLocations(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string DistanceRange = "By Zone",
            string MeasureType = "Opponent",
            string TeamID = "0",
            string LeagueID = null,
            string Conference = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string GameScope = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PaceAdjust = "N",
            string Period = "0",
            string PORound = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string PlayerExperience = null,
            string PlayerPosition = null,
            string SeasonSegment = null,
            string ShotClockRange = null,
            string StarterBench = null,
            string VsConference = null,
            string VsDivision = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("DistanceRange", DistanceRange));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("GameScope", GameScope));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            return await LeagueDashTeamShotLocations(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashTeamShotLocations(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguedashteamshotlocations/", "teamshotlocations", parameters, false);
        }

        public static async Task<List<BsonDocument>> LeagueDashTeamStats(
           string Season = null,
           string SeasonType = "Regular Season",
           string PerMode = "Totals",
           string MeasureType = "Base",
           string TeamID = null,
           string LeagueID = null,
           string Conference = null,
           string DateFrom = null,
           string DateTo = null,
           string Division = null,
           string GameScope = null,
           string GameSegment = null,
           string Height = null,
           string LastNGames = "0",
           string Location = null,
           string Month = "0",
           string OpponentTeamID = "0",
           string Outcome = null,
           string PORound = null,
           string PaceAdjust = "N",
           string Period = "0",
           string PlayerExperience = null,
           string PlayerPosition = null,
           string PlusMinus = "N",
           string Rank = "N",
           string SeasonSegment = null,
           string ShotClockRange = null,
           string StarterBench = null,
           string TwoWay = null,
           string VsConference = null,
           string VsDivision = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("GameScope", GameScope));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Height", Height));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("TwoWay", TwoWay));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            return await LeagueDashTeamStats(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueDashTeamStats(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguedashteamstats/", "teamstats", parameters);
        }


        //Players > Opponent Shooting
        public static async Task<List<BsonDocument>> LeagueDashOpponentShotLocations(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string MeasureType = "Opponent",
            string DistanceRange = "By Zone",
            string TeamID = "0",
            string LeagueID = null,
            string College = null,
            string Conference = null,
            string Country = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string DraftPick = null,
            string DraftYear = null,
            string GameScope = null,
            string Height = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PlayerExperience = null,
            string PLayerOrTeam = "Player",
            string PlayerPosition = null,
            string SeasonSegment = null,
            string StarterBench = null,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("DistanceRange", DistanceRange));
            parameters.Add(CreateParameterObject("College", College));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("Country", Country));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear));
            parameters.Add(CreateParameterObject("GameScope", GameScope));
            parameters.Add(CreateParameterObject("Height", Height));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience));
            parameters.Add(CreateParameterObject("PLayerOrTeam", PLayerOrTeam));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("Weight", Weight));

            return await LeagueDashPlayerShotLocations(parameters);
        }

        //Players > Hustle or Players > Box Outs
        public static async Task<List<BsonDocument>> LeagueHustleStatsPlayer(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string TeamID = "0",
            string LeagueID = null,
            string College = null,
            string Conference = null,
            string Country = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string DraftPick = null,
            string DraftYear = null,
            string Height = null,
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PlayerExperience = null,
            string PlayerPosition = null,
            string SeasonSegment = null,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("College", College));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("Country", Country));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear));
            parameters.Add(CreateParameterObject("Height", Height));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("Weight", Weight));

            return await LeagueHustleStatsPlayer(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueHustleStatsPlayer(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguehustlestatsplayer/", "playerhustlestats", parameters);

        }

        public static async Task<List<BsonDocument>> LeagueHustleStatsPlayerLeaders(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string TeamID = "0",
            string LeagueID = null,
            string College = null,
            string Conference = null,
            string Country = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string DraftPick = null,
            string DraftYear = null,
            string Height = null,
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PlayerExperience = null,
            string PlayerPosition = null,
            string SeasonSegment = null,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("College", College));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("Country", Country));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear));
            parameters.Add(CreateParameterObject("Height", Height));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("Weight", Weight));

            return await LeagueHustleStatsPlayerLeaders(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueHustleStatsPlayerLeaders(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguehustlestatsplayerleaders/", "playerleadershustlestats", parameters);
        }

        public static async Task<List<BsonDocument>> LeagueHustleStatsTeam(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string TeamID = "0",
            string LeagueID = null,
            string College = null,
            string Conference = null,
            string Country = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string DraftPick = null,
            string DraftYear = null,
            string Height = null,
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PlayerExperience = null,
            string PlayerPosition = null,
            string SeasonSegment = null,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("College", College));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("Country", Country));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear));
            parameters.Add(CreateParameterObject("Height", Height));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("Weight", Weight));

            return await LeagueHustleStatsTeam(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueHustleStatsTeam(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguehustlestatsteam/", "teamhustlestats", parameters);

        }

        public static async Task<List<BsonDocument>> LeagueHustleStatsTeamLeaders(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string TeamID = "0",
            string LeagueID = null,
            string College = null,
            string Conference = null,
            string Country = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string DraftPick = null,
            string DraftYear = null,
            string Height = null,
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string PlayerExperience = null,
            string PlayerPosition = null,
            string SeasonSegment = null,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("College", College));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("Country", Country));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear));
            parameters.Add(CreateParameterObject("Height", Height));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("Weight", Weight));

            return await LeagueHustleStatsTeamLeaders(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueHustleStatsTeamLeaders(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguehustlestatsteamleaders/", "teamhustlestatsleaders", parameters);
        }

        public static async Task<List<BsonDocument>> LeagueGameLog(
            string Season = null,
            string SeasonType = "Regular Season",
            string PlayerOrTeam = "T",
            string Counter = "0",
            string DateFrom = null,
            string DateTo = null,
            string LeagueID = null,
            string Direction = "ASC",
            string Sorter = "DATE"
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("Counter", Counter));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Direction", Direction));
            parameters.Add(CreateParameterObject("PlayerOrTeam", PlayerOrTeam));
            parameters.Add(CreateParameterObject("Sorter", Sorter));

            return await LeagueGameLog(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueGameLog(BsonArray parameters)
        {
            var collection = "player";
            if (parameters.Where(x => x["Key"] == "playerOrTeam" && x["Value"] == "T").ToList().Count > 0)
            {
                collection = "team";
            }
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguegamelog/", $"{collection}leaguegamelog", parameters);
        }

        public static async Task<List<BsonDocument>> LeagueLineupViz(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string MeasureType = "Base",
            string TeamID = "0",
            string LeagueID = null,
            string GroupQuantity = "5",
            string MinutesMin = "10",
            string Conference = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
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
            string VsConference = null,
            string VsDivision = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("GroupQuantity", GroupQuantity));
            parameters.Add(CreateParameterObject("MinutesMin", MinutesMin));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
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

            return await LeagueLineupViz(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueLineupViz(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguelineupviz/", "leaguelineupviz", parameters);
        }

        public static async Task<List<BsonDocument>> LeaguePlayerOnDetails(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string MeasureType = "Base",
            string TeamID = "0",
            string LeagueID = null,
            string Conference = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
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
            string VsConference = null,
            string VsDivision = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Division", Division));
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

            return await LeaguePlayerOnDetails(parameters);
        }

        public static async Task<List<BsonDocument>> LeaguePlayerOnDetails(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leagueplayerondetails/", "playerondetails", parameters);
        }

        public static async Task<List<BsonDocument>> LeagueSeasonMatchups(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string LeagueID = null,
            string OffTeamID = null,
            string OffPlayerID = null,
            string DefTeamID = null,
            string DefPlayerID = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("OffTeamID", OffTeamID));
            parameters.Add(CreateParameterObject("OffPlayerID", OffPlayerID));
            parameters.Add(CreateParameterObject("DefTeamID", DefTeamID));
            parameters.Add(CreateParameterObject("DefPlayerID", DefPlayerID));

            return await LeagueSeasonMatchups(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueSeasonMatchups(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leagueseasonmatchups/", "leagueseasonmatchups", parameters);
        }

        public static async Task<List<BsonDocument>> LeagueStandings(
           string Season = null,
           string SeasonType = "Regular Season",
           string LeagueID = null,
           string SeasonYear = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonYear));

            return await LeagueStandings(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueStandings(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguestandings/", "leaguestandings", parameters);
        }

        public static async Task<List<BsonDocument>> LeagueStandingsV3(
           string Season = null,
           string SeasonType = "Regular Season",
           string LeagueID = null,
           string SeasonYear = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonYear));

            return await LeagueStandingsV3(parameters);
        }

        public static async Task<List<BsonDocument>> LeagueStandingsV3(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/leaguestandingsv3/", "leaguestandingsv3", parameters);
        }
    }
}
