import { Component, OnInit } from '@angular/core';
import { StatQuery } from 'src/app/models/stat-query';
import { ParametersService } from 'src/app/services/parameters.service';
import { StatsService } from 'src/app/services/stats.service';

@Component({
  selector: 'app-videos-table',
  templateUrl: './videos-table.component.html',
  styleUrls: ['./videos-table.component.scss'],
  providers:[
    StatsService
  ]
})
export class VideosTableComponent implements OnInit {
  private _query: StatQuery = new StatQuery();
  public playlist: any[] = [];
  public playColumns: string[] = ['HOMEDESCRIPTION', 'PERIOD', 'PCTIMESTRING', 'VISITORDESCRIPTION',];

  constructor(private _statsService: StatsService, private _parametersService: ParametersService) { }

  ngOnInit(): void {
    this._statsService.values.subscribe(response => {
      if(response !== null){
        console.log(response);
        this.playlist = response["resultSets"]["playlist"];
      }
    });
    
    this._parametersService.parameters.subscribe(params => {
      if(params.GameID !== null){
        this._query.collection = "videodetailsasset";
        this._query.parse = false;
        this._query.timeout = 45;
        this._query.parameters = [
          { "Key": "AheadBehind", "Value": params.AheadBehind },
          { "Key": "ClutchTime", "Value": params.ClutchTime },
          { "Key": "ContextFilter", "Value": params.ContextFilter },
          { "Key": "ContextMeasure", "Value": "FGA" }, //params.ContextMeasure }, //FGA
          { "Key": "DateFrom", "Value": params.DateFrom },
          { "Key": "DateTo", "Value": params.DateTo },
          { "Key": "EndPeriod", "Value": params.EndPeriod },
          { "Key": "EndRange", "Value": params.EndRange },
          { "Key": "GameID", "Value": params.GameID },
          { "Key": "GameSegment", "Value": params.GameSegment },
          { "Key": "LastNGames", "Value": this.setDefaultParameterValue(params.LastNGames) },
          { "Key": "LeagueID", "Value": params.LeagueID },
          { "Key": "Location", "Value": params.Location },
          { "Key": "Month", "Value": this.setDefaultParameterValue(params.Month) },
          { "Key": "OpponentTeamID", "Value": this.setDefaultParameterValue(params.OpponentTeamID) },
          { "Key": "Outcome", "Value": params.Outcome },
          { "Key": "Period", "Value": this.setDefaultParameterValue(params.Period) },
          { "Key": "PlayerID", "Value": this.setDefaultParameterValue(params.PlayerID) },
          { "Key": "PointDiff", "Value": params.PointDiff },
          { "Key": "Position", "Value": params.Position },
          { "Key": "RangeType", "Value": params.RangeType },
          { "Key": "RookieYear", "Value": params.RookieYear },
          { "Key": "Season", "Value": params.Season },
          { "Key": "SeasonSegment", "Value": params.SeasonSegment },
          { "Key": "SeasonType", "Value": params.SeasonType },
          { "Key": "StartPeriod", "Value": params.StartPeriod },
          { "Key": "StartRange", "Value": params.StartRange },
          { "Key": "TeamID", "Value": this.setDefaultParameterValue(params.TeamID) },
          { "Key": "VsConference", "Value": params.VsConference },
          { "Key": "VsDivision", "Value": params.VsDivision },
        ];
  
        this._statsService.post(this._query);
      }
    });
  }

  private setDefaultParameterValue(param: any){
    if(param === null){
      return "0";
    }

    return param;
  }
}
