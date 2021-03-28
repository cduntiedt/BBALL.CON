import { Component, OnInit } from '@angular/core';
import { StatQuery } from 'src/app/models/stat-query';
import { ParametersService } from 'src/app/services/parameters.service';
import { StatsService } from 'src/app/services/stats.service';

@Component({
  selector: 'app-shot-chart',
  templateUrl: './shot-chart.component.html',
  styleUrls: ['./shot-chart.component.scss'],
  providers:[
    StatsService
  ]
})
export class ShotChartComponent implements OnInit {
  private _query : StatQuery = new StatQuery();
  public shots: any[] = [];
  private _layout =  {
    autosize: true, 
    title: 'A Shot Chart',
    images: [
      {
        "source": "assets/img/shot-chart/court.png",
        "xref": "x",
        "yref": "y",
        "x": 0,
        "y": 3,
        "sizex": 1,
        "sizey": 1,
        "xanchor": "left",
        "yanchor": "bottom"
      }
    ],
    xaxis:{
      showticklabels: false,
      showgrid: false,
      zeroline: false,
    },
    yaxis:{
      showticklabels: false,
      showgrid: false,
      zeroline: false,
    }
  };

  public graph = {
    data: [
      { 
        x: [0], 
        y: [0], 
        mode: 'markers',
        type: 'scatter' 
      }
    ],
    layout: this._layout,
  };

  constructor(private _statsService: StatsService,
    private _parametersService: ParametersService) { }

  ngOnInit(): void {
    this._statsService.data.subscribe(shots => {
      this.shots = shots;
      this.graph = {
        data:[
          {
            x: shots.map(shot => shot["LOC_X"]),
            y: shots.map(shot => shot["LOC_Y"]),
            mode: 'markers',
            type: 'scatter' 
          }
        ],
        layout: this._layout,
      };
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
