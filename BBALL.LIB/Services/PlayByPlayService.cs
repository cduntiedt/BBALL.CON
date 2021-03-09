using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace BBALL.LIB.Services
{
    public static class PlayByPlayService
    {
        public static async void PlayByPlayAll(string GameID)
        {
            await PlayByPlay(GameID);
            await PlayByPlayV2(GameID);
        }

        public static async Task<BsonDocument> PlayByPlay(
            string GameID,
            string StartPeriod = "0",
            string EndPeriod = "10"
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            return await PlayByPlay(parameters);
        }

        public static async Task<BsonDocument> PlayByPlay(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playbyplay/", "playbyplay", parameters);
        }

        public static async Task<BsonDocument> PlayByPlayV2(
            string GameID,
            string StartPeriod = "0",
            string EndPeriod = "10"
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            return await PlayByPlayV2(parameters);
        }

        public static async Task<BsonDocument> PlayByPlayV2(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/playbyplayv2/", "playbyplayv2", parameters);
        }
    }
}
