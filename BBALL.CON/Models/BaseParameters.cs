using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.CON.Models
{
    public class BaseParameters
    {
        public string Conference { get; set; } = null;
        public string DateFrom { get; set; } = null;
        public string DateTo { get; set; } = null;
        public string Division { get; set; } = null;
        public string GameSegment { get; set; } = null;
        public int LastNGames { get; set; } = 0;
        public string LeagueID { get; set; }
        public string MeasureType { get; set; }
        public int OpponentTeamID { get; set; } = 0;
        public string Outcome { get; set; } = null;
        public int PORound { get; set; } = 0;
        public string PaceAdjust { get; set; } = "N";
        public string PerMode { get; set; }
        public int Period { get; set; } = 0;
        public string PlusMinus { get; set; } = "N";
        public string Rank { get; set; } = "N";
        public string Season { get; set; }
        public string SeasonSegment { get; set; } = null;
        public string SeasonType { get; set; }
        public string ShotClockRange { get; set; } = null;
        public int TeamID { get; set; } = 0;
        public string VsConference { get; set; } = null;
        public string VsDivision { get; set; } = null;
    }
}
