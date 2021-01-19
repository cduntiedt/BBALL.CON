using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.CON.Services.Static
{
    public static class PaceAdjustService
    {
        public static List<string> PaceAdjustTypes { get { return _PaceAdjustTypes(); } }
        private static List<string> _PaceAdjustTypes()
        {
            List<string> paceAdjust = new List<string>();
            paceAdjust.Add("Y");
            paceAdjust.Add("N");
            return paceAdjust;
        }
    }
}
