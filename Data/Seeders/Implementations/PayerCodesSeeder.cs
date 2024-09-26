using HousingManagementService.Data.Seeders.Interfaces;
using HousingManagementService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Data.Seeders.Implementations;

public class PayerCodesSeeder: IDataSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PayerCode>().HasData(
            new PayerCode {Id = 1,LodgerId = 1},
            new PayerCode {Id = 2,LodgerId = 2, FeePercent = 90, Duty = 100000},
            new PayerCode {Id = 3,LodgerId = 3, Duty = 100001}
        );
    }
}