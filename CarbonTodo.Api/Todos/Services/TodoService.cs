using CarbonTodo.Core.Todos.Entities;
using CarbonTodo.Core.Todos.Repositories;

namespace CarbonTodo.Api.Todos.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;
        public TodoService(ITodoRepository todoRepository)
        {
            _repository = todoRepository;
        }

        public async Task<Todo> Create(string title)
        {
            return await _repository.Create(title);
        }

        public async Task Delete(Todo todo)
        {
            await _repository.Delete(todo);
            
        }

        public async Task DeleteAll()
        {
            await _repository.DeleteAll();
        }

        public async Task DeleteCompleted()
        {
            await _repository.DeleteCompleted();
        }

        public async Task<IEnumerable<Todo>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Todo?> FindById(int Id)
        {
            return await _repository.FindById(Id);
        }

        public async Task<Todo?> FindByOrder(int order)
        {
            return await _repository.FindByOrder(order);  
        }

        public Task<Todo> Update(Todo newTodo)
        {
            throw new NotImplementedException();
        }

    }
}
