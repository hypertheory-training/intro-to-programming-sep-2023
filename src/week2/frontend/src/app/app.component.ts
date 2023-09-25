import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  template: `
  <h1 class="text-red-500 font-extrabold text-3xl">Hello From Angular 16</h1>
  `,
  styles: [],
})
export class AppComponent {
 
 
}
