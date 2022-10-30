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

namespace BBALL.CON
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        /// <summary>
        /// Load the filtering objects to the database. Use this to rebuild the filters in the database.
        /// </summary>
        static void LoadFilters()
        {
            ConferenceService.LoadFilter();
            ContextMeasureService.LoadFilter();
        }
    }
}
