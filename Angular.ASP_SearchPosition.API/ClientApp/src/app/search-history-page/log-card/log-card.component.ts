import { Component, Input } from '@angular/core';
import { LogModel } from 'src/app/shared/log-model.model';

@Component({
  selector: 'app-log-card',
  templateUrl: './log-card.component.html',
  styleUrls: ['./log-card.component.css']
})
export class LogCardComponent {
  @Input() model : LogModel | undefined;
}
