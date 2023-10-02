import { Component, Input } from '@angular/core';
import { SearchResult } from 'src/app/shared/search-result.model';

@Component({
  selector: 'app-search-card',
  templateUrl: './search-card.component.html',
  styleUrls: ['./search-card.component.css']
})
export class SearchCardComponent {
  @Input() model : SearchResult | undefined;
}
