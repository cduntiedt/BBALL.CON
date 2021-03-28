import { Component, OnInit } from '@angular/core';
import { MatSelectChange } from '@angular/material/select';
import { StatQuery } from 'src/app/models/stat-query';
import { ParametersService } from 'src/app/services/parameters.service';
import { StatsService } from 'src/app/services/stats.service';

@Component({
  selector: 'app-team-games-select',
  templateUrl: './team-games-select.component.html',
  styleUrls: ['./team-games-select.component.scss'],
  providers:[
    StatsService
  ]
})
export class TeamGamesSelectComponent implements OnInit {
  private _query: StatQuery = new StatQuery();
  games: any[] = [];
  filteredGames: any[] = [];

  constructor(private _statsService: StatsService, 
    private _parametersService: ParametersService) { }

  ngOnInit(): void {
    this._statsService.data.subscribe(response => {
      this.games = response;
      this.filteredGames = response;      
    });
    
    this._parametersService.parameters.subscribe(params => {
      this._query.collection = "teamgamelogs";
      this._query.parameters = [
        { "Key": "TeamID", "Value": params.TeamID },
        { "Key": "LeagueID", "Value": params.LeagueID },
        { "Key": "Season", "Value": params.Season },
        { "Key": "SeasonType", "Value": params.SeasonType },
        { "Key": "MeasureType", "Value": params.MeasureType },
        { "Key": "PerMode", "Value": params.PerMode },
        { "Key": "LastNGames", "Value": params.LastNGames },
        { "Key": "Month", "Value": params.Month },
        { "Key": "OppTeamID", "Value": params.OpponentTeamID },
        { "Key": "Period", "Value": params.Period },
        { "Key": "PlayerID", "Value": params.PlayerID },
        { "Key": "DateFrom", "Value": params.DateFrom },
        { "Key": "DateTo", "Value": params.DateTo },
        { "Key": "GameSegment", "Value": params.GameSegment },
        { "Key": "Location", "Value": params.Location },
        { "Key": "Outcome", "Value": params.Outcome },
        { "Key": "PORound", "Value": params.PORound },
        { "Key": "SeasonSegment", "Value": params.SeasonSegment },
        { "Key": "ShotClockRange", "Value": params.ShotClockRange },
        { "Key": "VsConference", "Value": params.VsConference },
        { "Key": "VsDivision", "Value": params.VsDivision },
      ];

      if(this.games.length === 0){
        this._statsService.post(this._query, "TeamGameLogs");
      }else{
        this.filteredGames = this.games.filter(game => game["TEAM_ID"] === params.TeamID);
      }
    });
  }

  selectGame(event: MatSelectChange){
    this._parametersService.setValue("GameID", event.value["GAME_ID"]);
  }

  formatDate(date: string){
    var dt = new Date(date);
    return dt.toLocaleDateString();
  }
}
