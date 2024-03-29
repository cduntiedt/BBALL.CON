﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using System.Linq;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace BBALL.LIB.Services
{
    public static class TeamService
    {
        /// <summary>
        /// Get a list of team IDs
        /// </summary>
        /// <returns>A list of integer</returns>
        public static List<string> GetTeamIDs()
        {
            JArray defaultParameters = new JArray();
            defaultParameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(null)));
            JObject teamsCollection = DatabaseHelper.GetJSONDocument("commonteamyears", defaultParameters);
            JArray teamsResultSets = teamsCollection["resultSets"].ToObject<JArray>();

            JObject teamYears = teamsResultSets[0].ToObject<JObject>();

            JArray teamData = teamsResultSets[0]["data"].ToObject<JArray>();
            var teams = teamData.Select(x => (string)x["TEAM_ID"]).Distinct().ToList();

            return teams;
        }

        public static async Task<BsonDocument> CommonTeamYears(string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            return await CommonTeamYears(parameters);
        }

        public static async Task<BsonDocument> CommonTeamYears(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/commonteamyears/", "commonteamyears", parameters);
        }

        public static async Task<BsonDocument> FranchiseHistory(string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            return await FranchiseHistory(parameters);
        }

        public static async Task<BsonDocument> FranchiseHistory(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/franchisehistory/", "franchisehistory", parameters);
        }

        /// <summary>
        /// Repeated on the CommonService
        /// </summary>
        /// <param name="TeamID">The team ID.</param>
        /// <param name="Season">The season years.</param>
        /// <returns>A document with team roster info.</returns>
        public static async Task<BsonDocument> CommonTeamRoster(string TeamID = null, string Season = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            return await CommonTeamRoster(parameters);
        }

        public static async Task<BsonDocument> CommonTeamRoster(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/commonteamroster/", "commonteamroster", parameters);
        }

        public static async Task<BsonDocument> TeamAndPlayersVsPlayers(
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
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string PerMode = "Totals",
            string Season = null,
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
            string VsDivision = null,
            string LeagueID = null
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

            return await TeamAndPlayersVsPlayers(parameters);
        }

        public static async Task<BsonDocument> TeamAndPlayersVsPlayers(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamandplayersvsplayers/", "teamandplayersvsplayers", parameters);
        }

        public static async Task<BsonDocument> TeamDashLineups(
            string TeamID,
            string Season = null,
            string MeasureType = "Base",
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
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
            string VsDivision = null,
            string LeagueID = null
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

            return await TeamDashLineups(parameters);
        }

        public static async Task<BsonDocument> TeamDashLineups(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamdashlineups/", "teamdashlineups", parameters);
        }

        public static async Task<BsonDocument> TeamDashPtPass(
            string TeamID,
            string Season = null,
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
            string LastNGames = "0",
            string Month = "0",
            string OpponentTeamID = "0",
            string DateFrom = null,
            string DateTo = null,
            string Location = null,
            string Outcome = null,
            string SeasonSegment = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
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

            return await TeamDashPtPass(parameters);
        }

        public static async Task<BsonDocument> TeamDashPtPass(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamdashptpass/", "teamdashptpass", parameters);
        }

        public static async Task<BsonDocument> TeamDashPtReb(
           string TeamID,
           string Season = null,
           string PerMode = "Totals",
           string SeasonType = "Regular Season",
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
           string VsDivision = null,
           string LeagueID = null
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

            return await TeamDashPtReb(parameters);
        }

        public static async Task<BsonDocument> TeamDashPtReb(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamdashptreb/", "teamdashptreb", parameters);
        }

        public static async Task<BsonDocument> TeamDashPtShots(
           string TeamID,
           string Season = null,
           string PerMode = "Totals",
           string SeasonType = "Regular Season",
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
           string VsDivision = null,
           string LeagueID = null
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

            return await TeamDashPtShots(parameters);
        }

        public static async Task<BsonDocument> TeamDashPtShots(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamdashptshots/", "teamdashptshots", parameters);
        }

        public static async Task<BsonDocument> TeamDashboardByClutch(
            string TeamID,
            string Season = null,
            string MeasureType = "Base",
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
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
            string VsDivision = null,
           string LeagueID = null
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

            return await TeamDashboardByClutch(parameters);
        }

        public static async Task<BsonDocument> TeamDashboardByClutch(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamdashboardbyclutch/", "teamdashboardbyclutch", parameters);
        }

        public static async Task<BsonDocument> TeamDashboardByGameSplits(
              string TeamID,
              string Season = null,
              string MeasureType = "Base",
              string PerMode = "Totals",
              string SeasonType = "Regular Season",
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
              string VsDivision = null,
           string LeagueID = null
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

            return await TeamDashboardByGameSplits(parameters);
        }

        public static async Task<BsonDocument> TeamDashboardByGameSplits(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamdashboardbygamesplits/", "teamdashboardbygamesplits", parameters);
        }

        public static async Task<BsonDocument> TeamDashboardByGeneralSplits(
              string TeamID,
              string Season = null,
              string MeasureType = "Base",
              string PerMode = "Totals",
              string SeasonType = "Regular Season",
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
              string VsDivision = null,
           string LeagueID = null
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

            return await TeamDashboardByGeneralSplits(parameters);
        }

        public static async Task<BsonDocument> TeamDashboardByGeneralSplits(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamdashboardbygeneralsplits/", "teamdashboardbygeneralsplits", parameters);
        }

        public static async Task<BsonDocument> TeamDashboardByLastNGames(
             string TeamID,
             string Season = null,
             string MeasureType = "Base",
             string PerMode = "Totals",
             string SeasonType = "Regular Season",
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
             string VsDivision = null,
           string LeagueID = null
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

            return await TeamDashboardByLastNGames(parameters);
        }

        public static async Task<BsonDocument> TeamDashboardByLastNGames(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamdashboardbylastngames/", "teamdashboardbylastngames", parameters);
        }

        public static async Task<BsonDocument> TeamDashboardByOpponent(
            string TeamID,
            string Season = null,
            string MeasureType = "Base",
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
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
            string VsDivision = null,
           string LeagueID = null
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

            return await TeamDashboardByOpponent(parameters);
        }

        public static async Task<BsonDocument> TeamDashboardByOpponent(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamdashboardbyopponent/", "teamdashboardbyopponent", parameters);
        }

        public static async Task<BsonDocument> TeamDashboardByShootingSplits(
            string TeamID,
            string Season = null,
            string MeasureType = "Base",
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
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
            string VsDivision = null,
           string LeagueID = null
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

            return await TeamDashboardByShootingSplits(parameters);
        }

        public static async Task<BsonDocument> TeamDashboardByShootingSplits(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamdashboardbyshootingsplits/", "teamdashboardbyshootingsplits", parameters);
        }

        public static async Task<BsonDocument> TeamDashboardByTeamPerformance(
                string TeamID,
                string Season = null,
                string MeasureType = "Base",
                string PerMode = "Totals",
                string SeasonType = "Regular Season",
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
                string VsDivision = null,
           string LeagueID = null
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

            return await TeamDashboardByTeamPerformance(parameters);
        }

        public static async Task<BsonDocument> TeamDashboardByTeamPerformance(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamdashboardbyteamperformance/", "teamdashboardbyteamperformance", parameters);
        }

        public static async Task<BsonDocument> TeamDashboardByYearOverYear(
                string TeamID,
                string Season = null,
                string MeasureType = "Base",
                string PerMode = "Totals",
                string SeasonType = "Regular Season",
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
                string VsDivision = null,
           string LeagueID = null
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

            return await TeamDashboardByYearOverYear(parameters);
        }

        public static async Task<BsonDocument> TeamDashboardByYearOverYear(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamdashboardbyyearoveryear/", "teamdashboardbyyearoveryear", parameters);
        }

        public static async Task<BsonDocument> TeamDetails(string TeamID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            return await TeamDetails(parameters);
        }

        public static async Task<BsonDocument> TeamDetails(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamdetails/", "teamdetails", parameters);
        }

        public static async Task<BsonDocument> TeamEstimatedMetrics(
            string Season = null,
            string SeasonType = "Regular Season",
           string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            return await TeamEstimatedMetrics(parameters);
        }

        public static async Task<BsonDocument> TeamEstimatedMetrics(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamestimatedmetrics/", "teamestimatedmetrics", parameters, true, 15, "resultSet");
        }

        public static async Task<BsonDocument> TeamGameLog(
            string TeamID, 
            string Season = null,
            string SeasonType = "Regular Season",
            string DateTo = null,
            string DateFrom = null,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            return await TeamGameLog(parameters);
        }

        public static async Task<BsonDocument> TeamGameLog(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamgamelog/", "teamgamelog", parameters);
        }

        public static async Task<BsonDocument> TeamGameLogs(
            string TeamID = null,
            string Season = null,
            string MeasureType = null,
            string PerMode = null,
            string SeasonType = null,
            string LastNGames = null,
            string Month = null,
            string OppTeamID = null,
            string Period = null,
            string PlayerID = null,
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string Location = null,
            string Outcome = null,
            string PORound = null,
            string SeasonSegment = null,
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
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
            parameters.Add(CreateParameterObject("OppTeamID", OppTeamID));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
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

            return await TeamGameLogs(parameters);
        }

        public static async Task<BsonDocument> TeamGameLogs(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamgamelogs/", "teamgamelogs", parameters);
        }

        public static async Task<BsonDocument> TeamHistoricalLeaders(
            string TeamID,
            string Season = null,
            string LeagueID = null
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));

            //team historical leaders uses a custom season id and not the actual season year (Ex: 22020)
            string seasonYear = SeasonHelper.DefaultSeason(Season).Substring(0,4);
            string seasonID = "2" + seasonYear;
            parameters.Add(CreateParameterObject("SeasonID", seasonID));
            return await TeamHistoricalLeaders(parameters);
        }

        public static async Task<BsonDocument> TeamHistoricalLeaders(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamhistoricalleaders/", "teamhistoricalleaders", parameters);
        }

        public static async Task<BsonDocument> TeamInfoCommon(
            string TeamID,
            string Season = null,
            string SeasonType = "Regular Season",
            string LeagueID = null
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));

            return await TeamInfoCommon(parameters);
        }

        public static async Task<BsonDocument> TeamInfoCommon(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teaminfocommon/", "teaminfocommon", parameters);
        }

        public static async Task<BsonDocument> TeamPlayerDashboard(
           string TeamID,
           string Season = null,
           string MeasureType = "Base",
           string PerMode = "Totals",
           string SeasonType = "Regular Season",
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
           string VsDivision = null,
           string LeagueID = null
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

            return await TeamPlayerDashboard(parameters);
        }

        public static async Task<BsonDocument> TeamPlayerDashboard(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamplayerdashboard/", "teamplayerdashboard", parameters);
        }

        public static async Task<BsonDocument> TeamPlayerOnOffDetails(
           string TeamID,
           string Season = null,
           string MeasureType = "Base",
           string PerMode = "Totals",
           string SeasonType = "Regular Season",
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
           string VsConference = null,
           string VsDivision = null,
           string LeagueID = null
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
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            return await TeamPlayerOnOffDetails(parameters);
        }

        public static async Task<BsonDocument> TeamPlayerOnOffDetails(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamplayeronoffdetails/", "teamplayeronoffdetails", parameters);
        }

        public static async Task<BsonDocument> TeamPlayerOnOffSummary(
           string TeamID,
           string Season = null,
           string MeasureType = "Base",
           string PerMode = "Totals",
           string SeasonType = "Regular Season",
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
           string VsConference = null,
           string VsDivision = null,
           string LeagueID = null
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
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            return await TeamPlayerOnOffSummary(parameters);
        }

        public static async Task<BsonDocument> TeamPlayerOnOffSummary(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamplayeronoffsummary/", "teamplayeronoffsummary", parameters);
        }

        public static async Task<BsonDocument> TeamVsPlayer(
          string TeamID,
          string VsPlayerID,
          string Season = null,
          string MeasureType = "Base",
          string PerMode = "Totals",
          string SeasonType = "Regular Season",
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
          string PlayerID = null,
          string PORound = null,
          string SeasonSegment = null,
          string VsConference = null,
          string VsDivision = null,
          string LeagueID = null
         )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsPlayerID", VsPlayerID));
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
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            return await TeamVsPlayer(parameters);
        }

        public static async Task<BsonDocument> TeamVsPlayer(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamvsplayer/", "teamvsplayer", parameters);
        }

        public static async Task<BsonDocument> TeamYearByYearStats(
            string TeamID,
            string SeasonType = "Regular Season", 
            string PerMode = "Totals",
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            return await TeamYearByYearStats(parameters);
        }

        public static async Task<BsonDocument> TeamYearByYearStats(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/teamyearbyyearstats/", "teamyearbyyearstats", parameters);
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
