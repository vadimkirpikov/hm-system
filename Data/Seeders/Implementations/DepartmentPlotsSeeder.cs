using HousingManagementService.Data.Seeders.Interfaces;
using HousingManagementService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Data.Seeders.Implementations;

public class DepartmentPlotsSeeder: IDataSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepartmentPlot>().HasData(
            new DepartmentPlot {Id = 1, DepartmentId = 1, PlotId = 1},
            new DepartmentPlot {Id = 2, DepartmentId = 1, PlotId = 2},
            new DepartmentPlot {Id = 3, DepartmentId = 1, PlotId = 3},
            new DepartmentPlot {Id = 4, DepartmentId = 3, PlotId = 1},
            new DepartmentPlot {Id = 5, DepartmentId = 3, PlotId = 2},
            new DepartmentPlot {Id = 6, DepartmentId = 3, PlotId = 3},
            new DepartmentPlot {Id = 7, DepartmentId = 2, PlotId = 4},
            new DepartmentPlot {Id = 8, DepartmentId = 2, PlotId = 5},
            new DepartmentPlot {Id = 9, DepartmentId = 2, PlotId = 6},
            new DepartmentPlot {Id = 10, DepartmentId = 3, PlotId = 4},
            new DepartmentPlot {Id = 11, DepartmentId = 3, PlotId = 5},
            new DepartmentPlot {Id = 12, DepartmentId = 3, PlotId = 6}
        );
    }
}