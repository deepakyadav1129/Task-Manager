namespace TaskManager.Models
{
    public class SubTask
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }

        public int TaskId { get; set; }
        public TodoTask TodoTask { get; set; } = null!;
    }
}
