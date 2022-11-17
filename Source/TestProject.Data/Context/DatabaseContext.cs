using DamuBala.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using TestProject.Interfaces;
using TestProject.Models;

namespace TestProject.Data.Context {
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<HProjectDesicionEntity> HProjectDesicions { get; set; }
        public DbSet<HProjectStatusEntity> HProjectStatuses { get; set; }
        public DbSet<HProjectTypeEntity> HProjectTypes { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
          : base(options) {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            var entityTypes = modelBuilder.Model.GetEntityTypes();
            foreach(var entityType in entityTypes) {
                if(typeof(IRecoverable).IsAssignableFrom(entityType.ClrType)) {
                    var parameterExpr = Expression.Parameter(entityType.ClrType, "x");
                    var propertyExpr = Expression.Property(parameterExpr, nameof(IRecoverable.IsDeleted));
                    var isFalseExpr = Expression.Equal(propertyExpr, Expression.Constant(false));
                    var delegateType = Expression.GetDelegateType(entityType.ClrType, typeof(bool));
                    var lambda = Expression.Lambda(delegateType, isFalseExpr, parameterExpr);

                    modelBuilder.Entity(entityType.Name).HasQueryFilter(lambda);
                }
            }
        }
    }
}
