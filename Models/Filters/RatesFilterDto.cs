namespace HousingManagementService.Models.Filters;

public class RatesFilterDto
{
    public IEnumerable<int>? DepartmentIds { get; set; }
    public IEnumerable<int>? HouseIds { get; set; }
    public int MinConstPrice { get; set; } = 0;
    public int MaxConstPrice { get; set; } = int.MaxValue;
    public int MinPricePerSquareMeter { get; set; } = 0;
    public int MaxPricePerSquareMeter { get; set; } = int.MaxValue;
    public string? OrderByFieldName { get; set; }
    public bool IsDesc { get; set; } =  false;
}