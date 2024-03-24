using Havira.Tarefas.Domain.Entities;
using Havira.Tarefas.Domain.Interfaces;
using Havira.Tarefas.Application.DTOs.User;
using Havira.Tarefas.Application.Interfaces;
using System.Security.Claims;
using System.Text;

namespace Havira.Tarefas.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> CreateUsuarioAsync(UsuarioCreateDto usuarioDto)
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

        public async Task<Usuario> GetUsuarioByIdAsync(Guid id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task<Usuario> GetUsuarioByEmailAsync(string email)
        {
            return await _usuarioRepository.GetByEmailAsync(email);
        }

        public async Task UpdateUsuarioAsync(Guid id, UsuarioUpdateDto usuarioDto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                throw new InvalidOperationException("Usuário não encontrado.");
            }

            usuario.Password = HashPassword(usuarioDto.Password);
            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteUsuarioAsync(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                throw new InvalidOperationException("Usuário não encontrado.");
            }

            await _usuarioRepository.DeleteAsync(usuario);
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
