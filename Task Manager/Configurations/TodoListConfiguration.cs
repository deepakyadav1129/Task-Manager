using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Models;

namespace TaskManager.Configurations
{
    public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            // Relationship: User -> TodoLists (One-to-Many)
            // Each TodoList belongs to exactly one User
            // UserId acts as the foreign key
            builder.HasOne(x => x.User)
                   .WithMany(x => x.TodoLists)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relationship: TodoList -> Tasks (One-to-Many)
            // A TodoList can contain multiple TodoTasks
            // Deleting a TodoList deletes all its tasks
            builder.HasMany(x => x.TodoTasks)
                   .WithOne(x => x.TodoList)
                   .HasForeignKey(x => x.TodoListId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
