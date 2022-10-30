using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Logic
{
    public static class SeasonLogic
    {
        /// <summary>
        /// Load the data for a given season.
        /// </summary>
        /// <param name="season">The season to laod data for.</param>
        /// <param name="seasonTypes">The different season types.</param>
        /// <param name="dateFrom">The start date.</param>
        /// <param name="dateTo">The end date.</param>
        public static void LoadSeasonData(string season, List<string> seasonTypes, string dateFrom = null, string dateTo = null)
        {
            try
            {
                //Load player game logs
                Console.WriteLine("Player game log load started.");
                PlayerLogic.LoadPlayerGameLogs(season, seasonTypes);
                Console.WriteLine("Player game log load complete.");

                //Load team data 
                Console.WriteLine("Team data load started.");
                TeamLogic.LoadTeamData(season, seasonTypes, dateFrom, dateTo);
                Console.WriteLine("Team data load complete.");

                //Load player data
                Console.WriteLine("Player data load started.");
                PlayerLogic.LoadPlayerData(season, seasonTypes, dateFrom, dateTo);
                Console.WriteLine("Player data load complete.");

                //Load game data
                Console.WriteLine("Game data load started.");
                GameLogic.LoadGameData(season, seasonTypes, dateFrom, dateTo);
                Console.WriteLine("Game data load complete.");

                //Load season data
                Console.WriteLine("League data load started.");
                LeagueLogic.LoadLeagueData(season, seasonTypes);
                Console.WriteLine("League data load complete.");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
