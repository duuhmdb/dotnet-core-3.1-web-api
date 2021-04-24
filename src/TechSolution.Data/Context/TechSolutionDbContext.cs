using Microsoft.EntityFrameworkCore;
using System.Linq;
using TechSolution.Business.Models;

namespace TechSolution.Data.Context
{
    public class TechSolutionDbContext : DbContext
    {
        public TechSolutionDbContext(DbContextOptions<TechSolutionDbContext> options)
            : base(options)
        { }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<AnswerComment> AnswersComments { get; set; }

        public DbSet<QuestionComment> QuestionsComments { get; set; }

        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Remove general cascade delete
            foreach (var tableOptions in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
                tableOptions.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechSolutionDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
