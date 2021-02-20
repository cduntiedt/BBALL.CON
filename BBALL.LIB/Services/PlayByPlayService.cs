using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;
using MongoDB.Bson;

namespace BBALL.LIB.Services
{
    public static class PlayByPlayService
    {
        public static void PlayByPlayAll(string GameID)
        {
            PlayByPlay(GameID);
            PlayByPlayV2(GameID);
        }

        public static BsonDocument PlayByPlay(
            string GameID,
            string StartPeriod = "0",
            string EndPeriod = "10"
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            return PlayByPlay(parameters);
        }

        public static BsonDocument PlayByPlay(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playbyplay/", "playbyplay", parameters);
        }

        public static BsonDocument PlayByPlayV2(
            string GameID,
            string StartPeriod = "0",
            string EndPeriod = "10"
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            return PlayByPlayV2(parameters);
        }

        public static BsonDocument PlayByPlayV2(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playbyplayv2/", "playbyplayv2", parameters);
        }
    }
}
