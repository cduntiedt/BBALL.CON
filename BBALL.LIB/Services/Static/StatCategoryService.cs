using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services
{
    public static class StatCategoryService
    {
        public static List<string> StatCategories { get { return _StatCategories(); } }
        private static List<string> _StatCategories()
        {
            List<string> statCategory = new List<string>();
            statCategory.Add("PTS");
            statCategory.Add("MIN");
            statCategory.Add("OREB");
            statCategory.Add("DREB");
            statCategory.Add("REB");
            statCategory.Add("AST");
            statCategory.Add("STL");
            statCategory.Add("BLK");
            statCategory.Add("TOV");
            statCategory.Add("EFF");
            return statCategory;
        }

        /// <summary>
        /// Get a list of stat categories.
        /// Works with the HomePageService.
        /// </summary>
        public static List<string> HomePageStatCategories { get { return _HomePageStatCategories(); } }

        private static List<string> _HomePageStatCategories()
        {
            List<string> statCategory = new List<string>();
            statCategory.Add("Points");
            statCategory.Add("Rebounds");
            statCategory.Add("Assists");
            statCategory.Add("Defense");
            statCategory.Add("Clutch");
            statCategory.Add("Playmaking");
            statCategory.Add("Efficiency");
            statCategory.Add("Fast Break");
            statCategory.Add("Scoring Breakdown");
            return statCategory;
        }
    }
}
