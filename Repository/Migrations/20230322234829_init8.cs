using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Repository.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Students_StudentRa",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_StudentRa",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentRa",
                table: "Subjects");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Teachers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Teachers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Teachers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StudentId",
                table: "Subjects",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Students",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Students",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_StudentId",
                table: "Subjects",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Ra",
                table: "Students",
                column: "Ra",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Students_StudentId",
                table: "Subjects",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Students_StudentId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_StudentId",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_Ra",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "StudentRa",
                table: "Subjects",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Ra");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_StudentRa",
                table: "Subjects",
                column: "StudentRa");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Students_StudentRa",
                table: "Subjects",
                column: "StudentRa",
                principalTable: "Students",
                principalColumn: "Ra");
        }
    }
}
