using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Infra.Migrations
{
    /// <inheritdoc />
    public partial class fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalStacks_AspNetUsers_AppUserId",
                table: "ProfessionalStacks");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_AppUserId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalStacks_AppUserId",
                table: "ProfessionalStacks");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "ProfessionalStacks",
                newName: "ProfileId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessionalStackId",
                table: "WorkExperiences",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "WorkExperiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "WorkExperiences",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "Profiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionalStackId",
                table: "Profiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "Post",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PostId",
                table: "MediaUpload",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "MediaUpload",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "MediaUpload",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadedAt",
                table: "MediaUpload",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_ProfileId",
                table: "WorkExperiences",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AppUserId",
                table: "Profiles",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ProfessionalStackId",
                table: "Profiles",
                column: "ProfessionalStackId",
                unique: true,
                filter: "[ProfessionalStackId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ProfileId",
                table: "Post",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaUpload_AppUserId",
                table: "MediaUpload",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaUpload_ProfileId",
                table: "MediaUpload",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ProfileId",
                table: "Comment",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Profiles_ProfileId",
                table: "Comment",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaUpload_AspNetUsers_AppUserId",
                table: "MediaUpload",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaUpload_Profiles_ProfileId",
                table: "MediaUpload",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Profiles_ProfileId",
                table: "Post",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_ProfessionalStacks_ProfessionalStackId",
                table: "Profiles",
                column: "ProfessionalStackId",
                principalTable: "ProfessionalStacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_Profiles_ProfileId",
                table: "WorkExperiences",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Profiles_ProfileId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaUpload_AspNetUsers_AppUserId",
                table: "MediaUpload");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaUpload_Profiles_ProfileId",
                table: "MediaUpload");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Profiles_ProfileId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_ProfessionalStacks_ProfessionalStackId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_Profiles_ProfileId",
                table: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperiences_ProfileId",
                table: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_AppUserId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ProfessionalStackId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Post_ProfileId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_MediaUpload_AppUserId",
                table: "MediaUpload");

            migrationBuilder.DropIndex(
                name: "IX_MediaUpload_ProfileId",
                table: "MediaUpload");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ProfileId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "ProfessionalStackId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "MediaUpload");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "MediaUpload");

            migrationBuilder.DropColumn(
                name: "UploadedAt",
                table: "MediaUpload");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "ProfessionalStacks",
                newName: "AppUserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessionalStackId",
                table: "WorkExperiences",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "Profiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "PostId",
                table: "MediaUpload",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AppUserId",
                table: "Profiles",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalStacks_AppUserId",
                table: "ProfessionalStacks",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalStacks_AspNetUsers_AppUserId",
                table: "ProfessionalStacks",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
