using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services
{
    public static class StatTypeService
    {
        /// <summary>
        /// Get a list of stat types.
        /// Works with the HomePageService.
        /// </summary>
        public static List<string> StatTypes { get { return _StatTypes(); } }
        private static List<string> _StatTypes()
        {
            List<string> statTypes = new List<string>();
            statTypes.Add("Traditional");
            statTypes.Add("Advanced");
            statTypes.Add("Tracking");

            return statTypes;
        }
    }
}
