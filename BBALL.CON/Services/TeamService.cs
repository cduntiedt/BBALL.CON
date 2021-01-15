using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using System.Linq;
using BBALL.CON.Helpers;
using static BBALL.CON.Helpers.ParameterHelper;

namespace BBALL.CON
{
    public static class TeamService
    {
        /// <summary>
        /// Get a list of team IDs
        /// </summary>
        /// <returns>A list of integer</returns>
        public static List<int> GetTeamIDs()
        {
            JArray defaultParameters = new JArray();
            defaultParameters.Add(LeagueID);
            JObject teamsCollection = DatabaseHelper.GetDocument("commonteamyears", defaultParameters);
            JArray teamsResultSets = teamsCollection["resultSets"].ToObject<JArray>();

            JObject teamYears = teamsResultSets[0].ToObject<JObject>();

            JArray teamData = teamsResultSets[0]["data"].ToObject<JArray>();
            var teams = teamData.Select(x => (int)x["TEAM_ID"]).Distinct().ToList();

            return teams;
        }

        public static void CommonTeamYears(string leagueID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", leagueID, ParameterType.String));
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/commonteamyears/", "commonteamyears", parameters);
        }

        public static void FranchiseHistory(string leagueID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", leagueID, ParameterType.String));
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/franchisehistory/", "franchisehistory", parameters);
        }

        public static void CommonTeamRoster(int teamID, string season)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", teamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Season", season, ParameterType.String));
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/commonteamroster/", "commonteamroster", parameters);
        }

        public static void TeamDashboardByClutch()
        {

        }

        public static void TeamDashboardByGameSplits()
        {

        }

        public static void TeamDashboardByGeneralSplits()
        {

        }

        public static void TeamDashboardByLastNGames()
        {

        }

        public static void TeamDashboardByOpponent()
        {

        }

        public static void TeamDashboardByShootingSplits()
        {

        }

        public static void TeamDashboardByTeamPerformance()
        {

        }
        public static void TeamDashboardByTeamYearOverYear()
        {

        }

        public static void TeamDashLineups()
        {

        }

        public static void TeamDashPTPass()
        {

        }

        public static void TeamDashPTReb()
        {

        }

        public static void TeamGameLog(int teamID, string season, string seasonType)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", teamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Season", season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", seasonType, ParameterType.String));

            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teamgamelog/", "teamgamelog", parameters);
        }

        public static void TeamInfoCommon(int teamID, string season, string seasonType, string leagueID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("TeamID", teamID, ParameterType.Int));
            parameters.Add(CreateParameterObject("Season", season, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", seasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("LeagueID", leagueID, ParameterType.String));

            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teaminfocommon/", "teaminfocommon", parameters);
        }

        public static void TeamPlayerDashboar()
        {

        }

        public static void TeamPlayerOnOffDetails()
        {

        }

        public static void TeamPlayerOnOffSummary()
        {

        }
        public static void TeamYearByYearStats(string leagueID, string seasonType, string perMode, int teamID)
        {
            JArray parameters = new JArray();
            parameters.Add(CreateParameterObject("LeagueID", leagueID, ParameterType.String));
            parameters.Add(CreateParameterObject("SeasonType", seasonType, ParameterType.String));
            parameters.Add(CreateParameterObject("PerMode", perMode, ParameterType.String));
            parameters.Add(CreateParameterObject("TeamID", teamID, ParameterType.Int));
            DatabaseHelper.UpdateDatabase("https://stats.nba.com/stats/teamyearbyyearstats/", "teamyearbyyearstats", parameters);
        }

        public static List<KeyValuePair<int, string>> Teams { get { return _Teams(); } }
            

        private static List<KeyValuePair<int, string>> _Teams()
        {
            List<KeyValuePair<int, string>> teams = new List<KeyValuePair<int, string>>();
            teams.Add(KeyValuePair.Create(1610612737, "Atlanta Hawks"));
            teams.Add(KeyValuePair.Create(1610612738, "Boston Celtics"));
            teams.Add(KeyValuePair.Create(1610612751, "Brooklyn Nets"));
            teams.Add(KeyValuePair.Create(1610612766, "Charlotte Hornets"));
            teams.Add(KeyValuePair.Create(1610612741, "Chicago Bulls"));
            teams.Add(KeyValuePair.Create(1610612739, "Cleveland Cavaliers"));
            teams.Add(KeyValuePair.Create(1610612742, "Dallas Mavericks"));
            teams.Add(KeyValuePair.Create(1610612743, "Denver Nuggets"));
            teams.Add(KeyValuePair.Create(1610612765, "Detroit Pistons"));
            teams.Add(KeyValuePair.Create(1610612744, "Golden State Warriors"));
            teams.Add(KeyValuePair.Create(1610612745, "Houston Rockets"));
            teams.Add(KeyValuePair.Create(1610612754, "Indiana Pacers"));
            teams.Add(KeyValuePair.Create(1610612746, "Los Angeles Clippers"));
            teams.Add(KeyValuePair.Create(1610612747, "Los Angeles Lakers"));
            teams.Add(KeyValuePair.Create(1610612763, "Memphis Grizzlies"));
            teams.Add(KeyValuePair.Create(1610612748, "Miami Heat"));
            teams.Add(KeyValuePair.Create(1610612749, "Milwaukee Bucks"));
            teams.Add(KeyValuePair.Create(1610612750, "Minnesota Timberwolves"));
            teams.Add(KeyValuePair.Create(1610612740, "New Orleans Pelicans"));
            teams.Add(KeyValuePair.Create(1610612752, "New York Knicks"));
            teams.Add(KeyValuePair.Create(1610612760, "Oklahoma City Thunder"));
            teams.Add(KeyValuePair.Create(1610612753, "Orlando Magic"));
            teams.Add(KeyValuePair.Create(1610612755, "Philadelphia 76ers"));
            teams.Add(KeyValuePair.Create(1610612756, "Phoenix Suns"));
            teams.Add(KeyValuePair.Create(1610612757, "Portland Trail Blazers"));
            teams.Add(KeyValuePair.Create(1610612758, "Sacramento Kings"));
            teams.Add(KeyValuePair.Create(1610612759, "San Antonio Spurs"));
            teams.Add(KeyValuePair.Create(1610612761, "Toronto Raptors"));
            teams.Add(KeyValuePair.Create(1610612762, "Utah Jazz"));
            teams.Add(KeyValuePair.Create(1610612764, "Washington Wizards"));
            return teams;
        }
    }
}
