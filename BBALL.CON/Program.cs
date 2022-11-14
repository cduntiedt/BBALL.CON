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
using System.Globalization;
using System.Text.Json;

namespace BBALL.CON
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await RunProcess();
        }


        private static async Task RunProcess()
        {
            var daily = false;

            await DatabaseHelper.DropCollectionAsync("logerror");
            await DatabaseHelper.DropCollectionAsync("logapi");

            await DataLogic.LoadSingleSeasonData(daily);
        }
    }

}
