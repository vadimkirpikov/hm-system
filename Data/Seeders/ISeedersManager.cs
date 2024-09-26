using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Data.Seeders;

public interface ISeedersManager
{
    void Seed(ModelBuilder modelBuilder);
}