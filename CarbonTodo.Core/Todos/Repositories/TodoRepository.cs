using CarbonTodo.Core.Data;
using CarbonTodo.Core.Todos.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarbonTodo.Core.Todos.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly DatabaseContext _db;

    public TodoRepository(DatabaseContext todoDb)
    {
        _db = todoDb;
    }

    public async Task<IEnumerable<Todo>> FindAll()
    {
        var todos = await _db.Todos.OrderBy(t => t.Order).ToListAsync();
        return todos;
    }

    public async Task<Todo> Create(string title)
    {
        var todo = new Todo { Title = title };
        await _db.Todos.AddAsync(todo);

        todo.Url = "";
        await _db.SaveChangesAsync();
        todo.Url = $"todos/{todo.Id}";
        _db.Todos.Update(todo);
        await _db.SaveChangesAsync();

        return todo;
    }

    public async Task DeleteCompleted()
    {
        var completedTodos = _db.Todos.Where(todo => todo.Completed).ToList();
        await Delete(completedTodos);
    }

    public async Task DeleteAll()
    {
        var allTodos = _db.Todos.ToList();
        await Delete(allTodos);
    }

    public async Task Delete(int id)
    {
        await Delete(new Todo { Id = id });
    }

    public async Task<Todo?> FindById(int id)
    {
        return await _db.Todos.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task Update(Todo todo)
    {
        _db.Todos.Update(todo);
        await _db.SaveChangesAsync();
    }

    public async Task<Todo?> FindByOrder(int order)
    {
        return await _db.Todos.FirstOrDefaultAsync(t => t.Order == order);
    }

    public async Task Delete(Todo todo)
    {
        _db.Todos.Remove(todo);
        await _db.SaveChangesAsync();
    }

    private async Task Delete(IEnumerable<Todo> todos)
    {
        _db.Todos.RemoveRange(todos);
        await _db.SaveChangesAsync();
    }
}