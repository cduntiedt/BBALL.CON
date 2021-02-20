using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;
using MongoDB.Bson;

namespace BBALL.LIB.Services
{
    public static class MatchupsService
    {
        /// <summary>
        /// Also on LeagueService
        /// </summary>
        /// <param name="Season"></param>
        /// <param name="SeasonType"></param>
        /// <param name="PerMode"></param>
        /// <param name="LeagueID"></param>
        /// <param name="DefPlayerID"></param>
        /// <param name="DefTeamID"></param>
        /// <param name="OffPlayerID"></param>
        /// <param name="OffTeamID"></param>
        public static BsonDocument LeagueSeasonMatchups(
           string Season = null,
           string SeasonType = "Regular Season",
           string PerMode = "Totals",
           string LeagueID = null,
           string DefPlayerID = null,
           string DefTeamID = null,
           string OffPlayerID = null,
           string OffTeamID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("DefPlayerID", DefPlayerID));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DefTeamID", DefTeamID));
            parameters.Add(CreateParameterObject("OffPlayerID", OffPlayerID));
            parameters.Add(CreateParameterObject("OffTeamID", OffTeamID));
            return LeagueSeasonMatchups(parameters);
        }

        public static BsonDocument LeagueSeasonMatchups(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leagueseasonmatchups/", "leagueseasonmatchups", parameters);
        }

        public static BsonDocument MatchupsRollup(
            string Season = null,
            string SeasonType = "Regular Season",
            string PerMode = "Totals",
            string LeagueID = null,
            string DefPlayerID = null,
            string DefTeamID = null,
            string OffPlayerID = null,
            string OffTeamID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("DefPlayerID", DefPlayerID));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("DefTeamID", DefTeamID));
            parameters.Add(CreateParameterObject("OffPlayerID", OffPlayerID));
            parameters.Add(CreateParameterObject("OffTeamID", OffTeamID));
            return MatchupsRollup(parameters);
        }

        public static BsonDocument MatchupsRollup(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/matchupsrollup/", "matchupsrollup", parameters);
        }
    }
}
