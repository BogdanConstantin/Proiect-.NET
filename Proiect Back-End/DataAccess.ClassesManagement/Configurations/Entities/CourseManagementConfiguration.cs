namespace DataAccess.ClassesManagement.Configurations.Entities
{
    using global::Entities.ClassesManagement;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class CourseManagementConfiguration : BaseManagementEntityConfiguration, IEntityTypeConfiguration<CourseManagement>
    {
        public void Configure(EntityTypeBuilder<CourseManagement> builder)
        {
            base.Configure(builder);

            builder.HasOne(p => p.ManagedCourse).WithMany().HasForeignKey(p => p.ClassId);
        }
    }
}
