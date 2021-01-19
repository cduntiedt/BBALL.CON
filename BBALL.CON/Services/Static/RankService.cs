using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.CON.Services.Static
{
    public static class RankService
    {
        public static List<string> RankTypes { get { return _RankTypes(); } }
        private static List<string> _RankTypes()
        {
            List<string> ranked = new List<string>();
            ranked.Add("Y");
            ranked.Add("N");
            return ranked;
        }
    }
}
