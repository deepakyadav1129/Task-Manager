using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Models;

namespace TaskManager.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) { 
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100); 
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(500);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            // A User can own multiple TodoLists
            // If a User is deleted, all their TodoLists should also be deleted
            builder.HasMany(x => x.TodoLists) // user has one to many relation with todolist table
                   .WithOne(x => x.User) //
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
