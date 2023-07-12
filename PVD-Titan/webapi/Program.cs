using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using webapi;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("myDb1");

DbContextOptionsBuilder<CarDBContext> optionsBuilder = new DbContextOptionsBuilder<CarDBContext>();

// Add services to the container.
//builder.Services.AddDbContext<CarDBContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("myDb1")));
optionsBuilder.UseSqlServer(connectionString);

using (CarDBContext context = new CarDBContext(optionsBuilder.Options))
{
    var packageDefaults = context.PackageDefaults.ToList();
    var pvds = context.Cars.ToList();
    var vehicleTypes = context.VehicleTypes.ToList();
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
