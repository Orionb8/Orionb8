using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestProject.Data.Configurations 
{
    public class RoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        private const string managerRoleId = "78A7570F-3CE5-48BA-9461-80283ED1D94D";

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = managerRoleId,
                    Name = "manager",
                    NormalizedName = "MANAGER"
                }
            );
        }
    }
}
