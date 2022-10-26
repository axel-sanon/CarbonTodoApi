using CarbonTodo.Core.Todos;
using CarbonTodo.Core.Todos.Entities;
using EntityFramework.Exceptions.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CarbonTodo.Core.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Todo> Todos => Set<Todo>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseExceptionProcessor();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddTodos();
    }
}