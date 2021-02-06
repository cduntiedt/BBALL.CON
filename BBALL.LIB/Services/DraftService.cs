using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.LIB.Helpers;
using static BBALL.LIB.Helpers.ParameterHelper;

namespace BBALL.LIB
{
    public static class DraftService
    {
        public static void AllDraftCombineData(string LeagueID, string SeasonYear)
        {
            DraftCombineDrillResults(LeagueID, SeasonYear);
            DraftCombineStationaryShooting(LeagueID, SeasonYear);
            DraftCombinePlayerAnthro(LeagueID, SeasonYear);
            DraftCombineSpotShooting(LeagueID, SeasonYear);
            DraftCombineStats(LeagueID, SeasonYear);
        }
        public static void DraftBoard(
            string LeagueID = null, 
            string Season = null,
            string TopX = null,
            string TeamID = null,
            string RoundPick = null,
            string RoundNum = null,
            string OverallPick = null,
            string College= null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("TopX", TopX));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("RoundPick", RoundPick));
            parameters.Add(CreateParameterObject("RoundNum", RoundNum));
            parameters.Add(CreateParameterObject("OverallPick", OverallPick));
            parameters.Add(CreateParameterObject("College", College));
            DraftBoard(parameters);
        }

        public static void DraftBoard(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/draftboard/", "draftboard", parameters);
        }

        public static void DraftCombineDrillResults(string LeagueID = null, string SeasonYear = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonHelper.DefaultSeason(SeasonYear)));
            DraftCombineDrillResults(parameters);
        }

        public static void DraftCombineDrillResults(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/draftcombinedrillresults/", "draftcombinedrillresults", parameters);
        }

        public static void DraftCombineStationaryShooting(string LeagueID = null, string SeasonYear = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonHelper.DefaultSeason(Season)));
            DraftCombineStationaryShooting(parameters);
        }

        public static void DraftCombineStationaryShooting(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/draftcombinenonstationaryshooting/", "draftcombinenonstationaryshooting", parameters);
        }

        public static void DraftCombinePlayerAnthro(string LeagueID = null, string SeasonYear = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonHelper.DefaultSeason(SeasonYear)));
            DraftCombinePlayerAnthro(parameters);
        }

        public static void DraftCombinePlayerAnthro(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/draftcombineplayeranthro/", "draftcombineplayeranthro", parameters);
        }

        public static void DraftCombineSpotShooting(string LeagueID = null, string SeasonYear = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonHelper.DefaultSeason(SeasonYear)));
            DraftCombineSpotShooting(parameters);
        }

        public static void DraftCombineSpotShooting(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/draftcombinespotshooting/", "draftcombinespotshooting", parameters);
        }

        public static void DraftCombineStats(string LeagueID = null, string SeasonYear = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonHelper.DefaultSeason(SeasonYear)));
            DraftCombineStats(parameters);
        }

        public static void DraftCombineStats(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/draftcombinestats/", "draftcombinestats", parameters);
        }

        public static void DraftHistory(
            string LeagueID = null
            string Season = null,
            string TopX = null,
            string TeamID = null,
            string RoundPick = null,
            string RoundNum = null,
            string OverallPick = null,
            string College = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueHelper.DefaultLeagueID(LeagueID)));
            parameters.Add(CreateParameterObject("Season", SeasonHelper.DefaultSeason(Season)));
            parameters.Add(CreateParameterObject("TopX", TopX));
            parameters.Add(CreateParameterObject("TeamID", TeamID));
            parameters.Add(CreateParameterObject("RoundPick", RoundPick));
            parameters.Add(CreateParameterObject("RoundNum", RoundNum));
            parameters.Add(CreateParameterObject("OverallPick", OverallPick));
            parameters.Add(CreateParameterObject("College", College));
            DraftHistory(parameters);
        }

        public static void DraftHistory(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/drafthistory/", "drafthistory", parameters);
        }
    }
}
