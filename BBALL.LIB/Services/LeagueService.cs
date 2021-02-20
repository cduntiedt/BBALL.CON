using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;
using MongoDB.Bson;

namespace BBALL.LIB.Services
{
    public static class LeagueService
    {
        public static BsonDocument LeagueDashLineups(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string MeasureType = "Base",
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
            string TeamID = null,
            string ShotClockRange = null,
            string Conference = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string GameSegment = null,
            string Location = null,
            string Outcome = null,
            string PORound = null
        )
        {
            JArray parameters = new JArray();
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

            return LeagueDashLineups(parameters);
        }

        public static BsonDocument LeagueDashLineups(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashlineups/", "leaguedashlineups", parameters);
        }

        public static BsonDocument LeagueDashPlayerBioStats(
           string Season = null,
           string SeasonType = "Regular Season",
           string PerMode = "PerGame",
           string LeagueID = null,
           string TeamID = null,
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
            JArray parameters = new JArray();
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

            return LeagueDashPlayerBioStats(parameters);
        }

        public static BsonDocument LeagueDashPlayerBioStats(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayerbiostats/", "leaguedashplayerbiostats", parameters);
        }

        //Players > Clutch
        public static BsonDocument LeagueDashPlayerClutch(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string MeasureType = "Base",
            string AheadBehind = "Ahead or Behind",
            string ClutchTime = "Last 5 Minutes",
            string LeagueID = null,
            string TeamID = "0",
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
            string PostringDiff = "5",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string StarterBench = null,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            JArray parameters = new JArray();
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
            parameters.Add(CreateParameterObject("PostringDiff", PostringDiff));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("Weight", Weight));

            return LeagueDashPlayerClutch(parameters);
        }

        public static BsonDocument LeagueDashPlayerClutch(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayerclutch/", "leaguedashplayerclutch", parameters);
        }

        //Players > Shot Dashboard
        public static BsonDocument LeagueDashOppPtShot(
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
            JArray parameters = new JArray();
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

            return LeagueDashOppPtShot(parameters);
        }

        public static BsonDocument LeagueDashOppPtShot(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashoppptshot/", "leaguedashoppptshot", parameters);
        }

        //Players > Shot Dashboard
        public static BsonDocument LeagueDashPlayerPTShot(
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
            JArray parameters = new JArray();
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

            return LeagueDashPlayerPTShot(parameters);
        }

        public static BsonDocument LeagueDashPlayerPTShot(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayerptshot/", "leaguedashplayerptshot", parameters);
        }

        //Players > Shooting
        public static BsonDocument LeagueDashPlayerShotLocations(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string MeasureType = "Base",
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
            JArray parameters = new JArray();
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

            return LeagueDashPlayerShotLocations(parameters);
        }

        public static BsonDocument LeagueDashPlayerShotLocations(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayershotlocations/", "leaguedashplayershotlocations", parameters);
        }

        //Players > Traditional Stats
        public static BsonDocument LeagueDashPlayerStats(
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
            JArray parameters = new JArray();
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

            return LeagueDashPlayerStats(parameters);
        }

        public static BsonDocument LeagueDashPlayerStats(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayerstats/", "leaguedashplayerstats", parameters);
        }

        //Players > Defensive Dashboard
        public static BsonDocument LeagueDashPTDefend(
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
            JArray parameters = new JArray();
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

            return LeagueDashPTDefend(parameters);
        }

        public static BsonDocument LeagueDashPTDefend(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashptdefend/", "leaguedashptdefend", parameters);
        }

        //Players > Tracking
        public static BsonDocument LeagueDashPTStats(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string PtMeasureType = "CatchShoot",
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
            JArray parameters = new JArray();
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
            parameters.Add(CreateParameterObject("PLayerOrTeam", PLayerOrTeam));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("Weight", Weight));

            return LeagueDashPTStats(parameters);
        }

        public static BsonDocument LeagueDashPTStats(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashptstats/", "leaguedashptstats", parameters);
        }

        public static BsonDocument LeagueDashPTTeamDefend(
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
            JArray parameters = new JArray();
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

            return LeagueDashPTTeamDefend(parameters);
        }

        public static BsonDocument LeagueDashPTTeamDefend(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashptteamdefend/", "leaguedashptteamdefend", parameters);
        }

        public static BsonDocument LeagueDashTeamClutch(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string MeasureType = "Base",
            string AheadBehind = "Ahead or Behind",
            string ClutchTime = "Last 5 Minutes",
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
            JArray parameters = new JArray();
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

            return LeagueDashTeamClutch(parameters);
        }

        public static BsonDocument LeagueDashTeamClutch(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashteamclutch/", "leaguedashteamclutch", parameters);
        }

        public static BsonDocument LeagueDashTeamPtShot(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string TeamID = "0",
            string LeagueID = null,
            string CloseDefDistRange = null,
            string Conference = null,
            string DateFrom = null,
            string DateTo = null,
            string Division = null,
            string DribbleRange = null,
            string GameSegment = null,
            string GeneralRange = "Overall",
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
            JArray parameters = new JArray();
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

            return LeagueDashTeamPtShot(parameters);
        }

        public static BsonDocument LeagueDashTeamPtShot(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashteamptshot/", "leaguedashteamptshot", parameters);
        }

        public static BsonDocument LeagueDashTeamShotLocations(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string MeasureType = "Opponent",
            string DistanceRange = "By Zone",
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
            string PLayerOrTeam = "Player",
            string PlayerPosition = null,
            string SeasonSegment = null,
            string ShotClockRange = null,
            string StarterBench = null,
            string VsConference = null,
            string VsDivision = null)
        {
            JArray parameters = new JArray();
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
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience));
            parameters.Add(CreateParameterObject("PLayerOrTeam", PLayerOrTeam));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            return LeagueDashTeamShotLocations(parameters);
        }

        public static BsonDocument LeagueDashTeamShotLocations(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashteamshotlocations/", "leaguedashteamshotlocations", parameters);
        }

        public static BsonDocument LeagueDashTeamStats(
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
            JArray parameters = new JArray();
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

            return LeagueDashTeamStats(parameters);
        }

        public static BsonDocument LeagueDashTeamStats(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashteamstats/", "leaguedashteamstats", parameters);
        }


        //Players > Opponent Shooting
        public static BsonDocument LeagueDashOpponentShotLocations(
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
            JArray parameters = new JArray();
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

            return LeagueDashPlayerShotLocations(parameters);
        }

        //Players > Hustle or Players > Box Outs
        public static BsonDocument LeagueHustleStatsPlayer(
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
            JArray parameters = new JArray();
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

            return LeagueHustleStatsPlayer(parameters);
        }

        public static BsonDocument LeagueHustleStatsPlayer(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguehustlestatsplayer/", "leaguehustlestatsplayer", parameters);

        }

        public static BsonDocument LeagueHustleStatsPlayerLeaders(
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
            JArray parameters = new JArray();
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

            return LeagueHustleStatsPlayerLeaders(parameters);
        }

        public static BsonDocument LeagueHustleStatsPlayerLeaders(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguehustlestatsplayerleaders/", "leaguehustlestatsplayerleaders", parameters);
        }

        public static BsonDocument LeagueHustleStatsTeam(
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
            JArray parameters = new JArray();
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

            return LeagueHustleStatsTeam(parameters);
        }

        public static BsonDocument LeagueHustleStatsTeam(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguehustlestatsteam/", "leaguehustlestatsteam", parameters);

        }

        public static BsonDocument LeagueHustleStatsTeamLeaders(
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
            JArray parameters = new JArray();
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

            return LeagueHustleStatsTeamLeaders(parameters);
        }

        public static BsonDocument LeagueHustleStatsTeamLeaders(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguehustlestatsteamleaders/", "leaguehustlestatsteamleaders", parameters);
        }

        public static BsonDocument LeagueGameLog(
            string Season = null,
            string SeasonType = "Regular Season",
            string Counter = "1000",
            string DateFrom = null,
            string DateTo = null,
            string LeagueID = null,
            string Direction = "DESC",
            string PlayerOrTeam = "P",
            string Sorter = "Date"
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("Counter", Counter));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Direction", Direction));
            parameters.Add(CreateParameterObject("PlayerOrTeam", PlayerOrTeam));
            parameters.Add(CreateParameterObject("Sorter", Sorter));

            return LeagueGameLog(parameters);
        }

        public static BsonDocument LeagueGameLog(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguegamelog/", "leaguegamelog", parameters);
        }

        public static BsonDocument LeagueLineupViz(
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
            JArray parameters = new JArray();
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

            return LeagueLineupViz(parameters);
        }

        public static BsonDocument LeagueLineupViz(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguelineupviz/", "leaguelineupviz", parameters);
        }

        public static BsonDocument LeaguePlayerOnDetails(
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
            JArray parameters = new JArray();
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

            return LeaguePlayerOnDetails(parameters);
        }

        public static BsonDocument LeaguePlayerOnDetails(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leagueplayerondetails/", "leagueplayerondetails", parameters);
        }

        public static BsonDocument LeagueSeasonMatchups(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string LeagueID = null,
            string OffTeamID = null,
            string OffPlayerID = null,
            string DefTeamID = null,
            string DefPlayerID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("OffTeamID", OffTeamID));
            parameters.Add(CreateParameterObject("OffPlayerID", OffPlayerID));
            parameters.Add(CreateParameterObject("DefTeamID", DefTeamID));
            parameters.Add(CreateParameterObject("DefPlayerID", DefPlayerID));

            return LeagueSeasonMatchups(parameters);
        }

        public static BsonDocument LeagueSeasonMatchups(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leagueseasonmatchups/", "leagueseasonmatchups", parameters);
        }

        public static BsonDocument LeagueStandings(
           string Season = null,
           string SeasonType = "Regular Season",
           string LeagueID = null,
           string SeasonYear = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonYear));

            return LeagueStandings(parameters);
        }

        public static BsonDocument LeagueStandings(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguestandings/", "leaguestandings", parameters);
        }

        public static BsonDocument LeagueStandingsV3(
           string Season = null,
           string SeasonType = "Regular Season",
           string LeagueID = null,
           string SeasonYear = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonYear));

            return LeagueStandingsV3(parameters);
        }

        public static BsonDocument LeagueStandingsV3(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguestandingsv3/", "leaguestandingsv3", parameters);
        }
    }
}
