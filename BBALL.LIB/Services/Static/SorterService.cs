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
    }
}
