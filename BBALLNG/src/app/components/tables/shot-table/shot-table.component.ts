import { Component, OnInit } from '@angular/core';
import { ShotsService } from 'src/app/services/shots.service';
import { VideosService } from 'src/app/services/videos.service';

@Component({
  selector: 'app-shot-table',
  templateUrl: './shot-table.component.html',
  styleUrls: ['./shot-table.component.scss'],
  // providers:[
  //   ShotsService
  // ]
})
export class ShotTableComponent implements OnInit {
  public shots: any[] = [];
  public shotColumns: string[] = [
    'PLAYER_NAME', 
    'TEAM_NAME', 
    'PERIOD', 
    'TIME', 
    'SHOT_TYPE', 
    'SHOT_ZONE_RANGE',
    'EVENT_TYPE'
  ]; 

  constructor(private _shotsService: ShotsService, private _videosService: VideosService) { }

  ngOnInit(): void {
    this._shotsService.shots.subscribe(shots => {
      this.shots = shots;
    });

    //this._shotsService.loadData();
  }

  public selectRow(row: any){
    this._videosService.filterVideo(row["GAME_EVENT_ID"]);
  }

  public formatSeconds(seconds: number){
    if(seconds < 10){
      return "0" + seconds;
    }else{
      return seconds.toString();
    }
  }
}
