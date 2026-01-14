namespace TaskManager.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<TodoTask> TodoTasks { get; set; } = new List<TodoTask>();
    }
}
