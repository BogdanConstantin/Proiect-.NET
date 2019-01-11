namespace DataAccess.FilesHandler.Configurations.Entities
{
    using global::Entities.FilesHandler;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class FileConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<FileMetadata>
    {
        public void Configure(EntityTypeBuilder<FileMetadata> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Path)
                .IsRequired();

            builder.Property(p => p.FileName)
                .IsRequired();

            builder.Property(p => p.CourseId)
                .IsRequired();
        }
    }
}
