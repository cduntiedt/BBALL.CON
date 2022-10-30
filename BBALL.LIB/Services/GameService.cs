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
        /// <summary>
        /// Get a list of game IDs
        /// </summary>
        /// <returns>A list of string</returns>
        public static List<BsonDocument> ImportGames(JArray parameters = null)
        {
            try
            {
                List<BsonDocument> gameLogs = DatabaseHelper.GetAllDocuments("leaguegamelog", parameters);

                var seasons = gameLogs.GroupBy(x => new
                {
                    Season = x["Season"].ToString(),
                    SeasonType = x["SeasonType"].ToString()
                }).Select(x => x.First()).ToList();

                List<BsonDocument> seasonDocuments = new List<BsonDocument>();

                foreach (var season in seasons)
                {
                    var seasonGames = gameLogs.Where(x => x["Season"] == season["Season"] && x["SeasonType"] == season["SeasonType"]).ToList();

                    BsonDocument seasonDocument = new BsonDocument();
                    seasonDocument.Add("Season", season["Season"].ToString());
                    seasonDocument.Add("SeasonType", season["SeasonType"].ToString());

                    BsonArray gameArray = new BsonArray();

                    foreach (var seasonGame in seasonGames)
                    {
                        var gameLog = (BsonArray)seasonGame["resultSets"][0]["data"];
                        if (!gameLog.IsBsonNull)
                        {
                            foreach (var item in gameLog)
                            {
                                if (!item["MATCHUP"].ToString().Contains("@"))
                                {
                                    BsonDocument game = new BsonDocument();
                                    game.Add("GAME_ID", item["GAME_ID"].ToString());
                                    game.Add("GAME_DATE", item["GAME_DATE"].ToString());
                                    game.Add("MATCHUP", item["MATCHUP"].ToString());

                                    var existingGame = gameArray.Where(x => x["GAME_ID"].ToString() == item["GAME_ID"].ToString()).FirstOrDefault();
                                    if (existingGame != game)
                                    {
                                        gameArray.Add(game);
                                    }
                                }
                            }
                        }
                    }

                    seasonDocument.Add("Games", gameArray);
                    seasonDocuments.Add(seasonDocument);

                    JArray seasonParameters = new JArray();
                    seasonParameters.Add(CreateParameterObject("Season", season["Season"].ToString(), ParameterType.String));
                    seasonParameters.Add(CreateParameterObject("SeasonType", season["SeasonType"].ToString(), ParameterType.String));

                    DatabaseHelper.AddUpdateDocument("games", seasonDocument, seasonParameters);
                }

                return seasonDocuments;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public static async Task<List<BsonDocument>> GameRotation(string GameID, string LeagueID = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            return await GameRotation(parameters);
        }

        public static async Task<List<BsonDocument>> GameRotation(JArray parameters)
        {
            return await DatabaseHelper.UpdateDatabaseAsync("https://stats.nba.com/stats/gamerotation/", "gamerotation", parameters);
        }
    }
}
