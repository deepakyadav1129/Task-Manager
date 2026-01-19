namespace TaskManager.Models
{
    public class Note
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public int TodoTaskId { get; set; }
        public TodoTask TodoTask { get; set; } = null!;
    }
}
