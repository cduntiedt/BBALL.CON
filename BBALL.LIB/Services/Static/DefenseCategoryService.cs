using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services
{
    public static class DefenseCategoryService
    {
        public static List<string> Categories { get { return _Categories(); } }
        private static List<string> _Categories()
        {
            List<string> categories = new List<string>();
            categories.Add("Overall");
            categories.Add("3 Pointers");
            categories.Add("2 Pointers");
            categories.Add("Less Than 6Ft");
            categories.Add("Less Than 10Ft");
            categories.Add("Greater Than 15Ft");
            return categories;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Overall" }, { "value", "Overall" } },
                new BsonDocument { { "label", "3 Pointers" }, { "value", "3 Pointers" } },
                new BsonDocument { { "label", "2 Pointers" }, { "value", "2 Pointers" } },
                new BsonDocument { { "label", "Less Than 6Ft" }, { "value", "Less Than 6Ft" } },
                new BsonDocument { { "label", "Less Than 10Ft" }, { "value", "Less Than 10Ft" } },
                new BsonDocument { { "label", "Greater Than 15Ft" }, { "value", "Greater Than 15Ft" } }
            };

            DatabaseHelper.AddFilterCollection("defenseCategory", array);
        }
    }
}
