using System.ComponentModel.DataAnnotations;

namespace HousingManagementService.Models.Domain;

public class Lodger
{
    public int Id { get; set; }
    [Required]
    [StringLength(10)]
    public string LodgerPassport { get; set; }
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(50)]
    public string MiddleName { get; set; }
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    public int Age { get; set; }
    [Required]
    public int FeePercent { get; set; }
    [Required]
    public int Duty { get; set; }
    [Required]
    public ICollection<Ownership>? Ownerships { get; set; } = new List<Ownership>();
}