using CarbonTodo.Core.Todos.Entities;

namespace CarbonTodo.Core.Todos.Repositories;

public interface ITodoRepository
{
    Task<Todo?> FindById(int id);
    Task<Todo?> FindByOrder(int order);
    Task<IEnumerable<Todo>> FindAll();
    Task<Todo> Create(string title);
    Task DeleteCompleted();
    Task DeleteAll();
    Task Delete(int id);
    Task Delete(Todo todo);
    Task Update(Todo todo);
}