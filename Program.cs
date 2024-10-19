using Microsoft.EntityFrameworkCore;
using HousingManagementService.Data;
using HousingManagementService.Data.Seeders;
using HousingManagementService.Data.Seeders.Implementations;
using HousingManagementService.Data.Seeders.Interfaces;
using HousingManagementService.Mappings;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories;
using HousingManagementService.Repositories.Base;
using HousingManagementService.Repositories.Base.Abstractions;
using HousingManagementService.Repositories.Implementions;
using HousingManagementService.Repositories.Interfaces;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Implementations;
using HousingManagementService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");


builder.Services.AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers();
builder.Services.AddScoped<ICrudRepository<Service, ServiceView>, BaseRepository<Service, ServiceView>>()
    .AddScoped<ICrudRepository<House, HouseView>, BaseRepository<House, HouseView>>()
    .AddScoped<IBulkInsertRepository<Flat>, BulkInsertRepository<Flat>>()
    .AddScoped<ICrudRepository<House, HouseView>, BaseRepository<House, HouseView>>()
    .AddScoped<ICrudRepository<Flat, FlatView>, BaseRepository<Flat, FlatView>>()
    .AddScoped<ICrudRepository<Plot, PlotView>, BaseRepository<Plot, PlotView>>()
    .AddScoped<ICrudRepository<Department, DepartmentView>, BaseRepository<Department, DepartmentView>>()
    .AddScoped<ICrudRepository<Rate, RateView>, BaseRepository<Rate, RateView>>()
    .AddScoped<ICrudRepository<Ownership, OwnershipView>, BaseRepository<Ownership, OwnershipView>>()
    .AddScoped<ICrudRepository<DepartmentPlot, DepartmentPlotView>, BaseRepository<DepartmentPlot, DepartmentPlotView>>()
    .AddScoped<ICrudRepository<Lodger, LodgerView>, BaseRepository<Lodger, LodgerView>>()
    .AddScoped<IReadRepository<DepartmentRevenue>, ReadRepository<DepartmentRevenue>>()
    .AddScoped<IReadRepository<LodgerPlot>, ReadRepository<LodgerPlot>>()
    .AddScoped<IReadRepository<RentView>, ReadRepository<RentView>>();


builder.Services.AddScoped<IHouseAndFlatsRepository, HouseAndFlatsRepository>()
    .AddScoped<IBaseService<ServiceDto, ServiceView>, BaseService<ServiceDto, Service, ServiceView>>()
    .AddScoped<IHouseAndFlatsService, HouseAndFlatsService>()
    .AddScoped<IBaseService<HouseDto, HouseView>, BaseService<HouseDto, House, HouseView>>()
    .AddScoped<IBaseService<FlatDto, FlatView>, BaseService<FlatDto, Flat, FlatView>>()
    .AddScoped<IBaseService<PlotDto, PlotView>, BaseService<PlotDto, Plot, PlotView>>()
    .AddScoped<IBaseService<DepartmentDto, DepartmentView>, BaseService<DepartmentDto, Department, DepartmentView>>()
    .AddScoped<IBaseService<RateDto, RateView>, BaseService<RateDto, Rate, RateView>>()
    .AddScoped<IBaseService<OwnershipDto, OwnershipView>, BaseService<OwnershipDto, Ownership, OwnershipView>>()
    .AddScoped<IBaseService<DepartmentPlotDto, DepartmentPlotView>, BaseService<DepartmentPlotDto, DepartmentPlot, DepartmentPlotView>>()
    .AddScoped<IBaseService<LodgerDto, LodgerView>, BaseService<LodgerDto, Lodger, LodgerView>>()
    .AddScoped<IReadReportService<DepartmentRevenue>, ReadReportService<DepartmentRevenue>>()
    .AddScoped<IReadReportService<LodgerPlot>, ReadReportService<LodgerPlot>>()
    .AddScoped<IReadReportService<RentView>, ReadReportService<RentView>>();

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
    while (true)
    {
        try
        {
            var housingManagementDbContext = scope.ServiceProvider.GetRequiredService<HousingManagementDbContext>();
            housingManagementDbContext.DatabaseEnsureCreated();
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}
app.MapGet("/", () => Results.Redirect("/swagger/index.html"));
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");
app.UseRouting();
app.MapControllers();
app.Run();
