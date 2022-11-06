using BBALL.LIB.Helpers;
using BBALL.LIB.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BBALL.LIB.Logic
{
    public static class LeagueLogic
    {
        /// <summary>
        /// Load entire league data.
        /// </summary>
        /// <param name="season">The season to load.</param>
        /// <param name="seasonTypes">The season types.</param>
        public static async void LoadLeagueData(string season, List<string> seasonTypes)
        {
            try
            {
                var tasks = new List<Task>();

                DraftService.DraftCombineAll(season);

                foreach (var seasonType in seasonTypes)
                {
                    tasks.Add(TeamService.TeamEstimatedMetrics(season, seasonType));
                    ///season type
                    tasks.Add(LeagueService.LeagueStandingsV3(season, seasonType));

                    
                    foreach (var statType in StatTypeService.StatTypes)
                    {
                        if (seasonType != "Pre Season" && statType != "Tracking")
                        {
                            tasks.Add(HomePageService.HomePageV2(season, seasonType, statType));
                        }
                    }

                    tasks.Add(PlayerService.PlayerEstimatedMetrics(season, seasonType));

                    foreach (var perMode in PerModeService.PerModes)
                    {
                        ///per mode, and season type
                        tasks.Add(LeagueService.LeagueHustleStatsPlayer(season, seasonType, perMode));

                        tasks.Add(LeagueService.LeagueHustleStatsTeam(season, seasonType, perMode));
                        //LeagueService.LeagueSeasonMatchups(season, seasonType, perMode);

                        if(perMode != "Per36" && perMode != "Per48")
                        {
                            tasks.Add(LeagueService.LeagueDashPlayerBioStats(season, seasonType, perMode));

                            if(seasonType != "Pre Season")
                            {
                                tasks.Add(LeagueService.LeagueDashOppPtShot(season, seasonType, perMode));
                                tasks.Add(LeagueService.LeagueDashPlayerPTShot(season, seasonType, perMode));
                                tasks.Add(LeagueService.LeagueDashTeamPtShot(season, seasonType, perMode));
                                tasks.Add(MatchupsService.MatchupsRollup(season, seasonType, perMode));

                                foreach (var ptMeasureType in PTMeasureTypeService.PTMeasureTypes)
                                {
                                    ///season type, per mode, pt measure type
                                    tasks.Add(LeagueService.LeagueDashPTStats(season, seasonType, perMode, ptMeasureType));
                                }

                                foreach (var defensiveCategory in DefenseCategoryService.Categories)
                                {
                                    ///season type, per mode, defensive category
                                    tasks.Add(LeagueService.LeagueDashPTDefend(season, seasonType, perMode, defensiveCategory));
                                    tasks.Add(LeagueService.LeagueDashPTTeamDefend(season, seasonType, perMode, defensiveCategory));
                                }
                            }
                    
                            tasks.Add(LeagueService.LeagueHustleStatsPlayerLeaders(season, seasonType, perMode));
                            tasks.Add(LeagueService.LeagueHustleStatsTeamLeaders(season, seasonType, perMode));
                            tasks.Add(LeadersService.LeagueLeaders(season, seasonType, perMode)); ///TODO: loop through stat category
                        }

                        tasks.Add(LeagueService.LeagueDashPlayerShotLocations(season, seasonType, perMode));
                        tasks.Add(LeagueService.LeagueDashTeamShotLocations(season, seasonType, perMode));

                        //PlayerService.PlayerCareerByCollege(season, seasonType, perMode); ///TODO: would need to loop through categories
                        //PlayerService.PlayerCareerByCollegeRollup(season, seasonType, perMode); ///TODO: would need to loop through categories

                        foreach (var measureType in MeasureTypeService.LeagueMeasureTypes)
                        {
                            ///season type, per mode, measure type (teams might be different)
                            if(measureType != "Usage")
                            {
                                tasks.Add(LeagueService.LeagueDashTeamStats(season, seasonType, perMode, measureType));
                            }

                            if (measureType != "Four Factors" && measureType != "Opponent")
                            {
                                tasks.Add(LeagueService.LeagueDashPlayerStats(season, seasonType, perMode, measureType));
                            }

                            tasks.Add(LeagueService.LeagueLineupViz(season, seasonType, perMode, measureType));

                            if(measureType != "Defense" && measureType != "Four Factors" && measureType != "Opponent")
                            {
                                tasks.Add(LeagueService.LeagueDashPlayerClutch(season, seasonType, perMode, measureType));
                            }


                            if (measureType != "Defense" && measureType != "Usage")
                            {
                                tasks.Add(LeagueService.LeagueDashLineups(season, seasonType, perMode, measureType));
                                tasks.Add(LeagueService.LeagueDashTeamClutch(season, seasonType, perMode, measureType));
                                
                                if(seasonType != "Pre Season")
                                {
                                    tasks.Add(LeagueService.LeaguePlayerOnDetails(season, seasonType, perMode, measureType));
                                }
                            }
                        }
                    }
                }

                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                DatabaseHelper.ErrorDocument(ex, "LoadLeagueData", null, "load");
                throw;
            }
        }
    }
}
