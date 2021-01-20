using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.CON.Services.Static
{
    public static class PlayerPositionService
    {
        public static List<string> PlayerPositions { get { return _PlayerPositions(); } }
        private static List<string> _PlayerPositions()
        {
            List<string> positions = new List<string>();
            positions.Add("F");
            positions.Add("C");
            positions.Add("G");
            positions.Add("C-F");
            positions.Add("F-C");
            positions.Add("F-G");
            positions.Add("G-F");

            return positions;
        }
    }
}
