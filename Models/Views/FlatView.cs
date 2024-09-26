using System.ComponentModel.DataAnnotations;

namespace HousingManagementService.Models.Views;

public class FlatView
{
    public int Id { get; set; }
    public int Number { get; set; }
    public int Floor { get; set; }
    public int TotalArea { get; set; }
    public int HouseId { get; set; }
}