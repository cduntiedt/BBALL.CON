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

          int PlayerID,
          string LeagueID,
          string Season,
          string ContextFilter, //"SEASON_YEAR='2020-21'"
          string ContextMeasure = "FGA",
          string SeasonType = "Regular Season",
          string AheadBehind = null,
          string ClutchTime = null,
          string DateFrom = null,
          string DateTo = null,
          int EndPeriod = 10,
          int EndRange = 28800,
          string GameID = null,
          string GameSegment = null,
          int LastNGames = 0,
          string Location = null,
          int Month = 0,
          int OpponentTeamID = 0,
          string Outcome = null,
          int Period = 0,
          string PointDiff = null,
          string Position = null,
          int RangeType = 0,
          string RookieYear = "N",
          string SeasonSegment = null,
          int StartPeriod = 1,
          int StartRange = 0,
          int TeamID = 0,
          string VsConference = null,
          string VsDivision = null
          )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID, ParameterType.Int));
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("ContextFilter", ContextFilter, ParameterType.String));
            parameters.Add(CreateParameterObject("ContextMeasure", ContextMeasure, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("AheadBehind", AheadBehind, ParameterType.String));
            parameters.Add(CreateParameterObject("ClutchTime", ClutchTime, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod, ParameterType.Int));
            parameters.Add(CreateParameterObject("EndRange", EndRange, ParameterType.Int));
            parameters.Add(CreateParameterObject("GameID", GameID, ParameterType.String));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", Month, ParameterType.Int));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("Period", Period, ParameterType.Int));
            parameters.Add(CreateParameterObject("PointDiff", PointDiff, ParameterType.String));
            parameters.Add(CreateParameterObject("Position", Position, ParameterType.String));
            parameters.Add(CreateParameterObject("RangeType", RangeType, ParameterType.Int));
            parameters.Add(CreateParameterObject("RookieYear", RookieYear, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod, ParameterType.Int));
            parameters.Add(CreateParameterObject("StartRange", StartRange, ParameterType.Int));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));

            VideoDetails(parameters);
        }

        public static void VideoDetails(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/videodetails/", "videodetails", parameters);
        }
    }
}
