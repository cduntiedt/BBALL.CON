using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class DivisionService
    {
        public static List<string> Divisions { get { return _Divisions(); } }
        private static List<string> _Divisions()
        {
            List<string> divisions = new List<string>();
            divisions.Add("Atlantic");
            divisions.Add("Central");
            divisions.Add("Northwest");
            divisions.Add("Pacific");
            divisions.Add("Southeast");
            divisions.Add("Southwest");
            divisions.Add("East");
            divisions.Add("West");

            return divisions;
        }
    }
}
