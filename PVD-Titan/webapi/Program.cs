using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using webapi;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("myDb1");

string car_model = "SW";
string car_make = "Saturn";
string car_year = "2000";

DbContextOptionsBuilder<CarDBContext> optionsBuilder = new DbContextOptionsBuilder<CarDBContext>();

// Add services to the container.
//builder.Services.AddDbContext<CarDBContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("myDb1")));
optionsBuilder.UseSqlServer(connectionString);

using (CarDBContext context = new CarDBContext(optionsBuilder.Options))
{
    var packageDefaults = context.PackageDefaults;
    var pvds = context.Cars;
    var vehicleTypes = context.VehicleTypes;

    //get width and height from make, model and year
    string query = $"SELECT * FROM [dbo].[VehicleDimensions] join [dbo].[PVD] " +
        $"on [dbo].[PVD].car_type = [dbo].[VehicleDimensions].vehicle_type " +
        $"where [dbo].[PVD].vehicle_make = '{car_make}' and [dbo].[PVD].year_of_manufacture = '{car_year}' and " +
        $"[dbo].[PVD].vehicle_model = '{car_model}'";

    var wh_car = context.VehicleTypes.FromSqlRaw(query).ToList();

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
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
