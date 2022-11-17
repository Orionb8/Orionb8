using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Models.Dictionaries;

namespace TestProject.Data.Configurations
{
    public class HProjectStatusConfig : IEntityTypeConfiguration<HProjectStatusEntity>
    {
        public void Configure(EntityTypeBuilder<HProjectStatusEntity> builder)
        {
            builder.HasData(
                new HProjectStatusEntity
                {
                    Id = 1,
                    Name = "Инициация"
                },
                new HProjectStatusEntity
                {
                    Id = 2,
                    Name = "Анализ и выявление требований"
                },
                new HProjectStatusEntity
                {
                    Id = 3,
                    Name = "Проектирование и дизайн"
                },
                new HProjectStatusEntity
                {
                    Id = 4,
                    Name = "Разработка"
                },
                new HProjectStatusEntity
                {
                    Id = 5,
                    Name = "Тестирование"
                },
                new HProjectStatusEntity
                {
                    Id = 6,
                    Name = "Ввод в эксплуатацию"
                },
                new HProjectStatusEntity
                {
                    Id = 7,
                    Name = "Сопровождение"
                }
                );
        }
    }
}

