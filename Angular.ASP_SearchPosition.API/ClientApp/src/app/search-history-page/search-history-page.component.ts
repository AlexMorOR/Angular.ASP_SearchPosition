import { Component, OnInit } from '@angular/core';
import { SearchService } from '../shared/search.service';
import { LogService } from '../shared/log.service';

@Component({
  selector: 'app-search-history-page',
  templateUrl: './search-history-page.component.html',
  styleUrls: ['./search-history-page.component.css']
})
export class SearchHistoryPageComponent implements OnInit {

  /**
   *
   */
  constructor(
    public searchService: SearchService, 
    public logService: LogService
    ) {
    
  }

  ngOnInit(): void {
    this.searchService.updateHistory();
    this.logService.updateLog();
  }

}
