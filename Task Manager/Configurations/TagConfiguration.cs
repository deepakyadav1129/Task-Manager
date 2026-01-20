using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Models;

namespace Task_Manager.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Color).IsRequired().HasMaxLength(150);
            builder.HasMany(x => x.TaskTags) 
                   .WithOne(x => x.Tag) 
                   .HasForeignKey(x => x.TagId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
