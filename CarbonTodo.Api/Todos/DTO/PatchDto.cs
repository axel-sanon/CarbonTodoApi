namespace CarbonTodo.Api.Todos.DTO;

public class PatchDto
{
    public string Title { get; }

    public bool Completed { get; }

    public int Order { get; }
}