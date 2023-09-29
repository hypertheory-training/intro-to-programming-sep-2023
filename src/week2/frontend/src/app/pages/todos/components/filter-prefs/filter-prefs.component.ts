import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Store } from '@ngrx/store';
import { FilterOptions, todosFeature } from '../../state';
import { TodosEvents } from '../../state/todos.actions';

@Component({
  selector: 'app-filter-prefs',
  standalone: true,
  imports: [CommonModule],
  template: `
        <div class="join">
  <button [disabled]="by() === 'all'" (click)="setFilterBy('all')" class="btn join-item"><div class="badge badge-secondary">{{summary().total}}</div>Show All</button>
  <button [disabled]="by() === 'completed'" (click)="setFilterBy('completed')" class="btn join-item"><div class="badge badge-secondary">{{summary().complete}}</div>Show Completed</button>
  <button [disabled]="by() === 'incomplete'" (click)="setFilterBy('incomplete')" class="btn join-item"><div class="badge badge-secondary">{{summary().incomplete}}</div>Show Incomplete</button>
</div>
  `,
  styles: [
  ]
})
export class FilterPrefsComponent {

  store = inject(Store);
  by = this.store.selectSignal(todosFeature.selectFilterBy);
  summary = this.store.selectSignal(todosFeature.selectTodoSummary);
  setFilterBy(by: FilterOptions) {
    this.store.dispatch(TodosEvents.todoListFilteredBy({ by }));
  }
}
