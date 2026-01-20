namespace TaskManager.Models
{
    public class TaskTag
    {
        public int Id { get; set; }


        public int TagId { get; set; } //FK As Each task will have one tag
        public Tag Tag { get; set; } = null!;

        public int TodoTaskId { get; set; }
        public TodoTask TodoTask { get; set; } = null!;

    }
}
