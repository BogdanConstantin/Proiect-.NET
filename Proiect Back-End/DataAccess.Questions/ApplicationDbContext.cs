using DataAccess.Questions.Configurations.Entities;
using Entities.Questions;

namespace DataAccess.Questions
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());

            modelBuilder.ApplyConfiguration( new QuestionConfiguration());
        }
    }
}
