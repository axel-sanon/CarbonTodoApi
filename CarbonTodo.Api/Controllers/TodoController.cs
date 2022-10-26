using CarbonTodo.Api.Todos.DTO;
using CarbonTodo.Api.Todos.Services;
using CarbonTodo.Core.Todos.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CarbonTodo.Controllers
{
    [ApiController]
    [Route("todos")]
    public class TodoController : ControllerBase
    {

        private readonly ITodoService _service;
        public TodoController(ITodoService todoService)
        {
            _service = todoService;
        }


        [HttpGet(Name = "GetAllTodos")]
        public async Task<ActionResult<IEnumerable<Todo>>> FindAll()
        {
            return Ok(await _service.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOne(int id)
        {
            var todo = await _service.FindById(id);

            if (todo is null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Create([FromBody] CreateDto dto)
        {
            var todo = await _service.Create(dto.Title);
            return Created(todo.Url, todo);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(bool? completed)
        {
            if (completed is null)
            {
                await _service.DeleteAll();
                return NoContent();
            }


            await _service.DeleteCompleted();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _service.FindById(id);

            if (todo is null)
            {
                return NotFound();
            }

            await _service.Delete(todo);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDto dto)
        {
            var todo = await _service.FindById(id);

            if (todo is null)
            {
                return NotFound();
            }

            var orderTodo = await _service.FindByOrder(dto.Order);
            if (orderTodo is not null && todo.Id != orderTodo.Id)
            {
                return Conflict();
            }

            await _service.Update(new Todo()
            {
                Id = id,
                Title = dto.Title,
                Completed = dto.Completed,
                Order = dto.Order
            });

            return Ok();
        }

        //[HttpPatch("{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody] JsonPatchDocument<Todo> patchTodo)
        //{

        //    var foundTodo = await _service.FindById(id);
        //    if(foundTodo is null)
        //    {
        //        return NotFound();
        //    }
        //    var orderTodo = await _service.FindByOrder(
        //        );
        //    if (orderTodo is not null && foundTodo.Id != orderTodo.Id)
        //    {
        //        return Conflict();
        //    }


        //    if (patchTodo != null)
        //    {
        //        var todo = new Todo();

        //        patchTodo.ApplyTo(todo, ModelState);

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}
    }
}
