using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Models;

namespace Task_Manager.Configurations
{
    public class NoteConfiguraion : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            // Each Note is belongs to a single TodoTask
            // Notes are deleted automatically when the task is deleted
            builder.HasOne<TodoTask>(x => x.TodoTask)
                .WithMany(x => x.Notes)
                .HasForeignKey(x => x.TodoTaskId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
