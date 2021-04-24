using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TechSolution.Business.Models;

namespace TechSolution.Data.Mappings
{
    public class QuestionMapping : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.QuestionText)
                .HasColumnType("varchar(1500)")
                .IsRequired();

            builder.Property(p => p.QuestionTitle)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.QuestionViewed)
                .HasColumnType("float default(0)");

            builder.Property(p => p.QuestionTags)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.CreationDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.HasMany(p => p.Answers)
                .WithOne(p => p.Question)
                .HasForeignKey(fk => fk.QuestionId);

            builder.HasMany(p => p.QuestionsComments)
                .WithOne(p => p.Question)
                .HasForeignKey(fk => fk.QuestionId);

            builder.ToTable("Questions");
        }
    }
}
