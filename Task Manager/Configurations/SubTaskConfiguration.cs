using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Models;

namespace Task_Manager.Configurations
{
    public class SubTaskConfiguration : IEntityTypeConfiguration<SubTask>
    {
        public void Configure(EntityTypeBuilder<SubTask> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(150);
            builder.Property(x => x.IsCompleted).IsRequired();
            builder.Property(x => x.CompletedAt).HasDefaultValueSql("GETUTCDATE()");

            // Each SubTask belongs to one TodoTask
            // A SubTask cannot exist without its parent task
            builder.HasOne(x => x.TodoTask) // 
                   .WithMany(x => x.SubTasks) //
                   .HasForeignKey(x => x.TodoTaskId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
