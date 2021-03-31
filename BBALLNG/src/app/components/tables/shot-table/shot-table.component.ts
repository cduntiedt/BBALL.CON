import { Component, OnInit } from '@angular/core';
import { ShotsService } from 'src/app/services/shots.service';

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

  constructor(private _shotsService: ShotsService) { }

  ngOnInit(): void {
    this._shotsService.shots.subscribe(shots => {
      this.shots = shots;
    });

    //this._shotsService.loadData();
  }

}
