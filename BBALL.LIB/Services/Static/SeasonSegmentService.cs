using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class SeasonSegmentService
    {
        public static List<string> SeasonSegments { get { return _SeasonSegments(); } }
        private static List<string> _SeasonSegments()
        {
            List<string> conferences = new List<string>();
            conferences.Add("Post All-Star");
            conferences.Add("Pre All-Star");

            return conferences;
        }
    }
}
