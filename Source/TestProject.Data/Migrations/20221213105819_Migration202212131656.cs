using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TestProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration202212131656 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UploadId",
                table: "Documents",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Uploads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    downloadUrl = table.Column<string>(type: "text", nullable: true),
                    FileScreenName = table.Column<string>(type: "text", nullable: true),
                    FileSize = table.Column<double>(type: "double precision", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedByUser = table.Column<string>(type: "text", nullable: true),
                    CreatedAtTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedByUser = table.Column<string>(type: "text", nullable: true),
                    UpdatedAtTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedByUser = table.Column<string>(type: "text", nullable: true),
                    DeletedAtTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uploads", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38815E40-2E91-4033-849F-1202B5A319B8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "224f9a7b-aaa5-4b6d-a0bf-1ed87667a0b5", "AQAAAAIAAYagAAAAENyHRZ+gT5dirsYk1RjEo+3TSaV5u9dK8NZ9F+gWo7kpHtxFWbJQI5ujrZoPeYFYdw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UploadId",
                table: "Documents",
                column: "UploadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Uploads_UploadId",
                table: "Documents",
                column: "UploadId",
                principalTable: "Uploads",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Uploads_UploadId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "Uploads");

            migrationBuilder.DropIndex(
                name: "IX_Documents_UploadId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "UploadId",
                table: "Documents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38815E40-2E91-4033-849F-1202B5A319B8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "87bdc11c-a717-4690-9d1f-363278c0c9f0", "AQAAAAIAAYagAAAAEIHtte9765cDhJw9gLW/8s7vpdF4K7rG15At7NnjWWgu1BmIf0B6H4NE5Vxo5jZFZA==" });
        }
    }
}
