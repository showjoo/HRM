using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create3OtherTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobStatusLookUpId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    ResumeURL = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobStatusLookUps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatusLookUps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    SubmittedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SelectedForInterview = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectedReason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submissions_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobStatusLookUpId",
                table: "Jobs",
                column: "JobStatusLookUpId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_Email",
                table: "Candidates",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_CandidateId",
                table: "Submissions",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_JobId",
                table: "Submissions",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobStatusLookUps_JobStatusLookUpId",
                table: "Jobs",
                column: "JobStatusLookUpId",
                principalTable: "JobStatusLookUps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobStatusLookUps_JobStatusLookUpId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "JobStatusLookUps");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobStatusLookUpId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobStatusLookUpId",
                table: "Jobs");
        }
    }
}
