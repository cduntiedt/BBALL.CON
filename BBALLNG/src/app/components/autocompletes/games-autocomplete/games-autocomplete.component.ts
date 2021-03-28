import { Component, OnInit } from '@angular/core';
import { StatQuery } from 'src/app/models/stat-query';
import { StatsService } from 'src/app/services/stats.service';

@Component({
  selector: 'app-games-autocomplete',
  templateUrl: './games-autocomplete.component.html',
  styleUrls: ['./games-autocomplete.component.scss']
})
export class GamesAutocompleteComponent implements OnInit {
  private _query: StatQuery = new StatQuery();
  public games: any[] = [];

  constructor(private _statsService: StatsService) { }

  ngOnInit(): void {
  }

}
