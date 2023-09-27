import { createActionGroup, emptyProps } from "@ngrx/store";


export const CounterEvents = createActionGroup({
    source: 'Counter Component Events',
    events: {
        'Increment Clicked': emptyProps(),
        'Decrement Clicked': emptyProps()
    }
})