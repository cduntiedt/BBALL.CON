using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.LIB.Helpers;
using BBALL.LIB.Models;
using static BBALL.LIB.Helpers.ParameterHelper;

namespace BBALL.LIB.Services
{
    public static class _OLDLeagueService
    {
        public static void LeagueDashLineups(string leagueID, string season, string seasonType, string perMode, string measureType)
        {
            JArray parameters = ConvertBaseParametersToArray(leagueID, season, seasonType, perMode, measureType);
            LeagueDashLineups(parameters);
        }

        public static void LeagueDashLineups(
            string leagueID,
            string season,
            string seasonType,
            string perMode,
            string measureType,
            string conference = null,
            string dateFrom = null,
            string dateTo = null,
            string division = null,
            string gameSegment = null,
            int groupQuantity = 5,
            int lastNGames = 0,
            string location = null,
            int minutesMin = 25,
            int month = 0,
            int opponentTeamID = 0,
            string outcome = null,
            int poRound = 0,
            string paceAdjust = "N",
            int period = 0,
            string plusMinus = "N",
            string rank = "N",
            string seasonSegment = null,
            string shotClockRange = null,
            int teamID = 0,
            string vsConference = null,
            string vsDivision = null)
        {
            JArray parameters = CreateParameterArray(leagueID,
                                                season,
                                                seasonType,
                                                perMode,
                                                measureType,
                                                conference,
                                                dateFrom,
                                                dateTo,
                                                division,
                                                gameSegment,
                                                lastNGames,
                                                opponentTeamID,
                                                outcome,
                                                poRound,
                                                paceAdjust,
                                                period,
                                                plusMinus,
                                                rank,
                                                seasonSegment,
                                                shotClockRange,
                                                teamID,
                                                vsConference,
                                                vsDivision);
            parameters.Add(CreateParameterObject("GroupQuantity", groupQuantity, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", location, ParameterType.String));
            parameters.Add(CreateParameterObject("MinutesMin", minutesMin, ParameterType.Int));
            parameters.Add(CreateParameterObject("Month", month, ParameterType.Int));
            
            LeagueDashLineups(parameters);
        }

        public static void LeagueDashLineups(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashlineups/", "leaguedashlineups", parameters);
        }

        public static void LeagueDashPlayerBioStats(string leagueID, string perMode, string season, string seasonType)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", leagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", perMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", seasonType, ParameterType.String));
            LeagueDashPlayerBioStats(parameters);
        }

        public static void LeagueDashPlayerBioStats(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayerbiostats/", "leaguedashplayerbiostats", parameters);
        }

        public static void LeagueDashPlayerClutch(string leagueID, string season, string seasonType, string perMode, string measureType)
        {
            JArray parameters = ConvertBaseParametersToArray(leagueID, season, seasonType, perMode, measureType);
            LeagueDashPlayerClutch(parameters);
        }

        public static void LeagueDashPlayerClutch(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayerclutch/", "leaguedashplayerclutch", parameters);
        }

        public static void LeagueDashPlayerPTShot(string leagueID, string perMode, string season, string seasonType)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", leagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", perMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", seasonType, ParameterType.String));
            LeagueDashPlayerPTShot(parameters);
        }

        public static void LeagueDashPlayerPTShot(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayerptshot/", "leaguedashplayerptshot", parameters);
        }

        public static void LeagueDashPlayerShotLocations()
        {

        }

        public static void LeagueDashPlayerShotLocations(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashplayershotlocations/", "leaguedashplayershotlocations", parameters);
        }

        public static void LeagueDashPTDefend(string leagueID, string perMode, string season, string seasonType)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", leagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", perMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", seasonType, ParameterType.String));
            LeagueDashPTDefend(parameters);
        }

        public static void LeagueDashPTDefend(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashptdefend/", "leaguedashptdefend", parameters);
        }

        public static void LeagueDashPTTeamDefend(string leagueID, string perMode, string season, string seasonType)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", leagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", perMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", seasonType, ParameterType.String));
            LeagueDashPTTeamDefend(parameters);
        }

        public static void LeagueDashPTTeamDefend(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashptteamdefend/", "leaguedashptteamdefend", parameters);
        }

        public static void LeagueDashTeamClutch(string leagueID,
            string season,
            string seasonType,
            string perMode,
            string measureType,
            string aheadBehind = "Ahead or Behind",
            string clutchTime = "Last 5 Minutes",
            string conference = null,
            string dateFrom = null,
            string dateTo = null,
            string division = null,
            string gameScope = null,
            string gameSegment = null,
            int lastNGames = 0,
            string location = null,
            int month = 0,
            int opponentTeamID = 0,
            string outcome = null,
            int poRound = 0,
            string paceAdjust = "N",
            int period = 0,
            string playerExperience = null,
            string playerPosition = null,
            string plusMinus = "N",
            int pointDiff = 5,
            string rank = "N",
            string seasonSegment = null,
            string shotClockRange = null,
            string starterBench = null,
            int teamID = 0,
            string vsConference = null,
            string vsDivision = null)
        {
            JArray parameters = CreateParameterArray(leagueID,
                                                season,
                                                seasonType,
                                                perMode,
                                                measureType,
                                                conference,
                                                dateFrom,
                                                dateTo,
                                                division,
                                                gameSegment,
                                                lastNGames,
                                                opponentTeamID,
                                                outcome,
                                                poRound,
                                                paceAdjust,
                                                period,
                                                plusMinus,
                                                rank,
                                                seasonSegment,
                                                shotClockRange,
                                                teamID,
                                                vsConference,
                                                vsDivision);
            parameters.Add(CreateParameterObject("AheadBehind", aheadBehind, ParameterType.String));
            parameters.Add(CreateParameterObject("ClutchTime", clutchTime, ParameterType.String));
            parameters.Add(CreateParameterObject("GameScope", gameScope, ParameterType.String));
            parameters.Add(CreateParameterObject("Location", location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", month, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlayerExperience", playerExperience, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerPosition", playerPosition, ParameterType.String));
            parameters.Add(CreateParameterObject("PointDiff", pointDiff, ParameterType.Int));
            parameters.Add(CreateParameterObject("StarterBench", starterBench, ParameterType.String));

            LeagueDashTeamClutch(parameters);
        }

        public static void LeagueDashTeamClutch(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashteamclutch/", "leaguedashteamclutch", parameters);
        }

        public static void LeagueDashTeamPTShot(string leagueID, string perMode, string season, string seasonType)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", leagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", perMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", seasonType, ParameterType.String));

            LeagueDashTeamPTShot(parameters);
        }

        public static void LeagueDashTeamPTShot(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashteamptshot/", "leaguedashteamptshot", parameters);
        }

        public static void LeagueDashTeamShotLocations()
        {

        }

        public static void LeagueDashTeamStats(string leagueID,
            string season,
            string seasonType,
            string perMode,
            string measureType,
            string conference = null,
            string dateFrom = null,
            string dateTo = null,
            string division = null,
            string gameScope = null,
            string gameSegment = null,
            int lastNGames = 0,
            string location = null,
            int month = 0,
            int opponentTeamID = 0,
            string outcome = null,
            int poRound = 0,
            string paceAdjust = "N",
            int period = 0,
            string playerExperience = null,
            string playerPosition = null,
            string plusMinus = "N",
            string rank = "N",
            string seasonSegment = null,
            string shotClockRange = null,
            string starterBench = null,
            int teamID = 0,
            int twoWay = 0,
            string vsConference = null,
            string vsDivision = null)
        {
            JArray parameters = CreateParameterArray(leagueID,
                                                season,
                                                seasonType,
                                                perMode,
                                                measureType,
                                                conference,
                                                dateFrom,
                                                dateTo,
                                                division,
                                                gameSegment,
                                                lastNGames,
                                                opponentTeamID,
                                                outcome,
                                                poRound,
                                                paceAdjust,
                                                period,
                                                plusMinus,
                                                rank,
                                                seasonSegment,
                                                shotClockRange,
                                                teamID,
                                                vsConference,
                                                vsDivision);
            parameters.Add(CreateParameterObject("GameScope", gameScope, ParameterType.String));
            parameters.Add(CreateParameterObject("Location", location, ParameterType.String));
            parameters.Add(CreateParameterObject("Month", month, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlayerExperience", playerExperience, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerPosition", playerPosition, ParameterType.String));
            parameters.Add(CreateParameterObject("StarterBench", starterBench, ParameterType.String));
            parameters.Add(CreateParameterObject("TwoWay", twoWay, ParameterType.Int));

            LeagueDashTeamStats(parameters);
        }

        public static void LeagueDashTeamStats(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguedashteamstats/", "leaguedashteamstats", parameters);
        }

       

        public static void LeagueLineupsViz(
            string leagueID,
            string season,
            string seasonType,
            string perMode,
            string measureType,
            string conference = null, 
            string dateFrom = null, 
            string dateTo = null, 
            string division = null, 
            string gameSegment = null, 
            int groupQuantity = 5, 
            int lastNGames = 0, 
            string location = null, 
            int minutesMin = 25, 
            int month = 0, 
            int opponentTeamID = 0,
            string outcome = null,
            int poRound = 0,
            string paceAdjust = "N",
            int period = 0,
            string plusMinus = "N",
            string rank = "N",
            string seasonSegment = null,
            string shotClockRange = null,
            int teamID = 0,
            string vsConference = null,
            string vsDivision = null)
        {
            JArray parameters = CreateParameterArray(leagueID,
                                                season,
                                                seasonType,
                                                perMode,
                                                measureType,
                                                conference,
                                                dateFrom,
                                                dateTo,
                                                division,
                                                gameSegment,
                                                lastNGames,
                                                opponentTeamID,
                                                outcome,
                                                poRound,
                                                paceAdjust,
                                                period,
                                                plusMinus,
                                                rank,
                                                seasonSegment,
                                                shotClockRange,
                                                teamID,
                                                vsConference,
                                                vsDivision);
            parameters.Add(CreateParameterObject("GroupQuantity", groupQuantity, ParameterType.Int));
            parameters.Add(CreateParameterObject("Location", location, ParameterType.String));
            parameters.Add(CreateParameterObject("MinutesMin", minutesMin, ParameterType.Int));
            parameters.Add(CreateParameterObject("Month", month, ParameterType.Int));

            LeagueLineupsViz(parameters);
        }

        public static void LeagueLineupsViz(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguelineupviz/", "leaguelineupviz", parameters);
        }

        public static void LeagueStandings(string leagueID, string seasonType, string seasonYear)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", leagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", seasonYear, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", seasonType, ParameterType.String));
            LeagueStandings(parameters);
        }

        public static void LeagueStandings(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leaguestandings/", "leaguestandings", parameters);
        }
    }
}
