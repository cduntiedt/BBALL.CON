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
           string PerMode = "Totals",
           string SeasonType = "Regular Season",
           string LeagueID = null,
           string Season = null,
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
            LeagueSeasonMatchups(parameters);
        }

        public static void LeagueSeasonMatchups(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leagueseasonmatchups/", "leagueseasonmatchups", parameters);
        }

        public static void MatchupsRollup(
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
            string LeagueID = null,
            string Season = null,
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
            MatchupsRollup(parameters);
        }

        public static void MatchupsRollup(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/matchupsrollup/", "matchupsrollup", parameters);
        }
    }
}
