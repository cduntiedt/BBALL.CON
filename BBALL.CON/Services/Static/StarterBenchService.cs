using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.CON.Services.Static
{
    public static class StarterBenchService
    {
        public static List<string> StarterBench { get { return _StarterBench(); } }
        private static List<string> _StarterBench()
        {
            List<string> starterBench = new List<string>();
            starterBench.Add("Starters");
            starterBench.Add("Bench");

            return starterBench;
        }
    }
}
