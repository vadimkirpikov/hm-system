using System.ComponentModel.DataAnnotations;

namespace HousingManagementService.Models.Views;

public class HouseView
{
    public int Id { get; set; }
    public int PlotId { get; set; }
    public int FloorCount { get; set; }
    public string? Address { get; set; }
}