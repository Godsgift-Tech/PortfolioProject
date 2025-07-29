using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ProfessionalStackFeltch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_ProfessionalStacks_ProfessionalStackId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ProfessionalStackId",
                table: "Profiles");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalStacks_ProfileId",
                table: "ProfessionalStacks",
                column: "ProfileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalStacks_Profiles_ProfileId",
                table: "ProfessionalStacks",
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

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalStacks_ProfileId",
                table: "ProfessionalStacks");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ProfessionalStackId",
                table: "Profiles",
                column: "ProfessionalStackId",
                unique: true,
                filter: "[ProfessionalStackId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_ProfessionalStacks_ProfessionalStackId",
                table: "Profiles",
                column: "ProfessionalStackId",
                principalTable: "ProfessionalStacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
