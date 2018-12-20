namespace DataAccess.ClassesManagement.Configurations.Entities
{
    using global::Entities.ClassesManagement;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class LaboratoryManagementConfiguration : BaseManagementEntityConfiguration, IEntityTypeConfiguration<LaboratoryManagement>
    {
        public void Configure(EntityTypeBuilder<LaboratoryManagement> builder)
        {
            base.Configure(builder);

            builder.HasOne(p => p.ManagedLaboratory).WithMany().HasForeignKey(p => p.ClassId);
        }
    }
}
