namespace HousingManagementService.Models.Dtos;

public class RateDto
{
    public string? Name { get; set; }
    public int HouseId { get; set; }
    public int DepartmentId { get; set; }
    public int ConstantPricePerMonth { get; set; }
    public int PricePerSquareMeter { get; set; }
}