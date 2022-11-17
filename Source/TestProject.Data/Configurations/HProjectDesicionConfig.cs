using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Models.Dictionaries;

namespace TestProject.Data.Configurations
{
    public class HProjectDesicionConfig : IEntityTypeConfiguration<HProjectDesicionEntity>
    {
        public void Configure(EntityTypeBuilder<HProjectDesicionEntity> builder)
        {
            builder.HasData(
                new HProjectDesicionEntity
                {
                    Id = 1,
                    Name = "В процессе выполнения"
                },
                new HProjectDesicionEntity
                {
                    Id = 2,
                    Name = "Выполнение"
                },
                new HProjectDesicionEntity
                {
                    Id = 3,
                    Name = "Заморожено"
                },
                new HProjectDesicionEntity
                {
                    Id = 4,
                    Name = "На сопровождении"
                },
                new HProjectDesicionEntity
                {
                    Id = 5,
                    Name = "Закрыто"
                },
                new HProjectDesicionEntity
                {
                    Id = 6,
                    Name = "Отменено"
                }
                );
        }
    }
}

