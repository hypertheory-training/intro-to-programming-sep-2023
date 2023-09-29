import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TodosDataService } from '../services/todos-data.service';
import { Store } from '@ngrx/store';
import { todosFeature } from '../pages/todos/state';

@Component({
  selector: 'app-todo-summary',
  standalone: true,
  imports: [CommonModule],
  template: `
   <button class="btn">
  Todo Items
  <div class="badge">{{summary().total}}</div>
</button>
<button class="btn">
  Todo Items Completed
  <div class="badge badge-secondary">{{summary().complete}}</div>
</button>
<button class="btn">
  Todo Items Incomplete
  <div class="badge badge-secondary">{{summary().incomplete}}</div>
</button>
  `,
  styles: [
  ]
})
export class TodoSummaryComponent {


  constructor(private readonly store: Store) {

  }
  summary = this.store.selectSignal(todosFeature.selectTodoSummary);
}


export interface TodoSummary {
  total: number;
  incomplete: number;
  complete: number;
}