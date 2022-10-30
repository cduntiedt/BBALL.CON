using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services
{
    public static class PTMeasureTypeService
    {
        public static List<string> PTMeasureTypes { get { return _PTMeasureTypes(); } }
        private static List<string> _PTMeasureTypes()
        {
            List<string> types = new List<string>();
            types.Add("SpeedDistance");
            types.Add("Rebounding");
            types.Add("Possessions");
            types.Add("CatchShoot");
            types.Add("PullUpShot");
            types.Add("Defense");
            types.Add("Drives");
            types.Add("Passing");
            types.Add("ElbowTouch");
            types.Add("PostTouch");
            types.Add("PaintTouch");
            types.Add("Efficiency");
            return types;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "Speed Distance" }, { "value", "SpeedDistance" } },
                new BsonDocument { { "label", "Rebounding" }, { "value", "Rebounding" } },
                new BsonDocument { { "label", "Possessions" }, { "value", "Possessions" } },
                new BsonDocument { { "label", "Catch Shoot" }, { "value", "CatchShoot" } },
                new BsonDocument { { "label", "Pull Up Shot" }, { "value", "PullUpShot" } },
                new BsonDocument { { "label", "Defense" }, { "value", "Defense" } },
                new BsonDocument { { "label", "Drives" }, { "value", "Drives" } },
                new BsonDocument { { "label", "Passing" }, { "value", "Passing" } },
                new BsonDocument { { "label", "Elbow Touch" }, { "value", "ElbowTouch" } },
                new BsonDocument { { "label", "Post Touch" }, { "value", "PostTouch" } },
                new BsonDocument { { "label", "Paint Touch" }, { "value", "PaintTouch" } },
                new BsonDocument { { "label", "Efficiency" }, { "value", "Efficiency" } },
            };

            DatabaseHelper.AddFilterCollection("ptMeasureTypes", array);
        }
    }
}
