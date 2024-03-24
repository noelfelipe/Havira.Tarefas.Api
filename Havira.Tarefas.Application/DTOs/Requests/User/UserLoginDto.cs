using System.ComponentModel.DataAnnotations;

namespace Havira.Tarefas.Application.DTOs.Requests.User
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Por favor, insira o Email para efetuar o login.")]
        [EmailAddress(ErrorMessage = "Por favor digite um Email valido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Por favor, insira a Senha para efetuar o login.")]
        public string Password { get; set; }
    }
}
