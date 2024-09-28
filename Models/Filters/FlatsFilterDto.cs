namespace HousingManagementService.Models.Filters;

public class FlatsFilterDto
{
    public IEnumerable<int>? HouseIds { get; set; }
    public IEnumerable<int>? LodgersIds { get; set; }
    public IEnumerable<int>? FloorNumbers { get; set; }
    public int MinArea { get; set; }
    public int MaxArea { get; set; }
    public string? OrderByField { get; set; }
    public bool IsDescending { get; set; }
}