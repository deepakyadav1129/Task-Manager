namespace TaskManager.Models
{
    public class Reminder
    {
        public int Id { get; set; }
        public DateTime RemindAt { get; set; }
        public int TaskId { get; set; }
        public TodoTask TodoTask { get; set; } = null!;
    }
}
