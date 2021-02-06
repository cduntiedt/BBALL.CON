﻿using BBALL.LIB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBALL.LIB.Helpers
{
    public static class SeasonHelper
    {
        /// <summary>
        /// Get the default season parameter.
        /// </summary>
        /// <param name="season">The season if provided.</param>
        /// <returns>The season year.</returns>
        public static string DefaultSeason(string season = null)
        {
            if (season == null || season == "")
            {
                return SeasonService.CurrentSeason.FirstOrDefault();
            }

            return season;
        }
    }
}