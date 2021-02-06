using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class DistanceRangeService
    {
        public static List<string> DistanceRanges { get { return _DistanceRanges(); } }
        private static List<string> _DistanceRanges()
        {
            List<string> ranges = new List<string>();
            ranges.Add("5ft Range");
            ranges.Add("8ft Range");
            ranges.Add("By Zone");
            return ranges;
        }
    }
}
