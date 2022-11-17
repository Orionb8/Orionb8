using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Models.Dictionaries;

namespace TestProject.Data.Configurations
{
    public class HPositionConfig : IEntityTypeConfiguration<HPositionEntity>
    {
        public void Configure(EntityTypeBuilder<HPositionEntity> builder)
        {
            builder.HasData(
                new HPositionEntity
                {
                    Id = 1,
                    Name = "Аналитик"
                },
                new HPositionEntity
                {
                    Id = 2,
                    Name = "Менеджер"
                },
                new HPositionEntity
                {
                    Id = 3,
                    Name = "Разработчик Backend"
                },
                new HPositionEntity
                {
                    Id = 4,
                    Name = "Разработчик FrontEnd"
                },
                new HPositionEntity
                {
                    Id = 5,
                    Name = "Тестировщик"
                },
                new HPositionEntity
                {
                    Id = 6,
                    Name = "Дизайнер"
                }
                );
        }
    }
}

