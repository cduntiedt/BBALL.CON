using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services
{
    public static class PTMeasureTypeService
    {
        public static List<string> PTMeasureTypes { get { return _PTMeasureTypes(); } }
        private static List<string> _PTMeasureTypes()
        {
            List<string> types = new List<string>();
            types.Add("SpeedDistance");
            types.Add("Rebounding");
            types.Add("Possessions");
            types.Add("CatchShoot");
            types.Add("PullUpShot");
            types.Add("Defense");
            types.Add("Drives");
            types.Add("Passing");
            types.Add("ElbowTouch");
            types.Add("PostTouch");
            types.Add("PaintTouch");
            types.Add("Efficiency");
            return types;
        }
    }
}
