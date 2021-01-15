using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.CON.Services
{
    public static class MeasureTypeService
    {
        public static List<string> PlayerMeasureTypes { get { return _PlayerMeasureTypes(); } }
        private static List<string> _PlayerMeasureTypes()
        {
            List<string> measureTypes = new List<string>();
            measureTypes.Add("Base"); //traditional
            measureTypes.Add("Advanced");
            measureTypes.Add("Misc");
            measureTypes.Add("Scoring");
            measureTypes.Add("Usage");
            return measureTypes;
        }

        //used with league services
        public static List<string> TeamMeasureTypes { get { return _TeamMeasureTypes(); } }
        private static List<string> _TeamMeasureTypes()
        {
            List<string> measureTypes = new List<string>();
            measureTypes.Add("Base"); //traditional
            measureTypes.Add("Advanced");
            measureTypes.Add("Misc");
            measureTypes.Add("Four Factors");
            measureTypes.Add("Scoring");
            measureTypes.Add("Usage");
            measureTypes.Add("Opponent");
            return measureTypes;
        }
    }
}
