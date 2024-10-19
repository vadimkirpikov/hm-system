using HousingManagementService.Data.Seeders.Interfaces;
using HousingManagementService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Data.Seeders.Implementations;

public class RatesSeeder: IDataSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rate>().HasData(
            new Rate { Id = 1, Name = "1", DepartmentId = 1, HouseId = 1, ConstantPricePerMonth = 2600, PricePerSquareMeter = 0 },
            new Rate { Id = 2, Name = "1", DepartmentId = 1, HouseId = 2, ConstantPricePerMonth = 2601, PricePerSquareMeter = 0 },
            new Rate { Id = 3, Name = "1", DepartmentId = 1, HouseId = 3, ConstantPricePerMonth = 2602, PricePerSquareMeter = 0 },
            new Rate { Id = 4, Name = "1", DepartmentId = 1, HouseId = 4, ConstantPricePerMonth = 2603, PricePerSquareMeter = 0 },
            new Rate { Id = 5, Name = "1", DepartmentId = 1, HouseId = 5, ConstantPricePerMonth = 2604, PricePerSquareMeter = 0 },
            new Rate { Id = 6, Name = "1", DepartmentId = 1, HouseId = 6, ConstantPricePerMonth = 2605, PricePerSquareMeter = 0 },
            new Rate { Id = 7, Name = "1", DepartmentId = 1, HouseId = 7, ConstantPricePerMonth = 2606, PricePerSquareMeter = 0 },
            new Rate { Id = 8, Name = "1", DepartmentId = 2, HouseId = 8, ConstantPricePerMonth = 2607, PricePerSquareMeter = 0 },
            new Rate { Id = 9, Name = "1", DepartmentId = 2, HouseId = 9, ConstantPricePerMonth = 2608, PricePerSquareMeter = 0 },
            new Rate { Id = 10, Name = "1", DepartmentId = 2, HouseId = 10, ConstantPricePerMonth = 2609, PricePerSquareMeter = 0 },
            new Rate { Id = 11, Name = "1", DepartmentId = 2, HouseId = 11, ConstantPricePerMonth = 2610, PricePerSquareMeter = 0 },
            new Rate { Id = 12, Name = "1", DepartmentId = 3, HouseId = 1, ConstantPricePerMonth = 2700, PricePerSquareMeter = 20 },
            new Rate { Id = 13, Name = "1", DepartmentId = 3, HouseId = 2, ConstantPricePerMonth = 2700, PricePerSquareMeter = 21 },
            new Rate { Id = 14, Name = "1", DepartmentId = 3, HouseId = 3, ConstantPricePerMonth = 2700, PricePerSquareMeter = 22 },
            new Rate { Id = 15, Name = "1", DepartmentId = 3, HouseId = 4, ConstantPricePerMonth = 2700, PricePerSquareMeter = 23 },
            new Rate { Id = 16, Name = "1", DepartmentId = 3, HouseId = 5, ConstantPricePerMonth = 2700, PricePerSquareMeter = 24 },
            new Rate { Id = 17, Name = "1", DepartmentId = 3, HouseId = 6, ConstantPricePerMonth = 2700, PricePerSquareMeter = 25 },
            new Rate { Id = 18, Name = "1", DepartmentId = 3, HouseId = 7, ConstantPricePerMonth = 2700, PricePerSquareMeter = 26 },
            new Rate { Id = 19, Name = "1", DepartmentId = 3, HouseId = 8, ConstantPricePerMonth = 2700, PricePerSquareMeter = 27 },
            new Rate { Id = 20, Name = "1", DepartmentId = 3, HouseId = 9, ConstantPricePerMonth = 2700, PricePerSquareMeter = 28 },
            new Rate { Id = 21, Name = "1", DepartmentId = 3, HouseId = 10, ConstantPricePerMonth = 2700, PricePerSquareMeter = 29 },
            new Rate { Id = 22, Name = "1", DepartmentId = 3, HouseId = 11, ConstantPricePerMonth = 2700, PricePerSquareMeter = 30 }
            );
    }
}