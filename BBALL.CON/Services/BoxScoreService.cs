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
            int GameID,
            int EndPeriod = 10, 
            int EndRange = 28800, 
            int RangeType = 0,
            int StartPeriod = 0,
            int StartRange = 0
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID, ParameterType.Int));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod, ParameterType.Int));
            parameters.Add(CreateParameterObject("EndRange", EndRange, ParameterType.Int));
            parameters.Add(CreateParameterObject("RangeType", RangeType, ParameterType.Int));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod, ParameterType.Int));
            parameters.Add(CreateParameterObject("StartRange", StartRange, ParameterType.Int));
            BoxScoreAdvancedV2(parameters);
        }

        public static void BoxScoreAdvancedV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoreadvancedv2/", "boxscoreadvancedv2", parameters);
        }

        public static void BoxScoreDefensive(
            int GameID
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID, ParameterType.Int));
            BoxScoreDefensive(parameters);
        }

        public static void BoxScoreDefensive(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoredefensive/", "boxscoredefensive", parameters);
        }

        public static void BoxScoreFourFactorsV2(
            int GameID,
            int EndPeriod = 10,
            int EndRange = 28800,
            int RangeType = 0,
            int StartPeriod = 0,
            int StartRange = 0
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID, ParameterType.Int));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod, ParameterType.Int));
            parameters.Add(CreateParameterObject("EndRange", EndRange, ParameterType.Int));
            parameters.Add(CreateParameterObject("RangeType", RangeType, ParameterType.Int));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod, ParameterType.Int));
            parameters.Add(CreateParameterObject("StartRange", StartRange, ParameterType.Int));
            BoxScoreFourFactorsV2(parameters);
        }

        public static void BoxScoreFourFactorsV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscorefourfactorsv2/", "boxscorefourfactorsv2", parameters);
        }

        public static void BoxScoreMatchups(
           int GameID
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID, ParameterType.Int));
            BoxScoreMatchups(parameters);
        }

        public static void BoxScoreMatchups(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscorematchups/", "boxscorematchups", parameters);
        }

        public static void BoxScoreMiscV2(
            int GameID,
            int EndPeriod = 10,
            int EndRange = 28800,
            int RangeType = 0,
            int StartPeriod = 0,
            int StartRange = 0
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID, ParameterType.Int));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod, ParameterType.Int));
            parameters.Add(CreateParameterObject("EndRange", EndRange, ParameterType.Int));
            parameters.Add(CreateParameterObject("RangeType", RangeType, ParameterType.Int));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod, ParameterType.Int));
            parameters.Add(CreateParameterObject("StartRange", StartRange, ParameterType.Int));
            BoxScoreMiscV2(parameters);
        }

        public static void BoxScoreMiscV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoremiscv2/", "boxscoremiscv2", parameters);
        }

        public static void BoxScorePlayerTrackV2(
           int GameID
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID, ParameterType.Int));
            BoxScorePlayerTrackV2(parameters);
        }

        public static void BoxScorePlayerTrackV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoreplayertrackv2/", "boxscoreplayertrackv2", parameters);
        }

        public static void BoxScoreScoringV2(
            int GameID,
            int EndPeriod = 10,
            int EndRange = 28800,
            int RangeType = 0,
            int StartPeriod = 0,
            int StartRange = 0
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID, ParameterType.Int));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod, ParameterType.Int));
            parameters.Add(CreateParameterObject("EndRange", EndRange, ParameterType.Int));
            parameters.Add(CreateParameterObject("RangeType", RangeType, ParameterType.Int));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod, ParameterType.Int));
            parameters.Add(CreateParameterObject("StartRange", StartRange, ParameterType.Int));
            BoxScoreScoringV2(parameters);
        }

        public static void BoxScoreScoringV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscorescoringv2/", "boxscorescoringv2", parameters);
        }

        public static void BoxScoreSummaryV2(
           int GameID
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID, ParameterType.Int));
            BoxScoreSummaryV2(parameters);
        }

        public static void BoxScoreSummaryV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoresummaryv2/", "boxscoresummaryv2", parameters);
        }

        public static void BoxScoreTraditionalV2(
            int GameID,
            int EndPeriod = 10,
            int EndRange = 28800,
            int RangeType = 0,
            int StartPeriod = 0,
            int StartRange = 0
        )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID, ParameterType.Int));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod, ParameterType.Int));
            parameters.Add(CreateParameterObject("EndRange", EndRange, ParameterType.Int));
            parameters.Add(CreateParameterObject("RangeType", RangeType, ParameterType.Int));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod, ParameterType.Int));
            parameters.Add(CreateParameterObject("StartRange", StartRange, ParameterType.Int));
            BoxScoreTraditionalV2(parameters);
        }

        public static void BoxScoreTraditionalV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoretraditionalv2/", "boxscoretraditionalv2", parameters);
        }

        public static void BoxScoreUsageV2(
           int GameID,
           int EndPeriod = 10,
           int EndRange = 28800,
           int RangeType = 0,
           int StartPeriod = 0,
           int StartRange = 0
       )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID, ParameterType.Int));
            parameters.Add(CreateParameterObject("EndPeriod", EndPeriod, ParameterType.Int));
            parameters.Add(CreateParameterObject("EndRange", EndRange, ParameterType.Int));
            parameters.Add(CreateParameterObject("RangeType", RangeType, ParameterType.Int));
            parameters.Add(CreateParameterObject("StartPeriod", StartPeriod, ParameterType.Int));
            parameters.Add(CreateParameterObject("StartRange", StartRange, ParameterType.Int));
            BoxScoreUsageV2(parameters);
        }

        public static void BoxScoreUsageV2(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/boxscoreusagev2/", "boxscoreusagev2", parameters);
        }

        public static void HustleStatsBoxScore(
           int GameID
       )
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("GameID", GameID, ParameterType.Int));
            HustleStatsBoxScore(parameters);
        }

        public static void HustleStatsBoxScore(JArray parameters)
        {
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/hustlestatsboxscore/", "hustlestatsboxscore", parameters);
        }
    }
}
