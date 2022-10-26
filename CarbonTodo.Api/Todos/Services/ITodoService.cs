using CarbonTodo.Core.Todos.Entities;

namespace CarbonTodo.Api.Todos.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> FindAll();

        Task<Todo?> FindById(int id);

        Task<Todo?> FindByOrder(int order);

        Task<Todo> Create(string title);

        Task<Todo> Update(Todo newTodo);

        Task Delete(Todo todo);

        Task DeleteAll();

        Task DeleteCompleted();

    }
}
