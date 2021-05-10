using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechSolution.Data.Migrations
{
    public partial class UpdateMigrationAfterDowngradeEntityPackages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<Guid>(nullable: false),
                    QuestionTitle = table.Column<string>(type: "varchar(150)", nullable: false),
                    QuestionText = table.Column<string>(type: "varchar(1500)", nullable: false),
                    QuestionTags = table.Column<string>(type: "varchar(20)", nullable: true),
                    QuestionViewed = table.Column<double>(type: "float default(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<Guid>(nullable: false),
                    AnswerText = table.Column<string>(type: "varchar(1500)", nullable: false),
                    AcceptedAnswer = table.Column<bool>(nullable: false),
                    AnswerUpvotes = table.Column<int>(nullable: false),
                    AnswerDownvotes = table.Column<int>(nullable: false),
                    QuestionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<Guid>(nullable: false),
                    QuestionCommentsText = table.Column<string>(type: "varchar(200)", nullable: false),
                    QuestionCommentsUpvotes = table.Column<int>(nullable: false),
                    QuestionCommentsDownvotes = table.Column<int>(nullable: false),
                    QuestionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionComments_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswersComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<Guid>(nullable: false),
                    AnswerCommentText = table.Column<string>(type: "varchar(1000)", nullable: false),
                    AnswerCommentUpvotes = table.Column<int>(nullable: false),
                    AnswerCommentDownvotes = table.Column<int>(nullable: false),
                    AnswerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswersComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswersComments_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswersComments_AnswerId",
                table: "AnswersComments",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionComments_QuestionId",
                table: "QuestionComments",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswersComments");

            migrationBuilder.DropTable(
                name: "QuestionComments");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
