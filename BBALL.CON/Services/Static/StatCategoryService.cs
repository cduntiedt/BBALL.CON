using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.CON.Services
{
    public static class StatCategoryService
    {
        public static List<string> StatCategories { get { return _StatCategories(); } }
        private static List<string> _StatCategories()
        {
            List<string> measureTypes = new List<string>();
            measureTypes.Add("PTS");
            measureTypes.Add("MIN");
            measureTypes.Add("OREB");
            measureTypes.Add("DREB");
            measureTypes.Add("REB");
            measureTypes.Add("AST");
            measureTypes.Add("STL");
            measureTypes.Add("BLK");
            measureTypes.Add("TOV");
            measureTypes.Add("EFF");
            return measureTypes;
        }
    }
}
