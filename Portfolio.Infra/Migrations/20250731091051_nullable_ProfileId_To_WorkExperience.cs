using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Infra.Migrations
{
    /// <inheritdoc />
    public partial class nullable_ProfileId_To_WorkExperience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_Profiles_ProfileId",
                table: "WorkExperiences");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfileId",
                table: "WorkExperiences",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_Profiles_ProfileId",
                table: "WorkExperiences",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_Profiles_ProfileId",
                table: "WorkExperiences");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfileId",
                table: "WorkExperiences",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_Profiles_ProfileId",
                table: "WorkExperiences",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
