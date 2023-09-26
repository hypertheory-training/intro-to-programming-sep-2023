import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TodoEntryComponent } from "./components/todo-entry.component";
import { TodoListComponent } from "./components/todo-list.component";

@Component({
  standalone: true,
  template: `
   <section>
    <app-todo-entry />
   </section>
   <section>
    <app-todo-list />
   </section>
  `,
  styleUrls: ["./todos.component.css"],
  imports: [CommonModule, TodoEntryComponent, TodoListComponent]
})
export class TodosComponent {

}
