using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Core.Entities.Accountment;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using ResidentalComplexManagment.Core.Entities.ResidentNotifications;
using ResidentalComplexManagment.Core.Entities.Users;
using ResidentalComplexManagment.Domain.Entities.Accountment;
using ResidentalComplexManagment.Infrastructure.IdentityEntity;

namespace ResidentalComplexManagment.Infrastructure.Data
{
    public class AppDBContext : IdentityDbContext<AppUser, AppRole, string, IdentityUserClaim<string>, AppUserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Resident> Residents { get; set; }
        public DbSet<Nottification> Nottifications { get; set; }
        public DbSet<MKT> MKTs { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Appartment> Appartments { get; set; }
        public DbSet<ResidentDebt> AppartmentDebts { get; set; }
        public DbSet<ResidentPayment> ResidentPayments { get; set; }
        public DbSet<DebtItem> DebtItems { get; set; }
        public DbSet<CalculationValue> CalculationValues { get; set; }
        public DbSet<ResidentDebtItem> ResidentDebtItems { get; set; }
        public DbSet<ResidentDebt> ResidentDebts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(r => r.RoleId)
                        .IsRequired();

                userRole.HasOne(ur => ur.User)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
            });
        }
    }
}
