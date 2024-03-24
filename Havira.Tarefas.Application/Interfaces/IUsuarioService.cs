using Havira.Tarefas.Application.DTOs.User;
using Havira.Tarefas.Domain.Entities;

namespace Havira.Tarefas.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> CreateUsuarioAsync(UsuarioCreateDto usuarioDto);
        Task<Usuario> GetUsuarioByIdAsync(Guid id);
        Task<Usuario> GetUsuarioByEmailAsync(string email);
        Task UpdateUsuarioAsync(Guid id, UsuarioUpdateDto usuarioDto);
        Task DeleteUsuarioAsync(Guid id);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
