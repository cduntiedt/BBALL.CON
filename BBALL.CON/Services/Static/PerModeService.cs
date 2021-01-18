using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.CON.Services
{
    public static class PerModeService
    {
        public static List<string> PerModes { get { return _PerModes(); } }
        private static List<string> _PerModes()
        {
            List<string> perModes = new List<string>();
            perModes.Add("Totals");
            perModes.Add("PerGame");
            perModes.Add("Per36"); //TO DO: Verify this works with league leaders
            perModes.Add("Per48"); //TO DO: Verify this works
            return perModes;
        }

        public static List<string> TeamPerModes { get { return _TeamPerModes(); } }
        private static List<string> _TeamPerModes()
        {
            List<string> perModes = new List<string>();
            perModes.Add("Totals");
            perModes.Add("PerGame");
            return perModes;
        }

        public static List<string> FranchisePerModes { get { return _FranchisePerModes(); } }
        private static List<string> _FranchisePerModes()
        {
            List<string> perModes = new List<string>();
            perModes.Add("Totals");
            perModes.Add("PerGame");
            perModes.Add("MinutesPer");
            perModes.Add("Per48");
            perModes.Add("Per40");
            perModes.Add("Per36");
            perModes.Add("PerMinute");
            perModes.Add("PerPossession");
            perModes.Add("PerPlay");
            perModes.Add("Per100Possessions");
            perModes.Add("Per100Plays");
            return perModes;
        }
    }
}
