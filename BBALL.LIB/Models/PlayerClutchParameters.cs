using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Models
{
    public class PlayerClutchParameters : PlayerParameters
    {
        public string AheadBehind { get; set; } = "Ahead or Behind";
        public string ClutchTime { get; set; } = "Last 5 Minutes";
        public int PointDiff { get; set; } = 5;
    }
}
