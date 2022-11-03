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
            var seasonTypes = new List<string>();
            seasonTypes.Add(seasonType);
            GameLogic.LoadGameData(season, seasonTypes);
        }
    }
}
