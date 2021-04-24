using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TechSolution.Business.Models;

namespace TechSolution.Data.Mappings
{
    class QuestionCommentMapping : IEntityTypeConfiguration<QuestionComment>
    {
        public void Configure(EntityTypeBuilder<QuestionComment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreationDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.Property(x => x.QuestionCommentsText)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.ToTable("QuestionComments");
        }
    }
}
