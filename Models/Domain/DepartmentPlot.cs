

using System.ComponentModel.DataAnnotations.Schema;

namespace HousingManagementService.Models.Domain;

public class DepartmentPlot
{
    public int Id { get; set; }
    public int PlotId { get; set; }
    public Plot Plot { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    
}