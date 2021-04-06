import { Component, OnInit } from '@angular/core';
import { VgApiService } from '@videogular/ngx-videogular/core';
import { VideosService } from 'src/app/services/videos.service';

@Component({
  selector: 'app-shot-video',
  templateUrl: './shot-video.component.html',
  styleUrls: ['./shot-video.component.scss']
})
export class ShotVideoComponent implements OnInit {
  videos: any[] = [];
  video: any = '';
  playlist: any[] = [];
  index: number = 0;
  api: VgApiService | undefined;

  constructor(private _videosService: VideosService) { }

  ngOnInit(): void {
    this._videosService.meta.subscribe(meta=> {
      if(meta !== null){
        this.videos = meta['videoUrls'];
        this.video = this.videos[0].lurl;
        this.index = 0;
      }
    });

    this._videosService.playlist.subscribe(pl =>{
      if(pl !== null){
        this.playlist = pl;
      }
    })

    this._videosService.loadVideos();

    this._videosService.videoFilter.subscribe(filter => {
      if(filter !== null){
        this.index = this.playlist.findIndex(dataItem => dataItem['ei'] === filter);
        this.video = this.videos[this.index].lurl;
      }
    });
  }

  onPlayerReady(api: VgApiService){
    this.api = api;
    if(this.api.subscriptions !== undefined){
      this.api.getDefaultMedia().subscriptions.ended.subscribe(
        () => {
          console.log("finished");
          this.index += 1;
          if(this.index > this.videos.length){
            this.video = this.videos[this.index].lurl;
          }
        });
    }
    
  }
}
