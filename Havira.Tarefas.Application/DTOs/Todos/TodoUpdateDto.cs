namespace Havira.Tarefas.Application.DTOs.Todos
{
    public class TodoUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CompletionDate { get; set; }
    }

}
