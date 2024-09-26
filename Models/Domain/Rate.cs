using System.ComponentModel.DataAnnotations;

namespace HousingManagementService.Models.Domain;

public class Rate
{
    public int Id { get; set; }
    [MinLength(3), MaxLength(30)]
    public string Name { get; set; }
    [Required]
    public int HouseId { get; set; }
    public House House { get; set; }
    
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    
    public int ConstantPricePerMonth { get; set; }
    public int PricePerSquareMeter { get; set; }
    public int PricePerUnit { get; set; }
}