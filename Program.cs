using Microsoft.EntityFrameworkCore;
using HousingManagementService.Data;
using HousingManagementService.Data.Seeders;
using HousingManagementService.Data.Seeders.Implementations;
using HousingManagementService.Data.Seeders.Interfaces;
using HousingManagementService.Mappings;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;
using HousingManagementService.Repositories.Implementations;
using HousingManagementService.Repositories.Interfaces;
using HousingManagementService.Services.Implementations;
using HousingManagementService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");


builder.Services.AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers();

// SEEDERS
builder.Services.AddTransient<IDataSeeder, ServicesSeeder>()
    .AddTransient<IDataSeeder, DepartmentsSeeder>()
    .AddTransient<IDataSeeder, DepartmentPlotsSeeder>()
    .AddTransient<IDataSeeder, HousesSeeder>()
    .AddTransient<IDataSeeder, FlatsSeeder>()
    .AddTransient<IDataSeeder, LodgersSeeder>()
    .AddTransient<IDataSeeder, OwnershipsSeeder>()
    .AddTransient<IDataSeeder, PayerCodesSeeder>()
    .AddTransient<IDataSeeder, PlotsSeeder>()
    .AddTransient<IDataSeeder, RatesSeeder>();

// SEEDERS MANAGER
builder.Services.AddTransient<ISeedersManager, SeedersManager>();

// BASE REPOSITORIES
builder.Services.AddScoped<IBaseRepository<Service, ServiceView>, BaseRepository<Service, ServiceView>>()
    .AddScoped<IBaseRepository<Ownership, OwnershipView>, BaseRepository<Ownership, OwnershipView>>()
    .AddScoped<IBaseRepository<PayerCode, PayerCodeView>, BaseRepository<PayerCode, PayerCodeView>>()
    .AddScoped<IBaseRepository<DepartmentPlot, DepartmentPlotView>, BaseRepository<DepartmentPlot, DepartmentPlotView>>();

// REPOSITORIES
builder.Services.AddScoped<IDepartmentsRepository, DepartmentsRepository>()
    .AddScoped<IFlatsRepository, FlatsRepository>()
    .AddScoped<IHousesRepository, HousesRepository>()
    .AddScoped<ILodgersRepository, LodgersRepository>()
    .AddScoped<IPlotsRepository, PlotsRepository>()
    .AddScoped<IRatesRepository, RatesRepository>()
    .AddScoped<IHouseAndFlatsRepository, HouseAndFlatsRepository>()
    .AddScoped<IRentsViewRepository, RentsViewRepository>()
    .AddScoped<IDepartmentsRevenueRepository, DepartmentsRevenueRepository>()
    .AddScoped<ISuitabilityOfPlotsRepository, SuitabilityOfPlotsRepository>();


// SERVICES
builder.Services.AddScoped<IDepartmentsService, DepartmentsService>()
    .AddScoped<IFlatsService, FlatsService>()
    .AddScoped<IHousesService, HousesService>()
    .AddScoped<ILodgersService, LodgersService>()
    .AddScoped<IPlotsService, PlotsService>()
    .AddScoped<IRatesService, RatesService>()
    .AddScoped<IServicesService, ServicesService>()
    .AddScoped<IPayerCodesService, PayerCodesService>()
    .AddScoped<IOwnershipsService, OwnershipsService>()
    .AddScoped<IDepartmentPlotsService, DepartmentPlotsService>()
    .AddScoped<IHouseAndFlatsService, HouseAndFlatsService>()
    .AddScoped<IRentsViewService, RentsViewService>()
    .AddScoped<IDepartmentsRevenueService, DepartmentsRevenueService>()
    .AddScoped<ISuitabilityOfPlotsService, SuitabilityOfPlotsService>();


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
