using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.CON.Services.Static
{
    public static class LocationService
    {
        public static List<string> Locations { get { return _Locations(); } }
        private static List<string> _Locations()
        {
            List<string> locations = new List<string>();
            locations.Add("Home");
            locations.Add("Road");

            return locations;
        }
    }
}
