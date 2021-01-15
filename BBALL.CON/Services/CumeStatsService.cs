using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.CON.Helpers;
using static BBALL.CON.Helpers.ParameterHelper;

namespace BBALL.CON.Services
{
    public static class CumeStatsService
    {
        public static void CumeStatsPlayer(
            string GameIDs,
            string LeagueID,
            int PlayerID,
            string Season,
            string SeasonType = "Regular Season"
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameIDs", GameIDs, ParameterType.String));
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerID", PlayerID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            CumStatsPlayer(parameters);
        }

        public static void CumStatsPlayer(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/cumestatsplayer/", "cumestatsplayer", parameters);
        }

        public static void CumeStatsPlayerGames(
            string LeagueID,
            int PlayerID,
            string Season,
            string SeasonType = "Regular Season",
            string VsTeamID = null,
            string VsDivision = null,
            string VsConference = null,
            string Outcome = null,
            string Location = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("PlayerID", PlayerID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("VsTeamID", VsTeamID, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            CumeStatsPlayerGames(parameters);
        }

        public static void CumeStatsPlayerGames(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/cumestatsplayergames/", "cumestatsplayergames", parameters);
        }

        public static void CumeStatsTeam(
            string GameIDs,
            string LeagueID,
            int TeamID,
            string Season,
            string SeasonType = "Regular Season"
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameIDs", GameIDs, ParameterType.String));
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            CumeStatsTeam(parameters);
        }

        public static void CumeStatsTeam(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/cumestatsteam/", "cumestatsteam", parameters);
        }

        public static void CumeStatsTeamGames(
            string LeagueID,
            int TeamID,
            string Season,
            string SeasonType = "Regular Season",
            string VsTeamID = null,
            string VsDivision = null,
            string VsConference = null,
            string Outcome = null,
            string Location = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("VsTeamID", VsTeamID, ParameterType.String));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision, ParameterType.String));
            parameters.Add(CreateParameterObject("VsConference", VsConference, ParameterType.String));
            parameters.Add(CreateParameterObject("Outcome", Outcome, ParameterType.String));
            parameters.Add(CreateParameterObject("Location", Location, ParameterType.String));
            CumeStatsTeamGames(parameters);
        }

        public static void CumeStatsTeamGames(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/cumestatsteamgames/", "cumestatsteamgames", parameters);
        }
    }
}
