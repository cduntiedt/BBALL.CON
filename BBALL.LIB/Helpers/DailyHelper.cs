using System;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BBALL.LIB.Helpers.ParameterHelper;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;

namespace BBALL.LIB.Helpers
{
    public static class DailyHelper
    {
        public static string GetDate(int numb = -1)
        {
            var dt = DateTime.Now.AddDays(numb);
            return dt.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Get a list of teams that played during a specific time range.
        /// </summary>
        /// <param name="IDField">The unique field to obtain.</param>
        /// <param name="PlayerOrTeam">The player or team filter..</param>
        /// <param name="DateFrom">The start date.</param>
        /// <param name="DateTo">The end date.</param>
        /// <returns>A list of team IDs.</returns>
        public static List<string> GetIDs(string IDField, string PlayerOrTeam = "T", string Season = null, string DateFrom = null, string DateTo = null)
        {
            try
            {
                List<BsonDocument> seasonDocuments = SeasonHelper.GetSeasonDocuments(PlayerOrTeam, Season, DateFrom, DateTo);

                List<string> ids = new List<string>();

                foreach (var seasonDoc in seasonDocuments)
                {
                    var games = (BsonArray)seasonDoc["resultSets"][0]["data"];
                    foreach (var game in games)
                    {
                        var id = game[IDField].ToString();
                        ids.Add(id);
                    }
                }

                return ids.Distinct().OrderBy(x => x).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
