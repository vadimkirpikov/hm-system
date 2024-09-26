using System.ComponentModel.DataAnnotations;

namespace HousingManagementService.Models.Domain;

public class Flat
{
    public int Id { get; set; }
    [Required]
    public int Number { get; set; }
    [Required]
    public int Floor { get; set; }
    [Required]
    public int TotalArea { get; set; }
    
    [Required]
    public int HouseId { get; set; }
    public House? House { get; set; }

    public ICollection<Ownership>? Ownerships { get; set; } = new List<Ownership>();
}