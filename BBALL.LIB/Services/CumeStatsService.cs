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
    public static class CumeStatsService
    {
        public static async Task<List<BsonDocument>> CumeStatsPlayer(
            string GameIDs,
            string PlayerID,
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season"
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("GameIDs", GameIDs));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            return await CumStatsPlayer(parameters);
        }

        public static async Task<List<BsonDocument>> CumStatsPlayer(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/cumestatsplayer/", "cumestatsplayer", parameters);
        }

        public static async Task<List<BsonDocument>> CumeStatsPlayerGames(
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
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("VsTeamID", VsTeamID));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("Location", Location));
            return await CumeStatsPlayerGames(parameters);
        }

        public static async Task<List<BsonDocument>> CumeStatsPlayerGames(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/cumestatsplayergames/", "cumestatsplayergames", parameters);
        }

        public static async Task<List<BsonDocument>> CumeStatsTeam(
            string GameIDs,
            string TeamID,
            string LeagueID = null,
            string Season = null,
            string SeasonType = "Regular Season"
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("GameIDs", GameIDs));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            return await CumeStatsTeam(parameters);
        }

        public static async Task<List<BsonDocument>> CumeStatsTeam(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/cumestatsteam/", "cumestatsteam", parameters);
        }

        public static async Task<List<BsonDocument>> CumeStatsTeamGames(
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
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("VsTeamID", VsTeamID));
            parameters.Add(CreateParameterObject("VsDivision", VsDivision));
            parameters.Add(CreateParameterObject("VsConference", VsConference));
            parameters.Add(CreateParameterObject("Outcome", Outcome));
            parameters.Add(CreateParameterObject("Location", Location));
            return await CumeStatsTeamGames(parameters);
        }

        public static async Task<List<BsonDocument>> CumeStatsTeamGames(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/cumestatsteamgames/", "cumestatsteamgames", parameters);
        }
    }
}
