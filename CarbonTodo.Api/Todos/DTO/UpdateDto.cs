using System.ComponentModel.DataAnnotations;

namespace CarbonTodo.Api.Todos.DTO;

public class UpdateDto
{
    [Required] public string Title { get; }

    [Required] public bool Completed { get; }

    [Required] public int Order { get; }
}