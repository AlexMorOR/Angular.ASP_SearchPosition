import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { SearchEngine } from './search-engine.model';
import { SearchResult } from './search-result.model';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  baseUrl:string = environment.backendURL;
  searchUrl = this.baseUrl + "/search";
  enginesUrl = this.baseUrl + "/search/engines";
  historyUrl = this.baseUrl + "/search/history";

  searchResults : SearchResult[] = [];
  avaliableEngines : SearchEngine[] = [];

  constructor(private http: HttpClient) { }

  updateEngines(){
    this.http.get(this.enginesUrl).subscribe(
      {
        next : res =>{
          this.avaliableEngines = res as SearchEngine[];
        },
        error : e => { console.log(e); }
      }
    );
  }

  updateHistory(){
    this.http.get(this.historyUrl).subscribe(
      {
        next : res =>{
          this.searchResults = res as SearchResult[];
        },
        error : e => { console.log(e); }
      }
    );
  }

  search(query:string, url:string, engine:SearchEngine){
    this.http.get(this.searchUrl + 
      `?query=${query}&url=${url}&engine=${engine.searchEngine}`
      ).subscribe(
        {
          next : res =>{
            this.searchResults.unshift(res as SearchResult);
          },
          error : e => { console.log(e); }
        }
      );
  }
}
