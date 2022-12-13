using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Models.Dictionaries;

namespace TestProject.Data.Configurations
{
    public class HDocumentTypeConfig : IEntityTypeConfiguration<HDocumentTypeEntity>
    {
        public void Configure(EntityTypeBuilder<HDocumentTypeEntity> builder)
        {
            builder.HasData(
                new HDocumentTypeEntity
                {
                    Id = 1,
                    HTabId = 1,
                    Name = "Договор оказания услуг"
                },
                new HDocumentTypeEntity
                {
                    Id = 2,
                    HTabId = 1,
                    Name = "Бюджетная заявка"
                },
                new HDocumentTypeEntity
                {
                    Id = 3,
                    HTabId = 1,
                    Name = "Техническая спецификация"
                }, new HDocumentTypeEntity
                {
                    Id = 4,
                    HTabId = 1,
                    Name = "План-график проведения работ"
                }, new HDocumentTypeEntity
                {
                    Id = 5,
                    HTabId = 2,
                    Name = "Техническое задание"
                }, new HDocumentTypeEntity
                {
                    Id = 6,
                    HTabId = 2,
                    Name = "Протокол встречи"
                }, new HDocumentTypeEntity
                {
                    Id = 7,
                    HTabId = 2,
                    Name = "Спецификация требований к программному обеспечению"
                }, new HDocumentTypeEntity
                {
                    Id = 8,
                    HTabId = 3,
                    HFolderId = 1,
                    Name = "Диаграмма классов №"
                }, new HDocumentTypeEntity
                {
                    Id = 9,
                    HTabId = 3,
                    HFolderId = 2,
                    Name = "Сценарий №"
                }, new HDocumentTypeEntity
                {
                    Id = 10,
                    HTabId = 3,
                    HFolderId = 3,
                    Name = "Описание форматов"
                }, new HDocumentTypeEntity
                {
                    Id = 11,
                    HTabId = 3,
                    HFolderId = 3,
                    Name = "Схема интеграционного взаимодействия"
                }, new HDocumentTypeEntity
                {
                    Id = 12,
                    HTabId = 3,
                    HFolderId = 4,
                    Name = "Справочник"
                }, new HDocumentTypeEntity
                {
                    Id = 13,
                    HTabId = 3,
                    HFolderId = 4,
                    Name = "Реестр служебных сообщений"
                }, new HDocumentTypeEntity
                {
                    Id = 14,
                    HTabId = 3,
                    HFolderId = 4,
                    Name = "Реестр ошибок"
                }, new HDocumentTypeEntity
                {
                    Id = 15,
                    HTabId = 3,
                    HFolderId = 5,
                    Name = "Макет графического интерфейса"
                }, new HDocumentTypeEntity
                {
                    Id = 16,
                    HTabId = 3,
                    HFolderId = 5,
                    Name = "Описание форматов"
                }, new HDocumentTypeEntity
                {
                    Id = 17,
                    HTabId = 4,
                    Name = "Сервисы (справочно)"
                }, new HDocumentTypeEntity
                {
                    Id = 18,
                    HTabId = 4,
                    Name = "Подключение (справочно)"
                }, new HDocumentTypeEntity
                {
                    Id = 19,
                    HTabId = 4,
                    Name = "Исходный проект (справочно)"
                },
                new HDocumentTypeEntity
                {
                    Id = 20,
                    HTabId = 5,
                    HFolderId = 6,
                    Name = "Тест-план"
                }, new HDocumentTypeEntity
                {
                    Id = 21,
                    HTabId = 5,
                    HFolderId = 6,
                    Name = "Протокол тестирования"
                }, new HDocumentTypeEntity
                {
                    Id = 22,
                    HTabId = 5,
                    HFolderId = 7,
                    Name = "Тест-кейс №"
                }, new HDocumentTypeEntity
                {
                    Id = 23,
                    HTabId = 5,
                    HFolderId = 8,
                    Name = "Чек лист №"
                }, new HDocumentTypeEntity
                {
                    Id = 24,
                    HTabId = 5,
                    HFolderId = 9,
                    Name = "Отчет об ошибке №"
                }, new HDocumentTypeEntity
                {
                    Id = 25,
                    HTabId = 6,
                    Name = "Акт ввода в опытную эксплуатацию"
                }, new HDocumentTypeEntity
                {
                    Id = 26,
                    HTabId = 6,
                    Name = "Акт ввода в промышленную эксплуатацию"
                }, new HDocumentTypeEntity
                {
                    Id = 27,
                    HTabId = 6,
                    Name = "Акт приема-передачи"
                }, new HDocumentTypeEntity
                {
                    Id = 28,
                    HTabId = 6,
                    Name = "Протокол оказания услуг"
                }, new HDocumentTypeEntity
                {
                    Id = 29,
                    HTabId = 6,
                    Name = "Акт выполненных работ"
                }, new HDocumentTypeEntity
                {
                    Id = 30,
                    HTabId = 6,
                    Name = "План и методика испытаний"
                }, new HDocumentTypeEntity
                {
                    Id = 31,
                    HTabId = 6,
                    Name = "Протокол испытаний"
                }, new HDocumentTypeEntity
                {
                    Id = 32,
                    HTabId = 6,
                    Name = "Протокол демонстрации"
                }, new HDocumentTypeEntity
                {
                    Id = 33,
                    HTabId = 7,
                    Name = "Договор по сопровождению ИС"
                }, new HDocumentTypeEntity
                {
                    Id = 34,
                    HTabId = 7,
                    Name = "Протокол оказания услуг"
                }, new HDocumentTypeEntity
                {
                    Id = 35,
                    HTabId = 7,
                    Name = "Акт выполненных работ"
                }, new HDocumentTypeEntity
                {
                    Id = 36,
                    HTabId = 7,
                    Name = "Руководство пользователя"
                }, new HDocumentTypeEntity
                {
                    Id = 37,
                    HTabId = 7,
                    Name = "Руководство администратора"
                });
        }
    }
}

