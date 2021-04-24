using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechSolution.Business.Models;

namespace TechSolution.Data.Mappings
{
    public class AnswerMapping : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AnswerText)
                .HasColumnType("varchar(1500)")
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.HasMany(x => x.AnswerComments)
                .WithOne(x => x.Answer)
                .HasForeignKey(x => x.AnswerId);

            //builder.HasOne(x => x.Question)
            //    .WithMany(x => x.Answers)
            //    .HasForeignKey(x => x.QuestionId);

            builder.ToTable("Answers");
        }
    }
}
