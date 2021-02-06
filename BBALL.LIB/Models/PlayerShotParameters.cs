using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Models
{
    public class PlayerShotParameters : PlayerParameters
    {
        public string CloseDefDistRange { get; set; } = null;
        public string DribbleRange { get; set; } = null;
        public string GeneralRange { get; set; } = null;
        public string ShotDistRange { get; set; } = null;
        public string TouchTimeRange { get; set; } = null;
    }
}
