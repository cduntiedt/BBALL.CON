import { Component, OnInit } from '@angular/core';
import { StatQuery } from 'src/app/models/stat-query';
import { ShotsService } from 'src/app/services/shots.service';

@Component({
  selector: 'app-shot-chart',
  templateUrl: './shot-chart.component.html',
  styleUrls: ['./shot-chart.component.scss'],
  // providers:[
  //   ShotsService
  // ]
})
export class ShotChartComponent implements OnInit {
  private _query : StatQuery = new StatQuery();
  public shots: any[] = [];
  // public style: any = {
  //   position: 'relative', 
  //   width: '100%', 
  //   margin-top: '75%'
  // };  
  public graph: any;
  private _layout =  {
    autosize: true, 
    // width: 500,
    // height: 470,
    title: 'Shot Chart',
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
        "opacity": 0.6
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

  constructor(private _shotsService: ShotsService) { }

  ngOnInit(): void {
    this._shotsService.shots.subscribe(shots => {
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

    this._shotsService.loadData();
  }
}
