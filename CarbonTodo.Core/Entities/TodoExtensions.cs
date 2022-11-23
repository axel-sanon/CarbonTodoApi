using CarbonTodo.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace CarbonTodo.Core.Todos;

public static class TodoExtensions
{
    public static ModelBuilder AddTodos(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>().HasKey(todo => todo.Id);
        modelBuilder.Entity<Todo>().Property(todo => todo.Title).IsRequired();
        modelBuilder.Entity<Todo>().HasIndex(todo => todo.Order).IsUnique();
        modelBuilder.Entity<Todo>().Property(todo => todo.Completed).HasDefaultValue(false);
        
        return modelBuilder;
    }
}