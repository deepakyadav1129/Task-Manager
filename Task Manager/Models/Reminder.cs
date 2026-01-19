namespace TaskManager.Models
{
    public class Reminder
    {
        public int Id { get; set; }
        public DateTime RemindAt { get; set; }
        public int TodoTaskId { get; set; }
        public TodoTask TodoTask { get; set; } = null!;
    }
}
