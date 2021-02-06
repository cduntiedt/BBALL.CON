using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Helpers
{
    public static class EndpointHelper
    {
        public enum Endpoint
        {
            allstarballotpredictor,
            boxscoreadvancedv2,
            boxscorefourfactorsv2,
            boxscoremiscv2,
            boxscoreplayertrackv2,
            boxscorescoringv2,
            boxscoresummaryv2,
            boxscoretraditionalv2,
            boxscoreusagev2,
            commonteamyears,
            commonallplayers,
            commonplayerinfo,
            commonplayoffseries,
            commonteamroster,
            draftcombinedrillresults,
            draftcombinenonstationaryshooting,
            draftcombineplayeranthro,
            draftcombinespotshooting,
            draftcombinestats,
            drafthistory,
            franchisehistory,
            homepageleaders,
            homepagev2,
            leaderstiles,
            leaguedashlineups,
            leaguedashplayerbiostats,
            leaguedashplayerclutch,
            leaguedashplayerptshot,
            leaguedashplayershotlocations,
            leaguedashplayerstats,
            leaguedashptdefend,
            leaguedashptteamdefend,
            leaguedashteamclutch,
            leaguedashteamptshot,
            leaguedashteamshotlocations,
            leaguedashteamstats,
            leagueleaders,
            playbyplay,
            playbyplayv2,
            playercareerstats,
            playercompare,
            playerdashboardbyclutch,
            playerdashboardbygamesplits,
            playerdashboardbygeneralsplits,
            playerdashboardbylastngames,
            playerdashboardbyopponent,
            playerdashboardbyshootingsplits,
            playerdashboardbyteamperformance,
            playerdashboardbyyearoveryear,
            playerdashptpass,
            playerdashptreb,
            playerdashptshotdefend,
            playerdashptshots,
            playergamelog,
            playerprofile,
            playerprofilev2,
            playersvsplayers,
            playervsplayer,
            playoffpicture,
            scoreboard,
            scoreboardV2,
            shotchartdetail,
            shotchartlineupdetail,
            teamdashboardbyclutch,
            teamdashboardbygamesplits,
            teamdashboardbygeneralsplits,
            teamdashboardbylastngames,
            teamdashboardbyopponent,
            teamdashboardbyshootingsplits,
            teamdashboardbyteamperformance,
            teamdashboardbyyearoveryear,
            teamdashlineups,
            teamdashptpass,
            teamdashptreb,
            teamdashptshots,
            teamgamelog,
            teaminfocommon,
            teamplayerdashboard,
            teamplayeronoffdetails,
            teamplayeronoffsummary,
            teamvsplayer,
            teamyearbyyearstats,
            videoStatus
        }

        public static JObject GetEndpoint(Endpoint endpoint)
        {
            JObject values = new JObject();

            switch (endpoint)
            {
                case Endpoint.allstarballotpredictor:
                    break;
                case Endpoint.boxscoreadvancedv2:
                    break;
                case Endpoint.boxscorefourfactorsv2:
                    break;
                case Endpoint.boxscoremiscv2:
                    break;
                case Endpoint.boxscoreplayertrackv2:
                    break;
                case Endpoint.boxscorescoringv2:
                    break;
                case Endpoint.boxscoresummaryv2:
                    break;
                case Endpoint.boxscoretraditionalv2:
                    break;
                case Endpoint.boxscoreusagev2:
                    break;
                case Endpoint.commonteamyears:
                    break;
                case Endpoint.commonallplayers:
                    break;
                case Endpoint.commonplayerinfo:
                    break;
                case Endpoint.commonplayoffseries:
                    break;
                case Endpoint.commonteamroster:
                    break;
                case Endpoint.draftcombinedrillresults:
                    break;
                case Endpoint.draftcombinenonstationaryshooting:
                    break;
                case Endpoint.draftcombineplayeranthro:
                    break;
                case Endpoint.draftcombinespotshooting:
                    break;
                case Endpoint.draftcombinestats:
                    break;
                case Endpoint.drafthistory:
                    break;
                case Endpoint.franchisehistory:
                    break;
                case Endpoint.homepageleaders:
                    break;
                case Endpoint.homepagev2:
                    break;
                case Endpoint.leaderstiles:
                    break;
                case Endpoint.leaguedashlineups:
                    break;
                case Endpoint.leaguedashplayerbiostats:
                    break;
                case Endpoint.leaguedashplayerclutch:
                    break;
                case Endpoint.leaguedashplayerptshot:
                    break;
                case Endpoint.leaguedashplayershotlocations:
                    break;
                case Endpoint.leaguedashplayerstats:
                    break;
                case Endpoint.leaguedashptdefend:
                    break;
                case Endpoint.leaguedashptteamdefend:
                    break;
                case Endpoint.leaguedashteamclutch:
                    break;
                case Endpoint.leaguedashteamptshot:
                    break;
                case Endpoint.leaguedashteamshotlocations:
                    break;
                case Endpoint.leaguedashteamstats:
                    break;
                case Endpoint.leagueleaders:
                    break;
                case Endpoint.playbyplay:
                    break;
                case Endpoint.playbyplayv2:
                    break;
                case Endpoint.playercareerstats:
                    break;
                case Endpoint.playercompare:
                    break;
                case Endpoint.playerdashboardbyclutch:
                    break;
                case Endpoint.playerdashboardbygamesplits:
                    break;
                case Endpoint.playerdashboardbygeneralsplits:
                    break;
                case Endpoint.playerdashboardbylastngames:
                    break;
                case Endpoint.playerdashboardbyopponent:
                    break;
                case Endpoint.playerdashboardbyshootingsplits:
                    break;
                case Endpoint.playerdashboardbyteamperformance:
                    break;
                case Endpoint.playerdashboardbyyearoveryear:
                    break;
                case Endpoint.playerdashptpass:
                    break;
                case Endpoint.playerdashptreb:
                    break;
                case Endpoint.playerdashptshotdefend:
                    break;
                case Endpoint.playerdashptshots:
                    break;
                case Endpoint.playergamelog:
                    break;
                case Endpoint.playerprofile:
                    break;
                case Endpoint.playerprofilev2:
                    break;
                case Endpoint.playersvsplayers:
                    break;
                case Endpoint.playervsplayer:
                    break;
                case Endpoint.playoffpicture:
                    break;
                case Endpoint.scoreboard:
                    break;
                case Endpoint.scoreboardV2:
                    break;
                case Endpoint.shotchartdetail:
                    break;
                case Endpoint.shotchartlineupdetail:
                    break;
                case Endpoint.teamdashboardbyclutch:
                    break;
                case Endpoint.teamdashboardbygamesplits:
                    break;
                case Endpoint.teamdashboardbygeneralsplits:
                    break;
                case Endpoint.teamdashboardbylastngames:
                    break;
                case Endpoint.teamdashboardbyopponent:
                    break;
                case Endpoint.teamdashboardbyshootingsplits:
                    break;
                case Endpoint.teamdashboardbyteamperformance:
                    break;
                case Endpoint.teamdashboardbyyearoveryear:
                    break;
                case Endpoint.teamdashlineups:
                    break;
                case Endpoint.teamdashptpass:
                    break;
                case Endpoint.teamdashptreb:
                    break;
                case Endpoint.teamdashptshots:
                    break;
                case Endpoint.teamgamelog:
                    break;
                case Endpoint.teaminfocommon:
                    break;
                case Endpoint.teamplayerdashboard:
                    break;
                case Endpoint.teamplayeronoffdetails:
                    break;
                case Endpoint.teamplayeronoffsummary:
                    break;
                case Endpoint.teamvsplayer:
                    break;
                case Endpoint.teamyearbyyearstats:
                    break;
                case Endpoint.videoStatus:
                    break;
                default:
                    break;
            }

            return values;
        }
    }
}
