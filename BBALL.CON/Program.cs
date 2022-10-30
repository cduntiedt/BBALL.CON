using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BBALL.LIB.Services;
using BBALL.LIB.Helpers;
using System.Threading.Tasks;
using BBALL.LIB.Services.Static;
using BBALL.LIB.Logic;

namespace BBALL.CON
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = SeasonHelper.DefaultSeason();
            List<string> seasonTypes = SeasonHelper.GetSeasonTypes(season);
            for (int i = 0; i < seasonTypes.Count; i++)
            {
                Console.WriteLine(seasonTypes[i]);
            }
        }
    }
}
