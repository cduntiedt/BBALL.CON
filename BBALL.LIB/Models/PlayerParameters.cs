using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Models
{
    public class PlayerParameters : BaseParameters
    {
        public string College { get; set; } = null;
        public string Country { get; set; } = null;
        public string DraftPick { get; set; } = null;
        public string DraftYear { get; set; } = null;
        public string GameScope { get; set; } = null;
        public string Height { get; set; } = null;
        public int Month { get; set; } = 0;
        public string PlayerExperience { get; set; } = null;
        public string PlayerPosition { get; set; } = null;
        public string StarterBench { get; set; } = null;
        public int TwoWay { get; set; } = 0;
        public string Weight { get; set; } = null;
    }
}
