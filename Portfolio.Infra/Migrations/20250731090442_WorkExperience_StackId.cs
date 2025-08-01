using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Infra.Migrations
{
    /// <inheritdoc />
    public partial class WorkExperience_StackId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalStacks_Profiles_ProfileId",
                table: "ProfessionalStacks");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_ProfessionalStacks_ProfessionalStackId",
                table: "WorkExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_Profiles_ProfileId",
                table: "WorkExperiences");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalStacks_Profiles_ProfileId",
                table: "ProfessionalStacks",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_ProfessionalStacks_ProfessionalStackId",
                table: "WorkExperiences",
                column: "ProfessionalStackId",
                principalTable: "ProfessionalStacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_Profiles_ProfileId",
                table: "WorkExperiences",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalStacks_Profiles_ProfileId",
                table: "ProfessionalStacks");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_ProfessionalStacks_ProfessionalStackId",
                table: "WorkExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_Profiles_ProfileId",
                table: "WorkExperiences");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalStacks_Profiles_ProfileId",
                table: "ProfessionalStacks",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_ProfessionalStacks_ProfessionalStackId",
                table: "WorkExperiences",
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
    }
}
