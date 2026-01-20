using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Models;

namespace Task_Manager.Configurations
{
    public class TaskTagConfiguration : IEntityTypeConfiguration<TaskTag>
    {
        public void Configure(EntityTypeBuilder<TaskTag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.TodoTask) 
                   .WithMany(x => x.TaskTags)
                   .HasForeignKey(x => x.TodoTaskId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relationship: Tag -> TaskTags (One Tag can be used in many TaskTags)
            builder.HasOne(x => x.Tag)
                   .WithMany(x => x.TaskTags)
                   .HasForeignKey(x => x.TagId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
