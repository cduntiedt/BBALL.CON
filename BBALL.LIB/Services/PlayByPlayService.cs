using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;

namespace BBALL.LIB.Services
{
    public static class PlayByPlayService
    {
        public static void PlayByPlay(
          string GameID,
          string StartPeriod = "0",
          string EndPeriod = "10")
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            PlayByPlay(parameters);
        }

        public static void PlayByPlay(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playbyplay/", "playbyplay", parameters);
        }

        public static void PlayByPlayV2(
          string GameID,
          string StartPeriod = "0",
          string EndPeriod = "10")
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            PlayByPlayV2(parameters);
        }

        public static void PlayByPlayV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playbyplayv2/", "playbyplayv2", parameters);
        }
    }
}
