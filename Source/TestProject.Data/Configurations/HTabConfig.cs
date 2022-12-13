using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Models;
using TestProject.Models.Dictionaries;

namespace TestProject.Data.Configurations
{
    public class HTabConfig : IEntityTypeConfiguration<HTabEntity>
    {
        public void Configure(EntityTypeBuilder<HTabEntity> builder)
        {
            builder.HasData(
                new HTabEntity
                {
                    Id = 1,
                    Name = "Инициация"
                },
                new HTabEntity
                {
                    Id = 2,
                    Name = "Анализ и выявление требований"
                },
                new HTabEntity
                {
                    Id = 3,
                    Name = "Проектирование и дизайн"
                },
                new HTabEntity
                {
                    Id = 4,
                    Name = "Разработка"
                },
                new HTabEntity
                {
                    Id = 5,
                    Name = "Тестирование"
                },
                new HTabEntity
                {
                    Id = 6,
                    Name = "Ввод в эксплуатацию"
                },
                new HTabEntity
                {
                    Id = 7,
                    Name = "Сопровождение"
                });
        }

    }
}

