using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class DirectionService
    {
        public static List<string> Directions { get { return _Directions(); } }
        private static List<string> _Directions()
        {
            List<string> conferences = new List<string>();
            conferences.Add("ASC");
            conferences.Add("DSC");

            return conferences;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "ASC" }, { "value", "ASC" } },
                new BsonDocument { { "label", "DSC" }, { "value", "DSC" } },
            };

            DatabaseHelper.AddFilterCollection("direction", array);
        }
    }
}
