using CarbonTodo.Core.Entities;

namespace CarbonTodo.Api.Services;

public interface ITodoService
{
    Task<IEnumerable<Todo>> FindAll();

    Task<Todo?> FindById(int id);

    Task<Todo?> FindByOrder(int order);

    Task<Todo> Create(string title);

    Task Update(Todo newTodo);

    Task Delete(Todo todo);

    Task DeleteAll();

    Task DeleteCompleted();
    Task CompleteAll();
}