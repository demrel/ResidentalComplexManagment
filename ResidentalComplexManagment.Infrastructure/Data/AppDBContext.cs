using Microsoft.EntityFrameworkCore;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Core.Entities.Accountment;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using ResidentalComplexManagment.Core.Entities.ResidentNotifications;
using ResidentalComplexManagment.Core.Entities.Users;


namespace ResidentalComplexManagment.Infrastructure.Data
{
    public class AppDBContext : DbContext
    {
      
        public AppDBContext(DbContextOptions<AppDBContext> options, ICurrentUserService currentUserService) : base(options)
        {
           
        }

        public DbSet<Resident> Residents { get; set; }
        public DbSet<Nottification> Nottifications { get; set; }
        public DbSet<MKT> MKTs { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Appartment> Appartments { get; set; }
        public DbSet<PaymentCoefficient> PaymentCoefficients { get; set; }
        public DbSet<AppartmentDebt> AppartmentDebts { get; set; }
        public DbSet<ResidentPayment> ResidentPayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
