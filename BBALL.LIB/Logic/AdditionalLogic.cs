using BBALL.LIB.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BBALL.LIB.Logic
{
    internal class AdditionalLogic
    {
        //skipping loading additional player data for now to lessen the load
        static List<Task> LoadAdditionalPlayerData(string playerID, string season, string seasonType, string perMode)
        {
            var tasks = new List<Task>();
            
            foreach (var measureType in MeasureTypeService.PlayerMeasureTypes)
            {
                tasks.Add(PlayerService.PlayerDashboardByClutch(playerID, season, seasonType, perMode, measureType));
                tasks.Add(PlayerService.PlayerDashboardByGameSplits(playerID, season, seasonType, perMode, measureType));
                tasks.Add(PlayerService.PlayerDashboardByGeneralSplits(playerID, season, seasonType, perMode, measureType));
                tasks.Add(PlayerService.PlayerDashboardByLastNGames(playerID, season, seasonType, perMode, measureType));
                tasks.Add(PlayerService.PlayerDashboardByOpponent(playerID, season, seasonType, perMode, measureType));
                tasks.Add(PlayerService.PlayerDashboardByShootingSplits(playerID, season, seasonType, perMode, measureType));
                tasks.Add(PlayerService.PlayerDashboardByTeamPerformance(playerID, season, seasonType, perMode, measureType));
            }

            return tasks;
        }

        static List<Task> LoadAdditionalGameData(string gameID)
        {
            try
            {
                var tasks = new List<Task>();

                tasks.Add(BoxScoreService.BoxScorePlayerTrackV2(gameID));
                tasks.Add(BoxScoreService.BoxScoreSummaryV2(gameID));
                tasks.Add(BoxScoreService.HustleStatsBoxScore(gameID));

                tasks.Add(BoxScoreService.BoxScoreMatchups(gameID));
                tasks.Add(BoxScoreService.BoxScoreDefensive(gameID));

                tasks.Add(PlayByPlayService.PlayByPlayV2(gameID));

                tasks.Add(GameService.GameRotation(gameID));

                return tasks;
            }
            catch (Exception)
            {
                throw;
            }
        }

        static List<Task> LoadAdditionalTeamData(string teamID, string season, string seasonType)
        {
            var tasks = new List<Task>();
            
            //loop through different team per modes
            foreach (var perMode in PerModeService.TeamPerModes)
            {

                if (seasonType != "Pre Season")
                {
                    tasks.Add(FranchiseService.FranchisePlayers(teamID, perMode, seasonType));
                }

                tasks.Add(TeamService.TeamDashboardByShootingSplits(teamID, season, "Usage", perMode, seasonType));
                tasks.Add(TeamService.TeamPlayerOnOffSummary(teamID, season, "Usage", perMode, seasonType));

                //loop thorough different team measure types
                foreach (var measureType in MeasureTypeService.TeamMeasureTypes)
                {
                    tasks.Add(TeamService.TeamDashLineups(teamID, season, measureType, perMode, seasonType));
                    //tasks.Add(TeamService.TeamDashboardByClutch(teamID, season, measureType, perMode, seasonType));
                    tasks.Add(TeamService.TeamDashboardByGameSplits(teamID, season, measureType, perMode, seasonType));
                    tasks.Add(TeamService.TeamDashboardByGeneralSplits(teamID, season, measureType, perMode, seasonType));
                    //tasks.Add(TeamService.TeamDashboardByLastNGames(teamID, season, measureType, perMode, seasonType));
                    tasks.Add(TeamService.TeamDashboardByOpponent(teamID, season, measureType, perMode, seasonType));
                    tasks.Add(TeamService.TeamDashboardByShootingSplits(teamID, season, measureType, perMode, seasonType));
                    tasks.Add(TeamService.TeamDashboardByTeamPerformance(teamID, season, measureType, perMode, seasonType));
                    tasks.Add(TeamService.TeamDashboardByYearOverYear(teamID, season, measureType, perMode, seasonType));

                    if (measureType == "Opponent" || measureType == "Four Factors")
                    {
                        Console.WriteLine("Skip teamplayerdashboard.");
                    }
                    else
                    {
                        tasks.Add(TeamService.TeamPlayerDashboard(teamID, season, measureType, perMode, seasonType));
                    }
                    tasks.Add(TeamService.TeamPlayerOnOffDetails(teamID, season, measureType, perMode, seasonType));
                    tasks.Add(TeamService.TeamPlayerOnOffSummary(teamID, season, measureType, perMode, seasonType));
                }
            }

            return tasks;
        }
    }
}
