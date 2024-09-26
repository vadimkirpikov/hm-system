namespace HousingManagementService.Models.Views;

public class SuitabilityOfPlot
{
    public int PlotId { get; set; }
    public int PriorityLevel { get; set; }
    public int Budget { get; set; }
    public int RemainingServicesCount { get; set; }
    public string[] RemainingServices { get; set; }
}