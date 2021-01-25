using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.CON.Helpers;
using static BBALL.CON.Helpers.ParameterHelper;

namespace BBALL.CON.Services
{
    public static class PlayByPlayService
    {
        public static void PlayByPlay(
          string GameID,
          string StartPeriod = "0",
          string EndPeriod = "10")
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID, ParameterType.String));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod, ParameterType.String));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod, ParameterType.Int));
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
            parameters.Add(CreateParameterObject("GameID", GameID, ParameterType.String));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod, ParameterType.String));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod, ParameterType.Int));
            PlayByPlayV2(parameters);
        }

        public static void PlayByPlayV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/playbyplayv2/", "playbyplayv2", parameters);
        }
    }
}
