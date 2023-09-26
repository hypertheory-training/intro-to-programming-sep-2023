import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TodoItem } from 'src/app/services/todos-data.service';
import { ToggleOnOffComponent } from "../../../ui/toggle-on-off.component";

@Component({
  selector: 'app-todo-list',
  standalone: true,
  template: `
  <h2 class="text-2xl">{{message}}</h2>
   <ul>
      <li *ngFor="let item of items" >
        <span [ngClass]="{ completed: item.completed}">{{ item.description }}</span>
      
      <app-toggle-on-off *ngIf="item.completed === false" (click)="doThis(item)"/>

      </li>
     
</ul>
  `,
  styleUrls: ['../todos.component.css'],
  imports: [CommonModule, ToggleOnOffComponent]
})
export class TodoListComponent {
  @Input({ required: true }) items: TodoItem[] = [];
  @Input() message = 'Your Todo List';
  @Output() itemMarkedComplete = new EventEmitter<TodoItem>();

  doThis(item: TodoItem) {
    this.itemMarkedComplete.emit(item);
  }
}
