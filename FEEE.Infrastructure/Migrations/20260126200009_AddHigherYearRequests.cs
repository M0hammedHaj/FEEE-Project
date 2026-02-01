using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FEEE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHigherYearRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HigherYearRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HigherYearRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HigherYearRequests_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HigherYearRequests_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HigherYearRequests_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HigherYearRequests_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HigherYearRequestSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HigherYearRequestSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HigherYearRequestSubjects_HigherYearRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "HigherYearRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HigherYearRequestSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HigherYearRequests_SectionId",
                table: "HigherYearRequests",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_HigherYearRequests_SemesterId",
                table: "HigherYearRequests",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_HigherYearRequests_StudentId",
                table: "HigherYearRequests",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_HigherYearRequests_YearId",
                table: "HigherYearRequests",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_HigherYearRequestSubjects_RequestId_SubjectId",
                table: "HigherYearRequestSubjects",
                columns: new[] { "RequestId", "SubjectId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HigherYearRequestSubjects_SubjectId",
                table: "HigherYearRequestSubjects",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HigherYearRequestSubjects");

         

            migrationBuilder.DropTable(
                name: "HigherYearRequests");

        }
    }
}
