import { Component, OnInit } from '@angular/core';
import { SearchService } from '../shared/search.service';
import { SearchEngine } from '../shared/search-engine.model';

@Component({
  selector: 'app-search-page',
  templateUrl: './search-page.component.html',
  styleUrls: ['./search-page.component.css']
})
export class SearchPageComponent implements OnInit{
  /**
   *
   */
  constructor(public service: SearchService) {
    
  }

  ngOnInit(): void {
    this.service.updateEngines();
  }

  onSearch(data: {query: string, url: string, engine: SearchEngine}) {
    const { query, url, engine } = data;
    this.service.search(query, url, engine);
  }
}
