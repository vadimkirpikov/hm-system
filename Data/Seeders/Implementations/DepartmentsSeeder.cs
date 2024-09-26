using System.ComponentModel.Design;
using HousingManagementService.Data.Seeders.Interfaces;
using HousingManagementService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Data.Seeders.Implementations;

public class DepartmentsSeeder: IDataSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasData(
            new Department {Id = 1, Name = "ОП 1", ServiceId = 1, Address = "Пушкинская 2"},
            new Department {Id = 2, Name = "ОП 2", ServiceId = 1, Address = "Красноармейская 3"},
            new Department {Id = 3, Name = "Отопление 1", ServiceId = 2, Address = "Пушкинская 4"},
            new Department {Id = 4, Name = "Электро 1", ServiceId = 3, Address = "Пушкинская 1"}
        );
    }
}