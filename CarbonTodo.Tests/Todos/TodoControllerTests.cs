using Moq;
using CarbonTodo.Api.Controllers;
using CarbonTodo.Core.Entities;
using Xunit;
using CarbonTodo.Api.Services;

namespace CarbonTodo.Tests.Todos;

public class TodoControllerTests
{
    [Fact]
    public async Task GetAllTodos_return_list_of_todos_with_ok()
    {
        var todos = new List<Todo>();
        var mockService = new Mock<ITodoService>();
        mockService.Setup(s => s.FindAll()).ReturnsAsync(todos);

        var sut = new TodoController(mockService.Object);


        var result = await sut.FindAll();
    }
}