import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { StatQuery } from '../models/stat-query';

// @Injectable({
//   providedIn: 'root'
// })
@Injectable()
export class StatsService {
  private _values = new BehaviorSubject<any>(null);
  public values = this._values.asObservable();

  private _data = new BehaviorSubject<any[]>([]);
  public data = this._data.asObservable();

  constructor(private http: HttpClient) { }

  post(query: StatQuery, name: string = ""){
    this.http.post<any>(environment.api + 'stats', query).subscribe(response => {
      this._values.next(response);

      if(name != ""){
        var resultSets = response["result"]["resultSets"];
        for (let index = 0; index < resultSets.length; index++) {
          const resultSet = resultSets[index];
          if(resultSet["name"] == name){
            this._data.next(resultSet["data"]);
            break;
          }
        }
      }
    });
  }

  get(query: StatQuery, name: string = ""): Observable<any>{
    return this.http.post<any>(environment.api + 'stats', query).pipe(
      map(response => {
        return response["result"];
      })
    )
  }
}
