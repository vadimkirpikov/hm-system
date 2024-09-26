namespace HousingManagementService.Models.Domain;

public class Plot
{
    public int Id { get; set; }
    public int PriorityLevel { get; set; }
    public int Budget { get; set; }
    
    public ICollection<DepartmentPlot> DepartmentPlots { get; set; } = new List<DepartmentPlot>();
    public ICollection<House> Houses { get; set; } = new List<House>();
}