using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Helpers
{
    public static class LeagueHelper
    {
        /// <summary>
        /// Connect to the StatsService
        /// </summary>
        private static StatsHelper _stats = new StatsHelper();

        /// <summary>
        /// Get the default League ID parameter.
        /// </summary>
        /// <param name="id">The league ID value if provided.</param>
        /// <returns>The League ID.</returns>
        public static string DefaultLeagueID(string id)
        {
            if (id == null || id == "")
            {
                return _stats.LeagueID;
            }

            return id;
        }
    }
}
