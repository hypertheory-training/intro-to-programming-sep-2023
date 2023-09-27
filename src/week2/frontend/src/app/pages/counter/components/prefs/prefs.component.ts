import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Store } from '@ngrx/store';
import { CountByValues, CounterEvents } from '../../state/counter.actions';

@Component({
  selector: 'app-prefs',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="join">
  <button (click)="setCountBy(1)" class="btn join-item">Count By 1</button>
  <button (click)="setCountBy(3)" class="btn join-item">Count By 3</button>
  <button (click)="setCountBy(5)" class="btn join-item">Count By 5</button>
</div>
  `,
  styles: [
  ]
})
export class PrefsComponent {
  store = inject(Store);

  setCountBy(by: CountByValues) {
    this.store.dispatch(CounterEvents.countByChanged({ by }));
  }
}
