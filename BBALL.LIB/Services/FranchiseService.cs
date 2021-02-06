using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;
namespace BBALL.LIB.Services
{
    public static class FranchiseService
    {
        public static void FranchiseHistory(string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            FranchiseHistory(parameters);
        }

        public static void FranchiseHistory(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/franchisehistory/", "franchisehistory", parameters);
        }

        public static void FranchiseLeaders(string TeamID, string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            FranchiseLeaders(parameters);
        }

        public static void FranchiseLeaders(JArray parameters) {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/franchiseleaders/", "franchiseleaders", parameters);
        }

        public static void FranchisePlayers(
            string TeamID,
            string PerMode = "Totals", 
            string SeasonType = "Regular Season",
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            FranchisePlayers(parameters);
        }

        public static void FranchisePlayers(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/franchiseplayers/", "franchiseplayers", parameters);
        }
    }
}
