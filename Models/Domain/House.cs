using System.ComponentModel.DataAnnotations;

namespace HousingManagementService.Models.Domain;

public class House
{
    public int Id { get; set; }
    [Required]
    public int PlotId { get; set; }
    [Required]
    public int FloorCount { get; set; }
    [MinLength(10), MaxLength(100)]
    public string Address { get; set; }
    public Plot? Plot { get; set; }
    public ICollection<Flat>? Flats { get; set; } = new List<Flat>();
    public ICollection<Rate>? Rates { get; set; } = new List<Rate>();
}