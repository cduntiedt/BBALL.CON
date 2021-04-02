import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, pipe } from 'rxjs';
import { repeat } from 'rxjs/operators';
import { StatQuery } from '../models/stat-query';
import { ParametersService } from './parameters.service';
import { StatsService } from './stats.service';

@Injectable({
  providedIn: 'root'
})
export class VideosService {
  private _query: StatQuery = new StatQuery();
  private _videos: BehaviorSubject<any[]> = new BehaviorSubject<any[]>([]);
  public videos = this._videos.asObservable();
  private _playlist: BehaviorSubject<any[]> = new BehaviorSubject<any[]>([]);
  public playlist = this._playlist.asObservable();
  private _meta: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public meta = this._meta.asObservable();
  private _videoFilter: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public videoFilter = this._videoFilter.asObservable();

  constructor(private _parametersService: ParametersService, private _statsService: StatsService) { }

  public loadVideos(){
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
          { "Key": "LastNGames", "Value": this._parametersService.setDefaultValue(params.LastNGames) },
          { "Key": "LeagueID", "Value": params.LeagueID },
          { "Key": "Location", "Value": params.Location },
          { "Key": "Month", "Value": this._parametersService.setDefaultValue(params.Month) },
          { "Key": "OpponentTeamID", "Value": this._parametersService.setDefaultValue(params.OpponentTeamID) },
          { "Key": "Outcome", "Value": params.Outcome },
          { "Key": "Period", "Value": this._parametersService.setDefaultValue(params.Period) },
          { "Key": "PlayerID", "Value": this._parametersService.setDefaultValue(params.PlayerID) },
          { "Key": "PointDiff", "Value": params.PointDiff },
          { "Key": "Position", "Value": params.Position },
          { "Key": "RangeType", "Value": params.RangeType },
          { "Key": "RookieYear", "Value": params.RookieYear },
          { "Key": "Season", "Value": params.Season },
          { "Key": "SeasonSegment", "Value": params.SeasonSegment },
          { "Key": "SeasonType", "Value": params.SeasonType },
          { "Key": "StartPeriod", "Value": params.StartPeriod },
          { "Key": "StartRange", "Value": params.StartRange },
          { "Key": "TeamID", "Value": this._parametersService.setDefaultValue(params.TeamID) },
          { "Key": "VsConference", "Value": params.VsConference },
          { "Key": "VsDivision", "Value": params.VsDivision },
        ];
  

        this._statsService.get(this._query).subscribe(response => {
          if(response['resultSets']['Meta'] !== undefined){
            this._meta.next(response['resultSets']['Meta']);
            this._videos.next(response['resultSets']['Meta']['videoUrls']);
            this._playlist.next(response['resultSets']['playlist']);
          }
        });
      }
    });
  }

  public filterVideo(event: number){
    this._videoFilter.next(event);
  }
}
