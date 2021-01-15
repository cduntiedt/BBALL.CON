using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.CON.Helpers;
using static BBALL.CON.Helpers.ParameterHelper;

namespace BBALL.CON.Services
{
    public static class LeadersService
    {
        //Players > All Time Summary
        public static void AllTimeLeadersGrid(
            string LeagueID,
            string PerMode,
            string SeasonType,
            string TopX = "10"
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("TopX", TopX, ParameterType.String));

            AllTimeLeadersGrid(parameters);
        }

        public static void AllTimeLeadersGrid(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/alltimeleadersgrids/", "alltimeleadersgrids", parameters);
        }


        //Players > Official Leaders
        public static void LeagueLeaders(
           string LeagueID,
           string Season,
           string PerMode = "PerGame",
           string SeasonType = "Regular Season",
           string ActiveFlag = null,
           string Scope = "S",
           string StatCategory = "PTS"
           )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("ActiveFlag", ActiveFlag, ParameterType.String));
            parameters.Add(CreateParameterObject("Scope", Scope, ParameterType.String));
            parameters.Add(CreateParameterObject("StatCategory", StatCategory, ParameterType.String));
            LeagueLeaders(parameters);
        }

        public static void LeagueLeaders(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leagueleaders/", "leagueleaders", parameters);
        }
    }
}
