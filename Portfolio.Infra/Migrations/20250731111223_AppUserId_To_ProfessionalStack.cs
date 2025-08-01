using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AppUserId_To_ProfessionalStack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "ProfessionalStacks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalStacks_AppUserId",
                table: "ProfessionalStacks",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalStacks_AspNetUsers_AppUserId",
                table: "ProfessionalStacks",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalStacks_AspNetUsers_AppUserId",
                table: "ProfessionalStacks");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalStacks_AppUserId",
                table: "ProfessionalStacks");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ProfessionalStacks");
        }
    }
}
