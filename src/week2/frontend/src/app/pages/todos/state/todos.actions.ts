import { createActionGroup, emptyProps, props } from "@ngrx/store";
import { TodoItem } from "src/app/services/todos-data.service";
import { FilterPrefsComponent } from "../components/filter-prefs/filter-prefs.component";
import { FilterOptions } from ".";

export const TodosEvents = createActionGroup({
    source: 'Todos Events',
    events: {
        'Entered': emptyProps(),
        'Todo Item Added': props<{ description: string }>(),
        'Todo Item Completed': props<{ payload: TodoItem }>(),
        'Todo Item Failed Completed': props<{ payload: TodoItem }>(),
        'Todo List Filtered By': props<{ by: FilterOptions }>()
    }
})


export const TodosDocuments = createActionGroup({
    source: 'Todos Documents',
    events: {
        'Todo List': props<{ payload: TodoItem[] }>(),
        'Todo Item': props<{ payload: TodoItem }>()
    }
})