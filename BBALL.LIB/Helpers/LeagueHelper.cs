using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Helpers
{
    public static class LeagueHelper
    {
        /// <summary>
        /// Get the default League ID parameter.
        /// </summary>
        /// <param name="id">The league ID value if provided.</param>
        /// <returns>The League ID.</returns>
        public static string DefaultLeagueID(string id = null)
        {
            if (id == null || id == "")
            {
                return StatsHelper.LeagueID;
            }

            return id;
        }
    }
}
