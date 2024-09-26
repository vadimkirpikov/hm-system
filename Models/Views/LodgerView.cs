using System.ComponentModel.DataAnnotations;

namespace HousingManagementService.Models.Views;

public class LodgerView
{
    public int Id { get; set; }
    public string LodgerPassport { get; set; }
    public string MiddleName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}