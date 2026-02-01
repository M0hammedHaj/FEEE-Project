using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FEEE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixSubjectSectionRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Semesters_SemesterId",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "SectionSubjects");

            migrationBuilder.AddColumn<int>(
                name: "SectionID",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SectionID",
                table: "Subjects",
                column: "SectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Sections",
                table: "Subjects",
                column: "SectionID",
                principalTable: "Sections",
                principalColumn: "SectionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Semesters",
                table: "Subjects",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "SemesterId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Sections",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Semesters",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_SectionID",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SectionID",
                table: "Subjects");

            migrationBuilder.CreateTable(
                name: "SectionSubjects",
                columns: table => new
                {
                    SectionID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionSubjects", x => new { x.SectionID, x.SubjectID });
                    table.ForeignKey(
                        name: "FK_SectionSubjects_Sections",
                        column: x => x.SectionID,
                        principalTable: "Sections",
                        principalColumn: "SectionID");
                    table.ForeignKey(
                        name: "FK_SectionSubjects_Subjects",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectionSubjects_SubjectID",
                table: "SectionSubjects",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Semesters_SemesterId",
                table: "Subjects",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "SemesterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
