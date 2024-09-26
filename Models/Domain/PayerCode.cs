using System.ComponentModel.DataAnnotations;

namespace HousingManagementService.Models.Domain;

public class PayerCode
{
    public int Id { get; set; }
    public int LodgerId { get; set; }
    public Lodger? Lodger { get; set; }
    [Required]
    public int FeePercent { get; set; }
    [Required]
    public int Duty { get; set; }
}