﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace BBALL.LIB.Services
{
    public static class VideoService
    {
        public static async Task<BsonDocument> VideoDetails(
          string PlayerID,
          string LeagueID,
          string Season,
          string ContextFilter, //"SEASON_YEAR='2020-21'"
          string ContextMeasure = "FGA",
          string SeasonType = "Regular Season",
          string AheadBehind = null,
          string ClutchTime = null,
          string DateFrom = null,
          string DateTo = null,
          string EndPeriod = "10",
          string EndRange = "28800",
          string GameID = null,
          string GameSegment = null,
          string LastNGames = "0",
          string Location = null,
          string Month = "0",
          string OpponentTeamID = "0",
          string Outcome = null,
          string Period = "0",
          string PointDiff = null,
          string Position = null,
          string RangeType = "0",
          string RookieYear = "N",
          string SeasonSegment = null,
          string StartPeriod = "1",
          string StartRange = "0",
          string TeamID = "0",
          string VsConference = null,
          string VsDivision = null
          )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("ContextFilter", ContextFilter));
            parameters.Add(CreateParameterObject("ContextMeasure", ContextMeasure));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("AheadBehind", AheadBehind));
            parameters.Add(CreateParameterObject("ClutchTime", ClutchTime));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            parameters.Add(CreateParameterObject("EndRange", EndRange));
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PointDiff", PointDiff));
            parameters.Add(CreateParameterObject("Position", Position));
            parameters.Add(CreateParameterObject("RangeType", RangeType));
            parameters.Add(CreateParameterObject("RookieYear", RookieYear));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("StartRange", StartRange));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            return await VideoDetails(parameters);
        }

        public static async Task<BsonDocument> VideoDetails(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/videodetails/", "videodetails", parameters);
        }

        public static async Task<BsonDocument> VideoEvents(
            string GameEventID,
            string GameID
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("GameEventID", GameEventID));
            return await VideoEvents(parameters);
        }

        public static async Task<BsonDocument> VideoEvents(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/videoevents/", "videoevents", parameters);
        }

        public static async Task<BsonDocument> VideoStatus(
            string GameDate,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameDate", GameDate));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            return await VideoStatus(parameters);
        }

        public static async Task<BsonDocument> VideoStatus(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/videostatus/", "videostatus", parameters);
        }

        public static async Task<BsonDocument> VideoDetailAsset(
            string GameID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string ContextMeasure = "FGA",
            string PlayerID = "0",
            string ContextFilter = null, 
            string AheadBehind = null,
            string ClutchTime = null,
            string DateFrom = null,
            string DateTo = null,
            string EndPeriod = "0",
            string EndRange = "28800",
            string GameSegment = null,
            string LastNGames = "0",
            string LeagueID = null,
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string Period = "0",
            string PointDiff = null,
            string Position = null,
            string RangeType = "0",
            string RookieYear = null,
            string SeasonSegment = null,
            string StartPeriod = "0",
            string StartRange = "0",
            string TeamID = "0",
            string VsConference = null,
            string VsDivision = null
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("ContextFilter", ContextFilter));
            parameters.Add(CreateParameterObject("ContextMeasure", ContextMeasure));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("AheadBehind", AheadBehind));
            parameters.Add(CreateParameterObject("ClutchTime", ClutchTime));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            parameters.Add(CreateParameterObject("EndRange", EndRange));
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PointDiff", PointDiff));
            parameters.Add(CreateParameterObject("Position", Position));
            parameters.Add(CreateParameterObject("RangeType", RangeType));
            parameters.Add(CreateParameterObject("RookieYear", RookieYear));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("StartRange", StartRange));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));

            return await VideoDetailAsset(parameters);
        }

        public static async Task<BsonDocument> VideoDetailAsset(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/videodetailsasset/", "videodetailsasset", parameters, false, 30);
        }
    }
}
