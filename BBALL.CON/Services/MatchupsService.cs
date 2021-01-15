using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.CON.Helpers;
using static BBALL.CON.Helpers.ParameterHelper;

namespace BBALL.CON.Services
{
    public static class MatchupsService
    {
        public static void LeagueSeasonMatchups(
           string LeagueID,
           string Season,
           int DefPlayerID,
           string PerMode = "Totals",
           string SeasonType = "Regular Season",
           string DefTeamID = null,
           string OffPlayerID = null,
           string OffTeamID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("DefPlayerID", DefPlayerID, ParameterType.Int));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("DefTeamID", DefTeamID, ParameterType.String));
            parameters.Add(CreateParameterObject("OffPlayerID", OffPlayerID, ParameterType.String));
            parameters.Add(CreateParameterObject("OffTeamID", OffTeamID, ParameterType.String));
            LeagueSeasonMatchups(parameters);
        }

        public static void LeagueSeasonMatchups(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leagueseasonmatchups/", "leagueseasonmatchups", parameters);
        }

        public static void MatchupsRollup(
            string LeagueID,
            string Season,
            int DefPlayerID,
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
            string DefTeamID = null,
            string OffPlayerID = null,
            string OffTeamID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("DefPlayerID", DefPlayerID, ParameterType.Int));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("DefTeamID", DefTeamID, ParameterType.String));
            parameters.Add(CreateParameterObject("OffPlayerID", OffPlayerID, ParameterType.String));
            parameters.Add(CreateParameterObject("OffTeamID", OffTeamID, ParameterType.String));
            MatchupsRollup(parameters);
        }

        public static void MatchupsRollup(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/matchupsrollup/", "matchupsrollup", parameters);
        }
    }
}
