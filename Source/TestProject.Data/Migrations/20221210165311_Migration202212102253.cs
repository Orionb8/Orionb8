using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration202212102253 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_HProjectTypes_ProjecTypeId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjecTypeId",
                table: "Projects",
                newName: "ProjectTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjecTypeId",
                table: "Projects",
                newName: "IX_Projects_ProjectTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_HProjectTypes_ProjectTypeId",
                table: "Projects",
                column: "ProjectTypeId",
                principalTable: "HProjectTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_HProjectTypes_ProjectTypeId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectTypeId",
                table: "Projects",
                newName: "ProjecTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjectTypeId",
                table: "Projects",
                newName: "IX_Projects_ProjecTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_HProjectTypes_ProjecTypeId",
                table: "Projects",
                column: "ProjecTypeId",
                principalTable: "HProjectTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
