using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class GameSegmentServices
    {
        public static List<string> GameSegments { get { return _GameSegments(); } }
        private static List<string> _GameSegments()
        {
            List<string> gameSegments = new List<string>();
            gameSegments.Add("First Half");
            gameSegments.Add("Overtime");
            gameSegments.Add("Second Half");

            return gameSegments;
        }
    }
}
