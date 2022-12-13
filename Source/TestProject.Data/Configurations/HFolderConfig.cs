using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Models.Dictionaries;

namespace TestProject.Data.Configurations
{
    public class HFolderConfig : IEntityTypeConfiguration<HFolderEntity>
    {
        public void Configure(EntityTypeBuilder<HFolderEntity> builder)
        {
            builder.HasData(
                new HFolderEntity
                {
                    Id = 1,
                    HTabId = 3,
                    Name = "Модели данных"
                },
                new HFolderEntity
                {
                    Id = 2,
                    HTabId = 3,
                    Name = "Варианты использования"
                },
                new HFolderEntity
                {
                    Id = 3,
                    HTabId = 3,
                    Name = "Интеграционные взаимодействия"
                },
                new HFolderEntity
                {
                    Id = 4,
                    HTabId = 3,
                    Name = "Реестры"
                },
                new HFolderEntity
                {
                    Id = 5,
                    HTabId = 3,
                    Name = "Графический интерфейс"
                },
                new HFolderEntity
                {
                    Id = 6,
                    HTabId = 5,
                    Name = "Глобальные артефакты"
                },
                new HFolderEntity
                {
                    Id = 7,
                    HTabId = 5,
                    Name = "Тест-кейсы"
                },
                new HFolderEntity
                {
                    Id = 8,
                    HTabId = 5,
                    Name = "Чек-листы"
                },
                new HFolderEntity
                {
                    Id = 9,
                    HTabId = 5,
                    Name = "Отчеты"
                });
        }
    }
}

