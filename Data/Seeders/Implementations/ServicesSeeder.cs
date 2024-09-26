using HousingManagementService.Data.Seeders.Interfaces;
using HousingManagementService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Data.Seeders.Implementations;

public class ServicesSeeder: IDataSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Service>().HasData(
            new Service { Id = 1,Name = "Служба охраны" },
            new Service { Id = 2,Name = "Служба отопления" },
            new Service { Id = 3,Name = "Служба электроснабжения"}
        );
    }
}