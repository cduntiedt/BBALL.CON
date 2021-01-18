using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BBALL.CON.Helpers;
using static BBALL.CON.Helpers.ParameterHelper;
namespace BBALL.CON.Services
{
    public static class FranchiseService
    {
        public static void FranchiseHistory(string LeagueID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            FranchiseHistory(parameters);
        }

        public static void FranchiseHistory(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/franchisehistory/", "franchisehistory", parameters);
        }

        public static void FranchiseLeaders(int TeamID, string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            FranchiseLeaders(parameters);
        }

        public static void FranchiseLeaders(JArray parameters) {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/franchiseleaders/", "franchiseleaders", parameters);
        }

        public static void FranchisePlayers(string LeagueID, string PerMode, string SeasonType, int TeamID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            FranchisePlayers(parameters);
        }

        public static void FranchisePlayers(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/franchiseplayers/", "franchiseplayers", parameters);
        }
    }
}
