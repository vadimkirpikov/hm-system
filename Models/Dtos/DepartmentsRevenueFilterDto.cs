namespace HousingManagementService.Models.Dtos;

public class DepartmentsRevenueFilterDto
{
    public IEnumerable<int> DepartmentIds { get; set; }
    public IEnumerable<int> ServiceIds { get; set; }
    public int MinFlatsCount { get; set; }
    public int MaxFlatsCount { get; set; }
    public int MinRevenue { get; set; }
    public int MaxRevenue { get; set; }
    public string OrderByFieldName { get; set; }
    public bool IsDesc { get; set; }
}