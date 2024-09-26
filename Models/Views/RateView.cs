using System.ComponentModel.DataAnnotations;

namespace HousingManagementService.Models.Views;

public class RateView
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int HouseId { get; set; }
    public int DepartmentId { get; set; }
    public int ConstantPricePerMonth { get; set; }
    public int PricePerSquareMeter { get; set; }
    public int PricePerUnit { get; set; }
}