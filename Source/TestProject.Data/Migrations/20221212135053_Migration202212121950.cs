using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration202212121950 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HTabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HTabs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HFolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HTabId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HFolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HFolders_HTabs_HTabId",
                        column: x => x.HTabId,
                        principalTable: "HTabs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HDocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HTabId = table.Column<int>(type: "integer", nullable: false),
                    HFolderId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDocumentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HDocumentTypes_HFolders_HFolderId",
                        column: x => x.HFolderId,
                        principalTable: "HFolders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HDocumentTypes_HTabs_HTabId",
                        column: x => x.HTabId,
                        principalTable: "HTabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegisterDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    HTabId = table.Column<int>(type: "integer", nullable: false),
                    HFolderId = table.Column<int>(type: "integer", nullable: true),
                    HDocumentTypeId = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_HDocumentTypes_HDocumentTypeId",
                        column: x => x.HDocumentTypeId,
                        principalTable: "HDocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_HFolders_HFolderId",
                        column: x => x.HFolderId,
                        principalTable: "HFolders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documents_HTabs_HTabId",
                        column: x => x.HTabId,
                        principalTable: "HTabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HTabs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Инициация" },
                    { 2, "Анализ и выявление требований" },
                    { 3, "Проектирование и дизайн" },
                    { 4, "Разработка" },
                    { 5, "Тестирование" },
                    { 6, "Ввод в эксплуатацию" },
                    { 7, "Сопровождение" }
                });

            migrationBuilder.InsertData(
                table: "HDocumentTypes",
                columns: new[] { "Id", "HFolderId", "HTabId", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, "Договор оказания услуг" },
                    { 2, null, 1, "Бюджетная заявка" },
                    { 3, null, 1, "Техническая спецификация" },
                    { 4, null, 1, "План-график проведения работ" },
                    { 5, null, 2, "Техническое задание" },
                    { 6, null, 2, "Протокол встречи" },
                    { 7, null, 2, "Спецификация требований к программному обеспечению" },
                    { 17, null, 4, "Сервисы (справочно)" },
                    { 18, null, 4, "Подключение (справочно)" },
                    { 19, null, 4, "Исходный проект (справочно)" },
                    { 25, null, 6, "Акт ввода в опытную эксплуатацию" },
                    { 26, null, 6, "Акт ввода в промышленную эксплуатацию" },
                    { 27, null, 6, "Акт приема-передачи" },
                    { 28, null, 6, "Протокол оказания услуг" },
                    { 29, null, 6, "Акт выполненных работ" },
                    { 30, null, 6, "План и методика испытаний" },
                    { 31, null, 6, "Протокол испытаний" },
                    { 32, null, 6, "Протокол демонстрации" },
                    { 33, null, 7, "Договор по сопровождению ИС" },
                    { 34, null, 7, "Протокол оказания услуг" },
                    { 35, null, 7, "Акт выполненных работ" },
                    { 36, null, 7, "Руководство пользователя" },
                    { 37, null, 7, "Руководство администратора" }
                });

            migrationBuilder.InsertData(
                table: "HFolders",
                columns: new[] { "Id", "HTabId", "Name" },
                values: new object[,]
                {
                    { 1, 3, "Модели данных" },
                    { 2, 3, "Варианты использования" },
                    { 3, 3, "Интеграционные взаимодействия" },
                    { 4, 3, "Реестры" },
                    { 5, 3, "Графический интерфейс" },
                    { 6, 5, "Глобальные артефакты" },
                    { 7, 5, "Тест-кейсы" },
                    { 8, 5, "Чек-листы" },
                    { 9, 5, "Отчеты" }
                });

            migrationBuilder.InsertData(
                table: "HDocumentTypes",
                columns: new[] { "Id", "HFolderId", "HTabId", "Name" },
                values: new object[,]
                {
                    { 8, 1, 3, "Диаграмма классов №" },
                    { 9, 2, 3, "Сценарий №" },
                    { 10, 3, 3, "Описание форматов" },
                    { 11, 3, 3, "Схема интеграционного взаимодействия" },
                    { 12, 4, 3, "Справочник" },
                    { 13, 4, 3, "Реестр служебных сообщений" },
                    { 14, 4, 3, "Реестр ошибок" },
                    { 15, 5, 3, "Макет графического интерфейса" },
                    { 16, 5, 3, "Описание форматов" },
                    { 20, 6, 5, "Тест-план" },
                    { 21, 6, 5, "Протокол тестирования" },
                    { 22, 7, 5, "Тест-кейс №" },
                    { 23, 8, 5, "Чек лист №" },
                    { 24, 9, 5, "Отчет об ошибке №" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_HDocumentTypeId",
                table: "Documents",
                column: "HDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_HFolderId",
                table: "Documents",
                column: "HFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_HTabId",
                table: "Documents",
                column: "HTabId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ProjectId",
                table: "Documents",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_HDocumentTypes_HFolderId",
                table: "HDocumentTypes",
                column: "HFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_HDocumentTypes_HTabId",
                table: "HDocumentTypes",
                column: "HTabId");

            migrationBuilder.CreateIndex(
                name: "IX_HFolders_HTabId",
                table: "HFolders",
                column: "HTabId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "HDocumentTypes");

            migrationBuilder.DropTable(
                name: "HFolders");

            migrationBuilder.DropTable(
                name: "HTabs");

        }
    }
}
