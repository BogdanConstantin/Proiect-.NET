using DataAccess.FilesHandler.Configurations.Entities;
using Entities.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Questions.Configurations.Entities
{
    public class QuestionConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.QuestionString)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
