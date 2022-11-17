using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestProject.Data.Configurations
{
    public class UsersWithRolesConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        private const string managerId = "38815E40-2E91-4033-849F-1202B5A319B8";
        private const string managerRoleId = "78A7570F-3CE5-48BA-9461-80283ED1D94D";


        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = managerRoleId,
                    UserId = managerId
                });
        }
    }
}
