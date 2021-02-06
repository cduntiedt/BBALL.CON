using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;

namespace BBALL.LIB.Services
{
    public static class LeadersService
    {
        //Players > All Time Summary
        public static void AllTimeLeadersGrid(
            string PerMode = "Totals",
            string SeasonType = "Regular Season",
            string TopX = "10",
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("TopX", TopX));

            AllTimeLeadersGrid(parameters);
        }

        public static void AllTimeLeadersGrid(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/alltimeleadersgrids/", "alltimeleadersgrids", parameters);
        }


        //Players > Official Leaders
        public static void LeagueLeaders(
           string PerMode = "PerGame",
           string SeasonType = "Regular Season",
           string ActiveFlag = null,
           string Scope = "S",
           string StatCategory = "PTS",
            string LeagueID = null,
           string Season = null
           )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("ActiveFlag", ActiveFlag));
            parameters.Add(CreateParameterObject("Scope", Scope));
            parameters.Add(CreateParameterObject("StatCategory", StatCategory));
            LeagueLeaders(parameters);
        }

        public static void LeagueLeaders(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/leagueleaders/", "leagueleaders", parameters);
        }
    }
}
