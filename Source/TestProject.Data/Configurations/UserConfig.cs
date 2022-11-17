using System;
using DamuBala.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Models.Dictionaries;

namespace TestProject.Data.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        private const string managerId = "38815E40-2E91-4033-849F-1202B5A319B8";

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var manager = new ApplicationUser
            {
                Id = managerId,
                UserName = "manager",
                NormalizedUserName = "MANAGER",
                FirstName = "Manager",
                MiddleName = "Manager",
                LastName = "Manager",
                Email = "manager@project.kz",
                NormalizedEmail = "MANAGER@PROJECT.KZ",
                PhoneNumber = "+77085517931",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = new Guid().ToString("D"),
            };

            manager.PasswordHash = PassGenerate(manager);

            builder.HasData(manager);
                
        }

        public string PassGenerate(ApplicationUser user)
        {
            var passHash = new PasswordHasher<ApplicationUser>();
            return passHash.HashPassword(user, "Admin123!");
        }

    }
}

