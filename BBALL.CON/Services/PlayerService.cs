using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.CON.Helpers;
using static BBALL.CON.Helpers.ParameterHelper;

namespace BBALL.CON
{
    public static class PlayerService
    {
        //Players > Player Index
        public static void PlayerIndex(
            string LeagueID,
            string Season,
            string Active = null,
            string AllStar = null,
            string College = null,
            string Country = null,
            string DraftPick = null,
            string DraftYear = null,
            string Height = null,
            int Historical = 1,
            string PlayerPosition = null,
            int TeamID = 0,
            string Weight = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("Active", Active, ParameterType.String));
            parameters.Add(CreateParameterObject("AllStar", AllStar, ParameterType.String));
            parameters.Add(CreateParameterObject("College", College, ParameterType.String));
            parameters.Add(CreateParameterObject("Country", Country, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick, ParameterType.String));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear, ParameterType.String));
            parameters.Add(CreateParameterObject("Height", Height, ParameterType.String));
            parameters.Add(CreateParameterObject("Historical", Historical, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Weight", Weight, ParameterType.String));

            PlayerIndex(parameters);
        }

        public static void PlayerIndex(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerindex/", "playerindex", parameters);
        }

        public static void PlayerGameLogs(
            string LeagueID,
            string Season,
            string MeasureType = "Base",
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            int LastNGames = 0,
            string Location = null,
            int Month = 0,
            int OppTeamID = 0,
            string Outcome = null,
            int PORound = 0,
            int Period = 0,
            string PlayerID = null,
            string SeasonSegment = null,
            string ShotClockRange = null,
            int TeamID = 0,
            string VsConference = null,
            string VsDivision = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OppTeamID", OppTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("Period", Period, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlayerID", PlayerID, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            PlayerGameLogs(parameters);
        }

        public static void PlayerGameLogs(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playergamelogs/", "playergamelogs", parameters);
        }

        //Player > Profile
        public static void PlayerDashboardByYearOverYear(
            int PlayerID,
            string LeagueID,
            string Season,
            string PerMode = "PerGame",
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            int LastNGames = 0,
            string Location = null,
            int Month = 0,
            int OpponentTeamID = 0,
            string Outcome = null,
            int PORound = 0,
            string PaceAdjust = "N",
            int Period = 0,
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID, ParameterType.Int));
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust, ParameterType.String));
            parameters.Add(CreateParameterObject("Period", Period, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus, ParameterType.String));
            parameters.Add(CreateParameterObject("Rank", Rank, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange, ParameterType.String));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            PlayerDashboardByYearOverYear(parameters);
        }

        public static void PlayerDashboardByYearOverYear(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashboardbyyearoveryear/", "playerdashboardbyyearoveryear", parameters);
        }

        //Player > Splits
        public static void PlayerDashboardByGeneralSplits(
            int PlayerID,
            string LeagueID,
            string Season,
            string PerMode = "PerGame",
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            int LastNGames = 0,
            string Location = null,
            int Month = 0,
            int OpponentTeamID = 0,
            string Outcome = null,
            int PORound = 0,
            string PaceAdjust = "N",
            int Period = 0,
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID, ParameterType.Int));
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust, ParameterType.String));
            parameters.Add(CreateParameterObject("Period", Period, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus, ParameterType.String));
            parameters.Add(CreateParameterObject("Rank", Rank, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange, ParameterType.String));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            PlayerDashboardByGeneralSplits(parameters);
        }

        public static void PlayerDashboardByGeneralSplits(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashboardbygeneralsplits/", "playerdashboardbygeneralsplits", parameters);
        }

        //PLayer > Career
        public static void PlayerCareerStats(
            int PlayerID,
            string LeagueID,
            string PerMode = "PerGame"
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID, ParameterType.Int));
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            PlayerCareerStats(parameters);
        }

        public static void PlayerCareerStats(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playercareerstats/", "playercareerstats", parameters);
        }

        //Player > Career
        public static void PlayerProfileV2(
            int PlayerID,
            string LeagueID,
            string PerMode = "PerGame"
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID, ParameterType.Int));
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            PlayerProfileV2(parameters);
        }

        public static void PlayerProfileV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashboardbygeneralsplits/", "playerdashboardbygeneralsplits", parameters);
        }

        //Player > Career
        public static void PlayerAwards(int PlayerID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID, ParameterType.Int));
            PlayerAwards(parameters);
        }

        public static void PlayerAwards(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerawards/", "playerawards", parameters);
        }

        public static void PlayDashPTShots(
            int PlayerID,
            string LeagueID,
            string Season,
            string PerMode = "PerGame",
            string SeasonType = "Regular Season",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            int LastNGames = 0,
            string Location = null,
            int Month = 0,
            int OpponentTeamID = 0,
            string Outcome = null,
            int PORound = 0,
            int Period = 0,
            string SeasonSegment = null,
            int TeamID = 0,
            string VsConference = null,
            string VsDivision = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID, ParameterType.Int));
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("Period", Period, ParameterType.Int));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            PlayDashPTShots(parameters);
        }

        public static void PlayDashPTShots(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashptshots/", "playerdashptshots", parameters);
        }


        public static void PlayDashPTReb(int PlayerID,
            string LeagueID,
            string Season,
            string PerMode = "PerGame",
            string SeasonType = "Regular Season",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            int LastNGames = 0,
            string Location = null,
            int Month = 0,
            int OpponentTeamID = 0,
            string Outcome = null,
            int PORound = 0,
            int Period = 0,
            string SeasonSegment = null,
            int TeamID = 0,
            string VsConference = null,
            string VsDivision = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID, ParameterType.Int));
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("Period", Period, ParameterType.Int));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            PlayDashPTReb(parameters);
        }

        public static void PlayDashPTReb(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashptreb/", "playerdashptreb", parameters);
        }

        public static void PlayDashPTPass(int PlayerID,
            string LeagueID,
            string Season,
            string PerMode = "PerGame",
            string SeasonType = "Regular Season",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            int LastNGames = 0,
            string Location = null,
            int Month = 0,
            int OpponentTeamID = 0,
            string Outcome = null,
            int PORound = 0,
            int Period = 0,
            string SeasonSegment = null,
            int TeamID = 0,
            string VsConference = null,
            string VsDivision = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID, ParameterType.Int));
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("Period", Period, ParameterType.Int));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            PlayDashPTPass(parameters);
        }

        public static void PlayDashPTPass(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashptpass/", "playerdashptpass", parameters);
        }

        public static void PlayDashPTShotDefend(int PlayerID,
            string LeagueID,
            string Season,
            string PerMode = "PerGame",
            string SeasonType = "Regular Season",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            int LastNGames = 0,
            string Location = null,
            int Month = 0,
            int OpponentTeamID = 0,
            string Outcome = null,
            int PORound = 0,
            int Period = 0,
            string SeasonSegment = null,
            int TeamID = 0,
            string VsConference = null,
            string VsDivision = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID, ParameterType.Int));
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("Period", Period, ParameterType.Int));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            PlayDashPTShotDefend(parameters);
        }
        
        public static void PlayDashPTShotDefend(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashptshotdefend/", "playerdashptshotdefend", parameters);
        }

        public static void PlayerVsPlayer(
            int PlayerID,
            int VsPlayerID,
            string LeagueID,
            string Season,
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string PerMode = "PerGame",
            string DateFrom = null,
            string DateTo = null,
            int LastNGames = 0,
            string Location = null,
            int Month = 0,
            int OpponentTeamID = 0,
            string Outcome = null,
            string PaceAdjust = "N",
            int Period = 0,
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string VsConference = null,
            string VsDivision = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsPlayerID", VsPlayerID, ParameterType.Int));
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust, ParameterType.String));
            parameters.Add(CreateParameterObject("Period", Period, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus, ParameterType.Int));
            parameters.Add(CreateParameterObject("Rank", Rank, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            PlayerVsPlayer(parameters);
        }

        public static void PlayerVsPlayer(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playervsplayer/", "playervsplayer", parameters);
        }

        public static void PlayerCompare()
        {

        }

        public static void PlayerCompare(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playercompare/", "playercompare", parameters);
        }

        public static void PlayerDashboardByGameSplits()
        {

        }

        public static void PlayerDashboardByGameSplits(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashboardbygamesplits/", "playerdashboardbygamesplits", parameters);
        }


        public static void PlayerDashboardByLastNGames()
        {

        }

        public static void PlayerDashboardByLastNGames(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashboardbylastngames/", "playerdashboardbylastngames", parameters);
        }

        public static void PlayerDashboardByOpponent()
        {

        }

        public static void PlayerDashboardByOpponent(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashboardbyopponent/", "playerdashboardbyopponent", parameters);
        }

        public static void PlayerDashboardByShootingSplits()
        {

        }

        public static void PlayerDashboardByShootingSplits(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashboardbyshootingsplits/", "playerdashboardbyshootingsplits", parameters);
        }


        public static void PlayerDashboardByTeamPerformance()
        {

        }

        public static void PlayerDashboardByTeamPerformance(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashboardbyteamperformance/", "playerdashboardbyteamperformance", parameters);
        }

        public static void PlayersVsPlayers()
        {

        }

        public static void PlayersVsPlayers(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playercompare/", "playercompare", parameters);
        }
    }
}
