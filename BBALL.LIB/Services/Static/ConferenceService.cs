using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class ConferenceService
    {
        public static List<string> Conferences { get { return _Conferences(); } }
        private static List<string> _Conferences()
        {
            List<string> conferences = new List<string>();
            conferences.Add("East");
            conferences.Add("West");

            return conferences;
        }
    }
}
