using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;
using MongoDB.Bson;

namespace BBALL.LIB.Services
{
    public static class PlayerService
    {
        public static void ImportPlayers(List<string> seasons)
        {
            try
            {
                foreach (var season in seasons)
                {
                    var commonDocument = CommonService.CommonAllPlayers(season);

                    var players = (BsonArray)commonDocument["resultSets"][0]["data"];
                    if (!players.IsBsonNull)
                    {
                        foreach (var player in players)
                        {
                            //BsonDocument playerDocument = new BsonDocument();
                            //playerDocument.Add("PlayerID", player["PlayerID"].ToString());
                            Console.WriteLine(player);
                            CommonService.CommonPlayerInfo(player["PlayerID"].ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Player > Career
        public static BsonDocument PlayerAwards(string PlayerID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            return PlayerAwards(parameters);
        }

        public static BsonDocument PlayerAwards(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerawards/", "playerawards", parameters);
        }

        public static BsonDocument PlayerCareerByCollege(
           string Season = null,
           string SeasonType = "Regular Season",
           string PerMode = null,
           string College = null,
           string LeagueID = null
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("College", College));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));

            return PlayerCareerByCollege(parameters);
        }

        public static BsonDocument PlayerCareerByCollege(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playercareerbycollege/", "playercareerbycollege", parameters);
        }

        public static BsonDocument PlayerCareerByCollegeRollup(
           string Season = null,
           string SeasonType = "Regular Season",
           string PerMode = null,
           string LeagueID = null
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));

            return PlayerCareerByCollegeRollup(parameters);
        }

        public static BsonDocument PlayerCareerByCollegeRollup(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playercareerbycollegerollup/", "playercareerbycollegerollup", parameters);
        }

        //PLayer > Career
        public static BsonDocument PlayerCareerStats(
            string PlayerID,
            string PerMode = "PerGame",
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            return PlayerCareerStats(parameters);
        }

        public static BsonDocument PlayerCareerStats(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playercareerstats/", "playercareerstats", parameters);
        }

        public static BsonDocument PlayerCompare(
           string Season = null,
           string SeasonType = "Regular Season",
           string PerMode = "PerGame",
           string MeasureType = "Base",
           string LastNGames = "0",
           string Month = "0",
           string OpponentTeamID = "0",
           string PaceAdjust = "N",
           string Period = "0",
           string PlayerIDList = null,
           string PlusMinus = "N",
           string VsPlayerIDList = null,
           string VsDivision = null,
           string VsConference = null,
           string ShotClockRange = null,
           string SeasonSegment = null,
           string Outcome = null,
           string Location = null,
           string GameSegment = null,
           string Division = null,
           string DateTo = null,
           string DateFrom = null,
           string Conference = null,
           string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlayerIDList", PlayerIDList));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("VsPlayerIDList", VsPlayerIDList));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("Division", Division));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("Conference", Conference));
            return PlayerCompare(parameters);
        }

        public static BsonDocument PlayerCompare(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playercompare/", "playercompare", parameters);
        }

        public static BsonDocument PlayDashPTPass(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string Period = "0",
            string SeasonSegment = null,
            string TeamID = "0",
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
         )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
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
            return PlayDashPTPass(parameters);
        }

        public static BsonDocument PlayDashPTPass(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashptpass/", "playerdashptpass", parameters);
        }
        public static BsonDocument PlayDashPTReb(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string Period = "0",
            string SeasonSegment = null,
            string TeamID = "0",
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
          )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
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
            return PlayDashPTReb(parameters);
        }

        public static BsonDocument PlayDashPTReb(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashptreb/", "playerdashptreb", parameters);
        }

        public static BsonDocument PlayDashPTShotDefend(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string Period = "0",
            string SeasonSegment = null,
            string TeamID = "0",
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
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
            return PlayDashPTShotDefend(parameters);
        }

        public static BsonDocument PlayDashPTShotDefend(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashptshotdefend/", "playerdashptshotdefend", parameters);
        }

        public static BsonDocument PlayDashPTShots(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PORound = "0",
            string Period = "0",
            string SeasonSegment = null,
            string TeamID = "0",
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
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
            return PlayDashPTShots(parameters);
        }

        public static BsonDocument PlayDashPTShots(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashptshots/", "playerdashptshots", parameters);
        }

        public static BsonDocument PlayerDashboardByClutch(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season", 
            string PerMode = "Totals",
            string MeasureType = "Base",
            string LastNGames = "0",
            string Month = "0",
            string OpponentTeamID = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string VsDivision = null,
            string VsConference = null,
            string ShotClockRange = null,
            string SeasonSegment = null,
            string PORound = null,
            string Outcome = null,
            string Location = null,
            string GameSegment = null,
            string DateTo = null,
            string DateFrom = null,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            return PlayerDashboardByClutch(parameters);
        }

        public static BsonDocument PlayerDashboardByClutch(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashboardbyclutch/", "playerdashboardbyclutch", parameters);
        }

        public static BsonDocument PlayerDashboardByGameSplits(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string MeasureType = "Base",
            string LastNGames = "0",
            string Month = "0",
            string OpponentTeamID = "0",
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string VsDivision = null,
            string VsConference = null,
            string ShotClockRange = null,
            string SeasonSegment = null,
            string PORound = null,
            string Outcome = null,
            string Location = null,
            string GameSegment = null,
            string DateTo = null,
            string DateFrom = null,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            return PlayerDashboardByGameSplits(parameters);
        }

        public static BsonDocument PlayerDashboardByGameSplits(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashboardbygamesplits/", "playerdashboardbygamesplits", parameters);
        }

        //Player > Splits
        public static BsonDocument PlayerDashboardByGeneralSplits(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string MeasureType = "Base",
            string DateFrom = null,
            string DateTo = null,
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
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return PlayerDashboardByGeneralSplits(parameters);
        }

        public static BsonDocument PlayerDashboardByGeneralSplits(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashboardbygeneralsplits/", "playerdashboardbygeneralsplits", parameters);
        }

        public static BsonDocument PlayerDashboardByLastNGames(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string MeasureType = "Base",
            string DateFrom = null,
            string DateTo = null,
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
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return PlayerDashboardByLastNGames(parameters);
        }

        public static BsonDocument PlayerDashboardByLastNGames(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashboardbylastngames/", "playerdashboardbylastngames", parameters);
        }

        public static BsonDocument PlayerDashboardByOpponent(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string MeasureType = "Base",
            string DateFrom = null,
            string DateTo = null,
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
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return PlayerDashboardByOpponent(parameters);
        }

        public static BsonDocument PlayerDashboardByOpponent(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashboardbyopponent/", "playerdashboardbyopponent", parameters);
        }

        public static BsonDocument PlayerDashboardByShootingSplits(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string MeasureType = "Base",
            string DateFrom = null,
            string DateTo = null,
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
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return PlayerDashboardByShootingSplits(parameters);
        }

        public static BsonDocument PlayerDashboardByShootingSplits(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashboardbyshootingsplits/", "playerdashboardbyshootingsplits", parameters);
        }

        public static BsonDocument PlayerDashboardByTeamPerformance(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string MeasureType = "Base",
            string DateFrom = null,
            string DateTo = null,
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
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return PlayerDashboardByTeamPerformance(parameters);
        }

        public static BsonDocument PlayerDashboardByTeamPerformance(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashboardbyteamperformance/", "playerdashboardbyteamperformance", parameters);
        }

        //Player > Profile
        public static BsonDocument PlayerDashboardByYearOverYear(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "PerGame",
            string MeasureType = "Base",
            string DateFrom = null,
            string DateTo = null,
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
            string ShotClockRange = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return PlayerDashboardByYearOverYear(parameters);
        }

        public static BsonDocument PlayerDashboardByYearOverYear(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashboardbyyearoveryear/", "playerdashboardbyyearoveryear", parameters);
        }

        public static BsonDocument PlayerEstimatedMetrics(
           string Season = null,
           string SeasonType = "Regular Season",
           string LeagueID = null
           )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));

            return PlayerEstimatedMetrics(parameters);
        }

        public static BsonDocument PlayerEstimatedMetrics(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerestimatedmetrics/", "playerestimatedmetrics", parameters);
        }

        public static BsonDocument PlayerGameLog(
            string PlayerID,
            string Season = null, 
            string SeasonType = "Regular Season",
            string DateFrom = null,
            string DateTo = null,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            return PlayerGameLog(parameters);
        }

        public static BsonDocument PlayerGameLog(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playergamelog/", "playergamelog", parameters);
        }

        public static BsonDocument PlayerGameLogs(
            string Season = null,
            string SeasonType = null,
            string PerMode = null,
            string MeasureType = null,
            string DateFrom = null,
            string DateTo = null,
            string GameSegment = null,
            string LastNGames = null,
            string Location = null,
            string Month = null,
            string OppTeamID = null,
            string Outcome = null,
            string PORound = null,
            string Period = null,
            string PlayerID = null,
            string SeasonSegment = null,
            string ShotClockRange = null,
            string TeamID = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("GameSegment", GameSegment));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OppTeamID", OppTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PORound", PORound));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("ShotClockRange", ShotClockRange));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return PlayerGameLogs(parameters);
        }

        public static BsonDocument PlayerGameLogs(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playergamelogs/", "playergamelogs", parameters);
        }

        //Players > Player Index
        public static BsonDocument PlayerIndex(
            string Season = null,
            string Active = null,
            string AllStar = null,
            string College = null,
            string Country = null,
            string DraftPick = null,
            string DraftYear = null,
            string Height = null,
            string Historical = "1",
            string PlayerPosition = null,
            string TeamID = "0",
            string Weight = null,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("Active", Active));
            parameters.Add(CreateParameterObject("AllStar", AllStar));
            parameters.Add(CreateParameterObject("College", College));
            parameters.Add(CreateParameterObject("Country", Country));
            parameters.Add(CreateParameterObject("DraftPick", DraftPick));
            parameters.Add(CreateParameterObject("DraftYear", DraftYear));
            parameters.Add(CreateParameterObject("Height", Height));
            parameters.Add(CreateParameterObject("Historical", Historical));
            parameters.Add(CreateParameterObject("PlayerPosition", PlayerPosition));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("Weight", Weight));

            return PlayerIndex(parameters);
        }

        public static BsonDocument PlayerIndex(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerindex/", "playerindex", parameters);
        }

        public static BsonDocument PlayerNextNGames(
            string PlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string NumberOfGames = "5",
            string LeagueID = null
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("NumberOfGames", NumberOfGames));
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            return PlayerNextNGames(parameters);
        }

        public static BsonDocument PlayerNextNGames(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playernextngames/", "playernextngames", parameters);
        }

        //Player > Career
        public static BsonDocument PlayerProfileV2(
            string PlayerID,
            string PerMode = "PerGame",
            string LeagueID = null
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            return PlayerProfileV2(parameters);
        }

        public static BsonDocument PlayerProfileV2(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playerdashboardbygeneralsplits/", "playerdashboardbygeneralsplits", parameters);
        }

        public static BsonDocument PlayerVsPlayer(
            string PlayerID,
            string VsPlayerID,
            string Season = null,
            string SeasonType = "Regular Season",
            string MeasureType = "Base",
            string PerMode = "PerGame",
            string DateFrom = null,
            string DateTo = null,
            string LastNGames = "0",
            string Location = null,
            string Month = "0",
            string OpponentTeamID = "0",
            string Outcome = null,
            string PaceAdjust = "N",
            string Period = "0",
            string PlusMinus = "N",
            string Rank = "N",
            string SeasonSegment = null,
            string VsConference = null,
            string VsDivision = null,
            string LeagueID = null
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("VsPlayerID", VsPlayerID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("MeasureType", MeasureType));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DateFrom", DateFrom));
            parameters.Add(CreateParameterObject("DateTo", DateTo));
            parameters.Add(CreateParameterObject("LastNGames", LastNGames));
            parameters.Add(CreateParameterObject("Location", Location));
            parameters.Add(CreateParameterObject("Month", Month));
            parameters.Add(CreateParameterObject("OpponentTeamID", OpponentTeamID));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("PaceAdjust", PaceAdjust));
            parameters.Add(CreateParameterObject("Period", Period));
            parameters.Add(CreateParameterObject("PlusMinus", PlusMinus));
            parameters.Add(CreateParameterObject("Rank", Rank));
            parameters.Add(CreateParameterObject("SeasonSegment", SeasonSegment));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            return PlayerVsPlayer(parameters);
        }

        public static BsonDocument PlayerVsPlayer(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playervsplayer/", "playervsplayer", parameters);
        }
    }
}
