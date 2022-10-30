using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class VsConferenceService
    {
        public static List<string> Conferences { get { return _Conferences(); } }
        private static List<string> _Conferences()
        {
            List<string> conferences = new List<string>();
            conferences.Add("East");
            conferences.Add("West");

            return conferences;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "East" }, { "value", "East" } },
                new BsonDocument { { "label", "West" }, { "value", "West" } }
            };

            DatabaseHelper.AddFilterCollection("vsConference", array);
        }
    }
}
