namespace HousingManagementService.Models.Views;

public class DepartmentRevenue
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }
    public int FlatsCount { get; set; }
    public int Revenue { get; set; }
}