import { createActionGroup, emptyProps, props } from "@ngrx/store";
import { TodoItem } from "src/app/services/todos-data.service";

export const TodosEvents = createActionGroup({
    source: 'Todos Events',
    events: {
        'Entered': emptyProps(),
        'Todo Item Added': props<{ description: string }>()
    }
})


export const TodosDocuments = createActionGroup({
    source: 'Todos Documents',
    events: {
        'Todo List': props<{ payload: TodoItem[] }>(),
        'Todo Item': props<{ payload: TodoItem }>()
    }
})