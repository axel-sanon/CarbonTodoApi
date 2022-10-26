using CarbonTodo.Api.Todos.Services;
using CarbonTodo.Controllers;
using CarbonTodo.Core.Todos.Entities;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace CarbonTodo.Tests.Todos
{

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
}
