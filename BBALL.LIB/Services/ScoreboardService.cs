﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace BBALL.LIB.Services
{
    public static class ScoreboardService
    {
        public static async Task<BsonDocument> Scoreboard(
            string LeagueID = null,
            string DayOffset = null,
            string GameDate = null
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("DayOffset", DayOffset));
            parameters.Add(CreateParameterObject("GameDate", GameDate));

            return await Scoreboard(parameters);
        }

        public static async Task<BsonDocument> Scoreboard(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/scoreboard/", "scoreboard", parameters);
        }

        public static async Task<BsonDocument> ScoreboardV2(
            string LeagueID = null,
            string DayOffset = null,
            string GameDate = null
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("DayOffset", DayOffset));
            parameters.Add(CreateParameterObject("GameDate", GameDate));

            return await ScoreboardV2(parameters);
        }

        public static async Task<BsonDocument> ScoreboardV2(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/scoreboardv2/", "scoreboardv2", parameters);
        }
    }
}
