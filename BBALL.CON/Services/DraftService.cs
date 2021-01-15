using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.CON.Helpers;
using static BBALL.CON.Helpers.ParameterHelper;

namespace BBALL.CON
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
            string LeagueID, 
            string Season,
            string TopX = null,
            string TeamID = null,
            string RoundPick = null,
            string RoundNum = null,
            string OverallPick = null,
            string College= null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("TopX", TopX, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.String));
            parameters.Add(CreateParameterObject("RoundPick", RoundPick, ParameterType.String));
            parameters.Add(CreateParameterObject("RoundNum", RoundNum, ParameterType.String));
            parameters.Add(CreateParameterObject("OverallPick", OverallPick, ParameterType.String));
            parameters.Add(CreateParameterObject("College", College, ParameterType.String));
            DraftBoard(parameters);
        }

        public static void DraftBoard(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/draftboard/", "draftboard", parameters);
        }

        public static void DraftCombineDrillResults(string LeagueID, string SeasonYear)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonYear, ParameterType.String));
            DraftCombineDrillResults(parameters);
        }

        public static void DraftCombineDrillResults(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/draftcombinedrillresults/", "draftcombinedrillresults", parameters);
        }

        public static void DraftCombineStationaryShooting(string LeagueID, string SeasonYear)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonYear, ParameterType.String));
            DraftCombineStationaryShooting(parameters);
        }

        public static void DraftCombineStationaryShooting(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/draftcombinenonstationaryshooting/", "draftcombinenonstationaryshooting", parameters);
        }

        public static void DraftCombinePlayerAnthro(string LeagueID, string SeasonYear)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonYear, ParameterType.String));
            DraftCombinePlayerAnthro(parameters);
        }

        public static void DraftCombinePlayerAnthro(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/draftcombineplayeranthro/", "draftcombineplayeranthro", parameters);
        }

        public static void DraftCombineSpotShooting(string LeagueID, string SeasonYear)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonYear, ParameterType.String));
            DraftCombineSpotShooting(parameters);
        }

        public static void DraftCombineSpotShooting(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/draftcombinespotshooting/", "draftcombinespotshooting", parameters);
        }

        public static void DraftCombineStats(string LeagueID, string SeasonYear)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonYear", SeasonYear, ParameterType.String));
            DraftCombineStats(parameters);
        }

        public static void DraftCombineStats(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/draftcombinestats/", "draftcombinestats", parameters);
        }

        public static void DraftHistory(
            string LeagueID,
            string Season = null,
            string TopX = null,
            string TeamID = null,
            string RoundPick = null,
            string RoundNum = null,
            string OverallPick = null,
            string College = null)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", LeagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("Season", Season, ParameterType.String));
            parameters.Add(CreateParameterObject("TopX", TopX, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", TeamID, ParameterType.String));
            parameters.Add(CreateParameterObject("RoundPick", RoundPick, ParameterType.String));
            parameters.Add(CreateParameterObject("RoundNum", RoundNum, ParameterType.String));
            parameters.Add(CreateParameterObject("OverallPick", OverallPick, ParameterType.String));
            parameters.Add(CreateParameterObject("College", College, ParameterType.String));
            DraftHistory(parameters);
        }

        public static void DraftHistory(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/drafthistory/", "drafthistory", parameters);
        }
    }
}
