using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Models;

namespace Task_Manager.Configurations
{
    public class TodoTaskConfiguration : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Priority).IsRequired();
            builder.Property(x => x.DueDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdatedAt).HasDefaultValueSql("GETUTCDATE()");

            // A TodoTask can have multiple SubTasks
            // Deleting the task deletes all its subtasks
            builder.HasMany(x => x.SubTasks)
                   .WithOne(x => x.TodoTask)
                   .HasForeignKey(x => x.TodoTaskId)
                   .OnDelete(DeleteBehavior.Cascade);

            // A TodoTask can have multiple Notes
            // Notes cannot exist without a task
            builder.HasMany(x => x.Notes)
                .WithOne(x => x.TodoTask)
                .HasForeignKey(x => x.TodoTaskId)
                .OnDelete(DeleteBehavior.Cascade);

            // A TodoTask can have multiple Reminders
            // Deleting the task removes all reminders
            builder.HasMany(x => x.Reminders)
                .WithOne(x => x.TodoTask)
                .HasForeignKey(x => x.TodoTaskId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
