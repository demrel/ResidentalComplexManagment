using Microsoft.EntityFrameworkCore;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Core.Entities;
using ResidentalComplexManagment.Core.Entities.Accountment;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using ResidentalComplexManagment.Core.Entities.ResidentNotifications;
using ResidentalComplexManagment.Core.Entities.Users;
using ResidentalComplexManagment.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Infrastructure.Data
{
    public class AppDBContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;
        public AppDBContext(DbContextOptions<AppDBContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Resident> Residents { get; set; }
        public DbSet<Nottification> Nottifications { get; set; }
        public DbSet<MKT> MKTs { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Appartment> Appartments { get; set; }
        public DbSet<PaymentCoefficient> PaymentCoefficients { get; set; }
        public DbSet<AppartmentDebt> AppartmentDebts { get; set; }
        public DbSet<ResidentPayment> ResidentPayments { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Id= Guid.NewGuid().ToString();
                        entry.Entity.Created= DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
