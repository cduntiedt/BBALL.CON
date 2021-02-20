using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Services
{
    public static class ContextMeasureService
    {
        public static List<string> ContextMeasures { get { return _ContextMeasures(); } }
        private static List<string> _ContextMeasures()
        {
            List<string> measure = new List<string>();
            measure.Add("FGM");
            measure.Add("FGA"); 
            measure.Add("FG_PCT"); 
            measure.Add("FG3M"); 
            measure.Add("FG3A"); 
            measure.Add("FG3_PCT"); 
            measure.Add("FTM"); 
            measure.Add("FTA"); 
            measure.Add("OREB"); 
            measure.Add("DREB"); 
            measure.Add("AST"); 
            measure.Add("FGM_AST"); 
            measure.Add("FG3_AST"); 
            measure.Add("STL"); 
            measure.Add("BLK"); 
            measure.Add("BLKA"); 
            measure.Add("TOV"); 
            measure.Add("PF"); 
            measure.Add("PFD"); 
            measure.Add("POSS_END_FT"); 
            measure.Add("PTS_PAINT"); 
            measure.Add("PTS_FB"); 
            measure.Add("PTS_OFF_TOV"); 
            measure.Add("PTS_2ND_CHANCE"); 
            measure.Add("REB"); 
            measure.Add("TM_FGM"); 
            measure.Add("TM_FGA"); 
            measure.Add("TM_FG3M"); 
            measure.Add("TM_FG3A"); 
            measure.Add("TM_FTM"); 
            measure.Add("TM_FTA"); 
            measure.Add("TM_OREB"); 
            measure.Add("TM_DREB"); 
            measure.Add("TM_REB"); 
            measure.Add("TM_TEAM_REB"); 
            measure.Add("TM_AST"); 
            measure.Add("TM_STL"); 
            measure.Add("TM_BLK"); 
            measure.Add("TM_BLKA"); 
            measure.Add("TM_TOV"); 
            measure.Add("TM_TEAM_TOV"); 
            measure.Add("TM_PF"); 
            measure.Add("TM_PFD"); 
            measure.Add("TM_PTS"); 
            measure.Add("TM_PTS_PAINT"); 
            measure.Add("TM_PTS_FB"); 
            measure.Add("TM_PTS_OFF_TOV"); 
            measure.Add("TM_PTS_2ND_CHANCE"); 
            measure.Add("TM_FGM_AST"); 
            measure.Add("TM_FG3_AST"); 
            measure.Add("TM_POSS_END_FT"); 
            measure.Add("OPP_FGM"); 
            measure.Add("OPP_FGA"); 
            measure.Add("OPP_FG3M"); 
            measure.Add("OPP_FG3A"); 
            measure.Add("OPP_FTM"); 
            measure.Add("OPP_FTA"); 
            measure.Add("OPP_OREB"); 
            measure.Add("OPP_DREB"); 
            measure.Add("OPP_REB"); 
            measure.Add("OPP_TEAM_REB"); 
            measure.Add("OPP_AST"); 
            measure.Add("OPP_STL"); 
            measure.Add("OPP_BLK"); 
            measure.Add("OPP_BLKA"); 
            measure.Add("OPP_TOV"); 
            measure.Add("OPP_TEAM_TOV"); 
            measure.Add("OPP_PF"); 
            measure.Add("OPP_PFD"); 
            measure.Add("OPP_PTS"); 
            measure.Add("OPP_PTS_PAINT"); 
            measure.Add("OPP_PTS_FB"); 
            measure.Add("OPP_PTS_OFF_TOV"); 
            measure.Add("OPP_PTS_2ND_CHANCE"); 
            measure.Add("OPP_FGM_AST"); 
            measure.Add("OPP_FG3_AST"); 
            measure.Add("OPP_POSS_END_FT"); 
            measure.Add("PTS");

            return measure;
        }
    }
}
