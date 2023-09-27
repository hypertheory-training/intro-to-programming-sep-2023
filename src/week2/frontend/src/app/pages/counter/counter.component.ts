import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { counterFeature } from './state';
import { CounterEvents } from './state/counter.actions';

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
   <div>
    <button class="btn btn-sm btn-accent">Reset</button>
</div>
  `,
  styles: [
  ]
})
export class CounterComponent {
  current = this.store.selectSignal(counterFeature.selectCurrent);

  constructor(private readonly store: Store) { }
  increment() {
    this.store.dispatch(CounterEvents.incrementClicked());
  }

  decrement() {
    this.store.dispatch(CounterEvents.decrementClicked());
  }
}
