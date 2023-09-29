import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createFeature, createReducer, createSelector, on } from "@ngrx/store";
import { TodoItem } from "src/app/services/todos-data.service";
import { TodosDocuments, TodosEvents } from "./todos.actions";
import { TodoSummary } from "src/app/components/todo-summary.component";

export type FilterOptions = 'completed' | 'incomplete' | 'all';
export interface TodosState extends EntityState<TodoItem> {
    hasError: boolean,
    isLoaded: boolean,
    filterBy: FilterOptions
}

const adapter = createEntityAdapter<TodoItem>();

const initialState: TodosState = adapter.getInitialState({
    hasError: false,
    isLoaded: false,
    filterBy: 'all'
});

export const todosFeature = createFeature({
    name: 'todos',
    reducer: createReducer(initialState,
        on(TodosEvents.todoListFilteredBy, (s, { by }) => ({ ...s, filterBy: by })),
        on(TodosEvents.todoItemFailedCompleted, (s, a) => adapter.updateOne({ id: a.payload.id, changes: { completed: false } }, s)),
        on(TodosEvents.todoItemFailedCompleted, (s) => ({ ...s, hasError: true })),
        on(TodosEvents.todoItemCompleted, (s, a) => adapter.updateOne({ id: a.payload.id, changes: { completed: true } }, s)),
        on(TodosDocuments.todoItem, (s, a) => adapter.addOne(a.payload, s)),
        on(TodosDocuments.todoList, (s, a) => adapter.setAll(a.payload, s))),
    extraSelectors: ({ selectTodosState, selectFilterBy }) => {

        const { selectAll } = adapter.getSelectors();
        const todos = createSelector(selectTodosState, s => selectAll(s))


        return {
            selectTodoList: createSelector(selectFilterBy, todos, (filter, todos) => {

                if (filter === 'completed') {
                    return todos.filter(t => t.completed === true)
                }
                if (filter === 'incomplete') {
                    return todos.filter(t => t.completed === false)
                }
                return todos;
            }),
            selectTodoSummary: createSelector(todos, (todos) => {
                return {
                    total: todos.length,
                    complete: todos.filter(t => t.completed === true).length,
                    incomplete: todos.filter(t => t.completed === false).length
                } as TodoSummary
            })
        }
    }
})