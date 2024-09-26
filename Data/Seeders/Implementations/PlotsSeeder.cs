using HousingManagementService.Data.Seeders.Interfaces;
using HousingManagementService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Data.Seeders.Implementations;

public class PlotsSeeder: IDataSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plot>().HasData(
            new Plot {Id = 1, PriorityLevel = 1, Budget = 1000000},
            new Plot {Id = 2, PriorityLevel = 2, Budget = 2000000},
            new Plot {Id = 3, PriorityLevel = 1, Budget = 3000000},
            new Plot {Id = 4, PriorityLevel = 1, Budget = 4000000},
            new Plot {Id = 5, PriorityLevel = 3, Budget = 7000000},
            new Plot {Id = 6, PriorityLevel = 4, Budget = 6000000}
        );
    }
}