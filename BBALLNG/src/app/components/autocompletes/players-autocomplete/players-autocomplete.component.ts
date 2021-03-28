import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { StatQuery } from 'src/app/models/stat-query';
import { ParametersService } from 'src/app/services/parameters.service';
import { StatsService } from 'src/app/services/stats.service';

@Component({
  selector: 'app-players-autocomplete',
  templateUrl: './players-autocomplete.component.html',
  styleUrls: ['./players-autocomplete.component.scss'],
  providers: [
    StatsService
  ]
})
export class PlayersAutocompleteComponent implements OnInit {
  playersAutocomplete = new FormControl();
  private _query: StatQuery = new StatQuery();
  players: any[] = [];
  allPlayers: any[] = [];
  filteredPlayers!: Observable<any[]>;

  constructor(private _statsService: StatsService,
    private _parmetersService: ParametersService) { }

  ngOnInit(): void {
    this._statsService.data.subscribe(response => {
      this.players = response;
      this.allPlayers = response;
    });

    this._parmetersService.parameters.subscribe(params => {
      this._query.collection = "playerindex";
      this._query.parameters = [
        { "Key": "LeagueID", "Value": params.LeagueID },
        { "Key": "Season", "Value": params.Season },
        { "Key": "Active", "Value": params.Active },
        { "Key": "AllStar", "Value": params.AllStar },
        { "Key": "College", "Value": params.College },
        { "Key": "Country", "Value": params.Country },
        { "Key": "DraftPick", "Value": params.DraftPick },
        { "Key": "DraftYear", "Value": params.DraftYear },
        { "Key": "Height", "Value": params.Height },
        { "Key": "Historical", "Value": params.Historical },
        { "Key": "PlayerPosition", "Value": params.PlayerPosition },
        //{ "Key": "TeamID", "Value": null }, //stats api doesn't work with team ID
        { "Key": "Weight", "Value": params.Weight },
      ];
  
      if(this.players.length === 0){
        this._statsService.post(this._query, "PlayerIndex");
      }
      else {
        this.players = this.allPlayers.filter(player => player["TEAM_ID"] === params.TeamID);
        this.filteredPlayers = new Observable(observer => {
          observer.next(this.players);
        });

        this._filterChange();
      }
    });

    this._filterChange();
  }

  private _filterChange(){
    this.filteredPlayers = this.playersAutocomplete.valueChanges
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
      filterValue = value["PLAYER_FIRST_NAME"].toLowerCase() + ' ' + value["PLAYER_LAST_NAME"].toLowerCase();
    }
    return this.players.filter(player => (player["PLAYER_FIRST_NAME"].toLowerCase() + ' ' + player["PLAYER_LAST_NAME"].toLowerCase()).includes(filterValue));
  }

  selectPlayer(event: MatAutocompleteSelectedEvent){
    this._parmetersService.setValue("PlayerID", event.option.value["PERSON_ID"]);
  }

  getPlayerName(player: any){
    if(player === null){
      return "";
    }else{
      return player["PLAYER_FIRST_NAME"] + ' ' + player["PLAYER_LAST_NAME"];
    }
  }
}
