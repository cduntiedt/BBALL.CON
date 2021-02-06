using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class PlayerExperienceService
    {
        public static List<string> PlayerExperience { get { return _PlayerExperience(); } }
        private static List<string> _PlayerExperience()
        {
            List<string> player = new List<string>();
            player.Add("Rookie");
            player.Add("Sophomore");
            player.Add("Veteran");
            return player;
        }
    }
}
