using Havira.Tarefas.Domain.Entities;

namespace Havira.Tarefas.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
    }
}
