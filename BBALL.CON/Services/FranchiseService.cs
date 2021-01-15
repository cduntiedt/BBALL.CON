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
    }
}
