using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class DirectionService
    {
        public static List<string> Directions { get { return _Directions(); } }
        private static List<string> _Directions()
        {
            List<string> conferences = new List<string>();
            conferences.Add("ASC");
            conferences.Add("DSC");

            return conferences;
        }
    }
}
