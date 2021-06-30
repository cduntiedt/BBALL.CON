import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './modules/material/material.module';
import { AppRouterModule } from './modules/app-router/app-router.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { VideoModule } from './modules/video/video.module';

import { PlotlyViaCDNModule } from 'angular-plotly.js';
PlotlyViaCDNModule.setPlotlyVersion('latest');

import { AppComponent } from './app.component';
//pages
import { HomeComponent } from './pages/home/home.component';
import { ToolbarComponent } from './components/navigation/toolbar/toolbar.component';
import { PlayersAutocompleteComponent } from './components/autocompletes/players-autocomplete/players-autocomplete.component';
import { GamesAutocompleteComponent } from './components/autocompletes/games-autocomplete/games-autocomplete.component';
import { TeamsAutocompleteComponent } from './components/autocompletes/teams-autocomplete/teams-autocomplete.component';
import { TeamGamesSelectComponent } from './components/selects/team-games-select/team-games-select.component';
import { PlayByPlayTableComponent } from './components/tables/play-by-play-table/play-by-play-table.component';
import { VideosTableComponent } from './components/tables/videos-table/videos-table.component';
import { PlayerComponent } from './pages/player/player.component';
import { TeamsSelectComponent } from './components/selects/teams-select/teams-select.component';
import { ShotChartComponent } from './components/charts/shot-chart/shot-chart.component';
import { ShotTableComponent } from './components/tables/shot-table/shot-table.component';
import { StatsService } from './services/stats.service';
import { ShotVideoComponent } from './components/videos/shot-video/shot-video.component';
import { CastComponent } from './components/videos/cast/cast.component';
import { GameVideoComponent } from './pages/game/game-video/game-video.component';
import { SidenavComponent } from './components/navigation/sidenav/sidenav.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ToolbarComponent,
    PlayersAutocompleteComponent,
    GamesAutocompleteComponent,
    TeamsAutocompleteComponent,
    TeamGamesSelectComponent,
    PlayByPlayTableComponent,
    VideosTableComponent,
    PlayerComponent,
    TeamsSelectComponent,
    ShotChartComponent,
    ShotTableComponent,
    ShotVideoComponent,
    CastComponent,
    GameVideoComponent,
    SidenavComponent,
  ],
  imports: [
    BrowserModule,
    AppRouterModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    NgbModule,
    PlotlyViaCDNModule,
    VideoModule
  ],
  providers: [StatsService], //make a new module for shot details?
  bootstrap: [AppComponent],
  // schemas:[
  //   CUSTOM_ELEMENTS_SCHEMA
  // ]
})
export class AppModule { }
