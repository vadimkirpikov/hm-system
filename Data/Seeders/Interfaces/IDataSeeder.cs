using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Data.Seeders.Interfaces;

public interface IDataSeeder
{
    void Seed(ModelBuilder modelBuilder);
}