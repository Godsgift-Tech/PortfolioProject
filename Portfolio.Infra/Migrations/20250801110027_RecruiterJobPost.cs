using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RecruiterJobPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPost_AspNetUsers_AppUserId",
                table: "JobPost");

            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "RecruiterProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecruiterName",
                table: "RecruiterProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "RecruiterId",
                table: "JobPost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RecruiterMediaUpload",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RecruiterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruiterMediaUpload", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecruiterMediaUpload_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecruiterMediaUpload_JobPost_JobPostId",
                        column: x => x.JobPostId,
                        principalTable: "JobPost",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecruiterMediaUpload_RecruiterProfiles_RecruiterId",
                        column: x => x.RecruiterId,
                        principalTable: "RecruiterProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPost_RecruiterId",
                table: "JobPost",
                column: "RecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruiterMediaUpload_AppUserId",
                table: "RecruiterMediaUpload",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruiterMediaUpload_JobPostId",
                table: "RecruiterMediaUpload",
                column: "JobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruiterMediaUpload_RecruiterId",
                table: "RecruiterMediaUpload",
                column: "RecruiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPost_AspNetUsers_AppUserId",
                table: "JobPost",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPost_RecruiterProfiles_RecruiterId",
                table: "JobPost",
                column: "RecruiterId",
                principalTable: "RecruiterProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPost_AspNetUsers_AppUserId",
                table: "JobPost");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPost_RecruiterProfiles_RecruiterId",
                table: "JobPost");

            migrationBuilder.DropTable(
                name: "RecruiterMediaUpload");

            migrationBuilder.DropIndex(
                name: "IX_JobPost_RecruiterId",
                table: "JobPost");

            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "RecruiterProfiles");

            migrationBuilder.DropColumn(
                name: "RecruiterName",
                table: "RecruiterProfiles");

            migrationBuilder.DropColumn(
                name: "RecruiterId",
                table: "JobPost");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPost_AspNetUsers_AppUserId",
                table: "JobPost",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
