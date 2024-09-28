using HousingManagementService.Data.Seeders;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Views;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Data;

public class HousingManagementDbContext(
    DbContextOptions<HousingManagementDbContext> options,
    ISeedersManager seedersManager) : DbContext(options)
{
    // TABLES
    public DbSet<Service> Services { get; private set; }
    public DbSet<Department> Departments { get; private set; }
    public DbSet<Plot> Plots { get; private set; }
    public DbSet<House> Houses { get; private set; }
    public DbSet<Flat> Flats { get; private set; }
    public DbSet<Lodger> Lodgers { get; private set; }
    public DbSet<Ownership> Ownerships { get; private set; }
    public DbSet<Rate> Rates { get; private set; }
    public DbSet<DepartmentPlot> DepartmentPlots { get; private set; }

    // VIEWS
    public DbSet<ServiceView> ServicesView { get; private set; }
    public DbSet<DepartmentView> DepartmentsView { get; private set; }
    public DbSet<PlotView> PlotsView { get; private set; }
    public DbSet<HouseView> HousesView { get; private set; }
    public DbSet<FlatView> FlatsView { get; private set; }
    public DbSet<LodgerView> LodgersView { get; private set; }
    public DbSet<OwnershipView> OwnershipsView { get; private set; }
    public DbSet<RateView> RatesView { get; private set; }
    public DbSet<DepartmentPlotView> DepartmentPlotsView { get; private set; }
    public DbSet<RentView> RentsView { get; private set; }
    public DbSet<DepartmentRevenue> DepartmentsRevenue { get; private set; }
    public DbSet<SuitabilityOfPlot> SuitabilityOfPlots { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        // CONSTRAINTS
        const string passportIsDigitSql = "\"LodgerPassport\" SIMILAR TO '[0-9]{10}'";
        const string passportIsDigitConstraint = "passport_is_digit";

        // const string houseCheckSql = @"""HouseId"" IN (SELECT ""Id""
        //                                              FROM ""Houses""
        //                                              WHERE ""PlotId"" IN (SELECT dp.""PlotId""
        //                                                                 FROM ""DepartmentPlots"" dp
        //                                                                 WHERE ""DepartmentId"" = ""Rates"".""DepartmentId""))";
        // const string houseCheckConstraint = "house_check";
        //

        modelBuilder.Entity<Lodger>()
            .ToTable(lodgers => lodgers
                .HasCheckConstraint(passportIsDigitConstraint, passportIsDigitSql));
        // modelBuilder.Entity<Rate>()
        //     .ToTable(rate => rate
        //         .HasCheckConstraint(houseCheckConstraint, houseCheckSql));
        

        // INDEXES
        modelBuilder.Entity<Lodger>()
            .HasIndex(payerCode => payerCode.LodgerPassport)
            .IsUnique();
        modelBuilder.Entity<House>()
            .HasIndex(house => house.Address)
            .IsUnique();

        // MAPPING VIEWS
        modelBuilder.Entity<HouseView>()
            .ToView("HousesView")
            .HasNoKey();
        modelBuilder.Entity<LodgerView>()
            .ToView("LodgersView")
            .HasNoKey();
        modelBuilder.Entity<PlotView>()
            .ToView("PlotsView")
            .HasNoKey();
        modelBuilder.Entity<ServiceView>()
            .ToView("ServicesView")
            .HasNoKey();
        modelBuilder.Entity<DepartmentView>()
            .ToView("DepartmentsView")
            .HasNoKey();
        modelBuilder.Entity<OwnershipView>()
            .ToView("OwnershipsView")
            .HasNoKey();
        modelBuilder.Entity<RateView>()
            .ToView("RatesView")
            .HasNoKey();
        modelBuilder.Entity<DepartmentPlotView>()
            .ToView("DepartmentPlotsView")
            .HasNoKey();
        modelBuilder.Entity<FlatView>()
            .ToView("FlatsView")
            .HasNoKey();
        modelBuilder.Entity<RentView>()
            .ToView("Rents")
            .HasNoKey();
        modelBuilder.Entity<SuitabilityOfPlot>()
            .ToView("SuitabilityOfPlots")
            .HasNoKey();
        modelBuilder.Entity<DepartmentRevenue>()
            .ToView("DepartmentsRevenue")
            .HasNoKey();
        seedersManager.Seed(modelBuilder);
    }

    public void DatabaseEnsureCreated()
    {
        if (Database.EnsureCreated())
        {
            var sqlQuery = File.ReadAllText("/app/Data/script.sql");
            Database.ExecuteSqlRaw(sqlQuery);
        }
    }
}