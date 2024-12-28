using BeSpoked.Bikes.API.BAL;
using BeSpoked.Bikes.API.DAL;
using BeSpoked.Bikes.API.Data;
using BeSpoked.Bikes.API.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductRepo, SqlProductRepo>();
builder.Services.AddScoped<IProductDal, ProductDAL>();
builder.Services.AddScoped<IProductBAL, ProductBAL>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BikesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BikesConnectioString")));


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
