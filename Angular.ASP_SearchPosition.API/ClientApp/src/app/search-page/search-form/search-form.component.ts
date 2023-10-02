import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { SearchEngine } from 'src/app/shared/search-engine.model';

@Component({
  selector: 'app-search-form',
  templateUrl: './search-form.component.html',
  styleUrls: ['./search-form.component.css'],
})
export class SearchFormComponent {

  @Input() searchEngines : SearchEngine[] = [];

  searchForm = new FormGroup(
    {
      query: new FormControl(""),
      url: new FormControl(""),
      engine: new FormControl("")
    }
  );

  @Output() searchEvent = new EventEmitter<any>();

  onSubmit() {
    this.searchEvent.emit(this.searchForm.value);
  }
}
