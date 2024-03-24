using System.ComponentModel.DataAnnotations;

namespace Havira.Tarefas.Application.DTOs.Requests.Todos
{
    public class TodoCreateDto
    {
        [Required(ErrorMessage = "Por favor, insira o título da tarefa.")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Por favor, insira a descrição da tarefa.")]
        public required string Description { get; set; }
    }
}
