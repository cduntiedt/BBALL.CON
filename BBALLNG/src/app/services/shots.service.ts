import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { StatQuery } from '../models/stat-query';
import { ParametersService } from './parameters.service';
import { StatsService } from './stats.service';

@Injectable({
  providedIn: 'root'
})
//@Injectable()
export class ShotsService {
  private _query : StatQuery = new StatQuery();
  private _shots: BehaviorSubject<any[]> = new BehaviorSubject<any[]>([]);
  public shots = this._shots.asObservable();

  constructor(private _statsService: StatsService, private _parametersService: ParametersService) { }

  loadData(){
    this._statsService.data.subscribe(shots => {
      this._shots.next(shots);
    });

    this._parametersService.parameters.subscribe(params => {
      this._query.collection = "shotchartdetail";
      this._query.parameters = [
        { "Key": "PlayerID", "Value": this._parametersService.setDefaultValue(params.PlayerID) },
        { "Key": "LeagueID", "Value": params.LeagueID },
        { "Key": "Season", "Value": params.Season },
        { "Key": "ContextFilter", "Value": params.ContextFilter },
        { "Key": "ContextMeasure", "Value": "FGA" },
        { "Key": "SeasonType", "Value": params.SeasonType },
        { "Key": "AheadBehind", "Value": params.AheadBehind },
        { "Key": "ClutchTime", "Value": params.ClutchTime },
        { "Key": "DateFrom", "Value": params.DateFrom },
        { "Key": "DateTo", "Value": params.DateTo },
        { "Key": "EndPeriod", "Value": params.EndPeriod },
        { "Key": "EndRange", "Value": params.EndRange },
        { "Key": "GameID", "Value": params.GameID },
        { "Key": "GameSegment", "Value": params.GameSegment },
        { "Key": "LastNGames", "Value": this._parametersService.setDefaultValue(params.LastNGames) },
        { "Key": "Location", "Value": params.Location },
        { "Key": "Month", "Value": this._parametersService.setDefaultValue(params.Month) },
        { "Key": "OpponentTeamID", "Value": this._parametersService.setDefaultValue(params.OpponentTeamID) },
        { "Key": "Outcome", "Value": params.Outcome },
        { "Key": "Period", "Value": this._parametersService.setDefaultValue(params.Period) },
        { "Key": "PlayerPosition", "Value": params.PlayerPosition },
        { "Key": "PointDiff", "Value": params.PointDiff },
        { "Key": "Position", "Value": params.Position },
        { "Key": "RangeType", "Value": params.RangeType },
        { "Key": "RookieYear", "Value": params.RookieYear },
        { "Key": "SeasonSegment", "Value": params.SeasonSegment },
        { "Key": "StartPeriod", "Value": params.StartPeriod },
        { "Key": "StartRange", "Value": params.StartRange },
        { "Key": "TeamID", "Value": this._parametersService.setDefaultValue(params.TeamID) },
        { "Key": "VsConference", "Value": params.VsConference },
        { "Key": "VsDivision", "Value": params.VsDivision },
      ];

      if(params.PlayerID !== null || params.TeamID !== null || params.GameID !== null){
        this._statsService.post(this._query, "Shot_Chart_Detail");
      }
    });
  }
}
