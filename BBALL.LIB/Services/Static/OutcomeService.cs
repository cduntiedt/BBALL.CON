using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class OutcomeService
    {
        public static List<string> Outcomes { get { return _Outcomes(); } }
        private static List<string> _Outcomes()
        {
            List<string> outcomes = new List<string>();
            outcomes.Add("W");
            outcomes.Add("L");

            return outcomes;
        }
    }
}
