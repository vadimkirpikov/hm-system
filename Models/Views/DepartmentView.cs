using System.ComponentModel.DataAnnotations;

namespace HousingManagementService.Models.Views;

public class DepartmentView
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public int ServiceId { get; set; }
}