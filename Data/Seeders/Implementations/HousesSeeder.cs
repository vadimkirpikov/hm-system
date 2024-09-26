using HousingManagementService.Data.Seeders.Interfaces;
using HousingManagementService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Data.Seeders.Implementations;

public class HousesSeeder: IDataSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<House>().HasData(
            new House { Id = 1, Address = "Маяковского 1", FloorCount = 9, PlotId = 1},
            new House { Id = 2, Address = "Маяковского 2", FloorCount = 9, PlotId = 1},
            new House { Id = 3, Address = "Маяковского 3", FloorCount = 9, PlotId = 1},
            new House { Id = 4, Address = "Промышленная 1", FloorCount = 16, PlotId = 2},
            new House { Id = 5, Address = "Промышленная 2", FloorCount = 9, PlotId = 2},
            new House { Id = 6, Address = "Пушкинская 4", FloorCount = 9, PlotId = 3},
            new House { Id = 7, Address = "Пушкинская 5", FloorCount = 9, PlotId = 3},
            new House { Id = 8, Address = "Буммаш 1", FloorCount = 9, PlotId = 4},
            new House { Id = 9, Address = "Буммаш 2", FloorCount = 9, PlotId = 4},
            new House { Id = 10, Address = "Удмуртская 1", FloorCount = 9, PlotId = 5},
            new House { Id = 11, Address = "Удмуртская 2", FloorCount = 9, PlotId = 6}
        );
    }
}