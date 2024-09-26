using System.ComponentModel.DataAnnotations;

namespace HousingManagementService.Models.Domain;

public class Department
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MinLength(20), MaxLength(100)]
    public string Address { get; set; }
    
    public int ServiceId { get; set; }
    public Service? Service { get; set; }
    
    public ICollection<DepartmentPlot>? DepartmentPlots { get; set; } = new List<DepartmentPlot>();
    public ICollection<Rate>? Rates { get; set; } = new List<Rate>();
}