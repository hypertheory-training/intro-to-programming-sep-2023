import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createFeature, createReducer, createSelector, on } from "@ngrx/store";
import { TodoItem } from "src/app/services/todos-data.service";
import { TodosDocuments, TodosEvents } from "./todos.actions";


export interface TodosState extends EntityState<TodoItem> {
    hasError: boolean,
    isLoaded: boolean,
    sortBy: 'description' | 'status'
}

const adapter = createEntityAdapter<TodoItem>();

const initialState: TodosState = adapter.getInitialState({
    hasError: false,
    isLoaded: false,
    sortBy: 'description'
});

export const todosFeature = createFeature({
    name: 'todos',
    reducer: createReducer(initialState,
        on(TodosEvents.todoItemFailedCompleted, (s, a) => adapter.updateOne({ id: a.payload.id, changes: { completed: false } }, s)),
        on(TodosEvents.todoItemFailedCompleted, (s) => ({ ...s, hasError: true })),
        on(TodosEvents.todoItemCompleted, (s, a) => adapter.updateOne({ id: a.payload.id, changes: { completed: true } }, s)),
        on(TodosDocuments.todoItem, (s, a) => adapter.addOne(a.payload, s)),
        on(TodosDocuments.todoList, (s, a) => adapter.setAll(a.payload, s))),
    extraSelectors: ({ selectTodosState }) => {

        const { selectAll } = adapter.getSelectors();
        const selectTodoList = createSelector(selectTodosState, s => selectAll(s))
        return {
            selectTodoList
        }
    }
})