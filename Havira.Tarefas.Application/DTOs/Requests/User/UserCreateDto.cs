using System.ComponentModel.DataAnnotations;

namespace Havira.Tarefas.Application.DTOs.Requests.User
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "Por favor, insira o Email para criação do Usuario.")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Por favor, insira a Senha para criação do Usuario.")]
        public required string Password { get; set; }
    }
}
