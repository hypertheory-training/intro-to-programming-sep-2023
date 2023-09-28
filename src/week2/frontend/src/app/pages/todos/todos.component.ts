import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TodoEntryComponent } from "./components/todo-entry.component";
import { TodoListComponent } from "./components/todo-list.component";
import { TodoItem, TodosDataService } from 'src/app/services/todos-data.service';
import { Store } from '@ngrx/store';
import { todosFeature } from './state';
import { TodosEvents } from './state/todos.actions';

@Component({
  standalone: true,
  template: `
   <section>
    <app-todo-entry (itemAdded)="timeToAddAnItem($event)" />
   </section>
   <section>
    <app-todo-list [items]="todoItems" message="Here is all the stuff you have to do!" (itemMarkedComplete)="timeToMarkItemComplete($event)" />
   </section>
  `,
  styleUrls: ["./todos.component.css"],
  imports: [CommonModule, TodoEntryComponent, TodoListComponent]
})
export class TodosComponent {


  todoItems = this.store.selectSignal(todosFeature.selectTodoList)
  sayThis = 'Demo Header';
  constructor(private readonly store: Store) {
    store.dispatch(TodosEvents.entered());

  }

  timeToAddAnItem(description: string) {
    this.store.dispatch(TodosEvents.todoItemAdded({ description }));
  }

  timeToMarkItemComplete(item: TodoItem) {
    //this.service.markItemComplete(item);
  }
}
