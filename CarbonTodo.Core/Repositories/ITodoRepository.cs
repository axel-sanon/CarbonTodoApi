using CarbonTodo.Core.Entities;

namespace CarbonTodo.Core.Repositories;

public interface ITodoRepository
{

    public Task<IReadOnlyList<Todo>> GetAllAsync();

    Task<Todo> GetByIdAsync(int id);

    public Task UpdateAsync(Todo todo);

    Task<Todo> AddAsync(Todo todo);

    public Task<Todo?> GetByOrder(int order);

    public Task DeleteAll();

    public Task DeleteCompleted();
    Task DeleteAsync(Todo todo);
    Task UpdateCompleteAll();
}