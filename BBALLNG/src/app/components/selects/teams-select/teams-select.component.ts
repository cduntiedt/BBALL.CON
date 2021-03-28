import { Component, OnInit } from '@angular/core';
import { MatSelectChange } from '@angular/material/select';
import { map } from 'rxjs/operators';
import { Parameters } from 'src/app/models/parameters';
import { StatQuery } from 'src/app/models/stat-query';
import { ParametersService } from 'src/app/services/parameters.service';
import { StatsService } from 'src/app/services/stats.service';

@Component({
  selector: 'app-teams-select',
  templateUrl: './teams-select.component.html',
  styleUrls: ['./teams-select.component.scss'],
  providers:[
    StatsService
  ]
})
export class TeamsSelectComponent implements OnInit {
  private _query: StatQuery = new StatQuery();
  teams: any[] = [];

  constructor(private _statsService: StatsService, 
    private _parametersService: ParametersService) { }

  ngOnInit(): void {
    this._statsService.data.subscribe(response => {
      this.teams = response.filter(team => team["ABBREVIATION"] !== null);      
    });

    this._parametersService.parameters.subscribe(params => {
      this._query.collection = "commonteamyears";
      this._query.parameters = [
        { "Key": "LeagueID", "Value": params.LeagueID }
      ];

      if(this.teams.length === 0){
        this._statsService.post(this._query, "TeamYears");
      }
    });
  }

  public selectTeam(event: MatSelectChange){
    this._parametersService.setValue("TeamID", event.value["TEAM_ID"]);
  }
}
