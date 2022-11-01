using Newtonsoft.Json.Linq;
using BBALL.LIB.Services;
using static BBALL.LIB.Helpers.ParameterHelper;
using System;
using System.Threading.Tasks;
using System.Linq;
using BBALL.LIB.Helpers;
using BBALL.LIB.Logic;
using System.Collections.Generic;

namespace BBALL.CON
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var season = "2022-23";
            var seasonType = "Regular Season";
            var games = await LeagueService.LeagueGameLog(season, seasonType);

            foreach (var measureType in MeasureTypeService.PlayerMeasureTypes)
            {
                await PlayerService.PlayerGameLogs(season, seasonType, "Totals", measureType);
            }

            foreach (var measureType in MeasureTypeService.TeamMeasureTypes)
            {
                await TeamService.TeamGameLogs(null, season, seasonType, measureType);
            }
        }
    }
}
