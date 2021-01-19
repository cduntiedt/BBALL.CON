using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.CON.Services.Static
{
    public static class VsDivisionService
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
