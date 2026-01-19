using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Models;

namespace Task_Manager.Configurations
{
        public class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
        {
            public void Configure(EntityTypeBuilder<Reminder> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.RemindAt).IsRequired();

                // Each Reminder belongs to one TodoTask
                // Reminder cannot exist without a task
                builder.HasOne<TodoTask>(x => x.TodoTask)
                    .WithMany(x => x.Reminders)
                    .HasForeignKey(x => x.TodoTaskId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        }
}
