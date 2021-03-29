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
  public graph: any;
  private _layout =  {
    autosize: false, 
    width: 500,
    height: 470,
    title: 'A Shot Chart',
    images: [
      {
        "source": "assets/img/shot-chart/court.png",
        "xref": "x",
        "yref": "y",
        "x": -250,
        "y": -52,
        "sizing": "stretch",
        "sizex": 500,
        "sizey": 470,
        "xanchor": "left",
        "yanchor": "bottom",
        "layer": "below",
        "opacity": 0.3
      }
    ],
    xaxis:{
      range: [-250, 250],
      showticklabels: false,
      showgrid: false,
      zeroline: false,
    },
    yaxis:{
      range: [-52, 418],
      showticklabels: false,
      showgrid: false,
      zeroline: false,
    }
  };

  constructor(private _statsService: StatsService,
    private _parametersService: ParametersService) { }

  ngOnInit(): void {
    this._statsService.data.subscribe(shots => {
      this.shots = shots;
      let makes = shots.filter(shot => shot["SHOT_MADE_FLAG"] === 1);
      let misses = shots.filter(shot => shot["SHOT_MADE_FLAG"] === 0);
      this.graph = {
        data:[
          {
            name: "Makes",
            x: makes.map(shot => shot["LOC_X"]),
            y: makes.map(shot => shot["LOC_Y"]),
            mode: 'markers',
            marker: {
              color: 'green'
            },
            type: 'scatter' 
          },
          {
            name: "Misses",
            x: misses.map(shot => shot["LOC_X"]),
            y: misses.map(shot => shot["LOC_Y"]),
            mode: 'markers',
            marker: {
              color: 'red',
              symbol: 'x'
            },
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
