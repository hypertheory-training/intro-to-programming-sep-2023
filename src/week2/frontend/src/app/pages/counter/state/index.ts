import { createFeature, createReducer } from "@ngrx/store";


export interface CounterState {
    current: number;
}

const initialState: CounterState = {
    current: 42
}

export const counterFeature = createFeature({
    name: 'counter',
    reducer: createReducer(initialState)
})