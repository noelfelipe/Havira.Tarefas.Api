using Havira.Tarefas.Application.DTOs.Requests.User;
using Havira.Tarefas.Domain.Entities;

namespace Havira.Tarefas.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> CreateUsuarioAsync(UserCreateDto usuarioDto);
        Task<Usuario> GetUsuarioByEmailAsync(string email);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
