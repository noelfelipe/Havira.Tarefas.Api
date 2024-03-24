using System.ComponentModel.DataAnnotations;

namespace Havira.Tarefas.Application.DTOs.Requests.Todos
{
    public class TodoUpdateDto
    {
        [Required(ErrorMessage = "Por favor, insira a data de conclusão da tarefa.")]
        public required DateTime? CompletionDate { get; set; }
    }

}
