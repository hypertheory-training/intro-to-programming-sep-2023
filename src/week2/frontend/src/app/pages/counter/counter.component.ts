import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { counterFeature } from './state';

@Component({
  selector: 'app-counter',
  standalone: true,
  imports: [CommonModule],
  template: `
   <div>
    <button (click)="decrement()" class="btn btn-circle btn-sm">-</button>
    <span>{{ current() }}</span>
    <button (click)="increment()" class="btn btn-circle btn-sm">+</button>
   </div>
  `,
  styles: [
  ]
})
export class CounterComponent {
  current = this.store.selectSignal(counterFeature.selectCurrent);

  constructor(private readonly store: Store) { }
  increment() {
    //
  }

  decrement() {
    //this.current -= 1;
  }
}
