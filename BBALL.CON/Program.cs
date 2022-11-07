using Newtonsoft.Json.Linq;
using BBALL.LIB.Services;
using static BBALL.LIB.Helpers.ParameterHelper;
using System;
using System.Threading.Tasks;
using System.Linq;
using BBALL.LIB.Helpers;
using BBALL.LIB.Logic;
using System.Collections.Generic;
using MongoDB.Bson;

namespace BBALL.CON
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var daily = false;
            var shutdown = false;
            var dataSets = new List<string> { "league" };

            await DatabaseHelper.DropCollectionAsync("errorlog");

            await DataLogic.LoadData(daily, shutdown, dataSets);
        }
    }

}
