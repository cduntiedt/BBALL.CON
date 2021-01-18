using BBALL.CON.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBALL.CON.Helpers
{
    public static class ParameterHelper
    {
        public enum ParameterType
        {
            String,
            Int,
            Bool
        }

        /// <summary>
        /// Create the parameter object
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static JObject CreateParameterObject(string key, JToken value, ParameterType type)
        {
            JObject obj = new JObject();
            obj.Add("Key", key);
            obj.Add("Value", value);

            var parameterType = "";
            switch (type)
            {
                case ParameterType.Int:
                    parameterType = "int";
                    break;
                case ParameterType.Bool:
                    parameterType = "bool";
                    break;
                default:
                    parameterType = "string";
                    break;
            }

            obj.Add("Type", parameterType);

            return obj;
        }

        public static JArray CreateBaseParameterArray(
           string leagueID,
           string season,
           string seasonType,
           string perMode,
           string measureType,
           string conference,
           string dateFrom,
           string dateTo,
           string division,
           string gameSegment,
           int lastNGames,
           int opponentTeamID,
           string outcome,
           int poRound,
           string paceAdjust,
           int period,
           string plusMinus,
           string rank,
           string seasonSegment,
           string shotClockRange,
           int teamID,
           string vsConference,
           string vsDivision)
        {
            JArray parameters = new JArray();

            parameters.Add(CreateParameterObject("Conference", conference, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", dateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", dateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("Division", division, ParameterType.String));
            parameters.Add(CreateParameterObject("GameSegment", gameSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", lastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("LeagueID", leagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("MeasureType", measureType, ParameterType.String));
            parameters.Add(CreateParameterObject("OpponentTeamID", opponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", poRound, ParameterType.Int));
            parameters.Add(CreateParameterObject("PaceAdjust", paceAdjust, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", perMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Period", period, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlusMinus", plusMinus, ParameterType.String));
            parameters.Add(CreateParameterObject("Rank", rank, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonSegment", seasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", seasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("ShotClockRange", shotClockRange, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", teamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsConference", vsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", vsDivision, ParameterType.String));

            return parameters;
        }

        public static JArray ConvertBaseParametersToArray(BaseParameters baseParameters)
        {
            JArray parameters = new JArray();

            parameters.Add(CreateParameterObject("Conference", baseParameters.Conference, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", baseParameters.DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", baseParameters.DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("Division", baseParameters.Division, ParameterType.String));
            parameters.Add(CreateParameterObject("GameSegment", baseParameters.GameSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", baseParameters.LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("LeagueID", baseParameters.LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("MeasureType", baseParameters.MeasureType, ParameterType.String));
            parameters.Add(CreateParameterObject("OpponentTeamID", baseParameters.OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", baseParameters.Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", baseParameters.PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("PaceAdjust", baseParameters.PaceAdjust, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", baseParameters.PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Period", baseParameters.PerMode, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlusMinus", baseParameters.PlusMinus, ParameterType.String));
            parameters.Add(CreateParameterObject("Rank", baseParameters.Rank, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", baseParameters.Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonSegment", baseParameters.SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", baseParameters.SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("ShotClockRange", baseParameters.ShotClockRange, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", baseParameters.TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsConference", baseParameters.VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", baseParameters.VsDivision, ParameterType.String));

            return parameters;
        }

        public static JArray ConvertBaseParametersToArray(string leagueID, string season, string seasonType, string perMode, string measureType, BaseParameters baseParameters)
        {
            baseParameters.LeagueID = leagueID;
            baseParameters.Season = season;
            baseParameters.SeasonType = seasonType;
            baseParameters.PerMode = perMode;
            baseParameters.MeasureType = measureType;

            JArray parameters = new JArray();

            parameters.Add(CreateParameterObject("Conference", baseParameters.Conference, ParameterType.String));
            parameters.Add(CreateParameterObject("DateFrom", baseParameters.DateFrom, ParameterType.String));
            parameters.Add(CreateParameterObject("DateTo", baseParameters.DateTo, ParameterType.String));
            parameters.Add(CreateParameterObject("Division", baseParameters.Division, ParameterType.String));
            parameters.Add(CreateParameterObject("GameSegment", baseParameters.GameSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("LastNGames", baseParameters.LastNGames, ParameterType.Int));
            parameters.Add(CreateParameterObject("LeagueID", baseParameters.LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("MeasureType", baseParameters.MeasureType, ParameterType.String));
            parameters.Add(CreateParameterObject("OpponentTeamID", baseParameters.OpponentTeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Outcome", baseParameters.Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("PORound", baseParameters.PORound, ParameterType.Int));
            parameters.Add(CreateParameterObject("PaceAdjust", baseParameters.PaceAdjust, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", baseParameters.PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("Period", baseParameters.PerMode, ParameterType.Int));
            parameters.Add(CreateParameterObject("PlusMinus", baseParameters.PlusMinus, ParameterType.String));
            parameters.Add(CreateParameterObject("Rank", baseParameters.Rank, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", baseParameters.Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonSegment", baseParameters.SeasonSegment, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", baseParameters.SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("ShotClockRange", baseParameters.ShotClockRange, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", baseParameters.TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("VsConference", baseParameters.VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", baseParameters.VsDivision, ParameterType.String));

            return parameters;
        }

        public static JArray ConvertBaseParametersToArray(string leagueID, string season, string seasonType, string perMode, string measureType)
        {
            return ConvertBaseParametersToArray(leagueID, season, seasonType, perMode, measureType, new BaseParameters());
        }
    }
}
