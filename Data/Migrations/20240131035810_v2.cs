using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCrudWithIdentity.Data.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Premiuns_Students_StudentId1",
                table: "Premiuns");

            migrationBuilder.DropIndex(
                name: "IX_Premiuns_StudentId1",
                table: "Premiuns");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "Premiuns");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Premiuns",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Premiuns_StudentId",
                table: "Premiuns",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Premiuns_Students_StudentId",
                table: "Premiuns",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Premiuns_Students_StudentId",
                table: "Premiuns");

            migrationBuilder.DropIndex(
                name: "IX_Premiuns_StudentId",
                table: "Premiuns");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StudentId",
                table: "Premiuns",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                table: "Premiuns",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Premiuns_StudentId1",
                table: "Premiuns",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Premiuns_Students_StudentId1",
                table: "Premiuns",
                column: "StudentId1",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
