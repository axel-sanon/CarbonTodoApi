using CarbonTodo.Core.Entities;
using CarbonTodo.Core.Repositories;
using CarbonTodo.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace CarbonTodo.DAL.Repositories;

public class TodoRepository : ITodoRepository
{
    protected readonly DatabaseContext _dbContext;

    public TodoRepository(DatabaseContext context)
    {
        _dbContext = context;
    }

    public async Task<IReadOnlyList<Todo>> GetAllAsync()
    {
        return (await _dbContext.Todos.ToListAsync()).AsReadOnly();
    }

    public async Task<Todo> GetByIdAsync(int id)
    {
        return await _dbContext.Todos.FindAsync(id);
    }
    
    public async Task<int> GetMaxOrder()
    {
        return (await _dbContext.Todos.ToListAsync()).Select(x => x.Order).DefaultIfEmpty(0).Max();
    }

    public async Task<Todo> AddAsync(Todo todo)
    {
        int order = ( await GetMaxOrder()) + 1;

        todo.Order = order;
        await _dbContext.AddAsync(todo);
        todo.Url = $"/todos/{todo.Id}";

        _dbContext.SaveChanges();
        return todo;
    }

    public async Task<Todo?> GetByOrder(int order)
    {
        return await _dbContext.Todos.FirstOrDefaultAsync(t => t.Order == order);
    }

    public async Task DeleteAll()
    {
        _dbContext.Todos.RemoveRange(await _dbContext.Todos.ToListAsync());
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteCompleted()
    {
        var completedTodos = _dbContext.Todos.Where(todo => todo.Completed).ToList();
        _dbContext.Todos.RemoveRange(completedTodos);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Todo todo)
    {
        var t = _dbContext.Todos.Find(todo.Id);
        t.Order = todo.Order;
        t.Title = todo.Title;
        t.Url = $"/todos/{t.Id}";
        t.Completed = todo.Completed;


        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Todo todo)
    {
        _dbContext.Todos.Remove(todo);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateCompleteAll()
    {
        foreach (var todo in _dbContext.Todos)
        {
            todo.Completed = true;
        }
        await _dbContext.SaveChangesAsync();
    }
}