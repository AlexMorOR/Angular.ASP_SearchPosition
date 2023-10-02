import { Component, OnInit } from '@angular/core';
import { SearchService } from '../shared/search.service';
import { SearchEngine } from '../shared/search-engine.model';

@Component({
  selector: 'app-search-page',
  templateUrl: './search-page.component.html',
  styleUrls: ['./search-page.component.css'],
  providers: [SearchService]
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

  onSearch(data: {query: string, url: string, engine: number}) {
    const { query, url, engine } = data;
    console.log(this.service.avaliableEngines);
    console.log(engine);
    console.log(this.service.avaliableEngines.find(e => e.searchEngine === engine)!);
    this.service.search(
      query, 
      url, 
      this.service.avaliableEngines.find(e => e.searchEngine == engine)!
    );
  }
}
