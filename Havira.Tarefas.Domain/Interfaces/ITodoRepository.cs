using Havira.Tarefas.Domain.Entities;

namespace Havira.Tarefas.Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task AddAsync(Todo todo);
        Task<IEnumerable<Todo>> GetByUserIdAsync(Guid userId);
        Task<Todo> GetByIdAsync(Guid id);
        Task UpdateAsync(Todo todo);
        Task DeleteAsync(Todo todo);
    }
}
