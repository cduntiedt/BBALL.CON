using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services.Static
{
    public static class DefenseCategoryService
    {
        public static List<string> Categories { get { return _Categories(); } }
        private static List<string> _Categories()
        {
            List<string> categories = new List<string>();
            categories.Add("Overall");
            categories.Add("3 Pointers");
            categories.Add("2 Pointers");
            categories.Add("Less Than 6Ft");
            categories.Add("Less Than 10Ft");
            categories.Add("Greater Than 15Ft");
            return categories;
        }
    }
}
