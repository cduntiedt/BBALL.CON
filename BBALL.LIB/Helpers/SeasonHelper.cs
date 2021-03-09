using BBALL.LIB.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BBALL.LIB.Helpers.ParameterHelper;

namespace BBALL.LIB.Helpers
{
    public static class SeasonHelper
    {
        /// <summary>
        /// Get the default season parameter.
        /// </summary>
        /// <param name="season">The season if provided.</param>
        /// <returns>The season year.</returns>
        public static string DefaultSeason(string season = null)
        {
            if (season == null || season == "")
            {
                return SeasonService.CurrentSeason.FirstOrDefault();
            }

            return season;
        }

        public static List<BsonDocument> GetSeasonDocuments(string PlayerOrTeam = "T", string Season = null, string DateFrom = null, string DateTo = null)
        {
            List<BsonDocument> seasonDocuments = new List<BsonDocument>();

            foreach (var seasonType in SeasonTypeService.TeamSeasonTypes)
            {
                JArray parameters = new JArray();
                parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(null)));
                parameters.Add(CreateParameterObject("Season", DefaultSeason(Season)));
                parameters.Add(CreateParameterObject("SeasonType", seasonType));
                parameters.Add(CreateParameterObject("Counter", "0"));
                parameters.Add(CreateParameterObject("DateFrom", DateFrom));
                parameters.Add(CreateParameterObject("DateTo", DateTo));
                parameters.Add(CreateParameterObject("Direction", "ASC"));
                parameters.Add(CreateParameterObject("PlayerOrTeam", PlayerOrTeam));
                parameters.Add(CreateParameterObject("Sorter", "DATE"));

                BsonDocument seasonDoc = BsonSerializer.Deserialize<BsonDocument>(DatabaseHelper.GenerateDocument("https://stats.nba.com/stats/leaguegamelog/", parameters, true));
                seasonDocuments.Add(seasonDoc);
            }

            return seasonDocuments;
        }

        public static List<string> GetSeasonTypes(string Season = null, string DateFrom = null, string DateTo = null)
        {
            List<BsonDocument> seasonDocuments = GetSeasonDocuments("T", Season, DateFrom, DateTo);
            List<string> seasonTypes = new List<string>();

            foreach (var seasonDoc in seasonDocuments)
            {
                var data = (BsonArray)seasonDoc["resultSets"][0]["data"];
                if(data.Count > 0)
                {
                    seasonTypes.Add(seasonDoc["SeasonType"].ToString());
                }
            }

            return seasonTypes;
        }
    }
}
