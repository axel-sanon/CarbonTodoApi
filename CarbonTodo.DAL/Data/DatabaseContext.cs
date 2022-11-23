using CarbonTodo.Core.Entities;
using CarbonTodo.Core.Todos;
using EntityFramework.Exceptions.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CarbonTodo.DAL.Data;

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
        modelBuilder.Entity<Todo>().HasData(new Todo
        {
            Completed = false, Id = 1, Order = 1, Title = "todo", Url = ""
        });
        modelBuilder.Entity<Todo>().HasData(new Todo
        {
            Completed = true, Id = 2, Order = 2, Title = "todo1", Url = ""
        });
    }
}