import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { TodosDocuments, TodosEvents } from "./todos.actions";
import { map, mergeMap, switchMap } from "rxjs";
import { TodoItem } from "src/app/services/todos-data.service";
import { environment } from "src/environments/environment";
@Injectable()
export class TodosEffects {
    private readonly baseUrl = environment.todoApi;
    loadTodos$ = createEffect(() => this.actions$.pipe(

        ofType(TodosEvents.entered),
        switchMap(() => this.httpClient.get<{ items: TodoItem[] }>(`${this.baseUrl}todo-list`)
            .pipe(
                map(response => response.items), // { items: TodoItems[]} => TodoItem[]
                map(payload => TodosDocuments.todoList({ payload })) // TodoItem[] => 
            )
        )
    ), { dispatch: true })

    saveTodo$ = createEffect(() => this.actions$.pipe(
        ofType(TodosEvents.todoItemAdded),
        mergeMap((a) => this.httpClient.post<TodoItem>(`${this.baseUrl}todo-list`, { description: a.description })
            .pipe(
                map(payload => TodosDocuments.todoItem({ payload }))
            )
        )
    ), { dispatch: true })

    constructor(private readonly actions$: Actions, private readonly httpClient: HttpClient) { }
}