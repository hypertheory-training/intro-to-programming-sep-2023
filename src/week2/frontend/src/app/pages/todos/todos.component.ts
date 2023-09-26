import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({

  standalone: true,
  imports: [CommonModule],
  template: `
   <section>
      <label for="item">Item</label>
      <input type="text" id="item" />
      <button class="btn btn-primary">Add Item</button>
   </section>
   <section>
    <ul>
      <li>
        <span>Buy Beer</span>
      
        <button class="btn btn-circle">
  <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12" /></svg>
</button>

      </li>
      <li>
         <span class="completed">Get some Tortilla Chips</span>
      </li>
</ul>
   </section>
  `,
  styleUrls: ["./todos.component.css"]
})
export class TodosComponent {

}
