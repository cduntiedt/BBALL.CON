using System;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;
using System.Threading.Tasks;

namespace BBALL.LIB.Services
{
    public static class GameService
    {

        public static async Task<List<BsonDocument>> GameRotation(string GameID, string LeagueID = null)
        {
            BsonArray parameters = new BsonArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            return await GameRotation(parameters);
        }

        public static async Task<List<BsonDocument>> GameRotation(BsonArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/gamerotation/", "gamerotation", parameters);
        }
    }
}
