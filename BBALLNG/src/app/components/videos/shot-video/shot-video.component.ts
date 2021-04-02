import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
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
  
  constructor(private _videosService: VideosService) { }

  ngOnInit(): void {
    this._videosService.meta.subscribe(meta=> {
      if(meta !== null){
        this.videos = meta['videoUrls'];
        this.video = this.videos[0].lurl;
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
        let index = this.playlist.findIndex(dataItem => dataItem['ei'] === filter);
        this.video = this.videos[index].lurl;
      }
    });
  }
}
