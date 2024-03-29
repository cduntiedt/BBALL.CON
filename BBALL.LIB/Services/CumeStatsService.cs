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
    public static class CumeStatsService
    {
        public static async Task<BsonDocument> CumeStatsPlayer(
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
            return await CumStatsPlayer(parameters);
        }

        public static async Task<BsonDocument> CumStatsPlayer(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/cumestatsplayer/", "cumestatsplayer", parameters);
        }

        public static async Task<BsonDocument> CumeStatsPlayerGames(
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
            return await CumeStatsPlayerGames(parameters);
        }

        public static async Task<BsonDocument> CumeStatsPlayerGames(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/cumestatsplayergames/", "cumestatsplayergames", parameters);
        }

        public static async Task<BsonDocument> CumeStatsTeam(
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
            return await CumeStatsTeam(parameters);
        }

        public static async Task<BsonDocument> CumeStatsTeam(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/cumestatsteam/", "cumestatsteam", parameters);
        }

        public static async Task<BsonDocument> CumeStatsTeamGames(
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
            return await CumeStatsTeamGames(parameters);
        }

        public static async Task<BsonDocument> CumeStatsTeamGames(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/cumestatsteamgames/", "cumestatsteamgames", parameters);
        }
    }
}
