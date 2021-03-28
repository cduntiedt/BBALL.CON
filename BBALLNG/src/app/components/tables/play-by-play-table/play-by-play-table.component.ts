import { Component, OnInit } from '@angular/core';
import { StatQuery } from 'src/app/models/stat-query';
import { ParametersService } from 'src/app/services/parameters.service';
import { StatsService } from 'src/app/services/stats.service';

@Component({
  selector: 'app-play-by-play-table',
  templateUrl: './play-by-play-table.component.html',
  styleUrls: ['./play-by-play-table.component.scss'],
  providers: [
    StatsService
  ]
})
export class PlayByPlayTableComponent implements OnInit {
  private _query: StatQuery = new StatQuery();
  public plays: any[] = [];
  public playColumns: string[] = ['HOMEDESCRIPTION', 'PERIOD', 'PCTIMESTRING', 'VISITORDESCRIPTION',];

  constructor(private _statsService: StatsService, private _parametersService: ParametersService) { }

  ngOnInit(): void {
    this._statsService.data.subscribe(response => {
      this.plays = response.filter(play => play["NEUTRALDESCRIPTION"] === null);      
    });
    
    this._parametersService.parameters.subscribe(params => {
      if(params.GameID !== null){
        this._query.collection = "playbyplayv2";
        this._query.parameters = [
          { "Key": "GameID", "Value": params.GameID },
          { "Key": "StartPeriod", "Value": params.StartPeriod },
          { "Key": "EndPeriod", "Value": params.EndPeriod },
        ];
  
        this._statsService.post(this._query, "PlayByPlay");
      }
    });

    
  }

}
