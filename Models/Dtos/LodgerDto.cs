namespace HousingManagementService.Models.Dtos;

public class LodgerDto
{
    public string LodgerPassport { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public int Age { get; set; }
    public int FeePercent { get; set; }
    public int Duty { get; set; }
}