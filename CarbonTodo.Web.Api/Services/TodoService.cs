using CarbonTodo.Core.Entities;
using CarbonTodo.Core.Repositories;

namespace CarbonTodo.Api.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository todoRepository)
    {
        _repository = todoRepository;
    }

    public async Task<Todo> Create(string title)
    {
        var todo = new Todo() { Title = title, Url = "/" };
        return await _repository.AddAsync(todo);
    }

    public async Task Delete(Todo todo)
    {
        await _repository.DeleteAsync(todo);
    }

    public async Task DeleteAll()
    {
        await _repository.DeleteAll();
    }

    public async Task DeleteCompleted()
    {
        await _repository.DeleteCompleted();
    }

    public async Task CompleteAll()
    {
        await _repository.UpdateCompleteAll();
    }

    public async Task<IEnumerable<Todo>> FindAll()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Todo?> FindById(int Id)
    {
        return await _repository.GetByIdAsync(Id);
    }

    public async Task<Todo?> FindByOrder(int order)
    {
        return await _repository.GetByOrder(order);
    }

    public async Task Update(Todo newTodo)
    {
        await _repository.UpdateAsync(newTodo);
    }
}