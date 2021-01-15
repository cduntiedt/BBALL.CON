using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.CON.Helpers;
using static BBALL.CON.Helpers.ParameterHelper;

namespace BBALL.CON.Services
{
    public static class SynergyService
    {
        //Players > Playtype
        public static void SynergyPlayType(
            string LeagueID,
            string PerMode,
            string SeasonType,
            string SeasonYear,
            string PlayType = "Transition",
            string PlayerOrTeam = "P",
            string TypeGrouping = "offensive")
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", PerMode, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonYear, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayType", PlayType, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerOrTeam", PlayerOrTeam, ParameterType.String));
            parameters.Add(CreateParameterObject("TypeGrouping", TypeGrouping, ParameterType.String));

            SynergyPlayType(parameters);
        }

        public static void SynergyPlayType(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/synergyplaytype/", "synergyplaytype", parameters);
        }
    }
}
