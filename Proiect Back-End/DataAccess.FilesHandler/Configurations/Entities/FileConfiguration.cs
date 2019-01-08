namespace DataAccess.FilesHandler.Configurations.Entities
{
    using global::Entities.FilesHandler;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class FileConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Path)
                .IsRequired();

            builder.HasOne(f => f.Course).WithMany().HasForeignKey(f => f.CourseId);
        }
    }
}
