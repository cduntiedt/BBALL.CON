import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { StatQuery } from 'src/app/models/stat-query';
import { StatsService } from 'src/app/services/stats.service';
import { map, startWith } from 'rxjs/operators';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { ParametersService } from 'src/app/services/parameters.service';

@Component({
  selector: 'app-teams-autocomplete',
  templateUrl: './teams-autocomplete.component.html',
  styleUrls: ['./teams-autocomplete.component.scss'],
  providers:[
    StatsService
  ]
})
export class TeamsAutocompleteComponent implements OnInit {
  teamsAutocomplete = new FormControl();
  private _query: StatQuery = new StatQuery();
  teams: any[] = [];
  filteredTeams!: Observable<any[]>;

  constructor(private _statsService: StatsService, 
    private _parametersService: ParametersService) { }

  ngOnInit(): void {
    this._statsService.data.subscribe(response => {
      this.teams = response.filter(team => team["ABBREVIATION"] != null);
    });

    this._parametersService.parameters.subscribe(params => {
      this._query.collection = "commonteamyears";
      this._query.parameters = [
        { "Key": "LeagueID", "Value": params.LeagueID }
      ];
  
      this._statsService.post(this._query, "TeamYears");
    });

    this.filteredTeams = this.teamsAutocomplete.valueChanges
      .pipe(
          startWith(''),
          map(value => this._filter(value))
      );
  }

  private _filter(value: any): any[] {
    var filterValue = "";
    if(typeof value === 'string'){
      filterValue = value.toLowerCase();
    } else{
      filterValue = value["ABBREVIATION"].toLowerCase();
    }
    return this.teams.filter(team => team["ABBREVIATION"].toLowerCase().includes(filterValue));
  }

  selectTeam(event: MatAutocompleteSelectedEvent){
    this._parametersService.setValue("TeamID", event.option.value["TEAM_ID"]);
  }

  getTeamAbbr(team: any){
    if(team === null){
      return "";
    }else{
      return team["ABBREVIATION"];
    }
  }
}
