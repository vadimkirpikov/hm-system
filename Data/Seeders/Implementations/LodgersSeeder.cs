using HousingManagementService.Data.Seeders.Interfaces;
using HousingManagementService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Data.Seeders.Implementations;

public class LodgersSeeder: IDataSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lodger>().HasData(
            new Lodger {Id = 1, LodgerPassport = "9418724066", Age = 20, FirstName = "Vadim", MiddleName = "Kirpikov", LastName = "Igorevich"},
            new Lodger {Id = 2, LodgerPassport = "9424724066", Age = 20, FirstName = "Alex", MiddleName = "Fomin", LastName = "Alekseevich"},
            new Lodger {Id = 3, LodgerPassport = "9428724066", Age = 20, FirstName = "Belov", MiddleName = "Ilya", LastName = "Michaylovich"}
        );
    }
}