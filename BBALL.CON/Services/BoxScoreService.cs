using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BBALL.CON.Helpers;
using static BBALL.CON.Helpers.ParameterHelper;

namespace BBALL.CON.Services
{
    public static class BoxScoreService
    {
        public static void BoxScoreAdvancedV2(
            string GameID,
            string EndPeriod = "10", 
            string EndRange = "28800", 
            string RangeType = "0",
            string StartPeriod = "0",
            string StartRange = "0"
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            parameters.Add(CreateParameterObject("EndRange", EndRange));
            parameters.Add(CreateParameterObject("RangeType", RangeType));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("StartRange", StartRange));
            BoxScoreAdvancedV2(parameters);
        }

        public static void BoxScoreAdvancedV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoreadvancedv2/", "boxscoreadvancedv2", parameters);
        }

        public static void BoxScoreDefensive(
            string GameID
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            BoxScoreDefensive(parameters);
        }

        public static void BoxScoreDefensive(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoredefensive/", "boxscoredefensive", parameters);
        }

        public static void BoxScoreFourFactorsV2(
            string GameID,
            string EndPeriod = "10",
            string EndRange = "28800",
            string RangeType = "0",
            string StartPeriod = "0",
            string StartRange = "0"
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            parameters.Add(CreateParameterObject("EndRange", EndRange));
            parameters.Add(CreateParameterObject("RangeType", RangeType));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("StartRange", StartRange));
            BoxScoreFourFactorsV2(parameters);
        }

        public static void BoxScoreFourFactorsV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscorefourfactorsv2/", "boxscorefourfactorsv2", parameters);
        }

        public static void BoxScoreMatchups(
           string GameID
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            BoxScoreMatchups(parameters);
        }

        public static void BoxScoreMatchups(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscorematchups/", "boxscorematchups", parameters);
        }

        public static void BoxScoreMiscV2(
            string GameID,
            string EndPeriod = "10",
            string EndRange = "28800",
            string RangeType = "0",
            string StartPeriod = "0",
            string StartRange = "0"
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            parameters.Add(CreateParameterObject("EndRange", EndRange));
            parameters.Add(CreateParameterObject("RangeType", RangeType));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("StartRange", StartRange));
            BoxScoreMiscV2(parameters);
        }

        public static void BoxScoreMiscV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoremiscv2/", "boxscoremiscv2", parameters);
        }

        public static void BoxScorePlayerTrackV2(
           string GameID
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            BoxScorePlayerTrackV2(parameters);
        }

        public static void BoxScorePlayerTrackV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoreplayertrackv2/", "boxscoreplayertrackv2", parameters);
        }

        public static void BoxScoreScoringV2(
            string GameID,
            string EndPeriod = "10",
            string EndRange = "28800",
            string RangeType = "0",
            string StartPeriod = "0",
            string StartRange = "0"
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            parameters.Add(CreateParameterObject("EndRange", EndRange));
            parameters.Add(CreateParameterObject("RangeType", RangeType));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("StartRange", StartRange));
            BoxScoreScoringV2(parameters);
        }

        public static void BoxScoreScoringV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscorescoringv2/", "boxscorescoringv2", parameters);
        }

        public static void BoxScoreSummaryV2(
           string GameID
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            BoxScoreSummaryV2(parameters);
        }

        public static void BoxScoreSummaryV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoresummaryv2/", "boxscoresummaryv2", parameters);
        }

        public static void BoxScoreTraditionalV2(
            string GameID,
            string EndPeriod = "10",
            string EndRange = "28800",
            string RangeType = "0",
            string StartPeriod = "0",
            string StartRange = "0"
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            parameters.Add(CreateParameterObject("EndRange", EndRange));
            parameters.Add(CreateParameterObject("RangeType", RangeType));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("StartRange", StartRange));
            BoxScoreTraditionalV2(parameters);
        }

        public static void BoxScoreTraditionalV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoretraditionalv2/", "boxscoretraditionalv2", parameters);
        }

        public static void BoxScoreUsageV2(
           string GameID,
           string EndPeriod = "10",
           string EndRange = "28800",
           string RangeType = "0",
           string StartPeriod = "0",
           string StartRange = "0"
       )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod));
            parameters.Add(CreateParameterObject("EndRange", EndRange));
            parameters.Add(CreateParameterObject("RangeType", RangeType));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod));
            parameters.Add(CreateParameterObject("StartRange", StartRange));
            BoxScoreUsageV2(parameters);
        }

        public static void BoxScoreUsageV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoreusagev2/", "boxscoreusagev2", parameters);
        }

        public static void HustleStatsBoxScore(
           string GameID
       )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID));
            HustleStatsBoxScore(parameters);
        }

        public static void HustleStatsBoxScore(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/hustlestatsboxscore/", "hustlestatsboxscore", parameters);
        }
    }
}
