using HousingManagementService.Data.Seeders.Interfaces;
using HousingManagementService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Data.Seeders.Implementations;

public class OwnershipsSeeder : IDataSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ownership>().HasData(
            new Ownership { Id = 1, LodgerId = 1, FlatId = 1, OwnedArea = 35 },
            new Ownership { Id = 2, LodgerId = 2, FlatId = 2, OwnedArea = 40 },
            new Ownership { Id = 3, LodgerId = 3, FlatId = 3, OwnedArea = 45 },
            new Ownership { Id = 4, LodgerId = 1, FlatId = 4, OwnedArea = 50 },
            new Ownership { Id = 5, LodgerId = 2, FlatId = 5, OwnedArea = 55 },
            new Ownership { Id = 6, LodgerId = 3, FlatId = 6, OwnedArea = 60 },
            new Ownership { Id = 7, LodgerId = 1, FlatId = 7, OwnedArea = 65 },
            new Ownership { Id = 8, LodgerId = 2, FlatId = 8, OwnedArea = 70 },
            new Ownership { Id = 9, LodgerId = 3, FlatId = 9, OwnedArea = 75 },
            new Ownership { Id = 10, LodgerId = 1, FlatId = 10, OwnedArea = 30 },
            new Ownership { Id = 11, LodgerId = 2, FlatId = 11, OwnedArea = 80 },
            new Ownership { Id = 12, LodgerId = 3, FlatId = 12, OwnedArea = 35 },
            new Ownership { Id = 13, LodgerId = 1, FlatId = 13, OwnedArea = 60 },
            new Ownership { Id = 14, LodgerId = 2, FlatId = 14, OwnedArea = 55 },
            new Ownership { Id = 15, LodgerId = 3, FlatId = 15, OwnedArea = 50 },
            new Ownership { Id = 16, LodgerId = 1, FlatId = 16, OwnedArea = 45 },
            new Ownership { Id = 17, LodgerId = 2, FlatId = 17, OwnedArea = 40 },
            new Ownership { Id = 18, LodgerId = 3, FlatId = 18, OwnedArea = 35 },
            new Ownership { Id = 19, LodgerId = 1, FlatId = 19, OwnedArea = 30 },
            new Ownership { Id = 20, LodgerId = 2, FlatId = 20, OwnedArea = 80 },
            new Ownership { Id = 21, LodgerId = 3, FlatId = 21, OwnedArea = 70 },
            new Ownership { Id = 22, LodgerId = 1, FlatId = 22, OwnedArea = 65 },
            new Ownership { Id = 23, LodgerId = 2, FlatId = 23, OwnedArea = 55 },
            new Ownership { Id = 24, LodgerId = 3, FlatId = 24, OwnedArea = 45 },
            new Ownership { Id = 25, LodgerId = 1, FlatId = 25, OwnedArea = 35 },
            new Ownership { Id = 26, LodgerId = 2, FlatId = 26, OwnedArea = 30 },
            new Ownership { Id = 27, LodgerId = 3, FlatId = 27, OwnedArea = 40 },
            new Ownership { Id = 28, LodgerId = 1, FlatId = 28, OwnedArea = 50 },
            new Ownership { Id = 29, LodgerId = 2, FlatId = 29, OwnedArea = 65 },
            new Ownership { Id = 30, LodgerId = 3, FlatId = 30, OwnedArea = 75 },
            new Ownership { Id = 31, LodgerId = 1, FlatId = 31, OwnedArea = 60 },
            new Ownership { Id = 32, LodgerId = 2, FlatId = 32, OwnedArea = 55 },
            new Ownership { Id = 33, LodgerId = 3, FlatId = 33, OwnedArea = 40 },
            new Ownership { Id = 34, LodgerId = 1, FlatId = 34, OwnedArea = 35 },
            new Ownership { Id = 35, LodgerId = 2, FlatId = 35, OwnedArea = 50 },
            new Ownership { Id = 36, LodgerId = 3, FlatId = 36, OwnedArea = 70 },
            new Ownership { Id = 37, LodgerId = 1, FlatId = 37, OwnedArea = 60 },
            new Ownership { Id = 38, LodgerId = 2, FlatId = 38, OwnedArea = 30 },
            new Ownership { Id = 39, LodgerId = 3, FlatId = 39, OwnedArea = 80 },
            new Ownership { Id = 40, LodgerId = 1, FlatId = 40, OwnedArea = 75 }
        );
    }
}