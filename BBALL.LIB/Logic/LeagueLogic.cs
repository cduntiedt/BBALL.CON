using BBALL.LIB.Helpers;
using BBALL.LIB.Services;
using System;
using System.Collections.Generic;
using System.Text;

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
                DraftService.DraftCombineAll(season);

                foreach (var seasonType in seasonTypes)
                {
                    await TeamService.TeamEstimatedMetrics(season, seasonType);
                    ///season type
                    await LeagueService.LeagueStandingsV3(season, seasonType);

                    
                    foreach (var statType in StatTypeService.StatTypes)
                    {
                        if (seasonType != "Pre Season" && statType != "Tracking")
                        {
                            await HomePageService.HomePageV2(season, seasonType, statType);
                        }
                    }

                    await PlayerService.PlayerEstimatedMetrics(season, seasonType);

                    foreach (var perMode in PerModeService.PerModes)
                    {
                        ///per mode, and season type
                        await LeagueService.LeagueHustleStatsPlayer(season, seasonType, perMode);

                        await LeagueService.LeagueHustleStatsTeam(season, seasonType, perMode);
                        //LeagueService.LeagueSeasonMatchups(season, seasonType, perMode);


                        if(perMode != "Per36" && perMode != "Per48")
                        {
                            await LeagueService.LeagueDashPlayerBioStats(season, seasonType, perMode);

                            if(seasonType != "Pre Season")
                            {
                                await LeagueService.LeagueDashOppPtShot(season, seasonType, perMode);
                                await LeagueService.LeagueDashPlayerPTShot(season, seasonType, perMode);
                                await LeagueService.LeagueDashTeamPtShot(season, seasonType, perMode);
                                await MatchupsService.MatchupsRollup(season, seasonType, perMode);

                                foreach (var ptMeasureType in PTMeasureTypeService.PTMeasureTypes)
                                {
                                    ///season type, per mode, pt measure type
                                    await LeagueService.LeagueDashPTStats(season, seasonType, perMode, ptMeasureType);
                                }

                                foreach (var defensiveCategory in DefenseCategoryService.Categories)
                                {
                                    ///season type, per mode, defensive category
                                    await LeagueService.LeagueDashPTDefend(season, seasonType, perMode, defensiveCategory);
                                    await LeagueService.LeagueDashPTTeamDefend(season, seasonType, perMode, defensiveCategory);
                                }
                            }
                    
                            await LeagueService.LeagueHustleStatsPlayerLeaders(season, seasonType, perMode);
                            await LeagueService.LeagueHustleStatsTeamLeaders(season, seasonType, perMode);
                            await LeadersService.LeagueLeaders(season, seasonType, perMode); ///TODO: loop through stat category
                        }

                        await LeagueService.LeagueDashPlayerShotLocations(season, seasonType, perMode);
                        await LeagueService.LeagueDashTeamShotLocations(season, seasonType, perMode);

                        //PlayerService.PlayerCareerByCollege(season, seasonType, perMode); ///TODO: would need to loop through categories
                        //PlayerService.PlayerCareerByCollegeRollup(season, seasonType, perMode); ///TODO: would need to loop through categories

                        foreach (var measureType in MeasureTypeService.LeagueMeasureTypes)
                        {
                            ///season type, per mode, measure type (teams might be different)
                            if(measureType != "Usage")
                            {
                                await LeagueService.LeagueDashTeamStats(season, seasonType, perMode, measureType);
                            }

                            if (measureType != "Four Factors" && measureType != "Opponent")
                            {
                                await LeagueService.LeagueDashPlayerStats(season, seasonType, perMode, measureType);
                            }

                            await LeagueService.LeagueLineupViz(season, seasonType, perMode, measureType);

                            if(measureType != "Defense" && measureType != "Four Factors")
                            {
                                await LeagueService.LeagueDashPlayerClutch(season, seasonType, perMode, measureType);
                            }


                            if (measureType != "Defense" && measureType != "Usage")
                            {
                                await LeagueService.LeagueDashLineups(season, seasonType, perMode, measureType);
                                await LeagueService.LeagueDashTeamClutch(season, seasonType, perMode, measureType);
                                
                                if(seasonType != "Pre Season")
                                {
                                    await LeagueService.LeaguePlayerOnDetails(season, seasonType, perMode, measureType);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DatabaseHelper.ErrorDocument(ex, "LoadLeagueData", null, "load");
                throw;
            }
        }
    }
}
