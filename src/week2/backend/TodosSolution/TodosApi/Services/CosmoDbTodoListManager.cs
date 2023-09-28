namespace TodosApi.Services;

public class CosmoDbTodoListManager : IManageTodoLists
{
    public Task<TodoItemResponse> AddTodoItemAsync(TodoCreateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<TodoListSummaryResponse> GetAllTodosAsync()
    {
        throw new NotImplementedException();
    }
}
