using Dapper;
using System.Data;
using Havira.Tarefas.Domain.Entities;
using Havira.Tarefas.Domain.Interfaces;

namespace Havira.Tarefas.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _connection;

        public UsuarioRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task AddAsync(Usuario usuario)
        {
            var sql = "INSERT INTO Usuarios (Id, Email, Password) VALUES (@Id, @Email, @Password)";
            await _connection.ExecuteAsync(sql, usuario);
        }

        public async Task<Usuario> GetByIdAsync(Guid id)
        {
            var sql = "SELECT * FROM Usuarios WHERE Id = @Id";
            return await _connection.QuerySingleOrDefaultAsync<Usuario>(sql, new { Id = id });
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            var sql = "SELECT * FROM Usuarios WHERE Email = @Email";
            return await _connection.QuerySingleOrDefaultAsync<Usuario>(sql, new { Email = email });
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            var sql = "UPDATE Usuarios SET Email = @Email, Password = @Password WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, usuario);
        }

        public async Task DeleteAsync(Usuario usuario)
        {
            var sql = "DELETE FROM Usuarios WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { usuario.Id });
        }
    }
}
