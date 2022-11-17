using DamuBala.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using TestProject.Data.Configurations;
using TestProject.Interfaces;
using TestProject.Models;
using TestProject.Models.Dictionaries;

namespace TestProject.Data.Context
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<HProjectDesicionEntity> HProjectDesicions { get; set; }
        public DbSet<HPositionEntity> HPositions { get; set; }
        public DbSet<HProjectStatusEntity> HProjectStatuses { get; set; }
        public DbSet<HProjectTypeEntity> HProjectTypes { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
          : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnModelCreating(ModelBuilder entityBuilder)
        {
            base.OnModelCreating(entityBuilder);
            var entityTypes = entityBuilder.Model.GetEntityTypes();
            foreach (var entityType in entityTypes)
            {
                if (typeof(IRecoverable).IsAssignableFrom(entityType.ClrType))
                {
                    var parameterExpr = Expression.Parameter(entityType.ClrType, "x");
                    var propertyExpr = Expression.Property(parameterExpr, nameof(IRecoverable.IsDeleted));
                    var isFalseExpr = Expression.Equal(propertyExpr, Expression.Constant(false));
                    var delegateType = Expression.GetDelegateType(entityType.ClrType, typeof(bool));
                    var lambda = Expression.Lambda(delegateType, isFalseExpr, parameterExpr);

                    entityBuilder.Entity(entityType.Name).HasQueryFilter(lambda);
                }
            }

            entityBuilder.ApplyConfiguration(new HProjectTypeConfig());
            entityBuilder.ApplyConfiguration(new HProjectStatusConfig());
            entityBuilder.ApplyConfiguration(new HProjectDesicionConfig());
            entityBuilder.ApplyConfiguration(new HPositionConfig());
            entityBuilder.ApplyConfiguration(new UserConfig());
            entityBuilder.ApplyConfiguration(new RoleConfig());
            entityBuilder.ApplyConfiguration(new UsersWithRolesConfig());
        }
    }
}
