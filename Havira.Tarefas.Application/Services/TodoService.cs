using Havira.Tarefas.Application.DTOs.Todos;
using Havira.Tarefas.Application.Interfaces;
using Havira.Tarefas.Domain.Entities;
using Havira.Tarefas.Domain.Interfaces;

namespace Havira.Tarefas.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public TodoService(ITodoRepository todoRepository, IUsuarioRepository usuarioRepository)
        {
            _todoRepository = todoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Todo> CreateTodoAsync(TodoCreateDto todoDto, Guid userId)
        {
            var todo = new Todo
            {
                Id = Guid.NewGuid(),
                Title = todoDto.Title,
                Description = todoDto.Description,
                CreationDate = DateTime.UtcNow,
                UserId = userId
            };

            await _todoRepository.AddAsync(todo);
            return todo;
        }

        public async Task<IEnumerable<Todo>> GetTodosByUserIdAsync(Guid userId)
        {
            return await _todoRepository.GetByUserIdAsync(userId);
        }

        public async Task<Todo> GetTodoByIdAsync(Guid id)
        {
            return await _todoRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateTodoAsync(Guid id, TodoUpdateDto todoDto)
        {
            var todo = await _todoRepository.GetByIdAsync(id);
            if (todo != null)
            {
                todo.Title = todoDto.Title;
                todo.Description = todoDto.Description;
                todo.CompletionDate = todoDto.CompletionDate;
                await _todoRepository.UpdateAsync(todo);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteTodoAsync(Guid id)
        {
            var todo = await _todoRepository.GetByIdAsync(id);
            if (todo != null)
            {
                await _todoRepository.DeleteAsync(todo);
                return true;
            }
            return false;
        }
    }
}
