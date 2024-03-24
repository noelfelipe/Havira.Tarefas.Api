using Dapper;
using System.Data;
using Havira.Tarefas.Domain.Entities;
using Havira.Tarefas.Domain.Interfaces;

namespace Havira.Tarefas.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IDbConnection _connection;

        public TodoRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task AddAsync(Todo todo)
        {
            var sql = "INSERT INTO Todos (Id, Title, Description, CreationDate, CompletionDate, UserId) VALUES (@Id, @Title, @Description, @CreationDate, @CompletionDate, @UserId)";
            await _connection.ExecuteAsync(sql, todo);
        }

        public async Task<IEnumerable<Todo>> GetByUserIdAsync(Guid userId)
        {
            var sql = "SELECT * FROM Todos WHERE UserId = @UserId";
            return await _connection.QueryAsync<Todo>(sql, new { UserId = userId });
        }

        public async Task<Todo> GetByIdAsync(Guid id)
        {
            var sql = "SELECT * FROM Todos WHERE Id = @Id";
            return await _connection.QuerySingleOrDefaultAsync<Todo>(sql, new { Id = id });
        }

        public async Task UpdateAsync(Todo todo)
        {
            var sql = "UPDATE Todos SET CompletionDate = @CompletionDate WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, todo);
        }

        public async Task DeleteAsync(Todo todo)
        {
            var sql = "DELETE FROM Todos WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { todo.Id });
        }
    }
}
