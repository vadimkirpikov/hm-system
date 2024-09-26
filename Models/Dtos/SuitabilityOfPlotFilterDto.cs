namespace HousingManagementService.Models.Dtos;

public class SuitabilityOfPlotFilterDto
{
    public IEnumerable<int> PlotIds { get; set; }
    public IEnumerable<int> PriorityLevels { get; set; }
    public int MinBudget { get; set; }
    public int MaxBudget { get; set; }
    public string OrderByFieldName { get; set; }
    public bool IsDesc { get; set; }
}