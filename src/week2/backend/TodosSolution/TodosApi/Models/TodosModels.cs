using System.ComponentModel.DataAnnotations;

namespace TodosApi.Models;


public record TodoCreateRequest
{
    [Required, MaxLength(255)]
    public string Description { get; set; } = string.Empty;
}

public record TodoItemResponse
{
    public string Id { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Completed { get; set; }
}