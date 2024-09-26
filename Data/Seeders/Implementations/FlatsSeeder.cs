using System.ComponentModel.Design;
using HousingManagementService.Data.Seeders.Interfaces;
using HousingManagementService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Data.Seeders.Implementations;

public class FlatsSeeder : IDataSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flat>().HasData(
            // Дома 1
            new Flat { Id = 1, Number = 101, Floor = 1, TotalArea = 50, HouseId = 1 },
            new Flat { Id = 2, Number = 102, Floor = 1, TotalArea = 55, HouseId = 1 },
            new Flat { Id = 3, Number = 201, Floor = 2, TotalArea = 60, HouseId = 1 },
            new Flat { Id = 4, Number = 202, Floor = 2, TotalArea = 65, HouseId = 1 },
            new Flat { Id = 5, Number = 301, Floor = 3, TotalArea = 70, HouseId = 1 },

            // Дома 2
            new Flat { Id = 6, Number = 101, Floor = 1, TotalArea = 48, HouseId = 2 },
            new Flat { Id = 7, Number = 102, Floor = 1, TotalArea = 53, HouseId = 2 },
            new Flat { Id = 8, Number = 201, Floor = 2, TotalArea = 58, HouseId = 2 },
            new Flat { Id = 9, Number = 202, Floor = 2, TotalArea = 63, HouseId = 2 },
            new Flat { Id = 10, Number = 301, Floor = 3, TotalArea = 68, HouseId = 2 },

            // Дома 3
            new Flat { Id = 11, Number = 101, Floor = 1, TotalArea = 55, HouseId = 3 },
            new Flat { Id = 12, Number = 102, Floor = 1, TotalArea = 60, HouseId = 3 },
            new Flat { Id = 13, Number = 201, Floor = 2, TotalArea = 65, HouseId = 3 },
            new Flat { Id = 14, Number = 202, Floor = 2, TotalArea = 70, HouseId = 3 },

            // Дома 4
            new Flat { Id = 15, Number = 101, Floor = 1, TotalArea = 52, HouseId = 4 },
            new Flat { Id = 16, Number = 102, Floor = 1, TotalArea = 57, HouseId = 4 },
            new Flat { Id = 17, Number = 201, Floor = 2, TotalArea = 62, HouseId = 4 },

            // Дома 5
            new Flat { Id = 18, Number = 101, Floor = 1, TotalArea = 50, HouseId = 5 },
            new Flat { Id = 19, Number = 102, Floor = 1, TotalArea = 55, HouseId = 5 },
            new Flat { Id = 20, Number = 201, Floor = 2, TotalArea = 60, HouseId = 5 },
            new Flat { Id = 21, Number = 202, Floor = 2, TotalArea = 65, HouseId = 5 },
            new Flat { Id = 22, Number = 301, Floor = 3, TotalArea = 70, HouseId = 5 },

            // Дома 6
            new Flat { Id = 23, Number = 101, Floor = 1, TotalArea = 53, HouseId = 6 },
            new Flat { Id = 24, Number = 102, Floor = 1, TotalArea = 58, HouseId = 6 },
            new Flat { Id = 25, Number = 201, Floor = 2, TotalArea = 63, HouseId = 6 },

            // Дома 7
            new Flat { Id = 26, Number = 101, Floor = 1, TotalArea = 57, HouseId = 7 },
            new Flat { Id = 27, Number = 102, Floor = 1, TotalArea = 62, HouseId = 7 },
            new Flat { Id = 28, Number = 201, Floor = 2, TotalArea = 67, HouseId = 7 },

            // Дома 8
            new Flat { Id = 29, Number = 101, Floor = 1, TotalArea = 60, HouseId = 8 },
            new Flat { Id = 30, Number = 102, Floor = 1, TotalArea = 65, HouseId = 8 },
            new Flat { Id = 31, Number = 201, Floor = 2, TotalArea = 70, HouseId = 8 },
            new Flat { Id = 32, Number = 202, Floor = 2, TotalArea = 75, HouseId = 8 },

            // Дома 9
            new Flat { Id = 33, Number = 101, Floor = 1, TotalArea = 50, HouseId = 9 },
            new Flat { Id = 34, Number = 102, Floor = 1, TotalArea = 55, HouseId = 9 },
            new Flat { Id = 35, Number = 201, Floor = 2, TotalArea = 60, HouseId = 9 },

            // Дома 10
            new Flat { Id = 36, Number = 101, Floor = 1, TotalArea = 55, HouseId = 10 },
            new Flat { Id = 37, Number = 102, Floor = 1, TotalArea = 60, HouseId = 10 },
            new Flat { Id = 38, Number = 201, Floor = 2, TotalArea = 65, HouseId = 10 },
            new Flat { Id = 39, Number = 202, Floor = 2, TotalArea = 70, HouseId = 10 },
            new Flat { Id = 40, Number = 301, Floor = 3, TotalArea = 75, HouseId = 10 }
        );
    }
}