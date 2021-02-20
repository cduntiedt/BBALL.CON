using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;

namespace BBALL.LIB.Services
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

        public static void VideoDetailAsset(
            string PlayerID,
            string Season,
            string SeasonType = "Regular Season",
            string ContextMeasure = "FGA",
            string ContextFilter = null, 
            string AheadBehind = null,
            string ClutchTime = null,
            string DateFrom = null,
            string DateTo = null,
            string EndPeriod = "0",
            string EndRange = "28800",
            string GameID = null,
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

            VideoDetailAsset(parameters);
        }

        //https://stats.nba.com/stats/videodetailsasset?AheadBehind=&CFID=&CFPARAMS=&ClutchTime=&Conference=&ContextFilter=&ContextMeasure=FGA&DateFrom=&DateTo=&Division=&EndPeriod=0&EndRange=28800&GROUP_ID=&GameEventID=&GameID=0022000092&GameSegment=&GroupID=&GroupMode=&GroupQuantity=5&LastNGames=0&LeagueID=00&Location=&Month=0&OnOff=&OpponentTeamID=0&Outcome=&PORound=0&Period=0&PlayerID=201939&PlayerID1=&PlayerID2=&PlayerID3=&PlayerID4=&PlayerID5=&PlayerPosition=&PointDiff=&Position=&RangeType=0&RookieYear=&Season=2020-21&SeasonSegment=&SeasonType=Regular+Season&ShotClockRange=&StartPeriod=0&StartRange=0&StarterBench=&TeamID=1610612744&VsConference=&VsDivision=&VsPlayerID1=&VsPlayerID2=&VsPlayerID3=&VsPlayerID4=&VsPlayerID5=&VsTeamID=
        public static void VideoDetailAsset(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/videodetailsasset/", "videodetailasset", parameters);
        }
    }
}
