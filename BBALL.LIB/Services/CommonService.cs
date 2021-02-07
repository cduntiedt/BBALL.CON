using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;
using MongoDB.Bson;

namespace BBALL.LIB.Services
{
    public static class CommonService
    {
        public static BsonDocument CommonAllPlayers(string Season = null, string IsOnlyCurrentSeason = "1", string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("IsOnlyCurrentSeason", IsOnlyCurrentSeason));
            return CommonAllPlayers(parameters);
        }

        public static BsonDocument CommonAllPlayers(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/commonallplayers/", "commonallplayers", parameters);
        }

        public static BsonDocument CommonPlayerInfo(string PlayerID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("PlayerID", PlayerID));
            return CommonPlayerInfo(parameters);
        }

        public static BsonDocument CommonPlayerInfo(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/commonplayerinfo/", "commonplayerinfo", parameters);
        }

        public static BsonDocument CommonTeamRoster(string TeamID, string Season = null, string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));

            return CommonTeamRoster(parameters);
        }

        public static BsonDocument CommonTeamRoster(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/commonteamroster/", "commonteamroster", parameters);
        }

        public static BsonDocument CommonTeamYears(string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            return CommonTeamYears(parameters);
        }

        public static BsonDocument CommonTeamYears(JArray parameters)
        {
            return DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/commonteamyears/", "commonteamyears", parameters);
        }
    }
}
