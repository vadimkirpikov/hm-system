using System.ComponentModel.DataAnnotations;

namespace HousingManagementService.Models.Domain;

public class Service
{
    public int Id { get; set; }
    [MaxLength(50), MinLength(3)]
    public string Name { get; set; }
    public ICollection<Department>? Departments { get; set; } = new List<Department>();
}