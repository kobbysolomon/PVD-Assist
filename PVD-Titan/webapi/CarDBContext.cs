using Microsoft.EntityFrameworkCore;

namespace webapi
{
    public class CarDBContext: DbContext
    {
        public CarDBContext(DbContextOptions<CarDBContext> options) : base(options) { }
        public DbSet<PackageDefault> PackageDefaults { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
    }
}
