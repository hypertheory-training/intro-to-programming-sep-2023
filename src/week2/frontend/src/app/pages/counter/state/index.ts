import { createFeature, createReducer, on } from "@ngrx/store";
import { CounterEvents } from "./counter.actions";


export interface CounterState {
    current: number;
}

const initialState: CounterState = {
    current: 0
}

export const counterFeature = createFeature({
    name: 'counter',
    reducer: createReducer(initialState,
        on(CounterEvents.incrementClicked, (state) => ({ ...state, current: state.current + 1 })),
        on(CounterEvents.decrementClicked, (state) => ({ ...state, current: state.current - 1 })),
    )
})