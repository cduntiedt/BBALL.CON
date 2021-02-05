using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.CON.Helpers;
using static BBALL.CON.Helpers.ParameterHelper;

namespace BBALL.CON.Services
{
    public static class VideoService
    {
        public static void VideoDetails(
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

            VideoDetails(parameters);
        }

        public static void VideoDetails(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/videodetails/", "videodetails", parameters);
        }

        public static void VideoEvents(
            string GameEventID,
            string GameID
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("GameEventID", GameEventID));
            VideoEvents(parameters);
        }

        public static void VideoEvents(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/videoevents/", "videoevents", parameters);
        }

        public static void VideoStatus(
            string GameDate,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameDate", GameDate));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            VideoStatus(parameters);
        }

        public static void VideoStatus(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/videostatus/", "videostatus", parameters);
        }
    }
}
