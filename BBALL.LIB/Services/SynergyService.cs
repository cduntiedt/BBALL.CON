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
    public static class SynergyService
    {
        //Players > Playtype
        public static async Task<List<BsonDocument>> SynergyPlayType(
            string PerMode,
            string SeasonType = "Regular Season",
            string PlayType = "Transition",
            string PlayerOrTeam = "P",
            string TypeGrouping = "offensive",
            string SeasonYear = null,
            string LeagueID = null
            )
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("PerMode", PerMode));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonHelper.DefaultSeason(SeasonYear)));
            parameters.Add(CreateParameterObject("SeasonType", SeasonType));
            parameters.Add(CreateParameterObject("PlayType", PlayType));
            parameters.Add(CreateParameterObject("PlayerOrTeam", PlayerOrTeam));
            parameters.Add(CreateParameterObject("TypeGrouping", TypeGrouping));

            return await SynergyPlayType(parameters);
        }

        public static async Task<List<BsonDocument>> SynergyPlayType(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/synergyplaytypes/", "synergyplaytypes", parameters);
        }
    }
}
