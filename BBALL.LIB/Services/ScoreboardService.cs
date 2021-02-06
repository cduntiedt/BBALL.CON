using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;

namespace BBALL.LIB.Services
{
    public static class ScoreboardService
    {
        public static void Scoreboard(
            string LeagueID = null,
            string DayOffset = null,
            string GameDate = null
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("DayOffset", DayOffset));
            parameters.Add(CreateParameterObject("PerMode", GameDate));

            Scoreboard(parameters);
        }

        public static void Scoreboard(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/scoreboard/", "scoreboard", parameters);
        }

        public static void ScoreboardV2(
            string LeagueID = null,
            string DayOffset = null,
            string GameDate = null
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("DayOffset", DayOffset));
            parameters.Add(CreateParameterObject("PerMode", GameDate));

            ScoreboardV2(parameters);
        }

        public static void ScoreboardV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/scoreboardv2/", "scoreboardv2", parameters);
        }
    }
}
