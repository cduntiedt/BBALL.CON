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
            string PlayerID,
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season"
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameIDs", GameIDs));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            CumStatsPlayer(parameters);
        }

        public static void CumStatsPlayer(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/cumestatsplayer/", "cumestatsplayer", parameters);
        }

        public static void CumeStatsPlayerGames(
            string PlayerID,
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season",
            string VsTeamID = null,
            string VsDivision = null,
            string VsConference = null,
            string Outcome = null,
            string Location = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("VsTeamID", VsTeamID));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("Location", Location));
            CumeStatsPlayerGames(parameters);
        }

        public static void CumeStatsPlayerGames(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/cumestatsplayergames/", "cumestatsplayergames", parameters);
        }

        public static void CumeStatsTeam(
            string GameIDs,
            string TeamID,
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season"
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameIDs", GameIDs));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            CumeStatsTeam(parameters);
        }

        public static void CumeStatsTeam(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/cumestatsteam/", "cumestatsteam", parameters);
        }

        public static void CumeStatsTeamGames(
            string TeamID,
            string LeagueID,
            string Season = null,
            string SeasonType = "Regular Season",
            string VsTeamID = null,
            string VsDivision = null,
            string VsConference = null,
            string Outcome = null,
            string Location = null
            )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("VsTeamID", VsTeamID));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("Location", Location));
            CumeStatsTeamGames(parameters);
        }

        public static void CumeStatsTeamGames(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/cumestatsteamgames/", "cumestatsteamgames", parameters);
        }
    }
}
