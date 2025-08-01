using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RecruiterId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecruiterProfile_AspNetUsers_AppUserId",
                table: "RecruiterProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecruiterProfile",
                table: "RecruiterProfile");

            migrationBuilder.RenameTable(
                name: "RecruiterProfile",
                newName: "RecruiterProfiles");

            migrationBuilder.RenameIndex(
                name: "IX_RecruiterProfile_AppUserId",
                table: "RecruiterProfiles",
                newName: "IX_RecruiterProfiles_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecruiterProfiles",
                table: "RecruiterProfiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecruiterProfiles_AspNetUsers_AppUserId",
                table: "RecruiterProfiles",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecruiterProfiles_AspNetUsers_AppUserId",
                table: "RecruiterProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecruiterProfiles",
                table: "RecruiterProfiles");

            migrationBuilder.RenameTable(
                name: "RecruiterProfiles",
                newName: "RecruiterProfile");

            migrationBuilder.RenameIndex(
                name: "IX_RecruiterProfiles_AppUserId",
                table: "RecruiterProfile",
                newName: "IX_RecruiterProfile_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecruiterProfile",
                table: "RecruiterProfile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecruiterProfile_AspNetUsers_AppUserId",
                table: "RecruiterProfile",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
