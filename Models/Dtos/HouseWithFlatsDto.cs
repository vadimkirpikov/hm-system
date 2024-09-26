namespace HousingManagementService.Models.Dtos;

public class HouseWithFlatsDto
{
    public HouseDto HouseDto { get; set; }
    public IEnumerable<FlatDto> FlatsDto { get; set; }
}