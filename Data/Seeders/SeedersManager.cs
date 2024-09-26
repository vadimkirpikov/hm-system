using HousingManagementService.Data.Seeders.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Data.Seeders;

public class SeedersManager(IEnumerable<IDataSeeder> seeders): ISeedersManager
{
    public void Seed(ModelBuilder modelBuilder)
    {
        foreach (var dataSeeder in seeders)
        {
            dataSeeder.Seed(modelBuilder);
        }
    }
}