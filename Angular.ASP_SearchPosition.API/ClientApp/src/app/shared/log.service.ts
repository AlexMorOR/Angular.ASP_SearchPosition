import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LogModel } from './log-model.model';

@Injectable({
  providedIn: 'root'
})
export class LogService {

  baseUrl:string = environment.backendURL;
  logUrl = this.baseUrl + "/log";
  
  logs : LogModel[] = [];

  constructor(private http: HttpClient) { }

  updateLog(){
    this.http.get(this.logUrl).subscribe(
      {
        next : res =>{
          this.logs = res as LogModel[];
        },
        error : e => { console.log(e); }
      }
    );
  }
}
