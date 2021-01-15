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
        public static void LeagueDashPlayerBioStats(
           string LeagueID,
           string Season,
           string PerMode = "PerGame",
           string SeasonType = "Regular Season",
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
           int LastNGames = 0,
           string Location = null,
           int Month = 0,
           int OpponentTeamID = 0,
           string Outcome = null,
           int PORound = 0,
           int Period = 0,
           string PlayerExperience = null,
           string PlayerPosition = null,
           string SeasonSegment = null,
           string ShotClockRange = null,
           string StarterBench = null,
           int TeamID = 0,
           int TwoWay = 0,
           string VsConference = null,
           string VsDivision = null,
           string Weight = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("College", College, ParameterType.String));
            parameters.Add(CreateParameterObject("Conference", Conference, ParameterType.String));
            parameters.Add(CreateParameterObject("Country", Country, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("Division", Division, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear, ParameterType.String));
            parameters.Add(CreateParameterObject("GameScope", GameScope, ParameterType.String));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("Height", Height, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("Period", Period, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange, ParameterType.String));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("TwoWay", TwoWay, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            parameters.Add(CreateParameterObject("Weight", Weight, ParameterType.String));

            LeagueDashPlayerBioStats(parameters);
        }

        public static void LeagueDashPlayerBioStats(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayerbiostats/", "leaguedashplayerbiostats", parameters);
        }

        //Players > Clutch
        public static void LeagueDashPlayerClutch(
            string LeagueID,
            string MeasureType,
            string PerMode,
            string Season,
            string SeasonType,
            string AheadBehind = "Ahead or Behind",
            string ClutchTime = "Last 5 Minutes",
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
            int LastNGames = 0,
            string Location = null,
            int Month = 0,
            int OpponentTeamID = 0,
            string Outcome = null,
            int PORound = 0,
            string PaceAdjust = "N",
            int Period = 0,
            string PlayerExperience = null,
            string PlayerPosition = null,
            string PlusMinus = "N",
            int PointDiff = 5,
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string StarterBench = null,
            int TeamID = 0,
            int TwoWay = 0,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("AheadBehind", AheadBehind, ParameterType.String));
            parameters.Add(CreateParameterObject("ClutchTime", ClutchTime, ParameterType.String));
            parameters.Add(CreateParameterObject("College", College, ParameterType.String));
            parameters.Add(CreateParameterObject("Conference", Conference, ParameterType.String));
            parameters.Add(CreateParameterObject("Country", Country, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("Division", Division, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear, ParameterType.String));
            parameters.Add(CreateParameterObject("GameScope", GameScope, ParameterType.String));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("Height", Height, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust, ParameterType.String));
            parameters.Add(CreateParameterObject("Period", Period, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition, ParameterType.String));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus, ParameterType.String));
            parameters.Add(CreateParameterObject("PointDiff", PointDiff, ParameterType.Int));
            parameters.Add(CreateParameterObject("Rank", Rank, ParameterType.Int));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange, ParameterType.String));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("TwoWay", TwoWay, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            parameters.Add(CreateParameterObject("Weight", Weight, ParameterType.String));

            LeagueDashPlayerClutch(parameters);
        }

        public static void LeagueDashPlayerClutch(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayerclutch/", "leaguedashplayerclutch", parameters);
        }

        //Players > Shot Dashboard
        public static void LeagueDashPlayerPTShot(
            string LeagueID,
            string PerMode,
            string Season,
            string SeasonType,
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
            int LastNGames = 0,
            string Location = null,
            int Month = 0,
            int OpponentTeamID = 0,
            string Outcome = null,
            int PORound = 0,
            string PaceAdjust = "N",
            int Period = 0,
            string PlayerExperience = null,
            string PlayerPosition = null,
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string ShotDistRange = null,
            string StarterBench = null,
            int TeamID = 0,
            string TouchTimeRange = null,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("CloseDefDistRange", CloseDefDistRange, ParameterType.String));
            parameters.Add(CreateParameterObject("College", College, ParameterType.String));
            parameters.Add(CreateParameterObject("Conference", Conference, ParameterType.String));
            parameters.Add(CreateParameterObject("Country", Country, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("Division", Division, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear, ParameterType.String));
            parameters.Add(CreateParameterObject("DribbleRange", DribbleRange, ParameterType.String));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("GeneralRange", GeneralRange, ParameterType.String));
            parameters.Add(CreateParameterObject("Height", Height, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust, ParameterType.String));
            parameters.Add(CreateParameterObject("Period", Period, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition, ParameterType.String));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus, ParameterType.String));
            parameters.Add(CreateParameterObject("Rank", Rank, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange, ParameterType.String));
            parameters.Add(CreateParameterObject("ShotDistRange", ShotDistRange, ParameterType.String));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("TouchTimeRange", TouchTimeRange, ParameterType.String));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            parameters.Add(CreateParameterObject("Weight", Weight, ParameterType.String));

            LeagueDashPlayerPTShot(parameters);
        }

        public static void LeagueDashPlayerPTShot(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayerptshot/", "leaguedashplayerptshot", parameters);
        }

        //Players > Shooting
        public static void LeagueDashPlayerShotLocations(
            string LeagueID,
            string Season,
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string PerMode = "PerGame",
            string DistanceRange = "5ft Range",
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
            int LastNGames = 0,
            string Location = null,
            int Month = 0,
            int OpponentTeamID = 0,
            string Outcome = null,
            int PORound = 0,
            string PlayerExperience = null,
            string PLayerOrTeam = "Player",
            string PlayerPosition = null,
            string SeasonSegment = null,
            string StarterBench = null,
            int TeamID = 0,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType, ParameterType.String));
            parameters.Add(CreateParameterObject("DistanceRange", DistanceRange, ParameterType.String));
            parameters.Add(CreateParameterObject("College", College, ParameterType.String));
            parameters.Add(CreateParameterObject("Conference", Conference, ParameterType.String));
            parameters.Add(CreateParameterObject("Country", Country, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("Division", Division, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear, ParameterType.String));
            parameters.Add(CreateParameterObject("GameScope", GameScope, ParameterType.String));
            parameters.Add(CreateParameterObject("Height", Height, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience, ParameterType.String));
            parameters.Add(CreateParameterObject("PLayerOrTeam", PLayerOrTeam, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            parameters.Add(CreateParameterObject("Weight", Weight, ParameterType.String));

            LeagueDashPlayerShotLocations(parameters);
        }

        public static void LeagueDashPlayerShotLocations(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayershotlocations/", "leaguedashplayershotlocations", parameters);
        }

        //Players > Traditional Stats
        public static void LeagueDashPlayerStats(
            string LeagueID,
            string MeasureType,
            string PerMode,
            string Season,
            string SeasonType,
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
            int LastNGames = 0,
            string Location = null,
            int Month = 0,
            int OpponentTeamID = 0,
            string Outcome = null,
            int PORound = 0,
            string PaceAdjust = "N",
            int Period = 0,
            string PlayerExperience = null,
            string PlayerPosition = null,
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string StarterBench = null,
            int TeamID = 0,
            int TwoWay = 0,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("College", College, ParameterType.String));
            parameters.Add(CreateParameterObject("Conference", Conference, ParameterType.String));
            parameters.Add(CreateParameterObject("Country", Country, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("Division", Division, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear, ParameterType.String));
            parameters.Add(CreateParameterObject("GameScope", GameScope, ParameterType.String));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("Height", Height, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust, ParameterType.String));
            parameters.Add(CreateParameterObject("Period", Period, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition, ParameterType.String));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus, ParameterType.String));
            parameters.Add(CreateParameterObject("Rank", Rank, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange, ParameterType.String));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("TwoWay", TwoWay, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            parameters.Add(CreateParameterObject("Weight", Weight, ParameterType.String));

            LeagueDashPlayerStats(parameters);
        }

        public static void LeagueDashPlayerStats(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayerstats/", "leaguedashplayerstats", parameters);
        }

        //Players > Defensive Dashboard
        public static void LeagueDashPTDefend(
            string LeagueID,
            string PerMode,
            string Season,
            string SeasonType,
            string DefenseCategory = "Overall",
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
            int LastNGames = 0,
            string Location = null,
            int Month = 0,
            int OpponentTeamID = 0,
            string Outcome = null,
            int PORound = 0,
            string PaceAdjust = "N",
            int Period = 0,
            string PlayerExperience = null,
            string PlayerPosition = null,
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string StarterBench = null,
            int TeamID = 0,
            int TwoWay = 0,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("DefenseCategory", DefenseCategory, ParameterType.String));
            parameters.Add(CreateParameterObject("College", College, ParameterType.String));
            parameters.Add(CreateParameterObject("Conference", Conference, ParameterType.String));
            parameters.Add(CreateParameterObject("Country", Country, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("Division", Division, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear, ParameterType.String));
            parameters.Add(CreateParameterObject("GameScope", GameScope, ParameterType.String));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("Height", Height, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust, ParameterType.String));
            parameters.Add(CreateParameterObject("Period", Period, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition, ParameterType.String));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus, ParameterType.String));
            parameters.Add(CreateParameterObject("Rank", Rank, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange, ParameterType.String));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("TwoWay", TwoWay, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            parameters.Add(CreateParameterObject("Weight", Weight, ParameterType.String));

            LeagueDashPTDefend(parameters);
        }

        public static void LeagueDashPTDefend(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashptdefend/", "leaguedashptdefend", parameters);
        }

        //Players > Tracking
        public static void LeagueDashPTStats(
            string LeagueID,
            string PerMode,
            string Season,
            string SeasonType,
            string PtMeasureType = "CatchShoot",
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
            int LastNGames = 0,
            string Location = null,
            int Month = 0,
            int OpponentTeamID = 0,
            string Outcome = null,
            int PORound = 0,
            string PlayerExperience = null,
            string PLayerOrTeam = "Player",
            string PlayerPosition = null,
            string SeasonSegment = null,
            string StarterBench = null,
            int TeamID = 0,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("PtMeasureType", PtMeasureType, ParameterType.String));
            parameters.Add(CreateParameterObject("College", College, ParameterType.String));
            parameters.Add(CreateParameterObject("Conference", Conference, ParameterType.String));
            parameters.Add(CreateParameterObject("Country", Country, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("Division", Division, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear, ParameterType.String));
            parameters.Add(CreateParameterObject("GameScope", GameScope, ParameterType.String));
            parameters.Add(CreateParameterObject("Height", Height, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience, ParameterType.String));
            parameters.Add(CreateParameterObject("PLayerOrTeam", PLayerOrTeam, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            parameters.Add(CreateParameterObject("Weight", Weight, ParameterType.String));

            LeagueDashPTStats(parameters);
        }

        public static void LeagueDashPTStats(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashptstats/", "leaguedashptstats", parameters);
        }

        //Players > Opponent Shooting
        public static void LeagueDashOpponentShotLocations(
            string LeagueID,
            string Season,
            string SeasonType = "Regular Season",
            string MeasureType = "Opponent",
            string PerMode = "PerGame",
            string DistanceRange = "5ft Range",
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
            int LastNGames = 0,
            string Location = null,
            int Month = 0,
            int OpponentTeamID = 0,
            string Outcome = null,
            int PORound = 0,
            string PlayerExperience = null,
            string PLayerOrTeam = "Player",
            string PlayerPosition = null,
            string SeasonSegment = null,
            string StarterBench = null,
            int TeamID = 0,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType, ParameterType.String));
            parameters.Add(CreateParameterObject("DistanceRange", DistanceRange, ParameterType.String));
            parameters.Add(CreateParameterObject("College", College, ParameterType.String));
            parameters.Add(CreateParameterObject("Conference", Conference, ParameterType.String));
            parameters.Add(CreateParameterObject("Country", Country, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("Division", Division, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear, ParameterType.String));
            parameters.Add(CreateParameterObject("GameScope", GameScope, ParameterType.String));
            parameters.Add(CreateParameterObject("Height", Height, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience, ParameterType.String));
            parameters.Add(CreateParameterObject("PLayerOrTeam", PLayerOrTeam, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("StarterBench", StarterBench, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            parameters.Add(CreateParameterObject("Weight", Weight, ParameterType.String));

            LeagueDashPlayerShotLocations(parameters);
        }

        //Players > Hustle or Players > Box Outs
        public static void LeagueHustleStatsPlayer(
            string LeagueID,
            string Season,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
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
            int Month = 0,
            int OpponentTeamID = 0,
            string Outcome = null,
            int PORound = 0,
            string PlayerExperience = null,
            string PlayerPosition = null,
            string SeasonSegment = null,
            int TeamID = 0,
            string VsConference = null,
            string VsDivision = null,
            string Weight = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("College", College, ParameterType.String));
            parameters.Add(CreateParameterObject("Conference", Conference, ParameterType.String));
            parameters.Add(CreateParameterObject("Country", Country, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("Division", Division, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear, ParameterType.String));
            parameters.Add(CreateParameterObject("Height", Height, ParameterType.String));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlayerExperience", PlayerExperience, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            parameters.Add(CreateParameterObject("Weight", Weight, ParameterType.String));

            LeagueHustleStatsPlayer(parameters);
        }

        public static void LeagueHustleStatsPlayer(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguehustlestatsplayer/", "leaguehustlestatsplayer", parameters);

        }

        public static void LeagueGameLog(
            string LeagueID,
            string Season,
            string SeasonType = "Regular Season",
            int Counter = 1000,
            string DateFrom = null,
            string DateTo = null,
            string Direction = "DESC",
            string PlayerOrTeam = "P",
            string Sorter = "Date"
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("Counter", Counter, ParameterType.Int));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("Direction", Direction, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerOrTeam", PlayerOrTeam, ParameterType.String));
            parameters.Add(CreateParameterObject("Sorter", Sorter, ParameterType.String));

            LeagueGameLog(parameters);
        }

        public static void LeagueGameLog(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguegamelog/", "leaguegamelog", parameters);
        }
    }
}
