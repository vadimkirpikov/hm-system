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
    public string LastName { get; set; }
    [Required]
    [MaxLength(50)]
    public string MiddleName { get; set; }
    [Required]
    public int Age { get; set; }
    public PayerCode? PayerCode { get; set; }
    public ICollection<Ownership>? Ownerships { get; set; } = new List<Ownership>();
}