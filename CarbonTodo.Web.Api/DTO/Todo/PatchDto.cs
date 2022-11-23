namespace CarbonTodo.Api.DTO.Todo;

public class PatchDto
{
    public string Title { get; }

    public bool Completed { get; }

    public int Order { get; }
}