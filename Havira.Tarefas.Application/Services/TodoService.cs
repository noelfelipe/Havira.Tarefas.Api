using AutoMapper;
using Havira.Tarefas.Application.DTOs.Requests.Todos;
using Havira.Tarefas.Application.DTOs.Responses;
using Havira.Tarefas.Application.Interfaces;
using Havira.Tarefas.Domain.Entities;
using Havira.Tarefas.Domain.Interfaces;

namespace Havira.Tarefas.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public TodoService(IMapper mapper,ITodoRepository todoRepository)
        {
            _mapper = mapper;
            _todoRepository = todoRepository;
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

        public async Task<IEnumerable<TodoReadDto>> GetTodosByUserIdAsync(Guid userId)
        {
            var todo = await _todoRepository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<TodoReadDto>>(todo);
        }

        public async Task<TodoReadDto> GetTodoByIdAsync(Guid id)
        {
            var todo = await _todoRepository.GetByIdAsync(id);
            return _mapper.Map<TodoReadDto>(todo);
        }

        public async Task<bool> UpdateTodoAsync(Guid id, TodoUpdateDto todoDto)
        {
            var todo = await _todoRepository.GetByIdAsync(id);
            if (todo != null)
            {
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
