using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class ShotClockRangeService
    {
        public static List<string> ShotClockRanges { get { return _ShotClockRanges(); } }
        private static List<string> _ShotClockRanges()
        {
            List<string> shotClockRanges = new List<string>();
            shotClockRanges.Add("24-22");
            shotClockRanges.Add("22-18 Very Early");
            shotClockRanges.Add("18-15 Early");
            shotClockRanges.Add("15-7 Average");
            shotClockRanges.Add("7-4 Late");
            shotClockRanges.Add("4-0 Very Late");
            shotClockRanges.Add("ShotClock Off");

            return shotClockRanges;
        }
    }
}
