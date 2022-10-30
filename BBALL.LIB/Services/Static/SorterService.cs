using BBALL.LIB.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class SorterService
    {
        public static List<string> Sorters { get { return _Sorters(); } }
        private static List<string> _Sorters()
        {
            List<string> sorter = new List<string>();
            sorter.Add("FGM");
            sorter.Add("FGA");
            sorter.Add("FG_PCT");
            sorter.Add("FG3M");
            sorter.Add("FG3A");
            sorter.Add("FG3_PCT");
            sorter.Add("FTM");
            sorter.Add("FTA");
            sorter.Add("FT_PCT");
            sorter.Add("OREB");
            sorter.Add("DREB");
            sorter.Add("AST");
            sorter.Add("STL");
            sorter.Add("BLK");
            sorter.Add("TOV");
            sorter.Add("REB");
            sorter.Add("PTS");
            sorter.Add("DATE");

            return sorter;
        }

        public static void LoadFilter()
        {
            BsonArray array = new BsonArray {
                new BsonDocument { { "label", "FG Made" }, { "value", "FGM" } },
                new BsonDocument { { "label", "FG Attempts" }, { "value", "FGA" } },
                new BsonDocument { { "label", "FG %" }, { "value", "FG_PCT" } },
                new BsonDocument { { "label", "3PT FG Made" }, { "value", "FG3M" } },
                new BsonDocument { { "label", "3PT FG Attempts" }, { "value", "FG3A" } },
                new BsonDocument { { "label", "3PT FG %" }, { "value", "FG3_PCT" } },
                new BsonDocument { { "label", "FT Made" }, { "value", "FTM" } },
                new BsonDocument { { "label", "FT Attempts" }, { "value", "FTA" } },
                new BsonDocument { { "label", "FT %" }, { "value", "FT_PCT" } },
                new BsonDocument { { "label", "Offensive Rebounds" }, { "value", "OREB" } },
                new BsonDocument { { "label", "Defensive Rebounds" }, { "value", "DREB" } },
                new BsonDocument { { "label", "Assists" }, { "value", "AST" } },
                new BsonDocument { { "label", "Steals" }, { "value", "STL" } },
                new BsonDocument { { "label", "Blocks" }, { "value", "BLK" } },
                new BsonDocument { { "label", "Turnovers" }, { "value", "TOV" } },
                new BsonDocument { { "label", "Rebounds" }, { "value", "REB" } },
                new BsonDocument { { "label", "Points" }, { "value", "PTS" } },
                new BsonDocument { { "label", "Date" }, { "value", "DATE" } },
            };

            DatabaseHelper.AddFilterCollection("sortFields", array);
        }
    }
}
