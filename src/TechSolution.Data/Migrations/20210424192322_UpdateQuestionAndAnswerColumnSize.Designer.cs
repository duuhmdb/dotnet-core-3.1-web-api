﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechSolution.Data.Context;

namespace TechSolution.Data.Migrations
{
    [DbContext(typeof(TechSolutionDbContext))]
    [Migration("20210424192322_UpdateQuestionAndAnswerColumnSize")]
    partial class UpdateQuestionAndAnswerColumnSize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TechSolution.Business.Models.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AcceptedAnswer")
                        .HasColumnType("bit");

                    b.Property<int>("AnswerDownvotes")
                        .HasColumnType("int");

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("varchar(1500)");

                    b.Property<int>("AnswerUpvotes")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("TechSolution.Business.Models.AnswerComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnswerCommentDownvotes")
                        .HasColumnType("int");

                    b.Property<string>("AnswerCommentText")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("AnswerCommentUpvotes")
                        .HasColumnType("int");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.ToTable("AnswersComments");
                });

            modelBuilder.Entity("TechSolution.Business.Models.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("QuestionTags")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("varchar(1500)");

                    b.Property<string>("QuestionTitle")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<double>("QuestionViewed")
                        .HasColumnType("float default(0)");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("TechSolution.Business.Models.QuestionComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("QuestionCommentsDownvotes")
                        .HasColumnType("int");

                    b.Property<string>("QuestionCommentsText")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("QuestionCommentsUpvotes")
                        .HasColumnType("int");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionComments");
                });

            modelBuilder.Entity("TechSolution.Business.Models.Answer", b =>
                {
                    b.HasOne("TechSolution.Business.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("TechSolution.Business.Models.AnswerComment", b =>
                {
                    b.HasOne("TechSolution.Business.Models.Answer", "Answer")
                        .WithMany("AnswerComments")
                        .HasForeignKey("AnswerId")
                        .IsRequired();

                    b.Navigation("Answer");
                });

            modelBuilder.Entity("TechSolution.Business.Models.QuestionComment", b =>
                {
                    b.HasOne("TechSolution.Business.Models.Question", "Question")
                        .WithMany("QuestionsComments")
                        .HasForeignKey("QuestionId")
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("TechSolution.Business.Models.Answer", b =>
                {
                    b.Navigation("AnswerComments");
                });

            modelBuilder.Entity("TechSolution.Business.Models.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("QuestionsComments");
                });
#pragma warning restore 612, 618
        }
    }
}
