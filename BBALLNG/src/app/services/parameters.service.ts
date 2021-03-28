import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Parameters} from 'src/app/models/parameters';

@Injectable({
  providedIn: 'root'
})
export class ParametersService {
  private _values: Parameters = new Parameters();
  private _parameters = new BehaviorSubject<Parameters>(this._values);
  public parameters = this._parameters.asObservable();

  constructor() { }

  get(){
    return this.parameters;
  }

  setValue(field: any, value: any){
    const valueKey: keyof Parameters = field;
    this._values[valueKey] = value;
    this._parameters.next(this._values);
  }

  resetValues(){
    this._values = new Parameters();
    this._parameters.next(this._values);
  }

  setDefaultValue(value: any, def: any = "0"){
    if(value === null){
      return def;
    }

    return value;
  }
}
