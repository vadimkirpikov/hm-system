namespace HousingManagementService.Models.Dtos;

public class RentViewFilterDto
{
    public IEnumerable<string> Addresses { get; set; }
    public int MinPrice { get; set; }
    public int MaxPrice { get; set; }
    public string OrderByFieldName { get; set; }
    public bool IsDescending { get; set; }
}