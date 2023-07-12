using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace webapi
{
    public class CarDBContext: DbContext
    {
        public CarDBContext(DbContextOptions<CarDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("PVD");
            modelBuilder.Entity<PackageDefault>().HasNoKey().ToTable("PackageDimensions");
            modelBuilder.Entity<VehicleType>().HasNoKey().ToTable("VehicleDimensions");
        }
        public DbSet<PackageDefault> PackageDefaults { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
    }
}
