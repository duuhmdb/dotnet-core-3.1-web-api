using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechSolution.Business.Models;

namespace TechSolution.Data.Mappings
{
    class AnswerCommentMapping : IEntityTypeConfiguration<AnswerComment>
    {
        public void Configure(EntityTypeBuilder<AnswerComment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreationDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.Property(x => x.AnswerCommentText)
                .HasColumnType("varchar(1000)")
                .IsRequired();

            builder.ToTable("AnswersComments");
        }
    }
}
