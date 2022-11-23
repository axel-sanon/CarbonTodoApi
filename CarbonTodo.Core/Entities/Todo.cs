namespace CarbonTodo.Core.Entities;

public class Todo
{
    public int Id { get; init; }

    public string Title { get; set; }

    public bool Completed { get; set; }

    public int Order { get; set; }

    public string Url { get; set; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Todo);
    }

    public bool Equals(Todo? other)
    {
        return other is not null &&
               Id == other.Id &&
               Title == other.Title &&
               Completed == other.Completed &&
               Order == other.Order &&
               Url == other.Url;
    }

    public static bool operator ==(Todo? left, Todo? right)
    {
        return EqualityComparer<Todo>.Default.Equals(left, right);
    }

    public static bool operator !=(Todo? left, Todo? right)
    {
        return !(left == right);
    }
}