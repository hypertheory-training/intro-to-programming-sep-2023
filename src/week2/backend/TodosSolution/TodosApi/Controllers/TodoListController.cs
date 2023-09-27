namespace TodosApi.Controllers;

[ApiController]
public class TodoListController : ControllerBase
{

    // GET /todo-list

    [HttpPost("/todo-list")]
    public async Task<ActionResult> AddTodoItem([FromBody] TodoCreateRequest request)
    {
        // Some Magic! (Code)
        var response = new TodoItemResponse
        {
            Id = Guid.NewGuid().ToString(),
            Description = request.Description,
            Completed = false
        };
        return StatusCode(201, response);
    }
}
