﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using System.Linq;
using BBALL.CON.Helpers;
using static BBALL.CON.Helpers.ParameterHelper;

namespace BBALL.CON
{
    public static class TeamService
    {
        /// <summary>
        /// Get a list of team IDs
        /// </summary>
        /// <returns>A list of integer</returns>
        public static List<int> GetTeamIDs()
        {
            JArray defaultParameters = new JArray();
            defaultParameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(null)));
            JObject teamsCollection = DatabaseHelper.GetDocument("commonteamyears", defaultParameters);
            JArray teamsResultSets = teamsCollection["resultSets"].ToObject<JArray>();

            JObject teamYears = teamsResultSets[0].ToObject<JObject>();

            JArray teamData = teamsResultSets[0]["data"].ToObject<JArray>();
            var teams = teamData.Select(x => (int)x["TEAM_ID"]).Distinct().ToList();

            return teams;
        }

        public static void CommonTeamYears(string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID));
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/commonteamyears/", "commonteamyears", parameters);
        }

        public static void FranchiseHistory(string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID));
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/franchisehistory/", "franchisehistory", parameters);
        }

        public static void CommonTeamRoster(string TeamID = null, string Season = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/commonteamroster/", "commonteamroster", parameters);
        }

        public static void TeamAndPlayersVsPlayers(
            string PlayerID1,
            string PlayerID2,
            string PlayerID3,
            string PlayerID4,
            string PlayerID5,
            string TeamID,
            string VsPlayerID1,
            string VsPlayerID2,
            string VsPlayerID3,
            string VsPlayerID4,
            string VsPlayerID5,
            string VsTeamID,
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string PerMode = "Totals",
            string LastNGames = "0",
            string Month = "0",
            string OpponentTeamID = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string Conference = null,
            string DateFrom = null,
            string DateTo = null,
            string Divison = null,
            string GameSegment = null,
            string Location = null,
            string Outcome = null,
            string SeasonSegment = null,
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID1", PlayerID1));
            parameters.Add(CreateParameterObject("PlayerID2", PlayerID2));
            parameters.Add(CreateParameterObject("PlayerID3", PlayerID3));
            parameters.Add(CreateParameterObject("PlayerID4", PlayerID4));
            parameters.Add(CreateParameterObject("PlayerID5", PlayerID5));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsPlayerID1", VsPlayerID1));
            parameters.Add(CreateParameterObject("VsPlayerID2", VsPlayerID2));
            parameters.Add(CreateParameterObject("VsPlayerID3", VsPlayerID3));
            parameters.Add(CreateParameterObject("VsPlayerID4", VsPlayerID4));
            parameters.Add(CreateParameterObject("VsPlayerID5", VsPlayerID5));
            parameters.Add(CreateParameterObject("VsTeamID", VsTeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("Conference", Conference));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Divison", Divison));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            TeamAndPlayersVsPlayers(parameters);
        }

        public static void TeamAndPlayersVsPlayers(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teamandplayersvsplayers/", "teamandplayersvsplayers", parameters);
        }

        public static void TeamDashLineups(
            string TeamID,
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string PerMode = "Totals",
            string LastNGames = "0",
            string Month = "0",
            string OpponentTeamID = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string GroupQuantity = "5",
            string DateFrom = null,
            string DateTo = null,
            string GameID = null,
            string GameSegment = null,
            string Location = null,
            string Outcome = null,
            string PORound = null,
            string SeasonSegment = null,
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GroupQuantity", GroupQuantity));
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            TeamDashLineups(parameters);
        }

        public static void TeamDashLineups(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teamdashlineups/", "teamdashlineups", parameters);
        }

        public static void TeamDashPtPass(
            string TeamID,
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string LastNGames = "0",
            string Month = "0",
            string OpponentTeamID = "0",
            string DateFrom = null,
            string DateTo = null,
            string Location = null,
            string Outcome = null,
            string SeasonSegment = null,
            string VsConference = null,
            string VsDivision = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            TeamDashPtPass(parameters);
        }

        public static void TeamDashPtPass(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teamdashptpass/", "teamdashptpass", parameters);
        }

        public static void TeamDashPtReb(
           string TeamID,
           string LeagueID = null,
           string Season = null,
           string SeasonType = "Regular Season",
           string PerMode = "Totals",
           string LastNGames = "0",
           string Month = "0",
           string OpponentTeamID = "0",
           string Period = "0",
           string DateFrom = null,
           string DateTo = null,
           string GameSegment = null,
           string Location = null,
           string Outcome = null,
           string SeasonSegment = null,
           string VsConference = null,
           string VsDivision = null
           )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            TeamDashPtReb(parameters);
        }

        public static void TeamDashPtReb(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teamdashptreb/", "teamdashptreb", parameters);
        }

        public static void TeamDashPtShots(
           string TeamID,
           string LeagueID = null,
           string Season = null,
           string SeasonType = "Regular Season",
           string PerMode = "Totals",
           string LastNGames = "0",
           string Month = "0",
           string OpponentTeamID = "0",
           string Period = "0",
           string DateFrom = null,
           string DateTo = null,
           string GameSegment = null,
           string Location = null,
           string Outcome = null,
           string SeasonSegment = null,
           string VsConference = null,
           string VsDivision = null
           )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            TeamDashPtShots(parameters);
        }

        public static void TeamDashPtShots(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teamdashptshots/", "teamdashptshots", parameters);
        }

        public static void TeamDashboardByClutch(
            string TeamID,
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string PerMode = "Totals",
            string LastNGames = "0",
            string Month = "0",
            string OpponentTeamID = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string Location = null,
            string Outcome = null,
            string PORound = null,
            string SeasonSegment = null,
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null
           )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            TeamDashboardByClutch(parameters);
        }

        public static void TeamDashboardByClutch(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teamdashboardbyclutch/", "teamdashboardbyclutch", parameters);
        }

        public static void TeamDashboardByGameSplits(
              string TeamID,
              string LeagueID = null,
              string Season = null,
              string SeasonType = "Regular Season",
              string MeasureType = "Base",
              string PerMode = "Totals",
              string LastNGames = "0",
              string Month = "0",
              string OpponentTeamID = "0",
              string PaceAdjust = "N",
              string Period = "0",
              string PlusMinus = "N",
              string Rank = "N",
              string DateFrom = null,
              string DateTo = null,
              string GameSegment = null,
              string Location = null,
              string Outcome = null,
              string PORound = null,
              string SeasonSegment = null,
              string ShotClockRange = null,
              string VsConference = null,
              string VsDivision = null
             )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            TeamDashboardByGameSplits(parameters);
        }

        public static void TeamDashboardByGameSplits(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teamdashboardbygamesplits/", "teamdashboardbygamesplits", parameters);
        }

        public static void TeamDashboardByGeneralSplits(
              string TeamID,
              string LeagueID = null,
              string Season = null,
              string SeasonType = "Regular Season",
              string MeasureType = "Base",
              string PerMode = "Totals",
              string LastNGames = "0",
              string Month = "0",
              string OpponentTeamID = "0",
              string PaceAdjust = "N",
              string Period = "0",
              string PlusMinus = "N",
              string Rank = "N",
              string DateFrom = null,
              string DateTo = null,
              string GameSegment = null,
              string Location = null,
              string Outcome = null,
              string PORound = null,
              string SeasonSegment = null,
              string ShotClockRange = null,
              string VsConference = null,
              string VsDivision = null
             )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            TeamDashboardByGeneralSplits(parameters);
        }

        public static void TeamDashboardByGeneralSplits(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teamdashboardbygeneralsplits/", "teamdashboardbygeneralsplits", parameters);
        }

        public static void TeamDashboardByLastNGames(
             string TeamID,
             string LeagueID = null,
             string Season = null,
             string SeasonType = "Regular Season",
             string MeasureType = "Base",
             string PerMode = "Totals",
             string LastNGames = "0",
             string Month = "0",
             string OpponentTeamID = "0",
             string PaceAdjust = "N",
             string Period = "0",
             string PlusMinus = "N",
             string Rank = "N",
             string DateFrom = null,
             string DateTo = null,
             string GameSegment = null,
             string Location = null,
             string Outcome = null,
             string PORound = null,
             string SeasonSegment = null,
             string ShotClockRange = null,
             string VsConference = null,
             string VsDivision = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            TeamDashboardByLastNGames(parameters);
        }

        public static void TeamDashboardByLastNGames(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teamdashboardbylastngames/", "teamdashboardbylastngames", parameters);
        }

        public static void TeamDashboardByOpponent(
            string TeamID,
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string PerMode = "Totals",
            string LastNGames = "0",
            string Month = "0",
            string OpponentTeamID = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string Location = null,
            string Outcome = null,
            string PORound = null,
            string SeasonSegment = null,
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null
           )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            TeamDashboardByOpponent(parameters);
        }

        public static void TeamDashboardByOpponent(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teamdashboardbyopponent/", "teamdashboardbyopponent", parameters);
        }

        public static void TeamDashboardByShootingSplits(
            string TeamID,
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string PerMode = "Totals",
            string LastNGames = "0",
            string Month = "0",
            string OpponentTeamID = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string Location = null,
            string Outcome = null,
            string PORound = null,
            string SeasonSegment = null,
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null
           )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            TeamDashboardByShootingSplits(parameters);
        }

        public static void TeamDashboardByShootingSplits(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teamdashboardbyshootingsplits/", "teamdashboardbyshootingsplits", parameters);
        }

        public static void TeamDashboardByTeamPerformance(
                string TeamID,
                string LeagueID = null,
                string Season = null,
                string SeasonType = "Regular Season",
                string MeasureType = "Base",
                string PerMode = "Totals",
                string LastNGames = "0",
                string Month = "0",
                string OpponentTeamID = "0",
                string PaceAdjust = "N",
                string Period = "0",
                string PlusMinus = "N",
                string Rank = "N",
                string DateFrom = null,
                string DateTo = null,
                string GameSegment = null,
                string Location = null,
                string Outcome = null,
                string PORound = null,
                string SeasonSegment = null,
                string ShotClockRange = null,
                string VsConference = null,
                string VsDivision = null
               )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            TeamDashboardByTeamPerformance(parameters);
        }

        public static void TeamDashboardByTeamPerformance(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teamdashboardbyteamperformance/", "teamdashboardbyteamperformance", parameters);
        }

        public static void TeamDashboardByYearOverYear(
                string TeamID,
                string LeagueID = null,
                string Season = null,
                string SeasonType = "Regular Season",
                string MeasureType = "Base",
                string PerMode = "Totals",
                string LastNGames = "0",
                string Month = "0",
                string OpponentTeamID = "0",
                string PaceAdjust = "N",
                string Period = "0",
                string PlusMinus = "N",
                string Rank = "N",
                string DateFrom = null,
                string DateTo = null,
                string GameSegment = null,
                string Location = null,
                string Outcome = null,
                string PORound = null,
                string SeasonSegment = null,
                string ShotClockRange = null,
                string VsConference = null,
                string VsDivision = null
               )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            TeamDashboardByYearOverYear(parameters);
        }

        public static void TeamDashboardByYearOverYear(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teamdashboardbyyearoveryear/", "teamdashboardbyyearoveryear", parameters);
        }

        public static void TeamDetails()
        {

        }

        public static void TeamGameLog(int teamID, string season, string seasonType)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", teamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Season", season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", seasonType, ParameterType.String));

            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teamgamelog/", "teamgamelog", parameters);
        }

        public static void TeamInfoCommon(int teamID, string season, string seasonType, string leagueID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", teamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Season", season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", seasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("LeagueID", leagueID, ParameterType.String));

            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teaminfocommon/", "teaminfocommon", parameters);
        }

        public static void TeamPlayerDashboar()
        {

        }

        public static void TeamPlayerOnOffDetails()
        {

        }

        public static void TeamPlayerOnOffSummary()
        {

        }
        public static void TeamYearByYearStats(string leagueID, string seasonType, string perMode, int teamID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", leagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", seasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", perMode, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", teamID, ParameterType.Int));
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teamyearbyyearstats/", "teamyearbyyearstats", parameters);
        }

        public static List<KeyValuePair<int, string>> Teams { get { return _Teams(); } }
            

        private static List<KeyValuePair<int, string>> _Teams()
        {
            List<KeyValuePair<int, string>> teams = new List<KeyValuePair<int, string>>();
            teams.Add(KeyValuePair.Create(1610612737, "Atlanta Hawks"));
            teams.Add(KeyValuePair.Create(1610612738, "Boston Celtics"));
            teams.Add(KeyValuePair.Create(1610612751, "Brooklyn Nets"));
            teams.Add(KeyValuePair.Create(1610612766, "Charlotte Hornets"));
            teams.Add(KeyValuePair.Create(1610612741, "Chicago Bulls"));
            teams.Add(KeyValuePair.Create(1610612739, "Cleveland Cavaliers"));
            teams.Add(KeyValuePair.Create(1610612742, "Dallas Mavericks"));
            teams.Add(KeyValuePair.Create(1610612743, "Denver Nuggets"));
            teams.Add(KeyValuePair.Create(1610612765, "Detroit Pistons"));
            teams.Add(KeyValuePair.Create(1610612744, "Golden State Warriors"));
            teams.Add(KeyValuePair.Create(1610612745, "Houston Rockets"));
            teams.Add(KeyValuePair.Create(1610612754, "Indiana Pacers"));
            teams.Add(KeyValuePair.Create(1610612746, "Los Angeles Clippers"));
            teams.Add(KeyValuePair.Create(1610612747, "Los Angeles Lakers"));
            teams.Add(KeyValuePair.Create(1610612763, "Memphis Grizzlies"));
            teams.Add(KeyValuePair.Create(1610612748, "Miami Heat"));
            teams.Add(KeyValuePair.Create(1610612749, "Milwaukee Bucks"));
            teams.Add(KeyValuePair.Create(1610612750, "Minnesota Timberwolves"));
            teams.Add(KeyValuePair.Create(1610612740, "New Orleans Pelicans"));
            teams.Add(KeyValuePair.Create(1610612752, "New York Knicks"));
            teams.Add(KeyValuePair.Create(1610612760, "Oklahoma City Thunder"));
            teams.Add(KeyValuePair.Create(1610612753, "Orlando Magic"));
            teams.Add(KeyValuePair.Create(1610612755, "Philadelphia 76ers"));
            teams.Add(KeyValuePair.Create(1610612756, "Phoenix Suns"));
            teams.Add(KeyValuePair.Create(1610612757, "Portland Trail Blazers"));
            teams.Add(KeyValuePair.Create(1610612758, "Sacramento Kings"));
            teams.Add(KeyValuePair.Create(1610612759, "San Antonio Spurs"));
            teams.Add(KeyValuePair.Create(1610612761, "Toronto Raptors"));
            teams.Add(KeyValuePair.Create(1610612762, "Utah Jazz"));
            teams.Add(KeyValuePair.Create(1610612764, "Washington Wizards"));
            return teams;
        }
    }
}
