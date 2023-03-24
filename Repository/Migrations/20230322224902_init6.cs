using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Users_StudentId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_TeacherId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TeacherId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_StudentId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ShowNameOnRanking",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Subjects");

            migrationBuilder.AddColumn<string>(
                name: "StudentRa",
                table: "Subjects",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Ra = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ShowNameOnRanking = table.Column<bool>(type: "boolean", nullable: false),
                    TeacherId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Ra);
                    table.ForeignKey(
                        name: "FK_Students_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_StudentRa",
                table: "Subjects",
                column: "StudentRa");

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeacherId",
                table: "Students",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Students_StudentRa",
                table: "Subjects",
                column: "StudentRa",
                principalTable: "Students",
                principalColumn: "Ra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Students_StudentRa",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_StudentRa",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "StudentRa",
                table: "Subjects");

            migrationBuilder.AddColumn<bool>(
                name: "ShowNameOnRanking",
                table: "Users",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TeacherId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StudentId",
                table: "Subjects",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeacherId",
                table: "Users",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_StudentId",
                table: "Subjects",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Users_StudentId",
                table: "Subjects",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_TeacherId",
                table: "Users",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
