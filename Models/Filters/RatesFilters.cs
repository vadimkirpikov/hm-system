namespace HousingManagementService.Models.Filters;

public class RatesFilters
{
    public IEnumerable<int>? HouseIds {get; set;} = null;
    public IEnumerable<int>? DepIds {get; set;} = null;
    public int MinCpm { get; set; } = 0;
    public int MaxCpm {get; set;} = int.MaxValue;
    public int MinPcm {get; set;} = 0;
    public int MaxPcm { get; set; } = int.MaxValue;

    public bool OrderByCpm { get; set; } = false;
}