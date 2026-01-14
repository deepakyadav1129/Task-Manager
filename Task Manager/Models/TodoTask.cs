namespace TaskManager.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
        public required int Priority { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int TodoListId { get; set; }
        public TodoList TodoList { get; set; } = null!;

        public ICollection<SubTask> SubTasks { get; set; } = new List<SubTask>();
        public ICollection<Note> Notes  = new List<Note>();
        public ICollection<Reminder> Reminders { get; set; } = new List<Reminder>();

    }
}
