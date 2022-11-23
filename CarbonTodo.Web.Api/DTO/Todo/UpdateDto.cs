using System.ComponentModel.DataAnnotations;

namespace CarbonTodo.Api.DTO.Todo;

public class UpdateDto
{
    public UpdateDto(string title, bool completed, int order)
    {
        Title = title;
        Completed = completed;
        Order = order;
    }

    [Required] public string Title { get; }

    [Required] public bool Completed { get; }

    [Required] public int Order { get; }
}