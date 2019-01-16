using DataAccess.FilesHandler.Configurations.Entities;
using Entities.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Questions.Configurations.Entities
{
    public class AnswerConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Answer>
    {        
            public void Configure(EntityTypeBuilder<Answer> builder)
            {
                base.Configure(builder);

            builder.Property(p => p.AnswerString)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(p => p.Question).WithMany(p => p.Answers).HasForeignKey(p => p.QuestionId);
            }        
    }
}
