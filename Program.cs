using Microsoft.EntityFrameworkCore;
using HousingManagementService.Data;
using HousingManagementService.Data.Seeders;
using HousingManagementService.Data.Seeders.Implementations;
using HousingManagementService.Data.Seeders.Interfaces;
using HousingManagementService.Mappings;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;
using HousingManagementService.Repositories.Base.Abstractions;
using HousingManagementService.Services.Base;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");


builder.Services.AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers();
builder.Services.AddScoped<ICrudRepository<Service, ServiceView>, BaseRepository<Service, ServiceView>>();

builder.Services.AddScoped<IBaseService<ServiceDto, ServiceView>, BaseService<ServiceDto, Service, ServiceView>>();

// SEEDERS
builder.Services.AddTransient<IDataSeeder, ServicesSeeder>()
    .AddTransient<IDataSeeder, DepartmentsSeeder>()
    .AddTransient<IDataSeeder, DepartmentPlotsSeeder>()
    .AddTransient<IDataSeeder, HousesSeeder>()
    .AddTransient<IDataSeeder, FlatsSeeder>()
    .AddTransient<IDataSeeder, LodgersSeeder>()
    .AddTransient<IDataSeeder, OwnershipsSeeder>()
    .AddTransient<IDataSeeder, PlotsSeeder>()
    .AddTransient<IDataSeeder, RatesSeeder>();

// SEEDERS MANAGER
builder.Services.AddTransient<ISeedersManager, SeedersManager>();



builder.Services.AddDbContext<HousingManagementDbContext>(options => options
        .UseNpgsql(connectionString));

builder.Services.AddCors(options =>
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin() 
            .AllowAnyMethod()
            .AllowAnyHeader()));

builder.Services.AddAutoMapper(typeof(DtoMapperR), typeof(ViewMapper));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var housingManagementDbContext = scope.ServiceProvider.GetRequiredService<HousingManagementDbContext>();
    housingManagementDbContext.DatabaseEnsureCreated();
}
app.MapGet("/", () => Results.Redirect("/swagger/index.html"));
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");
app.UseRouting();
app.MapControllers();
app.Run();
