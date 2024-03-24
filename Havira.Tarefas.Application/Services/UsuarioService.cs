using Havira.Tarefas.Domain.Entities;
using Havira.Tarefas.Domain.Interfaces;
using Havira.Tarefas.Application.Interfaces;
using System.Security.Claims;
using System.Text;
using Havira.Tarefas.Application.DTOs.Requests.User;

namespace Havira.Tarefas.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> CreateUsuarioAsync(UserCreateDto usuarioDto)
        {
            var existingUser = await _usuarioRepository.GetByEmailAsync(usuarioDto.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Já existe um usuário com este e-mail.");
            }

            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Email = usuarioDto.Email,
                Password = HashPassword(usuarioDto.Password)
            };

            await _usuarioRepository.AddAsync(usuario);

            return usuario;
        }

        public async Task<Usuario> GetUsuarioByEmailAsync(string email)
        {
            return await _usuarioRepository.GetByEmailAsync(email);
        }


        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
