using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Models.Dictionaries;

namespace TestProject.Data.Configurations
{
    public class HProjectTypeConfig : IEntityTypeConfiguration<HProjectTypeEntity>
    {
        public void Configure(EntityTypeBuilder<HProjectTypeEntity> builder)
        {
            builder.HasData(
                new HProjectTypeEntity
                {
                    Id = 1,
                    Name = "Проект на основе заказа"
                },
                new HProjectTypeEntity
                {
                    Id = 2,
                    Name = "Собственный продукт"
                },
                new HProjectTypeEntity
                {
                    Id = 3,
                    Name = "Партнерский продукт"
                });
        }
    }
}
