namespace Havira.Tarefas.Application.DTOs.Todos
{
    public class TodoReadDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public Guid UserId { get; set; }
    }
}
