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
  video: any = 'https://videos.nba.com/nba/pbp/media/2021/04/01/0022000731/7/abf0d094-85ed-ce6b-d035-2e4aadf69b1a_1280x720.mp4';
  
  constructor(private _videosService: VideosService) { }

  ngOnInit(): void {
    this._videosService.videos.subscribe(videos => {
      if(videos.length !== 0){
        console.log(videos);
        this.videos = videos;
        this.video = videos[0].lurl;
        console.log(this.video);
      }
    });
    this._videosService.loadVideos();
  }
}
