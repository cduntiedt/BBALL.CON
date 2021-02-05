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
            string PerMode,
            string SeasonType = "Regular Season",
            string PlayType = "Transition",
            string PlayerOrTeam = "P",
            string TypeGrouping = "offensive",
            string SeasonYear = null,
            string LeagueID = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID));
            parameters.Add(CreateParameterObject("PerMode", PerMode);
            parameters.Add(CreateParameterObject("SeasonYear", SeasonHelper.DefaultSeason(SeasonYear));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType);
            parameters.Add(CreateParameterObject("PlayType", PlayType);
            parameters.Add(CreateParameterObject("PlayerOrTeam", PlayerOrTeam);
            parameters.Add(CreateParameterObject("TypeGrouping", TypeGrouping);

            SynergyPlayType(parameters);
        }

        public static void SynergyPlayType(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/synergyplaytype/", "synergyplaytype", parameters);
        }
    }
}
