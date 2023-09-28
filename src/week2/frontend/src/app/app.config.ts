import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideState, provideStore } from '@ngrx/store';
import { reducers } from './state';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { counterFeature } from './pages/counter/state';
import { provideEffects } from '@ngrx/effects';
import { CounterEffects } from './pages/counter/state/counter.effects';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideStore(reducers),
    provideStoreDevtools({
      autoPause: true,
      trace: true
    }),
    provideState(counterFeature),
    provideEffects([CounterEffects])

  ]
};
