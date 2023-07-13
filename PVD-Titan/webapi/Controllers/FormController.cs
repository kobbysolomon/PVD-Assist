using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace webapi.Controllers
{
    public class FormController : ControllerBase
    {
        private readonly CarDBContext _context;
        private string car_model = "SW";
        private string car_make = "Saturn";
        private string car_year = "2000";
        public FormController(CarDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<PackageDefault> Get() {
            var packageDefaults = _context.PackageDefaults;
            var pvds = _context.Cars;
            var vehicleTypes = _context.VehicleTypes;

            //get width and height from make, model and year
            string query = $"SELECT * FROM [dbo].[VehicleDimensions] join [dbo].[PVD] " +
                $"on [dbo].[PVD].car_type = [dbo].[VehicleDimensions].vehicle_type " +
                $"where [dbo].[PVD].vehicle_make = '{car_make}' and [dbo].[PVD].year_of_manufacture = '{car_year}' and " +
                $"[dbo].[PVD].vehicle_model = '{car_model}'";

            var wh_car = _context.VehicleTypes.FromSqlRaw(query).ToList();

            decimal width_car = wh_car[0].Avg_width;
            decimal height_car = wh_car[0].Avg_height;

            //get cargo volume
            string query2 = $"SELECT * FROM [dbo].[PVD] " +
                $"where [dbo].[PVD].vehicle_make = '{car_make}' and [dbo].[PVD].year_of_manufacture = '{car_year}' and " +
                $"[dbo].[PVD].vehicle_model = '{car_model}'";

            var cv_car = pvds.FromSqlRaw(query2).ToList();

            decimal cargo_volume = cv_car[0].Vehicle_cargo_space;

            decimal length_car = cargo_volume / width_car / height_car;

            List<decimal> lwh_trunk = new List<decimal> { length_car, width_car, height_car };

            string query3 = $"SELECT * FROM [dbo].[PackageDimensions] ORDER BY pkg_volume desc ";
            var package_db_list = packageDefaults.FromSqlRaw(query3).ToList();

            List<PackageDefault> assignedPackages = new List<PackageDefault>();

            foreach (PackageDefault package in package_db_list)
            {
                decimal l_p = package.Pkg_length;
                decimal w_p = package.Pkg_width;
                decimal h_p = package.Pkg_height;
                if (lwh_trunk[0] - l_p > 0 && lwh_trunk[1] - w_p > 0 && lwh_trunk[2] - h_p > 0)
                {
                    lwh_trunk[0] -= l_p;
                    lwh_trunk[1] -= w_p;
                    lwh_trunk[2] -= h_p;
                    assignedPackages.Add(package);
                }
            }

            return assignedPackages;
        }
    }
}
