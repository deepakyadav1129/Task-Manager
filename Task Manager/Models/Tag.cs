namespace TaskManager.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Color { get; set; }
        public ICollection<TaskTag> TaskTags { get; set; } = new List<TaskTag>();
    }
}
