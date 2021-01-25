using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.CON.Helpers;
using static BBALL.CON.Helpers.ParameterHelper;

namespace BBALL.CON.Services
{
    public static class LeagueService
    {
        public static void LeagueDashLineups(
            string Season = null,
            string LeagueID = null,
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string GroupQuantity = "5",
            string LastNGames = "0",
            string Month = "0",
            string OpponentTeamID = "0",
            string PaceAdjust = "N",
            string PerMode = "Totals",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
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

            LeagueDashLineups(parameters);
        }

        public static void LeagueDashLineups(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashlineups/", "leaguedashlineups", parameters);
        }

        public static void LeagueDashPlayerBioStats(
           string LeagueID = null,
           string Season = null,
           string PerMode = "PerGame",
           string SeasonType = "Regular Season",
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

            LeagueDashPlayerBioStats(parameters);
        }

        public static void LeagueDashPlayerBioStats(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayerbiostats/", "leaguedashplayerbiostats", parameters);
        }

        //Players > Clutch
        public static void LeagueDashPlayerClutch(
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string PerMode = "Totals",
            string AheadBehind = "Ahead or Behind",
            string ClutchTime = "Last 5 Minutes",
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

            LeagueDashPlayerClutch(parameters);
        }

        public static void LeagueDashPlayerClutch(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayerclutch/", "leaguedashplayerclutch", parameters);
        }

        //Players > Shot Dashboard
        public static void LeagueDashOppPtShot(
            string LeagueID = null,
            string Season = null,
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
            string TeamID = "0",
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

            LeagueDashOppPtShot(parameters);
        }

        public static void LeagueDashOppPtShot(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashoppptshot/", "leaguedashoppptshot", parameters);
        }

        //Players > Shot Dashboard
        public static void LeagueDashPlayerPTShot(
            string LeagueID = null,
            string Season = null,
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
            string TeamID = "0",
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

            LeagueDashPlayerPTShot(parameters);
        }

        public static void LeagueDashPlayerPTShot(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayerptshot/", "leaguedashplayerptshot", parameters);
        }

        //Players > Shooting
        public static void LeagueDashPlayerShotLocations(
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string PerMode = "PerGame",
            string DistanceRange = "By Zone",
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

            LeagueDashPlayerShotLocations(parameters);
        }

        public static void LeagueDashPlayerShotLocations(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayershotlocations/", "leaguedashplayershotlocations", parameters);
        }

        //Players > Traditional Stats
        public static void LeagueDashPlayerStats(
            string LeagueID = null,
            string Season = null,
            string MeasureType = "Base",
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
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

            LeagueDashPlayerStats(parameters);
        }

        public static void LeagueDashPlayerStats(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayerstats/", "leaguedashplayerstats", parameters);
        }

        //Players > Defensive Dashboard
        public static void LeagueDashPTDefend(
            string LeagueID = null,
            string Season = null,
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
            string DefenseCategory = "Overall",
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

            LeagueDashPTDefend(parameters);
        }

        public static void LeagueDashPTDefend(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashptdefend/", "leaguedashptdefend", parameters);
        }

        //Players > Tracking
        public static void LeagueDashPTStats(
            string LeagueID = null,
            string Season = null,
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
            string PtMeasureType = "CatchShoot",
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

            LeagueDashPTStats(parameters);
        }

        public static void LeagueDashPTStats(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashptstats/", "leaguedashptstats", parameters);
        }

        public static void LeagueDashPTTeamDefend(
            string LeagueID = null,
            string Season = null,
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
            string DefenseCategory = "Overall",
            string TeamID = "0",
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

            LeagueDashPTTeamDefend(parameters);
        }

        public static void LeagueDashPTTeamDefend(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashptteamdefend/", "leaguedashptteamdefend", parameters);
        }

        public static void LeagueDashTeamClutch(
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string PerMode = "Totals",
            string AheadBehind = "Ahead or Behind",
            string ClutchTime = "Last 5 Minutes",
            string TeamID = "0",
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

            LeagueDashTeamClutch(parameters);
        }

        public static void LeagueDashTeamClutch(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashteamclutch/", "leaguedashteamclutch", parameters);
        }

        public static void LeagueDashTeamPtShot(
            string LeagueID = null,
            string Season = null,
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
            string TeamID = "0",
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

            LeagueDashTeamPtShot(parameters);
        }

        public static void LeagueDashTeamPtShot(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashteamptshot/", "leaguedashteamptshot", parameters);
        }

        public static void LeagueDashTeamShotLocations(
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string MeasureType = "Opponent",
            string PerMode = "PerGame",
            string DistanceRange = "By Zone",
            string TeamID = "0",
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

            LeagueDashTeamShotLocations(parameters);
        }

        public static void LeagueDashTeamShotLocations(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashteamshotlocations/", "leaguedashteamshotlocations", parameters);
        }

        public static void LeagueDashTeamStats(
           string LeagueID = null,
           string Season = null,
           string MeasureType = "Base",
           string PerMode = "Totals",
           string SeasonType = "Regular Season",
           string TeamID = null,
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

            LeagueDashTeamStats(parameters);
        }

        public static void LeagueDashTeamStats(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashteamstats/", "leaguedashteamstats", parameters);
        }


        //Players > Opponent Shooting
        public static void LeagueDashOpponentShotLocations(
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string MeasureType = "Opponent",
            string PerMode = "PerGame",
            string DistanceRange = "By Zone",
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

            LeagueDashPlayerShotLocations(parameters);
        }

        //Players > Hustle or Players > Box Outs
        public static void LeagueHustleStatsPlayer(
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string TeamID = "0",
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

            LeagueHustleStatsPlayer(parameters);
        }

        public static void LeagueHustleStatsPlayer(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguehustlestatsplayer/", "leaguehustlestatsplayer", parameters);

        }

        public static void LeagueHustleStatsPlayerLeaders(
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string TeamID = "0",
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

            LeagueHustleStatsPlayerLeaders(parameters);
        }

        public static void LeagueHustleStatsPlayerLeaders(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguehustlestatsplayerleaders/", "leaguehustlestatsplayerleaders", parameters);
        }

        public static void LeagueHustleStatsTeam(
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string TeamID = "0",
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

            LeagueHustleStatsTeam(parameters);
        }

        public static void LeagueHustleStatsTeam(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguehustlestatsteam/", "leaguehustlestatsteam", parameters);

        }

        public static void LeagueHustleStatsTeamLeaders(
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string TeamID = "0",
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

            LeagueHustleStatsTeamLeaders(parameters);
        }

        public static void LeagueHustleStatsTeamLeaders(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguehustlestatsteamleaders/", "leaguehustlestatsteamleaders", parameters);

        }

        public static void LeagueGameLog(
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string Counter = "1000",
            string DateFrom = null,
            string DateTo = null,
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

            LeagueGameLog(parameters);
        }

        public static void LeagueGameLog(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguegamelog/", "leaguegamelog", parameters);
        }

        public static void LeagueLineupViz(
            string LeagueID = null,
            string Season = null,
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string TeamID = "0",
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

            LeagueLineupViz(parameters);
        }

        public static void LeagueLineupViz(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguelineupviz/", "leaguelineupviz", parameters);
        }

        public static void LeaguePlayerOnDetails(
            string LeagueID = null,
            string Season = null,
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string TeamID = "0",
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

            LeaguePlayerOnDetails(parameters);
        }

        public static void LeaguePlayerOnDetails(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leagueplayerondetails/", "leagueplayerondetails", parameters);
        }

        public static void LeagueSeasonMatchups(
            string LeagueID = null,
            string Season = null,
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
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

            LeagueSeasonMatchups(parameters);
        }

        public static void LeagueSeasonMatchups(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leagueseasonmatchups/", "leagueseasonmatchups", parameters);
        }

        public static void LeagueStandings(
           string LeagueID = null,
           string Season = null,
           string SeasonType = "Regular Season",
           string SeasonYear = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonYear));

            LeagueStandings(parameters);
        }

        public static void LeagueStandings(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguestandings/", "leaguestandings", parameters);
        }

        public static void LeagueStandingsV3(
           string LeagueID = null,
           string Season = null,
           string SeasonType = "Regular Season",
           string SeasonYear = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonYear));

            LeagueStandingsV3(parameters);
        }

        public static void LeagueStandingsV3(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguestandingsv3/", "leaguestandingsv3", parameters);
        }
    }
}
